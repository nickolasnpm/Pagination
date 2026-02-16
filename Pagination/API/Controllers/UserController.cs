using Azure.Core;
using CommandLine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pagination.Application.DTO;
using Pagination.Application.Common;
using Pagination.Application.Interface.Repository;
using Pagination.Domain.Model;
using Pagination.Infrastructure;

namespace Pagination.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IOffsetRepository _offsetRepository;
        private readonly ICursorRepository _cursorRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IOffsetRepository offsetRepository, ICursorRepository cursorRepository, ILogger<UserController> logger) 
        {
            _offsetRepository = offsetRepository;
            _cursorRepository = cursorRepository;
            _logger = logger;
        }

        [HttpGet("getusers")]
        public async Task<IActionResult> DefaultPaginationAsync ([FromQuery] DefaultPaginationRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                switch (request.PaginationType)
                {
                    case (int)PaginationType.Offset:
                        return await OffsetPaginationAsync(request.offsetPagination!);

                    case (int)PaginationType.Cursor:
                        return await CursorPaginationAsync(request.cursorPagination!);

                    default:
                        return BadRequest("Invalid pagination type.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured. PaginationType: {PaginationType}", request.PaginationType);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }

        }

        private async Task<IActionResult> OffsetPaginationAsync(OffsetPaginationRequest request)
        {
            if (request.Page < 1)
            {
                return BadRequest("Page number must be greater than 0.");
            }

            var (users, totalCount) = await _offsetRepository.GetAsync(request);

            int totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);

            bool hasNextPage = request.Page < totalPages;
            bool hasPreviousPage = request.Page > 1;

            return Ok(new OffsetPaginationResponse<User>()
            {
                Data = users,
                TotalCount = totalCount,
                TotalPages = totalPages,
                HasNextPage = hasNextPage,
                HasPreviousPage = hasPreviousPage
            });
        }

        private async Task<IActionResult> CursorPaginationAsync(CursorPaginationRequest request)
        {
            if (request.Cursor < 0)
            {
                return BadRequest("Cursor must be a non-negative value.");
            }

            var (users, totalCount) = await _cursorRepository.GetAsync(request);

            bool hasMore = users.Count > request.PageSize;

            if (hasMore)
                users.RemoveAt(users.Count - 1);

            bool hasNextPage;
            bool hasPreviousPage;

            if (request.IsQueryPreviousPage)
            {
                users.Reverse();
                hasNextPage = true;
                hasPreviousPage = hasMore;
            }
            else
            {
                hasNextPage = hasMore;
                hasPreviousPage = request.Cursor > 0;
            }

            long? nextCursor = hasNextPage ? users.Last().Id : null;
            long? previousCursor = hasPreviousPage ? users.First().Id : null;

            return Ok(new CursorPaginationResponse<User>
            {
                Data = users,
                TotalCount = totalCount, // optional
                NextCursor = nextCursor,
                PreviousCursor = previousCursor,
            });
        }
    }
}

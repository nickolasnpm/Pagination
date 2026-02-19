using Azure.Core;
using CommandLine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pagination.Application.DTO;
using Pagination.Application.Common;
using Pagination.Application.Interface.Repository;
using Pagination.Application.Queries;
using Pagination.Domain.Entity;

namespace Pagination.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController (IOffsetRepository _offsetRepository, ICursorRepository _cursorRepository, ILogger<UserController> _logger) 
        : ControllerBase
    {
        [HttpGet("getusers")]
        public async Task<IActionResult> GetPaginatedUsers ([FromQuery] PaginationRequestDTO request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                switch (request.PaginationType)
                {
                    case PaginationType.Cursor:
                        if (request.CursorPagination is null)
                            return BadRequest("Cursor pagination request is required.");
                        return await CursorPaginationAsync(request.CursorPagination);

                    case PaginationType.Offset:
                        if (request.OffsetPagination is null)
                            return BadRequest("Offset pagination request is required.");
                        return await OffsetPaginationAsync(request.OffsetPagination);

                    default:
                        return BadRequest("Invalid pagination type.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while processing pagination type {request.PaginationType}: ", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {ex.Message}");
            }

        }

        // Just place it here for demo purpose. Should be inside service class
        private async Task<IActionResult> OffsetPaginationAsync(OffsetPaginationRequest request)
        {
            if (request.Page < 1)
            {
                return BadRequest("Page number must be greater than 0.");
            }

            var (users, totalCount) = await _offsetRepository.GetAsync(request, UserIncludeOptions.All);
            //var (users, totalCount) = await _offsetRepository.GetAsync(request, new UserIncludeOptions() { Address = true });

            int totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);

            bool hasNextPage = request.Page < totalPages;
            bool hasPreviousPage = request.Page > 1;

            return Ok(new OffsetPaginationResponse<User>()
            {
                Data = await users.ToListAsync(),
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

            var (users, totalCount) = await _cursorRepository.GetAsync(request, UserIncludeOptions.All);
            var result = await users.ToListAsync();

            bool hasMore = result.Count > request.PageSize;

            if (hasMore)
                result.RemoveAt(result.Count - 1);

            bool hasNextPage;
            bool hasPreviousPage;

            if (request.IsQueryPreviousPage)
            {
                result.Reverse();
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
                Data = result,
                TotalCount = totalCount, // optional
                NextCursor = nextCursor,
                PreviousCursor = previousCursor,
            });
        }
    }
}

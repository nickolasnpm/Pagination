using Pagination.Application.Common;

namespace Pagination.Application.DTO
{
    public class DefaultPaginationRequest
    {
        public PaginationType PaginationType { get; set; }
        
        public OffsetPaginationRequest? OffsetPagination { get; set; }
        public CursorPaginationRequest? CursorPagination { get; set; }
    }

    public class OffsetPaginationRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;

    }

    public class CursorPaginationRequest
    {
        public long Cursor { get; set; } = 0;
        public int PageSize { get; set; } = 50;
        public bool IsQueryPreviousPage { get; set; } = false;
    }
}

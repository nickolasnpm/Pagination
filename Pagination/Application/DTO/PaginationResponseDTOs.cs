namespace Pagination.Application.DTO
{
    public class PaginationResponse<T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public int TotalCount { get; set; }
    }

    public class OffsetPaginationResponse<T>: PaginationResponse<T>
    {
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }

    public class CursorPaginationResponse<T>: PaginationResponse<T>
    {
        public long? NextCursor { get; set; }
        public long? PreviousCursor { get; set; }
    }
}

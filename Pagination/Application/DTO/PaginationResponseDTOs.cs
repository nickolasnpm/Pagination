namespace Pagination.Application.DTO
{
    public class PaginationResponseDTO<T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public int TotalCount { get; set; }
    }

    public class OffsetPaginationResponse<T>: PaginationResponseDTO<T>
    {
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }

    public class CursorPaginationResponse<T>: PaginationResponseDTO<T>
    {
        public long? NextCursor { get; set; }
        public long? PreviousCursor { get; set; }
    }
}

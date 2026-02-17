namespace Pagination.Application.DTO
{
    public class AppSettings
    {
        public int UserCountStrategy { get; set; }
        public bool IsUseNoTracking { get; set; }
        public bool IsUseSplitQuery { get; set; }
    }
}

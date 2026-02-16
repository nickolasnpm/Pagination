namespace Pagination.Application.Common
{
    public enum PaginationType
    {
        Offset = 1,
        Cursor = 2
    }

    public enum UserCountStrategy
    {
        None = 1,   
        Cache = 2
    }

    public enum CacheKeyAndTimes
    {
        UserCount = 60
    }
}

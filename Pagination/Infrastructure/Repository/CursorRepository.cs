using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pagination.Application.Common;
using Pagination.Application.Configuration;
using Pagination.Application.DTO;
using Pagination.Application.Extensions.Repository;
using Pagination.Application.Interface.Repository;
using Pagination.Application.Queries;
using Pagination.Domain.Model;
using Pagination.Infrastructure.Caching;

namespace Pagination.Infrastructure.Repository
{
    public class CursorRepository(UserDbContext _userDbContext, IOptions<AppSettings> _appSettings, IOptions<CacheSettings> _cacheSettings) 
        : ICursorRepository
    {
        public async Task<(IQueryable<User>, int)> GetAsync(CursorPaginationRequest request, UserIncludeOptions includeOptions)
        {
            IQueryable<User> queryable = _userDbContext.Users.AsNoTracking();

            int totalCount = 0;

            if (_appSettings.Value.IsUseCache)
            {
                var userCountCacheSettings = _cacheSettings.Value.Items[CacheKeys.UserCount];

                totalCount = await AsyncCache<int>.GetOrUpdateAsync(userCountCacheSettings.Key, 
                    TimeSpan.FromMinutes(userCountCacheSettings.ExpirationMinutes), () => queryable.CountAsync());
            }
            else
            {
                totalCount = await queryable.CountAsync();
            }

            if (request.IsQueryPreviousPage)
            {
                queryable = queryable.Where(u => u.Id < request.Cursor).OrderByDescending(u => u.Id);
            }
            else
            {
                queryable = queryable.Where(u => u.Id > request.Cursor).OrderBy(u => u.Id);
            }

            if (includeOptions == UserIncludeOptions.All)
            {
                queryable = queryable.AsSplitQuery();
            }

            queryable = queryable.ApplyIncludes(includeOptions);

            return (queryable.Take(request.PageSize + 1), totalCount);
        }
    }
}

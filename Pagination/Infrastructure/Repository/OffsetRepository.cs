using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pagination.Application.Common;
using Pagination.Application.Configuration;
using Pagination.Application.DTO;
using Pagination.Application.Extensions.Repository;
using Pagination.Application.Interface.Repository;
using Pagination.Application.Queries;
using Pagination.Domain.Entity;
using Pagination.Infrastructure.Caching;

namespace Pagination.Infrastructure.Repository
{
    public class OffsetRepository (UserDbContext _userDbContext, IOptions<AppSettings> _appSettings, IOptions<CacheSettings> _cacheSettings) 
        : IOffsetRepository
    {
        public IQueryable<User> GetAll()
        {
            return _userDbContext.Users.AsNoTracking();
        }

        public async Task<(IQueryable<User>, int)> GetAsync(OffsetPaginationRequest request, UserIncludeOptions includeOptions)
        {
            IQueryable<User> queryable = GetAll();

            var totalCount = 0;

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

            if (includeOptions == UserIncludeOptions.All)
            {
                queryable = queryable.AsSplitQuery();
            }

            queryable = queryable.ApplyIncludes(includeOptions);

            return (queryable.OrderBy(u => u.Id).Skip((request.Page! - 1) * request.PageSize).Take(request.PageSize), totalCount);
        }
    }
}

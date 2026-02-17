using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pagination.Application.DTO;
using Pagination.Application.Common;
using Pagination.Application.Interface.Repository;
using Pagination.Domain.Model;
using Pagination.Infrastructure.Caching;
using System.Linq;

namespace Pagination.Infrastructure.Repository
{
    public class OffsetRepository : IOffsetRepository
    {
        private readonly UserDbContext _userDbContext;
        private readonly bool _isUseCache;
        private readonly bool _isUseNoTracking;
        private readonly bool _isUseSplitQuery;

        public OffsetRepository(UserDbContext userDbContext, IOptions<AppSettings> appSettings)
        {
            _userDbContext = userDbContext;
            _isUseCache = appSettings.Value.IsUseCache;
            _isUseNoTracking = appSettings.Value.IsUseNoTracking;
            _isUseSplitQuery = appSettings.Value.IsUseSplitQuery;
        }

        public async Task<(List<User>, int)> GetAsync(OffsetPaginationRequest request)
        {
            IQueryable<User> queryable = _userDbContext.Users;

            if (_isUseNoTracking)
                queryable = queryable.AsNoTracking();

            var totalCount = 0;

            if (_isUseCache)
            {
                totalCount = await AsyncCache<int>.GetOrUpdateAsync(
                    CacheKeyAndTimes.UserCount.ToString(), TimeSpan.FromMinutes((int)CacheKeyAndTimes.UserCount), () => queryable.CountAsync());
            }
            else
            {
                totalCount = await queryable.CountAsync();
            }

            if (_isUseSplitQuery)
            {
                queryable = queryable.AsSplitQuery();
            }

            queryable = queryable
                .Include(u => u.Roles)
                .Include(u => u.Address)
                .Include(u => u.BankAccount)
                    .ThenInclude(ba => ba.Transactions)
                .Include(u => u.CreditCards)
                    .ThenInclude(cc => cc.Statements)
                .Include(u => u.Loans)
                    .ThenInclude(l => l.Repayments)
                .Include(u => u.SupportTickets)
                    .ThenInclude(st => st.Comments);

            return (await queryable.OrderBy(u => u.Id).Skip((request.Page! - 1) * request.PageSize).Take(request.PageSize).ToListAsync(), totalCount);
        }
    }
}

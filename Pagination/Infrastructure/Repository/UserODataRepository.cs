using Microsoft.EntityFrameworkCore;
using Pagination.Application.Interface.Repository;
using Pagination.Domain.Entity;

namespace Pagination.Infrastructure.Repository
{
    public class UserODataRepository(UserDbContext _userDbContext) : IUserODataRepository
    {
        public IQueryable<User> GetAll()
        {
            return _userDbContext.Users.AsNoTracking();
        }
    }
}

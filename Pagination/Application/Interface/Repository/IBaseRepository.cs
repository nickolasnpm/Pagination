using Pagination.Application.DTO;
using Pagination.Application.Queries;
using Pagination.Domain.Entity;

namespace Pagination.Application.Interface.Repository
{
    public interface IBaseRepository<TEntity, TRequest, TIncludeOptions> where TEntity : class where TRequest : class where TIncludeOptions : class
    {
        Task<(IQueryable<TEntity> Items, int TotalCount)> GetAsync(TRequest request, TIncludeOptions includeOptions);
    }

    // deviate from clean architecture folder structure, should be in separate file
    public interface ICursorRepository : IBaseRepository<User, CursorPaginationRequest,  UserIncludeOptions>
    {

    }

    public interface IOffsetRepository : IBaseRepository<User, OffsetPaginationRequest, UserIncludeOptions>
    {

    }
}


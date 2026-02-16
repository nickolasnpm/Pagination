using Pagination.Application.DTO;
using Pagination.Domain.Model;

namespace Pagination.Application.Interface.Repository
{
    public interface IBaseRepository<TEntity, TRequest> where TEntity : class where TRequest : class
    {
        Task<(List<TEntity> Items, int TotalCount)> GetAsync(TRequest request);
    }

    // deviate from clean architecture folder structure, should be in separate file
    public interface ICursorRepository : IBaseRepository<User, CursorPaginationRequest>
    {

    }

    public interface IOffsetRepository : IBaseRepository<User, OffsetPaginationRequest>
    {

    }
}


using OnlineBookShop.API.Infrastructure.Models;
using OnlineBookShop.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookShop.API.Repositories.Interfaces
{
    public interface IRepository 
    {
        Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity;

        Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity;

        Task<bool> SaveAll();

        Task<TEntity> Add<TEntity>(TEntity entity) where TEntity : BaseEntity;

        Task<TEntity> Update<TEntity>(TEntity entity) where TEntity : BaseEntity;

        Task<TEntity> Delete<TEntity>(int id) where TEntity : BaseEntity;

        Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : BaseEntity
                                                                                             where TDto : class;
    }
}

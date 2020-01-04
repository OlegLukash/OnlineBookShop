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

    }
}

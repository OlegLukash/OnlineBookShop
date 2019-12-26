using OnlineBookShop.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookShop.API.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(int id);

        Task<List<TEntity>> GetAll();

    }
}

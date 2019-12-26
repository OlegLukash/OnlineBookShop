using Microsoft.EntityFrameworkCore;
using OnlineBookShop.API.Repositories.Interfaces;
using OnlineBookShop.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookShop.API.Repositories.Implementation
{
    public class EFCoreRepository<TEntity> : IRepository<TEntity> where TEntity: BaseEntity
    {
        private readonly OnlineBookShopDbContext _onlineBookShopDbContext;

        public EFCoreRepository(OnlineBookShopDbContext onlineBookShopDbContext)
        {
            _onlineBookShopDbContext = onlineBookShopDbContext;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _onlineBookShopDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _onlineBookShopDbContext.FindAsync<TEntity>(id);
        }
    }
}

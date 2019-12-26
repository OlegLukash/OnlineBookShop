using Microsoft.EntityFrameworkCore;
using OnlineBookShop.API.Repositories.Interfaces;
using OnlineBookShop.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookShop.API.Repositories.Implementation
{
    public class EFCoreRepository: IRepository
    {
        private readonly OnlineBookShopDbContext _onlineBookShopDbContext;

        public EFCoreRepository(OnlineBookShopDbContext onlineBookShopDbContext)
        {
            _onlineBookShopDbContext = onlineBookShopDbContext;
        }

        public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity
        {
            return await _onlineBookShopDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity
        {
            return await _onlineBookShopDbContext.FindAsync<TEntity>();
        }
    }
}

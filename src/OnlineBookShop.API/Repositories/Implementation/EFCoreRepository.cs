using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBookShop.API.Infrastructure.Extensions;
using OnlineBookShop.API.Infrastructure.Models;
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
        private readonly IMapper _mapper;

        public EFCoreRepository(OnlineBookShopDbContext onlineBookShopDbContext, IMapper mapper)
        {
            _onlineBookShopDbContext = onlineBookShopDbContext;
            _mapper = mapper;
        }

        public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity
        {
            return await _onlineBookShopDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity
        {
            return await _onlineBookShopDbContext.FindAsync<TEntity>(id);
        }

        public async Task<bool> SaveAll()
        {
            return await _onlineBookShopDbContext.SaveChangesAsync() >= 0;
        }

        public async Task<TEntity> Add<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _onlineBookShopDbContext.Set<TEntity>().Add(entity);
            await _onlineBookShopDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update<TEntity>(TEntity entity) where TEntity: BaseEntity
        {
            // In case entity is not tracked
            _onlineBookShopDbContext.Entry(entity).State = EntityState.Modified;
            await _onlineBookShopDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete<TEntity>(int id) where TEntity: BaseEntity
        {
            var entity = await _onlineBookShopDbContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                throw new Exception($"Object of type {typeof(TEntity)} with id { id } not found");
            }

            _onlineBookShopDbContext.Set<TEntity>().Remove(entity);
            await _onlineBookShopDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity: BaseEntity 
                                                                                                    where TDto: class
        {
            return await _onlineBookShopDbContext.Set<TEntity>().CreatePaginatedResultAsync<TEntity, TDto>(pagedRequest, _mapper);
        }
    }
}

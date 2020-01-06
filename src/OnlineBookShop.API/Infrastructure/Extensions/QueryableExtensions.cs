using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineBookShop.API.Infrastructure.Models;
using OnlineBookShop.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShop.API.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public async static Task<PagedResult<TDto>> CreatePagedResultAsync<TEntity, TDto>(this IQueryable<TEntity> query, PagedRequest pagedRequest, IMapper mapper) 
            where TEntity : BaseEntity                                                                                                                                                
            where TDto: class
        {
            var total = await query.CountAsync();

            query = query.Paginate(pagedRequest);

            var projectionResult = query.ProjectTo<TDto>(mapper.ConfigurationProvider);
            
            var listResult = await projectionResult.ToListAsync();

            return new PagedResult<TDto>() 
            { 
                Items = listResult, 
                PageSize = pagedRequest.PageSize, 
                PageNumber = pagedRequest.PageNumber, 
                Total = total 
            };
        }

        private static IQueryable<T> Paginate<T>(this IQueryable<T> query, PagedRequest pagedRequestDescription)
        {
            var entities = query.Skip((pagedRequestDescription.PageNumber - 1) * pagedRequestDescription.PageSize).Take(pagedRequestDescription.PageSize);
            return entities;
        }
    }
}

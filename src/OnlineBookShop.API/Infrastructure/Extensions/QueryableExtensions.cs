using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineBookShop.API.Infrastructure.Models;
using OnlineBookShop.Domain;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace OnlineBookShop.API.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public async static Task<PaginatedResult<TDto>> CreatePaginatedResultAsync<TEntity, TDto>(this IQueryable<TEntity> query, PagedRequest pagedRequest, IMapper mapper) 
            where TEntity : BaseEntity                                                                                                                                                
            where TDto: class
        {
            var total = await query.CountAsync();

            query = query.Paginate(pagedRequest);

            var projectionResult = query.ProjectTo<TDto>(mapper.ConfigurationProvider);

            projectionResult = projectionResult.Sort(pagedRequest);
            
            var listResult = await projectionResult.ToListAsync();

            return new PaginatedResult<TDto>() 
            { 
                Items = listResult, 
                PageSize = pagedRequest.PageSize, 
                PageIndex = pagedRequest.PageIndex, 
                Total = total 
            };
        }

        private static IQueryable<T> Paginate<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            var entities = query.Skip((pagedRequest.PageIndex) * pagedRequest.PageSize).Take(pagedRequest.PageSize);
            return entities;
        }

        private static IQueryable<T> Sort<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            if (!string.IsNullOrWhiteSpace(pagedRequest.ColumnNameForSorting))
            {
                query = query.OrderBy(pagedRequest.ColumnNameForSorting + " " + pagedRequest.SortDirection);
            }
            return query;
        }
    }
}

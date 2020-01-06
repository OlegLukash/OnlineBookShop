using System.Collections.Generic;

namespace OnlineBookShop.API.Infrastructure.Models
{
    public class PagedResult<T> where T: class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public IList<T> Items { get; set; }
    }
}

using System.Collections.Generic;

namespace OnlineBookShop.API.Infrastructure.Models
{
    public class PagedRequest
    {
        public PagedRequest()
        {
            Filters = new List<Filter>();
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string ColumnNameForSorting { get; set; }

        public string SortDirection { get; set; }

        public IList<Filter> Filters { get; set; }
    }
}

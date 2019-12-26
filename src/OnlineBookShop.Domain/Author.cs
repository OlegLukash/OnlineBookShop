using System;
using System.Collections.Generic;

namespace OnlineBookShop.Domain
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}

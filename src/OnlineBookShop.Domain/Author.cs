using System;
using System.Collections.Generic;

namespace OnlineBookShop.Domain
{
    public class Author : Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}

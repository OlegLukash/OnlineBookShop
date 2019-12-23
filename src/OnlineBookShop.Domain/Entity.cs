using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookShop.Domain
{
    public abstract class Entity<TId>
    {
        public TId Id { get; set; }
    }
}

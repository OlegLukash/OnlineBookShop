using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookShop.Domain
{
    public class Review : Entity<int>
    {
        public string VoterName { get; set; }

        public short NumStars { get; set; }

        public string Comment { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}

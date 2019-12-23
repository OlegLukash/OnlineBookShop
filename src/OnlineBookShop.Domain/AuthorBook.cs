﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookShop.Domain
{
    public class AuthorBook
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}

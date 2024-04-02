using BookBorrowingAPI.Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBorrowingAPI.Helper
{
    public class SearchBookModelToBookHelper
    {
        public Book SearchBookToBookMapping(SearchBookModel e)
        {
            Book u = new Book();
            u.BookName = e.BookName;
            u.Author = e.Author;
            u.Genre = e.Genre;
            return u;
        }
    }
}

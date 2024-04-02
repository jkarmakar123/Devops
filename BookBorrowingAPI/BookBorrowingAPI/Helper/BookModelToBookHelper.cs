using BookBorrowingAPI.Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBorrowingAPI.Helper
{
    public class BookModelToBookHelper
    {
        public Book BookModelToBookMapping(BookModel e)
        {
            Book u = new Book();
            u.BookName = e.BookName;
            u.Author = e.Author;
            u.Description = e.Description;
            u.Genre = e.Genre;
            u.LentByUserId = e.LentByUserId;
            u.Rating = e.Rating;
            return u;
        }
    }
}

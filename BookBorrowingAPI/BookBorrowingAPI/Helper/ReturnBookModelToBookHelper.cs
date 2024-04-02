using BookBorrowingAPI.Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBorrowingAPI.Helper
{
    public class ReturnBookModelToBookHelper
    {
        public Book ReturnBookModelToBookMapping(ReturnBookModel e)
        {
            Book u = new Book();
            u.BookId = e.BookId;
            u.CurrentlyBorrowedByUserId = e.CurrentlyBorrowedByUserId;
            return u;
        }
    }
}

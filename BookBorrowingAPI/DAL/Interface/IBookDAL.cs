using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IBookDAL
    {
        public bool AddBooks(Book val);
        public IEnumerable<Object> GetBooks();
        public IEnumerable<Object> SearchBooks(Book val);
        public Object GetBookById(int _id);
        public bool BorrowBooks(Book val);
        public bool ReturnBooks(Book val);
    }
}

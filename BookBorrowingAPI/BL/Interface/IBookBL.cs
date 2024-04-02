using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interface
{
    public interface IBookBL
    {
        public bool AddBooks(Book val);
        public IEnumerable<Object> GetBooks();
        public Object GetBookById(int _id);
        public Object SearchBooks(Book val);
        public bool BorrowBooks(Book val);

        public bool ReturnBooks(Book val);
    }
}

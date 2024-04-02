using BL.Interface;
using DAL.Interface;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class BookBL:IBookBL
    {
        private readonly IBookDAL _bookDal;

        public BookBL(IBookDAL bookDal)
        {
            _bookDal = bookDal;
        }

        public bool AddBooks(Book val)
        {
            try
            {
                val.IsBookAvailable = true;
                return _bookDal.AddBooks(val);
            }catch(Exception ex)
            {
                throw ex;
            }
           

        }

        public bool ReturnBooks(Book val)
        {
            try
            {
                return _bookDal.ReturnBooks(val);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public IEnumerable<Object> GetBooks()
        {
            var b = _bookDal.GetBooks();
            return b;
        }
        public Object GetBookById(int _id)
        {
            var b = _bookDal.GetBookById(_id);
            return b;
        }

        public Object SearchBooks(Book val)
        {


            if (val.Author == null || val.Genre == null || val.BookName == null)
            {
                throw new Exception("Argument cant be null");
            }

            try
            {
                var query = _bookDal.SearchBooks(val);
                return query;
            }catch(Exception ex)
            {
                throw ex;
            }

            
            
           
               

        }

        public bool BorrowBooks(Book val)
        {

            try
            {
                var b = _bookDal.BorrowBooks(val);
                return b;
            }
            catch (Exception ex)
            {
                 throw ex;
                
            }


        }

    }
}

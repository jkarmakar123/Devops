using DAL.Interface;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class BookDAL:IBookDAL
    {
        private readonly BookBorrowingContext _context;

        public BookDAL(BookBorrowingContext dbContext)
        {
            _context = dbContext;
        }

        public bool AddBooks(Book val)
        {
            try
            {


                _context.Books.Add(val);
                _context.SaveChanges();

                var q1 = (from u1 in _context.Users
                          where u1.UserId == val.LentByUserId
                          select u1).ToList().FirstOrDefault();
                q1.BooksLent = q1.BooksLent + 1;

                _context.Users.Update(q1);
                _context.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                 throw ex;
               // return false;
            }
        }

        public bool ReturnBooks(Book val)
        {
            try
            {


                var q1 = (from u1 in _context.Users
                          where u1.UserId == val.CurrentlyBorrowedByUserId
                          select u1).ToList().FirstOrDefault();

                var book = (from b1 in _context.Books
                            where b1.BookId == val.BookId
                            select b1).ToList().FirstOrDefault();
                if(q1==null || book == null)
                {
                    return false;
                }

                if (q1.BooksBorrowed == 0)
                {
                    return false;
                }
                else if (book.IsBookAvailable == true)
                {
                    return false;
                }
                else if (book.CurrentlyBorrowedByUserId != q1.UserId)
                {
                    return false;
                }
                else
                {
                    book.IsBookAvailable = true;
                    book.CurrentlyBorrowedByUserId = null;
                    _context.Books.Update(book);
                    _context.SaveChanges();


                    q1.BooksBorrowed = q1.BooksBorrowed - 1;

                    _context.Users.Update(q1);
                    _context.SaveChanges();

                  

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                // return false;
            }
        }
        public IEnumerable<Object> SearchBooks(Book val)
        {
            try
            {
                var e =( from bk in _context.Books
                        join u in _context.Users
                        on bk.LentByUserId equals u.UserId
                        where bk.Author.Contains(val.Author) && bk.BookName.Contains(val.BookName) && bk.Genre.Contains(val.Genre)
                        select new { bk.BookId, bk.BookName, bk.Author,bk.Genre, bk.Description, bk.Rating, bk.IsBookAvailable,
                            bk.LentByUserId, bk.CurrentlyBorrowedByUserId,
                            u.UserId,u.Name, u.UserName }).ToList();
                return e;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Object> GetBooks()
        {
            try
            {
                //var b = _context.Books.ToList();
                var b = (from bk in _context.Books
                         join u in _context.Users
                          on bk.LentByUserId equals u.UserId
                         select new { bk.BookId, bk.BookName,bk.Genre, bk.Author, bk.Description, bk.Rating, bk.IsBookAvailable, bk.LentByUserId, bk.CurrentlyBorrowedByUserId,
                             u.UserId,u.Name, u.UserName}).ToList();
                return b;
            }catch(Exception ex)
            {
                throw ex;
            }
          

        }

        public Object GetBookById(int _id)
        {
            var b = (from bk in _context.Books join u in _context.Users
                     on bk.LentByUserId equals u.UserId where bk.BookId == _id
                     select new { bk.BookId,bk.BookName,bk.Author,bk.Genre,bk.Description,bk.Rating,bk.IsBookAvailable,bk.LentByUserId,bk.CurrentlyBorrowedByUserId,u.UserId,u.Name,u.UserName }).FirstOrDefault();
            return b;
        }

        public bool BorrowBooks(Book val)
        {

            try
            {

                var q1 = (from u1 in _context.Users
                          where u1.UserId == val.LentByUserId
                          select u1).ToList().FirstOrDefault();
                var q2 = (from u2 in _context.Users
                          where u2.UserId == val.CurrentlyBorrowedByUserId
                          select u2).ToList().FirstOrDefault();

                var q =( from c in _context.Books 
                         where c.BookId==val.BookId select c).ToList().FirstOrDefault();

                if (q1.UserId == q2.UserId)
                {
                    return false;
                }

                if (q2.TokenAvailable == 0)
                {
                    return false;
                }

                if (q.IsBookAvailable == false)
                {
                    return false;
                }
                else
                {
                    q1.TokenAvailable = q1.TokenAvailable + 1;
                    _context.Users.Update(q1);
                   

                    q2.TokenAvailable = q2.TokenAvailable - 1;
                    q2.BooksBorrowed = q2.BooksBorrowed + 1;
                    _context.Users.Update(q2);
                   


                    q.IsBookAvailable = false;
                    q.CurrentlyBorrowedByUserId = val.CurrentlyBorrowedByUserId;
                    _context.Books.Update(q);
                    _context.SaveChanges();
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
               
            }


        }

       

    }
}

using BookBorrowingAPI.Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBorrowingAPI.Helper
{
    public class UserToUserModelHelper
    {
        public UserModel UserToUserModelMapping(User e)
        {
            UserModel u = new UserModel();
            u.Name = e.Name;
            u.UserName = e.UserName;
            //u.Password = e.Password;
            u.UserId = e.UserId;
            u.TokenAvailable = e.TokenAvailable;
            u.BooksBorrowed = e.BooksBorrowed;
            u.BooksLent = e.BooksLent;
            return u;
        }
    }
}

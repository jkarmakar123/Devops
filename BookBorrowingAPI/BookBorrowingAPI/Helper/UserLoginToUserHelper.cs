using BookBorrowingAPI.Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBorrowingAPI.Helper
{
    public class UserLoginToUserHelper
    {
        public User UserLoginToUserMapping(UserLogin e)
        {
            User u = new User();
            u.UserName = e.UserName;
            u.Password = e.Password;
            return u;
        }
    }
}

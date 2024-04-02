using DAL.Interface;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UserDAL:IUserDAL
    {
        private readonly BookBorrowingContext _context;

        public UserDAL(BookBorrowingContext dbContext)
        {
            _context = dbContext;
        }


        public User IsUserValid(User user)
        {
            var query = (_context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password));

            if (query != null)
            {
                User userDal = query;
                return userDal;
            }
            return null;
        }

        public User GetUserById(int _id)
        {
            var u = (from  usr in _context.Users                
                     where usr.UserId == _id
                     select usr).FirstOrDefault();
            return u;

           
        }

    }
}

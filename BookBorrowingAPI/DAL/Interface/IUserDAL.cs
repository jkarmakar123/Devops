using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IUserDAL
    {
        public User IsUserValid(User user);
        public User GetUserById(int _id);
    }
}

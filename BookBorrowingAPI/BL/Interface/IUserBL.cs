using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interface
{
     public interface IUserBL
    {
        public User IsUserValid(User user);
        public User GetUserById(int id);
    }
}

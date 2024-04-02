using BL.Interface;
using DAL.Interface;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class UserBL: IUserBL
    {
        private readonly IUserDAL _userDal;

        public UserBL(IUserDAL userDal)
        {
            _userDal = userDal;
        }

        public User IsUserValid(User user)
        {
            var u = _userDal.IsUserValid(user);
            if (u != null)
                return u;
            else
                return null;

        }

        public User GetUserById(int id)
        {
            var u = _userDal.GetUserById(id);
           
            return u;
            
        }
    }
}

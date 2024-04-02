using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBorrowingAPI.Model
{
    public class UserModel
    {
        public string tokenjwt { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        //public string Password { get; set; }
        public int TokenAvailable { get; set; }
        public int BooksLent { get; set; }
        public int BooksBorrowed { get; set; }
    }
}

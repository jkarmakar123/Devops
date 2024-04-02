using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class User
    {

        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int TokenAvailable { get; set; }
        public int BooksLent { get; set; }
        public int BooksBorrowed { get; set; }

    }
}

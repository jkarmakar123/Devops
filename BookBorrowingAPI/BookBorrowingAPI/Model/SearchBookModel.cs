using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBorrowingAPI.Model
{
    public class SearchBookModel
    {
      
        public string BookName { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }
    }
}

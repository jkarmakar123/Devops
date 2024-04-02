using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class Book
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public float? Rating { get; set; }

       
        public string Author { get; set; }

       
        public string Genre { get; set; }

        public bool IsBookAvailable { get; set; }

       
        public string Description { get; set; }

       
        public int LentByUserId { get; set; }

        public int? CurrentlyBorrowedByUserId { get; set; }
    

    }
}

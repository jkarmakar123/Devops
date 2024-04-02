using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookBorrowingAPI.Model
{
    public class BookModel
    {
        [Required]
        public string BookName { get; set; }

        [Required]
        [Range(0.1,5)]
        public float? Rating { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Genre { get; set; }

       // public bool IsBookAvailable { get; set; }

        [Required]
        public string Description { get; set; }

       [Required]
        public int LentByUserId { get; set; }

     //   public int? CurrentlyBorrowedByUserId { get; set; }


    }
}

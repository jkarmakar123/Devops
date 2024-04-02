﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookBorrowingAPI.Model
{
    public class ReturnBookModel
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public int CurrentlyBorrowedByUserId { get; set; }
    }
}

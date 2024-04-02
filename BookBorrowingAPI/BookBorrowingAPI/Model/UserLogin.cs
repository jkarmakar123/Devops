using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookBorrowingAPI.Model
{
    public class UserLogin
    {
        [Required]
        public string UserName { get; set; }

        // [MinLength(4)]
        [Required]
        public string Password { get; set; }
    }
}

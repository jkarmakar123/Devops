using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class BookBorrowingContext: DbContext
    {
        public BookBorrowingContext(DbContextOptions<BookBorrowingContext> options)
          : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}

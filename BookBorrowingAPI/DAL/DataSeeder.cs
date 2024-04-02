using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DataSeeder
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var seerviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = seerviceScope.ServiceProvider.GetService<BookBorrowingContext>();
                if (!context.Users.Any())
                {

                    var users = new List<User>
                {
                new User {Name="admin2", UserName = "admin2@example.com", Password = "P@ssword2",TokenAvailable=3,BooksBorrowed=0,BooksLent=0},
                new User {Name="joy1", UserName = "joy123@gmail.com", Password = "P@ss",TokenAvailable=3,BooksBorrowed=0,BooksLent=0},
                new User {Name="joy2", UserName = "joy246@gmail.com", Password = "P@ssword2",TokenAvailable=3,BooksBorrowed=0,BooksLent=0},
                new User {Name="joy3", UserName = "joy789@gmail.com", Password = "P@ssword2",TokenAvailable=3,BooksBorrowed=0,BooksLent=0}

                };

                    context.Users.AddRange(users);
                    context.SaveChanges();
                }
              
            }
        }
    }
}

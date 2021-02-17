using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYUAmazon.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            BookDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookDbContext>();

            //Make sure all migrations are done
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Books.Any())
            {
                //Add Data to see if it is passing through
                context.Books.AddRange(

                    new Book
                    {
                        title = "Les Miserables",
                        authorFirst = "Victor",
                        authorLast = "Hugo",
                        publisher = "Signet",
                        ISBN = "978-0451419439",
                        classification = "Fiction",
                        category = "Classic",
                        price = 9.95
                    },

                    new Book
                    {
                        title = "Team of Rivals",
                        authorFirst = "Doris",
                        authorMiddle = "Kearns",
                        authorLast = "Goodwin",
                        publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        classification = "Non-Fiction",
                        category = "Biography",
                        price = 14.58
                    },

                    new Book
                    {
                        title = "The Snowball",
                        authorFirst = "Alice",
                        authorLast = "Schroeder",
                        publisher = "Bantam",
                        ISBN = "978-0553384611",
                        classification = "Non-Fiction",
                        category = "Biography",
                        price = 21.54
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

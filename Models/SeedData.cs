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
                        price = 9.95,
                        pages = 1488
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
                        price = 14.58,
                        pages = 944
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
                        price = 21.54,
                        pages = 832
                    },

                    new Book
                    {
                        title = "Hunger Games",
                        authorFirst = "Suzanne",
                        authorLast = "Collins",
                        publisher = "Scholastic Corporation",
                        ISBN = "978-0439023481",
                        classification = "Fiction",
                        category = "Action",
                        price = 8.00,
                        pages = 374
                    },

                    new Book
                    {
                        title = "How to Win Friends and Influence People",
                        authorFirst = "Dale",
                        authorLast = "Carnegie",
                        publisher = "Simon & Schuster",
                        ISBN = "978-1442344815",
                        classification = "Non-Fiction",
                        category = "Self-Help",
                        price = 16.99,
                        pages = 291
                    },

                    new Book
                    {
                        title = "Night of the Howling Dogs",
                        authorFirst = "Graham",
                        authorLast = "Salisbury",
                        publisher = "Hachette",
                        ISBN = "978-0440238393",
                        classification = "Fiction",
                        category = "Action",
                        price = 14.58,
                        pages = 944
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TheBookCave.Data;
using TheBookCave.Models.EntityModels;
namespace TheBookCave
{
    public class Program
    {   
        /// Main fallinu er breytt, SeedData athugar hvort thad seu gogn inn i toflu.
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            SeedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        // Baett vid koda til ad vinna med Database, til thess ad baeta i grunn.
        public static void SeedData()
        {  
            // byr til breytuna db sem er new DataContext
            var db = new DataContext();
        
            // byr til lista af bokum. Gagnagrunnurinn ser um ad bua til ID
            // ef db er tomur, tha addaru inn i gagnagrunn.
             if(!db.Books.Any())
            {
                var intialBooks = new List<Book>()
                {   
                    new Book {
                        ISBN = "1111111111111",
                        Title = "A Game of Thrones : Book 1 of A Song of Ice and Fire",
                        Author = "George R. R. Martin",
                        Genre = "Fantasy",
                        Image = "someimage",
                        Description = " The first volume of A Song of Ice and Fire, the greatest fantasy epic of the modern age. GAME OF THRONES is now a major TV series from HBO, starring Sean Bean. Summers span decades. Winter can last a lifetime. And the struggle for the Iron Throne has begun. As Warden of the north, Lord Eddard Stark counts it a curse when King Robert bestows on him the office of the Hand. His honour weighs him down at court where a true man does what he will, not what he must ...and a dead enemy is a thing of beauty. The old gods have no power in the south, Stark's family is split and there is treachery at court. Worse, the vengeance-mad heir of the deposed Dragon King has grown to maturity in exile in the Free Cities. He claims the Iron Throne.",
                        Rating = 1,
                        Review = "GoodBook",
                        Price = 1
                    }                  
                };
                
                db.AddRange(intialBooks);       /// Setur initalBooks i db
                db.SaveChanges();               /// Vista breytingu
             }  
        } 
    }   
}

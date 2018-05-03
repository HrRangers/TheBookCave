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
            //SeedData();
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
                    new Book {Title = "Good Book" },
                    new Book {Title = "Bad Book" }
                };
                
                db.AddRange(intialBooks);       /// Setur initalBooks i db
                db.SaveChanges();               /// Vista breytingu
             }  
        } 
    }   
}

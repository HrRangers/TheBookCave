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
            var db = new DataContext();
            var shipping = new Shipping()
            {
                Address = "Some",      
                City = "Some",    
                HouseNumber = 24,  
                Country = "Some",
                PostalCode = "201",
                UserID = "Email"

            };
            db.AddRange(shipping);
            db.SaveChanges();               
               
        }   
    }   
}

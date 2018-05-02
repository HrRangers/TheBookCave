using Microsoft.EntityFrameworkCore;
using TheBookCave.Models.EntityModels;

namespace TheBookCave.Data
{   
    public class DataContext : DbContext
    {   
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           /* optionsBuilder     /// Hér kemur linkur fyrir SQL server. 
                .UseSqlServer(); */    
        }
        
        // Í terminal: dotnet ef migrations add initalMigration
        // Bætist við mappa sem heitir migrations. I terminal "dotnet ef [options] [command]"
        // Svo til ad uppfaera gagnagrunn, I terminal "dotnet ef database update"
   }
    

}
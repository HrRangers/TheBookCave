using Microsoft.EntityFrameworkCore;
using TheBookCave.Models.EntityModels;

namespace TheBookCave.Data
{   
    public class DataContext : DbContext
    {   
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder     /// Hér kemur linkur fyrir SQL server. 
                .UseSqlServer("Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H20;Persist Security Info=False;User ID=VLN2_2018_H20_usr;Password=ThUnD3RC4TZ!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");     
        }
        
        // Í terminal: dotnet ef migrations add initalMigration
        // Bætist við mappa sem heitir migrations. I terminal "dotnet ef [options] [command]"
        // Svo til ad uppfaera gagnagrunn, I terminal "dotnet ef database update"
   }
    

}
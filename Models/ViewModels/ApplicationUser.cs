using Microsoft.AspNetCore.Identity;

namespace authentication_repo.Models
{

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FavoriteBook { get; set; }
        public int Age { get; set; }
    }
}
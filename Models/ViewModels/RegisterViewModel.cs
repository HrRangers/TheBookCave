using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace authentication_repo.Models.ViewModels
{

    public class RegisterViewModel
    {   
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FirstName{ get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
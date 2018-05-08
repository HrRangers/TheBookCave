using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Models.InputModels;
using TheBookCave.Data;
using authentication_repo.Models.ViewModels;
using authentication_repo.Models;
using System.Security.Claims;
using TheBookCave.Repositories;

namespace authentication_repo.Controllers
{
    public class UserController : Controller
    {   

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager; 
        
        private UserRepo _userRepo;
        
        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager; 
            _userRepo = new UserRepo();
        }
        public IActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {   
            /// ClientSide validation!
            if(!ModelState.IsValid) { return View(); }
            
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            
            var result =  await _userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {
                /// The User is successfully registered
                /// 
                await _userManager.AddClaimAsync(user, new Claim("Name", $"{model.FirstName} {model.LastName}"));
                await _signInManager.SignInAsync(user, false);
                SeedData(model);
                return RedirectToAction("UserRegister");

            }
            return View();
        }


        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]   
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if(!ModelState.IsValid) {return View(); }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if(result.Succeeded)
            {   
                return RedirectToAction("Index", "Book");
            }
            return View();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("LogIn", "User");
        }   

        
        public static void SeedData(RegisterViewModel model)
        {   
            var user_db = new DataContext();
            var users = new List<User>()
            {
                new User {

                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                   
        
                }                  
            };

            user_db.AddRange(users);
            user_db.SaveChanges();

        }
        
        [HttpGet]
        public IActionResult UserRegister()
        {   
            
            return View();
        }

        [HttpPost]
        public IActionResult UserRegister(ShippingAddressInputModel newAddres)
        {   

            if(ModelState.IsValid)
            {   
               
                SeedData(newAddres);
   
            }       
            return View();
        }
       
        [HttpPost]
        public static void SeedData(ShippingAddressInputModel newAddres)
        {   
            var user_db = new DataContext();
            var get_user = _userRepo.GetUsers();
            get_user.Select(x => x.UserID).FirstOrDefault();

            var shipping_db = new DataContext();
            var shipping = new List<ShippingAddress>
            {
                new ShippingAddress 
                {
                    Address = newAddres.Address,
                    City = newAddres.City,
                    HouseNumber = newAddres.HouseNumber,
                    Country = newAddres.Country,
                    PostalCode = newAddres.PostalCode,
                    UserID = get_user.UserID
                }            
                
            
            };
            shipping_db.AddRange(shipping);
            
         

            shipping_db.SaveChanges();
        }
        [HttpPost]
   /*     public static void SeedDataUpdateUserID(User user)
        {   
            var shipping_db = new DataContext();
            shipping_db.ShippingAddress.Add(new ShippingAddress{
                UserID = user.Id
            });
               shipping_db.ShippingAddress.Add(new ShippingAddress{
                UserID = user.Id
            });
      
            shipping_db.SaveChanges();        
        }*/

        [HttpGet]
        public IActionResult UserAccount()
        {   var user = _userRepo.GetUser();
            return View();
        }

        public IActionResult AccessDenied()
        {
            return RedirectToAction("LogIn", "User");
        }
    }
}
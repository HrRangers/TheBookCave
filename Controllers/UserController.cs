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
using Microsoft.AspNetCore.Authorization;
using TheBookCave.Repositories;

namespace authentication_repo.Controllers
{
    public class UserController : Controller
    {   

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager; 
        
        private UserRepo _userRepo;
        private ShippingRepo _shippingRepo;
        
        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager; 
            _userRepo = new UserRepo();
            _shippingRepo = new ShippingRepo();
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
                await _userManager.AddClaimAsync(user, new Claim("Name","Email", $"{model.FirstName} {model.LastName} {model.Email}"));
                await _signInManager.SignInAsync(user, false);
               // SeedData(model);
                return RedirectToAction("RegisterShipping");

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

 
      /*  public static void SeedData(RegisterViewModel model)
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
   */
        [Authorize]
        [HttpGet]
        public IActionResult RegisterShipping()
        {   
            
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult RegisterShipping(ShippingInputModel newAddres, ApplicationUser userdetails)
        {   

            if(ModelState.IsValid)
            {   
                
                SeedData(newAddres, userdetails);
                return RedirectToAction("MyProfile");
            }       
            return View("RegisterShipping");
        }
        [Authorize]
        [HttpPost]
        public static void SeedData(ShippingInputModel newAddres, ApplicationUser userdetails)
        {   
            var user_db = new DataContext();    
            var shipping_db = new DataContext();
            var shipping = new List<Shipping>
            {
                new Shipping
                {
                    Address = newAddres.Address,
                    City = newAddres.City,
                    HouseNumber = newAddres.HouseNumber,
                    Country = newAddres.Country,
                    PostalCode = newAddres.PostalCode,
                    UserID = userdetails.Email
                    
                }
                          
            };
            shipping_db.AddRange(shipping);
        
            shipping_db.SaveChanges();
        }
        
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        //Úr nyjasta myndbandi
        [Authorize]
        public async Task<IActionResult> MyProfile()
        {
            //get user data
            var user = await _userManager.GetUserAsync(User);

            return View(new ProfileViewModel {
                FirstName = user.FirstName,
                LastName = user.LastName,
                FavoriteBook = user.FavoriteBook,
                Age = user.Age
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> MyProfile(ProfileViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            //Update properties
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Age = model.Age;
            user.FavoriteBook = model.FavoriteBook;

            await _userManager.UpdateAsync(user);

            return View();
        }
    }
}
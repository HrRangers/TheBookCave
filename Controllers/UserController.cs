using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models;
using authentication_repo.Models.ViewModels;
using authentication_repo.Models;
using System.Security.Claims;

namespace authentication_repo.Controllers
{
    public class UserController : Controller
    {   

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager; 

        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager; 
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
                return RedirectToAction("Register");

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
        [HttpPost]
        public IActionResult UserRegister()
        {
            
            return View();
        }
        public IActionResult UserAccount()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return RedirectToAction("LogIn", "User");
        }
    }
}
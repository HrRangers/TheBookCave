using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TheBookCave.Repositories;
using TheBookCave.Models.EntityModels;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;
using TheBookCave.ViewModels;

namespace TheBookCave.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        
        private CartRepo _cartRepo;
        private DataContext _db;

        private BookRepo _bookRepo;

        public CartController()
        {
            _cartRepo = new CartRepo();
            _bookRepo = new BookRepo();
            _db = new DataContext();
        }
        public IActionResult ShoppingCart()
        {
            return View("ShoppingCart");
        }

        public IActionResult AccessDenied()
        {
            return RedirectToAction("LogIn", "User", new { area = "" });
        }

    }
}
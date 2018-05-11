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

        
        [HttpPost]
        public IActionResult AddToCart(int id)
        {   
            //var cartItem = _cartRepo.GetCart().SingleOrDefault();
            //var cartItem = _db.Cart;
             var cartdb = new DataContext();
             var cartItem = new List<Cart>
             {
                new Cart()
                {
                    BookId = id,
                }


             };
            var selectedBook = (from b in _bookRepo.GetAllBooks()
                                orderby b.Id
                                select b).ToList(); 
       
               
               cartdb.AddRange(cartItem);
               cartdb.SaveChanges();
                return View(selectedBook);            
            
             
            
        }
        [HttpGet]
          public IActionResult Step1()
        {
            return View();
        }
           public IActionResult Step2()
        {
            return View();
        }
            public IActionResult Step3()
        {
            return View();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;


namespace TheBookCave.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
           
        public IActionResult ShoppingCart()
        {
            return View("ShoppingCart");
        }

        public IActionResult AccessDenied()
        {
            return RedirectToAction("LogIn", "User");
        }

    }
}
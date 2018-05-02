using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models;

namespace TheBookCave.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserLogin()
        {
            return View("UserLoginIndex");
        }

    }       
}   
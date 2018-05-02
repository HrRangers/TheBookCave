using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models;

namespace TheBookCave.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListOfBooks()
        {
            return View("ListOfBooks");
        }
        public IActionResult NewBooks()
        {
            return View("NewBooks");
        }
        public IActionResult TopTenBooks()
        {
            return View("TopTenBooks");
        }
        public IActionResult AboutUs()
        {
            return View("AboutUs");
        }
         public IActionResult ContactUs()
        {
            return View("ContactUs");
        }
    }
}
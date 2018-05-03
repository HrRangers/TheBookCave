using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models;
using TheBookCave.Repositories;

namespace TheBookCave.Controllers
{
    public class BookController : Controller
    {   
        private BookRepo _bookRepo;
        
        public BookController()
        {
            _bookRepo = new BookRepo();
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ListOfBooks()
        {   
            var books = _bookRepo.GetAllBooks();
            return View("ListOfBooks");
           // return View(books);
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
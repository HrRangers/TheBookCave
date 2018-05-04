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

        [HttpPost]
        public IActionResult ListOfBooks(string genre)
        {   

            if (genre == null)
            {
                return ListOfBooks();
            }
            else
            {   
                var genrelistBooks= _bookRepo.GetBooksByGenre(genre);
                return View(genrelistBooks);
            }      
        }
        [HttpGet]
        public IActionResult ListOfBooks()
        {   
            var books = _bookRepo.GetAllBooks();
            //return View("ListOfBooks");
            return View(books);
        }
        public IActionResult NewBooks()
        {
            return View("NewBooks");
        }
        public IActionResult TopTenBooks()
        {   
            var toptenBooks = _bookRepo.GetTop10Books();
            return View(toptenBooks);
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
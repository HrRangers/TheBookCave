using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet]
        public IActionResult Index()
        {
            var books = _bookRepo.GetAllBooks();
            return View(books);
        }
        [HttpPost]
        public IActionResult Index(string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                var resultBooks = _bookRepo.GetBooksBySearch(searchString);
                return View(resultBooks);
            }
            else
            {
                return View("NotFound");
            }
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
                var genrelistBooks = _bookRepo.GetBooksByGenre(genre);
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

        [HttpPost]
        public IActionResult SortBooks(string sort)
        {
            var sortedBooks = _bookRepo.GetAllBooks();
            if (sort == null)
            {
                return ListOfBooks();
            }
            if (sort == "A to Z")
            {
                sortedBooks = _bookRepo.SortBooksAscending();
            }
            else if (sort == "Z to A")
            {
                sortedBooks = _bookRepo.SortBooksDescending();
            }
            else if (sort == "Lower prices")
            {
                sortedBooks = _bookRepo.SortBooksLowest();
            }
            else if (sort == "Medium prices")
            {
                sortedBooks = _bookRepo.SortBooksMedium();
            }
            else if (sort == "Higher prices")
            {
                sortedBooks = _bookRepo.SortBooksHigest();
            }
            return View(sortedBooks);
        }

        [HttpGet]
        public IActionResult BookDetails(string isbn)
        {
            if (isbn == null)
            {
                return View("Error");
            }

            var bookbyISBN = _bookRepo.GetBookByISBN(isbn);

            return View(bookbyISBN);

        }
        public IActionResult NewBooks()
        {
            var newestBooks = _bookRepo.GetNewArrivals();
            return View(newestBooks);
        }

        [HttpGet]
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
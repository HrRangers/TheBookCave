using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories
{   
    public class BookRepo
    {
        private DataContext _db;
        public BookRepo()
        {
            _db = new DataContext();
        }

        public List<BookListViewModel> GetAllBooks()
        {
            var books = (from a in _db.Books
                        select new BookListViewModel
                        {
                            Id = a.Id,
                            Title = a.Title,
                            Author = a.Author,
                            Genre = a.Genre,
                            Rating = a.Rating,
                            Image = a.Image,
                            Review = a.Review,
                            Price = a.Price,
                            Description = a.Description
        
                        }).ToList();
            return books;
        }
    }
}



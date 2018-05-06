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
            var books = (from b in _db.Books
                        select new BookListViewModel
                        {
                            Id = b.Id,
                            ISBN = b.ISBN,
                            Title = b.Title,
                            Author = b.Author,
                            Genre = b.Genre,
                            Rating = b.Rating,
                            Image = b.Image,
                            Review = b.Review,
                            Price = b.Price,
                            Description = b.Description
        
                        }).ToList();
            return books;
        }

        public List<BookListViewModel> GetTop10Books()
        {
             var top10books = (from b in GetAllBooks()
                        orderby b.Rating
                        descending
                        select b).Take(10).ToList();
             return top10books;
        }
        public List<BookListViewModel> GetBooksByGenre(string genre)
        {       
            var genrelistBooks = (from g in GetAllBooks()
                            where (g.Genre.ToLower() == genre.ToLower())
                            select g).ToList();                        
                return genrelistBooks;
        }
        public List<BookListViewModel> GetBookByISBN(string isbn)
        {
            var bookbyISBN = (from b in GetAllBooks()
                        where (b.ISBN.ToLower() == isbn.ToLower())
                        select b).ToList();
            
            return bookbyISBN;
        }
  
    }
}



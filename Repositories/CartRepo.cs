using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;


namespace TheBookCave.Repositories
{
    public class CartRepo
    {
        /*         private DataContext _db;

        public CartRepo()
        {
            _db = new DataContext();
        }
         public List<CartRepo> GetCart()
        {
            var cart = (from c in _db.Cart
                         select new CartViewModel()
                         {
                            BookId = c.BookId,
                            CartId = c.CartId,
                            Quantity = c.Quantity,
                            Email = c.Email

                         }).ToList();
            return cart;
        }
        */
    }
}
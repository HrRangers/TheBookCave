using System.Collections.Generic;
using TheBookCave.Models.EntityModels;

namespace TheBookCave.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public int CartTotal { get; set; }
    }
}
namespace TheBookCave.Models.ViewModels
{
    public class CartViewModel
    {
        public int BookId { get; set; }

        public int CartId { get; set; } 

        public int Quantity { get; set; }

        public string Email { get; set; }
    }
}
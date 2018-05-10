namespace TheBookCave.Models.EntityModels
{
    public class Cart
    {
        public int CartId { get; set; } 
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public string Email { get; set; }
    }

}
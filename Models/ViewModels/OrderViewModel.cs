namespace TheBookCave.Models.ViewModel
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public int BookId { get; set; }
        public int ShippingID { get; set; }
        public long OrderPrice { get; set; }
        public int Quantity { get; set; }
      
    }

}
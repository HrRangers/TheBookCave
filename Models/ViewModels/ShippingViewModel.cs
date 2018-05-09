namespace TheBookCave.Models.ViewModels
{

    public class ShippingViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public long HouseNumber { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public int UserID { get; set; }
    }

}
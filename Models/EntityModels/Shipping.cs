namespace TheBookCave.Models.EntityModels
{
     public class Shipping
    {   
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public long HouseNumber { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string UserID { get; set; }

    }

}
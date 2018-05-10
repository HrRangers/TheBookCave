namespace TheBookCave.Models.EntityModels
{
    public class Order
    {
        /// Order tharf ad hafa ID. Gagnagrunnur gefur Id
        public int OrderId { get; set; }
        /// Order tharf ad hafa verd
        public int OrderPrice { get; set; }
        /// Order tharf ad hafa fjölda af pöntunum
        public int BookId { get; set; }
        public int ShippingID { get; set; }     
        public string Email  { get; set; }  
        public string Address { get; set; }
        public string City { get; set; }
        public long HouseNumber { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public int UserID { get; set; }
    }

}
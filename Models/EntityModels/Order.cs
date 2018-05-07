namespace TheBookCave.Models.EntityModels
{
    public class Order
    {
        /// Order tharf ad hafa ID. Gagnagrunnur gefur Id
        public int Id { get; set; }
        /// Order tharf ad hafa verd
        public long OrderPrice { get; set; }
        /// Order tharf ad hafa fjölda af pöntunum
        public int BookId { get; set; }
        public int UserID { get; set; }
        public int ShippingID { get; set; }     
    }

}
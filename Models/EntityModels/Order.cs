namespace TheBookCave.Models.EntityModels
{
    public class Order
    {   
        /// Order tharf ad hafa ID. Gagnagrunnur gefur Id
        public int Id { get; set; }

         /// Order tharf ad hafa verd
        public int OrderPrice { get; set; }

        /// Order tharf ad hafa fjölda af pöntunum
        public int Quantity { get; set; }

        /// Order tharf ad hafa Bókanúmer
        public int BookId { get; set; }

    }

}
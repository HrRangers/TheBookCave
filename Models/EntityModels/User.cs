namespace TheBookCave.Models.EntityModels
{      /// Þarf ekki lengur // 
    public class User
    {
    /// User tharf ad hafa ID. Gagnagrunnur gefur Id
        public int Id { get; set; }
   /// User tharf ad hafa Email addressu
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string FavoriteBook { get; set; }
        public byte[] Image;  
        /// User tharf ad hafa pöntunarnúmer
     
        public int ShippingID  { get; set; }
    }


}
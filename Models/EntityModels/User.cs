namespace TheBookCave.Models.EntityModels
{
    public class User
    {   
        /// User tharf ad hafa ID. Gagnagrunnur gefur Id
        public int Id { get; set;}
        
        /// User tharf ad hafa Username
        public string Username {get; set;}
        
        /// User tharf ad hafa Email addressu
        public string Email {get; set;}

        /// User tharf ad hafa fyrsta nafn
        public string FirstName {get; set;}

        /// User tharf ad hafa seinna nafn
        public string LastName {get; set;}
        
        /// User tharf ad hafa götuheiti
        public string StreetName {get; set;}
        
        /// User tharf ad hafa húsnúmer
        public int HouseNumber {get; set;}
        
        /// User tharf ad hafa sveitarfélag
        public string City {get; set;}
        
        /// User tharf ad hafa Land
        public string Country {get; set;}
        
        /// User tharf ad hafa póstnúmer
        public int PostalCode {get; set;}
        
        /// User tharf ad hafa Uppáhalds bók
        public string FavoriteBook {get; set;}
        
        /// User tharf ad hafa pöntunarnúmer
        public int OrderId {get; set;}
    }


}
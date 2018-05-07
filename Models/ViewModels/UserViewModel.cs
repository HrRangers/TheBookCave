namespace TheBookCave.Models.ViewModels
{

    public class UserViewModel
    {
        public int UserID { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string FavoriteBook { get; set; }
        public byte[] Image;
        public string Address { get; set; }
        public string City { get; set; }
        public long HouseNumber { get; set; }
        public string PostalCode { get; set; }  
    }

}
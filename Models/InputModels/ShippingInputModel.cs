using System.ComponentModel.DataAnnotations;

namespace TheBookCave.Models.InputModels
 {   
    public class ShippingInputModel
    {
        
        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public long HouseNumber { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PostalCode { get; set; }
    
    }

}
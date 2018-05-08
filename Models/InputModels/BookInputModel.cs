using System.ComponentModel.DataAnnotations;

namespace TheBookCave.Models.InputModels
{    
    public class BookInputModel
    {
        
        [Required]
        public int Rating { get; set; }


        [Required]
         public string Review { get; set; }
    
    }

}
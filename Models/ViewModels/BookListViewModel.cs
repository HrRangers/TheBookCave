
namespace TheBookCave.Models.ViewModels
{
    public class BookListViewModel
    {   
        /// Bok tharf ad hafa ID. Gagnagrunnur gefur Id
        public int Id { get; set; }
        
        /// Bok tharf ad ISBN numer
        public string ISBN { get; set; }

        /// Bok tharf ad hafa Titill
        public string Title { get; set; }

        /// Bok tharf ad hafa Author, Author gaeti kannski verid annad model.
        public string Author { get; set; }
        
        /// Bok tharf ad hafa bokaflokk
        public string Genre { get; set; }
       
        /// Bok tharf ad hafa rating. 0 til 5
        public int Rating{ get; set; }
        
        /// Bok tharf ad hafa bokakapu
        public string Image{ get; set; }

        /// Bok tharf ad hafa Umsagnir.
        public string Review{ get; set; }
       
        /// Bok tharf ad grunnverd, ekki viss hvort thad eigi ad vera annarsstaðar
        public int Price { get; set; }

        /// Bok tharf ad stutta lysingu.
        public string Description { get; set; }

    }
}
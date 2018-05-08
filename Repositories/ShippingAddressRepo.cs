using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories
{
    public class ShippingAddressRepo
    {
        private DataContext _db;
        public ShippingAddressRepo()
        {
            _db = new DataContext();
        }


    }

}
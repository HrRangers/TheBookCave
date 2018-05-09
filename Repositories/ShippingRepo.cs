using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories
{
    public class ShippingRepo
    {
        private DataContext _db;
        public ShippingRepo()
        {
            _db = new DataContext();
        }
        /*
        List<ShippingViewModel> GetAllShipping()
        {
            var shipping = (from s in _db.ShippingAddress
                            join u in _db.Users on s.UserID equals u.Id
                            select new ShippingViewModel
                            {   
                                Id = s.Id,
                                Address = s.Address,
                                City = s.City,
                                HouseNumber = s.HouseNumber,
                                Country = s.Country,
                                PostalCode = s.PostalCode,
                                UserID = u.Id           

                            }).ToList();
            
            return shipping;            
        }*/

    }
        
}

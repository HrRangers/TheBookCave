using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories
{
    public class UserRepo
    {
        private DataContext _db;
        public UserRepo()
        {
            _db = new DataContext();
        }

        public List<UserViewModel> GetUsers()
        {
            var user = (from u in _db.Users
                        join s in _db.ShippingAddress on u.Id equals s.Id
                        select new UserViewModel
                        {
                            UserID = u.Id,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            Country = s.Country,
                            FavoriteBook = u.FavoriteBook,
                            Image = u.Image,
                            Address = s.Address,
                            City = s.City,
                            HouseNumber = s.HouseNumber,
                            PostalCode = s.PostalCode,
                            ShippingID = s.Id
                        }).ToList();
                 return user;

        }



        

    }
}
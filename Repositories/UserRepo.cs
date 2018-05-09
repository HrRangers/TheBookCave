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
        
        public List<UserViewModel> GetAllUsers()
        {
            var users = (from u in _db.Users
                        select new UserViewModel
                        {
                            UserID = u.Id,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            FavoriteBook = u.FavoriteBook,
                            Image = u.Image,
                  
                        }).ToList();
            return users;
        }      



        public List<UserViewModel> GetUserShipping()
        {
            var user = (from u in _db.Users
                        join s in _db.ShippingAddress on u.Id equals s.UserID
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
                        }).ToList();
                 return user;

        }

 

        public List<UserViewModel> GetUserByEmail(string email)
        {
            var userByEmail = (from e in GetAllUsers()
                            where (e.Email.ToLower() == email.ToLower())
                            select e).ToList();
                       
            return userByEmail; 

        }

/*
         public List<UserViewModel> GetUserID()
        {
            var userID = (from u in GetAllUsers()
                              orderby u.UserID 
                              descending
                              select u).rDefault();
             return userID;
        }
 */
    }
}
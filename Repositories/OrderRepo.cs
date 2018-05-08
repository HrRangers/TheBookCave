using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories
{
    public class OrderRepo
    {
        private DataContext _db;
        public OrderRepo()
        {
            _db = new DataContext();
        }

    }

}
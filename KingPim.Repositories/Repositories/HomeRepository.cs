using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPim.Repositories.Repositories
{
    public class HomeRepository : IHome
    {
        // Put the Db into a variable to use later on:
        private ApplicationDbContext _ctx;
        public HomeRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public Category Get(int id)
        {
            return _ctx.Categories.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Category> GetAll()
        {
            return _ctx.Categories;
        }
    }
}

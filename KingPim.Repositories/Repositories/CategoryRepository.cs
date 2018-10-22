using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories.Repositories
{
    public class CategoryRepository : ICategory
    {
        public IEnumerable<Category> Categories => new List<Category>
        {
            new Category {Name = "Pants"},
            new Category {Name = "Piké"}
        };

        // TODO: GetAll
        public IEnumerable <Category> GetAll()
        {
            return Categories;
        }
    }
}

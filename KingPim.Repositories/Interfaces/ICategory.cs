using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface ICategory
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
        void Add(Category newCategory);
        void Update(Category updateCategory);
        void Delete(Category deleteCategory);
    }
}

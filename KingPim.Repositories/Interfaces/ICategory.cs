using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface ICategory
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
        void Add(CategoryViewModel newCategory);
        void Update(CategoryViewModel updateCategory);
        Category Delete(int id);
    }
}

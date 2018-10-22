using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface ICategory
    {
        IEnumerable<Category> Categories { get; }
        IEnumerable<Category> GetAll();
    }
}

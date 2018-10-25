using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories.Interfaces
{
    public interface IHome
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
    }
}

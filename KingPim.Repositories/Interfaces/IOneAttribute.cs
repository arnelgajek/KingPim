using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories.Interfaces
{
    public interface IOneAttribute
    {
        IEnumerable<OneAttribute> GetAll();
        OneAttribute Get(int id);
        void Add(OneAttribute newOneAttribute);
        void Update(OneAttribute updateOneAttribute);
        void Delete(OneAttribute deleteOneAttribute);
    }
}

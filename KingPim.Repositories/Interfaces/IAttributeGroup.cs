using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories.Interfaces
{
    public interface IAttributeGroup
    {
        IEnumerable<AttributeGroup> GetAll();
        AttributeGroup Get(int id);
        void Add(AttributeGroupViewModel newAttributeGroup);
        void Update(AttributeGroupViewModel updateAttributeGroup);
        AttributeGroup Delete(int id);
    }
}

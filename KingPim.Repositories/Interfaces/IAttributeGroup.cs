using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories.Interfaces
{
    public interface IAttributeGroup
    {
        IEnumerable<AttributeGroup> GetAll();
        AttributeGroup Get(int id);
        void Add(AttributeGroup newAttributeGroup);
        void Update(AttributeGroup updateAttributeGroup);
        void Delete(AttributeGroup deleteAttributeGroup);
    }
}

using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPim.Repositories.Repositories
{
    public class AttributeGroupRepository : IAttributeGroup
    {
        // Put the Db into a variable to use later on:
        private ApplicationDbContext _ctx;
        public AttributeGroupRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(AttributeGroup newAttributeGroup)
        {
            throw new NotImplementedException();
        }

        public void Update(AttributeGroup updateAttributeGroup)
        {
            throw new NotImplementedException();
        }

        public void Delete(AttributeGroup deleteAttributeGroup)
        {
            throw new NotImplementedException();
        }

        public AttributeGroup Get(int id)
        {
            return _ctx.AttributeGroups.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<AttributeGroup> GetAll()
        {
            return _ctx.AttributeGroups;
        }
    }
}

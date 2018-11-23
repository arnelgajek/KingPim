using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories.Repositories
{
    public class PredefinedAttributeListOptionsRepository : IPredefinedAttributeListOptions
    {
        private ApplicationDbContext _ctx;
        public PredefinedAttributeListOptionsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<PredefinedAttrListOptions> GetAllOptions()
        {
            return _ctx.PredefinedAttrListOptions;
        }
    }
}

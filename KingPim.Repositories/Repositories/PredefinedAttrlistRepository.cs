using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories.Repositories
{
    public class PredefinedAttrlistRepository : IPredefinedAttrList
    {
        private ApplicationDbContext _ctx;
        public PredefinedAttrlistRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<PredefinedAttrList> GetAllLists()
        {
            return _ctx.PredefinedAttrLists;
        }

        public IEnumerable<PredefinedAttrListOptions> GetAllOptions()
        {
            return _ctx.PredefinedAttrListOptions;
        }
    }
}

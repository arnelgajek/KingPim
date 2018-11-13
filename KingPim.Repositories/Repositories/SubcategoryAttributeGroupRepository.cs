using KingPim.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories.Repositories
{
    public class SubcategoryAttributeGroupRepository
    {
            private ApplicationDbContext _ctx;
            public SubcategoryAttributeGroupRepository(ApplicationDbContext ctx)
            {
                _ctx = ctx;
            }
    }
}

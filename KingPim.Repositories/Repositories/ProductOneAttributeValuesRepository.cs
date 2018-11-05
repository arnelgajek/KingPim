using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KingPim.Repositories.Repositories
{
    public class ProductOneAttributeValuesRepository : IProductOneAttributeValues
    {
        private ApplicationDbContext _ctx;
        public ProductOneAttributeValuesRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ProductOneAttributeValue> GetAll()
        {
            return _ctx.ProductOneAttributeValues;
        }
    }
}

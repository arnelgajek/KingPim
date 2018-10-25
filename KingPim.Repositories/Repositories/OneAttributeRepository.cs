using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPim.Repositories.Repositories
{
    public class OneAttributeRepository : IOneAttribute
    {
        // Put the Db into a variable to use later on:
        private ApplicationDbContext _ctx;
        public OneAttributeRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(OneAttribute newOneAttribute)
        {
            throw new NotImplementedException();
        }

        public void Update(OneAttribute updatAttribute)
        {
            throw new NotImplementedException();
        }

        public void Delete(OneAttribute deleteAttribute)
        {
            throw new NotImplementedException();
        }

        public OneAttribute Get(int id)
        {
            return _ctx.OneAttributes.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<OneAttribute> GetAll()
        {
            return _ctx.OneAttributes;
        }
    }
}

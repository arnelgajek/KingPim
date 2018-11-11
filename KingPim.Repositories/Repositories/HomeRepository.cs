using KingPim.Data;
using KingPim.Repositories.Interfaces;

namespace KingPim.Repositories.Repositories
{
    public class HomeRepository : IHome
    {
        // Put the Db into a variable to use later on:
        private ApplicationDbContext _ctx;
        public HomeRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
    }
}

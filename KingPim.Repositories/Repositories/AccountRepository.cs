using KingPim.Data;
using KingPim.Models.ViewModels;
using System.Security.Principal;

namespace KingPim.Repositories.Repositories
{
    public class AccountRepository : IIdentity
    {
        private ApplicationDbContext _ctx;

        public AccountRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public string AuthenticationType => throw new System.NotImplementedException();

        public bool IsAuthenticated => throw new System.NotImplementedException();

        public string Name => throw new System.NotImplementedException();

        public void Add(AccountViewModel vm)
        {

        }
    }
}

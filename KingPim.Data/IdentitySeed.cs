using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Data
{
    public class IdentitySeed : IIdentitySeed
    {
        private const string _admin = "admin@kingpim.se";
        private const string _password = "buggeroff";

        // Constructor so we can use Dependency Injection from DB.
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IdentitySeed(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> CreateAdminAccountIfEmpty()
        {
            if (!_context.Users.Any(u => u.UserName == _admin))
            {
                var user = new IdentityUser
                {
                    UserName = _admin,
                    Email = "admin@kingpim.se",
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, _password);
                var test = result.Succeeded;
            }
            return true;
        }
    }
}

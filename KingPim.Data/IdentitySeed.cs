using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Data
{
    public class IdentitySeed : IIdentitySeed
    {
        private const string _administrator = "administrator@kingpim.se";
        private const string _password = "buggeroff";

        private const string _editor = "editor@kingpim.se";
        private const string _password2 = "buggeroff2";

        private const string _publisher = "publisher@kingpim.se";
        private const string _password3 = "buggeroff3";

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IdentitySeed(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> CreateAdminAccountIfEmpty()
        {
            if (!_context.Users.Any())
            {
                var administrator = new IdentityUser
                {
                    UserName = _administrator,
                    Email = "administrator@kingpim.se",
                    EmailConfirmed = true
                };

                var editor = new IdentityUser
                {
                    UserName = _editor,
                    Email = "editor@kingpim.se",
                    EmailConfirmed = true
                };

                var publisher = new IdentityUser
                {
                    UserName = _publisher,
                    Email = "publisher@kingpim.se",
                    EmailConfirmed = true
                };

                var admin = await _userManager.CreateAsync(administrator, _password);
                var edit = await _userManager.CreateAsync(editor, _password2);
                var publish = await _userManager.CreateAsync(publisher, _password3);

                var identitySeed1 = admin.Succeeded;
                var identitySeed2 = edit.Succeeded;
                var identitySeed3 = publish.Succeeded;
            }
            return true;
        }
    }
}

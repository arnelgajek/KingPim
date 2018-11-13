using KingPim.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Allows the Administrator to add a new user and does the connection with FK for User and Roles to Db:
        [HttpPost]
        public async Task<IActionResult> Add(AccountViewModel vm)
        {
            var user = new IdentityUser
            {
                UserName = vm.UserName,
                Email = vm.UserName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, vm.Password);

            if (result.Succeeded)
            {
                var findByEmail = await _userManager.FindByEmailAsync(user.Email);

                await _userManager.AddToRoleAsync(findByEmail, vm.Roles);
            }
            return View(nameof(Index));
        }

        // If the user has forgotten his/hers password:
        [AllowAnonymous]
        public IActionResult SendEmail(AccountViewModel vm)
        {
            return View();
        }

        // Send the resetlink via mail to the users mail:


        // Sends the user back to the login page:
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

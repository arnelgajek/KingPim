using KingPim.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            // Checks if the user is authenticated and sends him/her to /Account:
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                return View();
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            // Checks if the username and password is correct:
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(vm.UserName);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, vm.Password, false, false)).Succeeded)
                    {
                        return RedirectToAction("Index", "Account");
                    }
                }
            }
            return View("Index", vm);
        }
         
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgottenPassword(LoginViewModel vm, string apiKey)
        {
            var user = await _userManager.FindByNameAsync(vm.UserName);
            var confCode = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action(
                controller: "Home",
                action: "ResetPassword",
                values: new { userId = user.Id, code = confCode },
                protocol: Request.Scheme);

            // The new SendGridClient with the API-key:
            var client = new SendGridClient(apiKey);


            // The message from SendGrid:
            var msg = new SendGridMessage
            {
                From = new EmailAddress("info@kingpim.se", "Password Reset")
            };

            // The reciever of the mail:
            msg.AddTo(vm.UserName);

            // The template id the email should use from SendGrid:
            msg.TemplateId = "8cfda5bc-a0a7-47da-9be7-b942c7a3669a";

            // Set the substitution tag values from SendGrid Template:
            msg.AddSubstitution("forgottenPasswordLink", callbackUrl);
            msg.AddSubstitution("userName", vm.UserName);

            // Send the email async and get the response from API:
            var response = client.SendEmailAsync(msg).Result;
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var usersName = user.UserName;
            var model = new LoginViewModel
            {
                UserName = usersName,
                Code = code
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(vm.UserName);
                var result = await _userManager.ResetPasswordAsync(user, vm.Code, vm.Password);
                var success = result.Succeeded; 
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }
    }
}

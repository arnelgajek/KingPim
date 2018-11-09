using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IHome homeRepo;

        public HomeController(IHome homeRepository)
        {
            homeRepo = homeRepository;
        }
        public IActionResult Index()
        {
            var cat = homeRepo.GetAll();
            return View(cat);
        }

        public IActionResult Get(int id)
        {
            return View(homeRepo.Get(id));
        }
    }
}

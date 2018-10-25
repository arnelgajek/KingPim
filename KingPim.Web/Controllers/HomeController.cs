using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Controllers
{
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

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Controllers
{
    public class HomeController : Controller
    {
        // TODO: Connect to database with private property and private cunstructor.

        public IActionResult Index()
        {
            // TODO: Where should this one be returned?
            return View();
        }

        // TODO: GetAll
        public IActionResult GetAll()
        {
            return View();
        }
    }
}

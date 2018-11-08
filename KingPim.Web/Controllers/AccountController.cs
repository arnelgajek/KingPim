using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Repositories.Interfaces;
using KingPim.Models.ViewModels;

namespace KingPim.Web.Controllers
{
    // TODO: Don't forget to add authorization!
    public class OneAttributeController : Controller
    {
        private IOneAttribute oneAttrRepo;

        public OneAttributeController(IOneAttribute oneAttrRepository)
        {
            oneAttrRepo = oneAttrRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var oneAttr = oneAttrRepo.GetAll();
            return View(oneAttr);
        }

        [HttpPost]
        public IActionResult Add(OneAttributeViewModel vm)
        {
            oneAttrRepo.Add(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return View(oneAttrRepo.Get(id));
        }

        [HttpPost]
        public IActionResult Update(OneAttributeViewModel vm)
        {
            oneAttrRepo.Update(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deletedOneAttr = oneAttrRepo.Delete(id);
            if (deletedOneAttr != null)
            {

            }
            else
            {

            }
            return RedirectToAction(nameof(Index));
        }
    }
}

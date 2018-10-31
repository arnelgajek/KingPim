using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Controllers
{
    // TODO: Don't forget to add authorization!
    public class AttributeGroupController : Controller
    {
        private IAttributeGroup attrGroupRepo;

        public AttributeGroupController(IAttributeGroup attrGroupRepository)
        {
            attrGroupRepo = attrGroupRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var attrGroup = attrGroupRepo.GetAll();
            return View(attrGroup);
        }

        [HttpPost]
        public IActionResult Add(AttributeGroupViewModel vm)
        {
            attrGroupRepo.Add(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return View(attrGroupRepo.Get(id));
        }

        [HttpPost]
        public IActionResult Update(AttributeGroupViewModel vm)
        {
            attrGroupRepo.Update(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleteAttrGroup = attrGroupRepo.Delete(id);
            if (deleteAttrGroup != null)
            {

            }
            else
            {

            }
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using KingPim.Repositories.Interfaces;
using KingPim.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class OneAttributeController : Controller
    {
        private IOneAttribute oneAttrRepo;
        private IAttributeGroup attGroupRepo;

        public OneAttributeController(IOneAttribute oneAttrRepository, IAttributeGroup attGroupRepository)
        {
            oneAttrRepo = oneAttrRepository;
            attGroupRepo = attGroupRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var oneAttrVm = new OneAttributeViewModel
            {
                OneAttributes = oneAttrRepo.GetAll(),
                AttributeGroups = attGroupRepo.GetAll()
            };
            return View(oneAttrVm);
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

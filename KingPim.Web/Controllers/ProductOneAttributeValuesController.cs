using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace KingPim.Web.Controllers
{
    public class ProductOneAttributeValuesController : Controller
    {
        private IProductOneAttributeValues prodOneAttrValRepo;

        public ProductOneAttributeValuesController(IProductOneAttributeValues prodOneAttrValRepository)
        {
            prodOneAttrValRepo = prodOneAttrValRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var prodAttrOneGroup = prodOneAttrValRepo.GetAll();
            return View(prodAttrOneGroup);
        }
    }
}

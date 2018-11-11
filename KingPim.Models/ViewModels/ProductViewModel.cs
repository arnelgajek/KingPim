using KingPim.Models.Models;
using System.Collections.Generic;

namespace KingPim.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public bool Published { get; set; }
        public int SubCategoryId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<SubCategory> SubCategories {get; set; }
    }
}

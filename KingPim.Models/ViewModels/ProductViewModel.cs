using KingPim.Models.Models;
using System.Collections.Generic;

namespace KingPim.Models.ViewModels
{
    public class ProductViewModel : ReadOnlyAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Value { get; set; }
        public int? SubCategoryId { get; set; }
        public int? AttributeGroupId { get; set; }
        public int? ProductsAttributeValueId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set; }
        public IEnumerable<AttributeGroup> AttributeGroups { get; set; }
        public IEnumerable<SubCategoryAttributeGroup> SubCategoryAttributeGroups {get; set;}
        public IEnumerable<ProductOneAttributeValue> ProductAttributeValues { get; set; }
    }
}

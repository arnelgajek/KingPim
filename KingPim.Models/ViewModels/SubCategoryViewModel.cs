using KingPim.Models.Models;
using System.Collections.Generic;

namespace KingPim.Models.ViewModels
{
    public class SubCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int AttributeGroupId {get; set;}
        //public int SubCategoryAttributeGroupsId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set; }
        public IEnumerable<AttributeGroup> AttributeGroups { get; set; }
        //public IEnumerable<SubCategoryAttributeGroup> SubCategoryAttributeGroups { get; set; }
    }
}

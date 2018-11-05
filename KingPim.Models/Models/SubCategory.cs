using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPim.Models.Models
{
    public class SubCategory : ReadOnlyAttribute
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1)]
        public string Name { get; set; }
        public virtual Category Category { get; }
        [Column(Order = 2)]
        public int? CategoryId { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<SubCategoryAttributeGroup> SubCategoryAttributeGroups { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.Models
{
    public class SubCategory : ReadOnlyAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Category Category { get; }
        public int CategoryId { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<AttributeGroup> AttributeGroups { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.Models
{
    public class Product : ReadOnlyAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public int SubCategoryId { get; set; }
    }
}

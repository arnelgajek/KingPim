using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.Models
{
    public class ProductCatalog
    {
        public int Id { get; set; }
        public virtual Category Category { get; set; }
    }
}

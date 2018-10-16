using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}

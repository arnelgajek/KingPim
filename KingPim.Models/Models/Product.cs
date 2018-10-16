using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int AttributeGroupId { get; set; } 
        public virtual AttributeGroup AttributeGroup { get; set; }
    }
}

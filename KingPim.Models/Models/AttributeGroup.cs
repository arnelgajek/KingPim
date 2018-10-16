using KingPim.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.Models
{
    public class AttributeGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductAttributeId { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}

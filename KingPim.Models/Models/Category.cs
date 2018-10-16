using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.Models
{
    public class Category
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}

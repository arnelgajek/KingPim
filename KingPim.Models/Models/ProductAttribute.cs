using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Data
{
    public class ProductAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public string Colour { get; set; }
        public decimal Price { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPim.Models.Models
{
    public class Product : ReadOnlyAttribute
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1)]
        public string Name { get; set; }
        [Column(Order = 2)]
        public string Description { get; set; }
        [Column(Order = 3)]
        public string Price { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        [Column(Order = 4)]
        public int? SubCategoryId { get; set; }
    }
}

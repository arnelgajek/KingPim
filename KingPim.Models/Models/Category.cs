using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPim.Models.Models
{
    public class Category : ReadOnlyAttribute
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1)]
        public string Name { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}

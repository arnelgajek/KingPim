using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Published { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}

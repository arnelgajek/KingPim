using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPim.Models.Models
{
    public class ReadOnlyAttribute
    {
        [Column(Order = 997)]
        public DateTime AddedDate { get; set; }
        [Column(Order = 998)]
        public DateTime UpdatedDate { get; set; }
        [Column(Order = 999)]
        public bool Published { get; set; }

        //public double Version { get; set; }
        //public virtual IdentityUser IdentityUser { get; set; }
        //public int IdentityUserId { get; set; }
    }
}

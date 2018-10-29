using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPim.Models.Models
{
    public class ProductOneAttributeValue
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1)]
        public string Value { get; set; }
        [Column(Order = 2)]
        public virtual OneAttribute OneAttribute { get; set; }
        [Column(Order = 3)]
        public int? OneAttributeId { get; set; }
        public virtual Product Product { get; set; }
        [Column(Order = 4)]
        public int? ProductId { get; set; }
    }
}

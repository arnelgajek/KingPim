﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPim.Models.Models
{
    public class OneAttribute
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1)]
        public string Name { get; set; }
        [Column(Order = 2)]
        public string Description { get; set; }
        [Column(Order = 3)]
        public string Type { get; set; }
        [Column(Order = 4)]
        public virtual AttributeGroup AttributeGroup { get; set; }
        [Column(Order = 5)]
        public int? AttributeGroupId { get; set; }
    }
}

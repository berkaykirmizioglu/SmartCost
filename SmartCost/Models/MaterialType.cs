using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SmartCost.Models
{
    public class MaterialType
    {
        public int Id { get; set; }
        [DisplayName("Malzeme Tipi:")]
        public string Name { get; set; }
    }
}
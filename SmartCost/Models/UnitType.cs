using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SmartCost.Models
{
    public class UnitType
    {
        public int Id { get; set; }

        [DisplayName("Birim Tipi:")]
        public string Name { get; set; }
    }
}
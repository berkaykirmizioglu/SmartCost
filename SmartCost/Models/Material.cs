using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SmartCost.Models
{
    public class Material
    {
        public int Id { get; set; }

        [DisplayName("Ürün Kodu:")]
        public string ProductCode { get; set; }

        [DisplayName("Malzeme Tipi:")]
        public MaterialType MaterialType { get; set; }
        [DisplayName("Malzeme Tipi:")]
        public int MaterialTypeId { get; set; }

        [DisplayName("Birim:")]
        public UnitType UnitType { get; set; }

        [DisplayName("Birim:")]
        public int UnitTypeId { get; set; }

        [DisplayName("Genişlik (mm):")]
        public int? Width { get; set; }

        [DisplayName("Uzunluk (mm):")]
        public int? Height { get; set; }

        [DisplayName("Kalınlık (mm):")]
        public int? Thickness { get; set; }

        [DisplayName("Birim Fiyatı (₺):")]
        public double PriceOfUnit { get; set; }

        [DisplayName("Açıklama:")]
        public string Description { get; set; }

        [DisplayName("Notlar:")]
        public string Notes { get; set; }
    }
}
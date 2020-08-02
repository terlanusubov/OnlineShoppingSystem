using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GagiStoreSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Specifications { get; set; }
        public string Barcode { get; set; }
        public string Link { get; set; }
        public decimal BuyAmounWithTurk { get; set; }
        public decimal BuyAmount { get; set; }
        public decimal SaleAmount { get; set; }
        public decimal CostAmount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

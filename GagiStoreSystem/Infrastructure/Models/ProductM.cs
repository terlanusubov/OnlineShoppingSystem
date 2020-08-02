using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GagiStoreSystem.Infrastructure.Models
{
    public class ProductM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        public string Specifications { get; set; }
        [Required]
        public string Barcode { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public decimal BuyAmount { get; set; }
        [Required]
        public decimal BuyAmountWithTurk { get; set; }
        [Required]
        public decimal SaleAmount { get; set; }
        [Required]
        public decimal CostAmount { get; set; }
    }
}

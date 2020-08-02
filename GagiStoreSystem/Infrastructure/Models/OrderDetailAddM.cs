using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GagiStoreSystem.Infrastructure.Models
{
    public class OrderDetailAddM
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public decimal Count { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public string Note { get; set; }
    }
}

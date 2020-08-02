using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GagiStoreSystem.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public int OrderDetailStatusId { get; set; }
        //public decimal TurkeyKargo { get; set; }
        //public decimal BakuKargo { get; set; }
        public string Note { get; set; }
    }
}

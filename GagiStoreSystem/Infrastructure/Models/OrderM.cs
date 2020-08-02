using GagiStoreSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GagiStoreSystem.Infrastructure.Models
{
    public class OrderM
    {
        [Required]
        public int PacketId { get; set; }
        [Required]
        public string ReceiverName { get; set; }
        [Required]
        public string ReceiverSurname { get; set; }
        [Required]
        public string Instagram { get; set; }
        [Required]
        public string Phone { get; set; }
        public DateTime OrderDate { get; set; }
        //public decimal TotalAmount { get; set; }
        //public decimal Discount { get; set; }
        //public DateTime BuyDate { get; set; }
        //public int OrderStatusId { get; set; }
        //public decimal TurkeyKargo { get; set; }
        //public decimal BakuKargo { get; set; }
        public string Note { get; set; }

        //public virtual ICollection<Cost> Costs { get; set; }
    }
}

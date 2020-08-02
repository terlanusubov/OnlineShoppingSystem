using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GagiStoreSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public virtual Packet Packet { get; set; }
        public int PacketId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverSurname { get; set; }
        public string Instagram { get; set; }
        public string Phone { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? BuyDate { get; set; }
        public int OrderStatusId { get; set; }
        public decimal TurkeyKargo { get; set; }
        public decimal BakuKargo { get; set; }
        public string Note { get; set; }

        public virtual  ICollection<Cost> Costs { get; set; }
        public virtual  ICollection<OrderDetails> OrderDetails { get; set; }
    }
}

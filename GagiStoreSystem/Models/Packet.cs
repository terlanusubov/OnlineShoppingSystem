using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GagiStoreSystem.Models
{
    public class Packet
    {
        public int Id { get; set; }
        public string TrackingNumber { get; set; }
        public string Link { get; set; }
        public int ProductCount { get; set; }
        public int PacketStatusId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

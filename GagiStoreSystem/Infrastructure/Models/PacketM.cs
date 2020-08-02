using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GagiStoreSystem.Infrastructure.Models
{
    public class PacketM
    {
        [Required]
        public string TrackingNumber { get; set; }
        [Required]
        public string TrackingLink { get; set; }
    }
}

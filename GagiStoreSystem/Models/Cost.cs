using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GagiStoreSystem.Models
{
    public class Cost
    {
        public int Id { get; set; }
        public decimal CostAmount { get; set; }
        public string Description { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
    }
}

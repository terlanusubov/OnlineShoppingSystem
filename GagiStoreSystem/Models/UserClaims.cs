using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GagiStoreSystem.Models
{
    public class UserClaims
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Claims Claims { get; set; }
        public int ClaimsId { get; set; }

    }
}

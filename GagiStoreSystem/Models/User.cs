using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GagiStoreSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Photo { get; set; }
        public virtual ICollection<UserClaims> Claims { get; set; }
    }
}

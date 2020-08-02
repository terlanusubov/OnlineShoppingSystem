using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GagiStoreSystem.Infrastructure.Models
{
    public class LoginM
    {
        [Required(ErrorMessage ="İstifadəçi adı mütləqdir.")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage ="Şifrə mütləqdir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

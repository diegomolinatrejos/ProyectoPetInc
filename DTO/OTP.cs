using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OTP : BaseClass
    {
        public int idUsuario { get; set; }
        public string secretPassword { get; set; }
    }
}

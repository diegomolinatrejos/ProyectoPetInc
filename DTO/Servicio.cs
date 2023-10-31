using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Servicio : BaseClass
    {
        public string nombreServicio { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
    }
}

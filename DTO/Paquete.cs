using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Paquete : BaseClass
    {
        public string nombrePaquete { get; set; }
        public decimal subtotal { get; set; }
        public decimal precioTotal { get; set; }
        public Estado estado { get; set; }
    }
}

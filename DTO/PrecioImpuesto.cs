using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class PrecioImpuesto : BaseClass
    {
        public decimal precioBase { get; set; }
        public decimal descuentoPaquete { get; set; }
        public decimal impuesto { get; set; }
    }
}

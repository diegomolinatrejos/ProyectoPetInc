using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Paquete : BaseClass
    {
        public string NombrePaquete { get; set; }
        public List<Servicio> servicios { get; set; }
        public decimal Subtotal { get; set; }
        public PrecioImpuesto Descuento { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}

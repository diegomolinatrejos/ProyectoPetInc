using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PaquetesServicios: BaseClass
    {
        public Paquete paquete {  get; set; }
        public Servicio servicio { get; set; }
    }
}

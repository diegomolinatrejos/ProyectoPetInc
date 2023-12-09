using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;

namespace DTO
{
    public class ReservaServicios: BaseClass
    {
        public Reserva reserva {  get; set; }
        public Servicio servicio { get; set; }  

    }
}

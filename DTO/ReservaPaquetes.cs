using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;

namespace DTO
{
    public class ReservaPaquetes: BaseClass
    {
        public Reserva reserva {  get; set; }  
        public Paquete paquete { get; set; }

    }
}

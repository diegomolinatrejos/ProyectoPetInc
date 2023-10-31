using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Pago : BaseClass
    {
        public Reserva reserva { get; set; }
        public decimal total { get; set; }
        public Vale referenciaVale { get; set; }

        //public Paypal referenciaPaypal { get; set; }
        public bool fuePagado { get; set; }
    }
}

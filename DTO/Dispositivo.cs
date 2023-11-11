using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Dispositivo : BaseClass
    {
        public string numeroSerie { get; set; }
        public int disponibilidad { get; set; }
    }
}

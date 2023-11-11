using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class DatosDispositivo : BaseClass

    {
        public Dispositivo idDispositivo {  get; set; }
        public string temperatura {  get; set; }
        public string humedadRelativa { get; set; }
        public string fecha {  get; set; }

    }
}

using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Mascota : BaseClass
    {
        public Cliente cliente { get; set; }
        public string nombreMascota { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string raza { get; set; }
        public int agresividad { get; set; }
        public string foto1 { get; set; }
        public string foto2 { get; set; }
        public int estado { get; set; }

        //public static implicit operator Mascota(Mascota v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

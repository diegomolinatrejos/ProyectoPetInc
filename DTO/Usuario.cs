using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Usuario : BaseClass
    {
        public string email { get; set; }
        public string contrasena { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string documentoIdentidad { get; set; }
        public string telefono { get; set; }
        public string direccionMapa { get; set; }
        public string foto { get; set; }
        public Rol rol { get; set; }
        public int idRol {  get; set; }
        public Estado estadoInfo {  get; set; }
        public string otp {  get; set; }
    }
}

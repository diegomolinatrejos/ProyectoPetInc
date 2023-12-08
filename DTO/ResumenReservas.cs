using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class ResumenReservas
    {
        public int Id { get; set; }
        public string FechaEntrada { get; set; }
        public string FechaSalida { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public int IdMascota { get; set; }
        public string NombreMascota { get; set; }
        public string Especie { get; set; }
        public int IdDispositivo { get; set; }
        public decimal Total { get; set; }
        public string NombreEstado { get; set; }
    }
}

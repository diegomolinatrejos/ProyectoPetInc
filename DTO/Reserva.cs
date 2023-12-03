using DTO.Models;

namespace DTO.Models
{
    public class Reserva : BaseClass
    {
        public DateTime fechaEntrada { get; set; }
        public DateTime fechaSalida { get; set; }
        public Usuario cliente { get; set; }
        public Mascota mascota { get; set; }
        public Dispositivo dispositivo { get; set; }
        public string comentario { get; set; }
        public decimal total { get; set; }
        public int confirmada { get; set; }
        public Estado estadoReserva { get; set; }
        public decimal precioBase { get; set; }
        public decimal impuesto { get; set; }
    }
}
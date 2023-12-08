using App_Logic.Admins;
using DTO.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {

        [HttpGet]
        public List<ResumenReservas> GetResumenReservas()
        {
            List<ResumenReservas> dataReserva = new List<ResumenReservas>
    {
        new ResumenReservas
        {
            Id = 1,
            FechaEntrada = "2023-01-01",
            FechaSalida = "2023-01-10",
            IdUsuario = 101,
            Nombre = "Cliente1",
            IdMascota = 201,
            NombreMascota = "Mascota1",
            Especie = "Perro",
            IdDispositivo = 301,
            Total = 150,
            NombreEstado = "Confirmada"
        },

        new ResumenReservas
        {
            Id = 2,
            FechaEntrada = "2023-01-05",
            FechaSalida = "2023-01-15",
            IdUsuario = 102,
            Nombre = "Cliente2",
            IdMascota = 202,
            NombreMascota = "Mascota2",
            Especie = "Gato",
            IdDispositivo = 302,
            Total = 120,
            NombreEstado = "Pendiente"
        },

        new ResumenReservas
        {
            Id = 3,
            FechaEntrada = "2023-02-10",
            FechaSalida = "2023-02-20",
            IdUsuario = 103,
            Nombre = "Cliente3",
            IdMascota = 203,
            NombreMascota = "Mascota3",
            Especie = "AVE",
            IdDispositivo = 303,
            Total = 300,
            NombreEstado = "Confirmada"
        },

        // ... Repite el patrón para las demás reservas
        new ResumenReservas
        {
            Id = 4,
            FechaEntrada = "2023-04-10",
            FechaSalida = "2023-04-20",
            IdUsuario = 104,
            Nombre = "Cliente4",
            IdMascota = 204,
            NombreMascota = "Mascota4",
            Especie = "Conejo",
            IdDispositivo = 304,
            Total = 180,
            NombreEstado = "Pendiente"
        },

        new ResumenReservas
        {
            Id = 5,
            FechaEntrada = "2023-04-10",
            FechaSalida = "2023-04-20",
            IdUsuario = 105,
            Nombre = "Cliente4",
            IdMascota = 205,
            NombreMascota = "Mascota4",
            Especie = "Perro",
            IdDispositivo = 305,
            Total = 180,
            NombreEstado = "Pendiente"
        },
    };
            Console.WriteLine(dataReserva);
            return dataReserva;
        }


        [HttpGet]
        public List<Reserva> GetReserva()
        {
            AdminReservas adminReservas = new AdminReservas();

            return adminReservas.GetAllReservas();
        }


        [HttpPost]
        public string CreateReserva(Reserva reserva)
        {
            AdminReservas adminReserva = new AdminReservas();

            adminReserva.CreateReserva(reserva);

            return "OK";

        }

        [HttpGet]
        public Reserva GetReservaPorId(int id)
        {
            AdminReservas adminReserva = new AdminReservas();
            return adminReserva.GetReservaById(id);

        }

        [HttpPut]
        public string UpdateReserva(Reserva reserva)
        {
            AdminReservas adminReserva = new AdminReservas();
            adminReserva.UpdateReserva(reserva);
            return "Reserva Actualizada";
        }
    }
}

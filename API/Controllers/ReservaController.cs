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

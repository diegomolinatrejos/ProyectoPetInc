using App_Logic.Admins;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservaPaquetesController : ControllerBase
    {
        [HttpGet]
        public List<ReservaPaquetes> GetAllReservaPaquetes()
        {
            AdminReservaPaquetes adminRp = new AdminReservaPaquetes();
            return adminRp.GetAllReservaPaquetes();
        }
        [HttpPost]
        public string CreateReservaPaquete(ReservaPaquetes paq)
        {
            AdminReservaPaquetes adminRp = new AdminReservaPaquetes();
            adminRp.CreateReservaPaquete(paq);
            return "Paquete asociado a la reserva";
        }

        [HttpGet]
        public List<ReservaPaquetes> GetPaquetePorIdReserva(int id)
        {
            AdminReservaPaquetes adminRp = new AdminReservaPaquetes();
            return adminRp.GetPaquetesByIdReserva(id);
        }

        [HttpDelete]
        public string EliminarPaqueteDeReserva(int id)
        {
            AdminReservaPaquetes adminRp = new AdminReservaPaquetes();
            adminRp.DeletePaqueteDeReserva(id);
            return "Paquete eliminado de Reserva";
        }
    }
}

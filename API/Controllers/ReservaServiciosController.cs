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
    public class ReservaServiciosController : ControllerBase
    {
        [HttpGet]
        public List<ReservaServicios> GetAllReservaServicios()
        {
            AdminReservaServicios adminRs = new AdminReservaServicios();
            return adminRs.GetAllReservaServicios();
        }
        [HttpPost]
        public string CreateReservaServicio(ReservaServicios paq)
        {
            AdminReservaServicios adminRs = new AdminReservaServicios();
            adminRs.CreateReservaServicio(paq);
            return "Servicio asociado a la reserva";
        }

        [HttpGet]
        public List<ReservaServicios> GetServicioPorIdReserva(int id)
        {
            AdminReservaServicios adminRs = new AdminReservaServicios();
            return adminRs.GetServiciosByIdReserva(id);
        }

        [HttpDelete]
        public string EliminarServicioDeReserva(int id)
        {
            AdminReservaServicios adminRs = new AdminReservaServicios();
            adminRs.DeleteServicioDeReserva(id);
            return "Servicio eliminado de Reserva";
        }

    }
}

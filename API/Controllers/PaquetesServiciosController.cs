using App_Logic.Admins;
using DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using App_Logic.Admins;
using DTO.Models;
using DTO;

namespace API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaquetesServiciosController : ControllerBase
    {
        [HttpGet]
        public List<PaquetesServicios> GetPaquetes()
        {
            AdminPaquetesServicios adminPs = new AdminPaquetesServicios();
            return adminPs.GetAllPaquetesServicios();

        }

        [HttpPost]
        public string CreatePaqueteServicio(PaquetesServicios paq)
        {
            AdminPaquetesServicios adminPs = new AdminPaquetesServicios();
            adminPs.CreatePaquetesServicio(paq);
            return "Paquete Servicio Creado";
        }

        [HttpGet]
        public List<PaquetesServicios> GetServiciosPorIdPaquete(int id)
        {
            AdminPaquetesServicios adminPs = new AdminPaquetesServicios();
            return adminPs.GetServiciosByIdPaquete(id);
        }

        [HttpPut]
        public string EliminarServicioDePaquete(int id)
        {
            AdminPaquetesServicios adminPs = new AdminPaquetesServicios();
            adminPs.DeleteServicioDePaquete(id);
            return "Servicio";
        }
    }
}

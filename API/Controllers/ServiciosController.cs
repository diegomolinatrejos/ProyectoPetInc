using DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App_Logic.Admins;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;

namespace API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private AdminServicios adminServicios;


        public ServiciosController()
        {
            adminServicios = new AdminServicios();
        }

        [HttpGet]
        public List<Servicio> GetServicios()
        {
            return adminServicios.GetAllServicios();
        }

        [HttpPost]
        public string CreateServicio(Servicio servicio)
        {
            adminServicios.CreateServicio(servicio);
            return "OK";
        }

        [HttpGet]
        public Servicio GetServicioPorId(int id)
        {
            return adminServicios.GetServicioById(id);
        }

        [HttpPut]
        public string DeactivateServicio(int id)
        {
            adminServicios.DeactivateServicioById(id);
            return "Servicio desactivado";
        }

        [HttpPut]
        public string UpdateServicio(Servicio servicio)
        {
            adminServicios.UpdateServicio(servicio);
            return "Servicio actualizado";
        }
    }
}

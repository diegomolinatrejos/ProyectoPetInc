using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using App_Logic.Admins;
using DTO.Models;

namespace API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaqueteController : ControllerBase
    {

        [HttpGet]
        public List<Paquete> GetPaquetes()
        {
            AdminPaquetes adminPaquetes = new AdminPaquetes();  
            return adminPaquetes.GetAllPaquetes();

        }

        [HttpPost]
        public string CreatePaquete (Paquete paq)
        {
            AdminPaquetes adminPaquetes = new AdminPaquetes();
            adminPaquetes.CreatePaquete(paq);
                return "Paquete Creado";
        }

        [HttpGet]
        public Paquete GetPaquetePorId(int id) 
        {
            AdminPaquetes adminPaquetes = new AdminPaquetes();
            return adminPaquetes.GetPaqueteById(id);
        }

        [HttpPut]
        public string UpdatePaquete (Paquete paquete)
        {
            AdminPaquetes adminPaquetes = new AdminPaquetes();
            adminPaquetes.UpdatePaquete(paquete);
            return "Paquete actualizado";

        }

        [HttpPut]
        public string DesactivarPaquete (int paquete)
        {
            AdminPaquetes adminPaquetes = new AdminPaquetes();
            adminPaquetes.DeletePaqueteById(paquete);
            return "Estado de paquete cambiado";       
        }

    }
}

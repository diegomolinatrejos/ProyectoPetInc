using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App_Logic.Admins;
using DTO.Models;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class DispositivoController : ControllerBase
    {
        [HttpGet]
        public List<Dispositivo> GetDispositivos()
        {
            AdminDispositivo adminDispositivo = new AdminDispositivo();
            return adminDispositivo.GetAllDispositivos();
        }


        [HttpPost]
        public string CreateDispositivo(Dispositivo dispositivo)
        {
            AdminDispositivo adminDispositivo = new AdminDispositivo();
            adminDispositivo.CreateDispositivo(dispositivo);
            return "Dispositivo Creado";

        }

        [HttpGet]
        public Dispositivo GetDispositivoPorId(int id)
        {
            AdminDispositivo adminDispositivo = new AdminDispositivo();
            return adminDispositivo.GetDispositivoById(id);

        }

        [HttpPut]
        public string UpdateDispositivo(Dispositivo dispositivo)
        {
            AdminDispositivo adminDispositivo = new AdminDispositivo();
            adminDispositivo.UpdateDispositivo(dispositivo);
            return "Dispositivo Actualizada";
        }
    }
}

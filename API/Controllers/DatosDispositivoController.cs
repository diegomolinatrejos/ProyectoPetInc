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

    public class DatosDispositivoController : ControllerBase
    {
        [HttpGet]
        public List<DatosDispositivo> GetDatosDispositivo()
        {
            AdminDatosDispositivo adminDatosDisp = new AdminDatosDispositivo();

            return adminDatosDisp.GetAllDatosDispositivo();
        }


        [HttpPost]
        public string CreateDatosDispositivo(DatosDispositivo admin)
        {
            AdminDatosDispositivo adminDatosDispositivo = new AdminDatosDispositivo();

            adminDatosDispositivo.CreateDatosDispositivo(admin);

            return "OK";

        }

        [HttpGet]
        public List<DatosDispositivo> GetDatosDispositivoById(int idDispositivo)
        {
            AdminDatosDispositivo adminDatosDispositivo = new AdminDatosDispositivo();
            return adminDatosDispositivo.GetDatosDispositivoById(idDispositivo);
           
        }

    }
}

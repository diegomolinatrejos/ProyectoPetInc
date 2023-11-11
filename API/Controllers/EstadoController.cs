using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO.Models;
using App_Logic.Admins;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        [HttpGet]
        public List<Estado> GetEstados()
        {
            AdminEstado adminEstado = new AdminEstado();

            return adminEstado.GetAllEstados();
        }

        [HttpGet]

        public Estado GetEstadoById(int id)
        {
            AdminEstado adminEstado = new AdminEstado();

            return adminEstado.GetEstadoById(id);
        }

        [HttpPost]
        public string CreateEstado(Estado estado)
        {
            AdminEstado adminEstado = new AdminEstado();

            adminEstado.CreateEstado(estado);

            return "Ok";
        }
    }
}

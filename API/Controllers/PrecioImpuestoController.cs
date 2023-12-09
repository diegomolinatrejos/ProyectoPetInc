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
    public class PrecioImpuestoController : ControllerBase
    {
        [HttpGet]
        public List<PrecioImpuesto> GetPrecioImpuesto()
        {
           AdminPrecioImpuesto precioImpuesto = new AdminPrecioImpuesto();
            return precioImpuesto.GetPrecioImpuesto();
        }

        [HttpPut]
        public string UpdatePrecioImpuesto(PrecioImpuesto pi)
        {
            AdminPrecioImpuesto adminprecioImpuesto = new AdminPrecioImpuesto();
            adminprecioImpuesto.UpdatePrecioImpuesto(pi);
            return "PrecioImpuesto Actualizado";
        }
    }
}

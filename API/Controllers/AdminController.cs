using DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App_Logic;
using Microsoft.AspNetCore.Cors;
using App_Logic.Admins;

namespace API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        [HttpGet]
        public List<Usuario> GetUsuarios()
        {
            AdminUsuarios adminUsuarios = new AdminUsuarios();

            return adminUsuarios.GetAllUsuarios();
        }


        [HttpPost]
        public string CreateUsuario(Usuario admin)
        {
            AdminUsuarios adminUsuarios = new AdminUsuarios();

            adminUsuarios.CreateUsuario(admin);

            return "OK";

        }

    }
}

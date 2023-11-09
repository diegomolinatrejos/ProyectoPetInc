using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO.Models;
using App_Logic.Admins;

namespace API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        [HttpGet]
        public List<Rol> GetRoles()
        {
            AdminRol adminRol = new AdminRol();

            return adminRol.GetAllRoles();
        }

        [HttpGet]

        public Rol GetRolById(int id)
        {
            AdminRol adminRol = new AdminRol();

            return adminRol.GetRolById(id);
        }

        [HttpPost]
        public string CreateRol(Rol rol)
        {
            AdminRol adminRol = new AdminRol();

            adminRol.CreateRol(rol);

            return "Ok";
        }

    }
}

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

        [HttpGet]
        public Usuario GetUsuarioPorId (int id)
        {
            AdminUsuarios adminUsuario = new AdminUsuarios();
            return adminUsuario.GetUsuarioById(id);
            
        }
        [HttpGet]
        public List <Usuario> GetUsuarioPorFrase(string searchPhrase)
        {
            AdminUsuarios adminUsuario = new AdminUsuarios();

            return adminUsuario.GetUsuarioByPhrase (searchPhrase);

        }

        [HttpPost]
        [Route("AuthenticateUser")]
        public IActionResult AuthenticateUser(Usuario user)
        {
            AdminUsuarios adminUsuarios = new AdminUsuarios();
            var userAutenticado = adminUsuarios.AuthenticateUser(user.email, user.contrasena);

            if (userAutenticado != null)
            {
                return Ok(userAutenticado);
            }

            return NotFound();
        }
    }
}

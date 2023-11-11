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
        public IActionResult AuthenticateUser(Usuario user)
        {
            AdminUsuarios adminUsuarios = new AdminUsuarios();

            var authenticatedUser = adminUsuarios.AuthenticateUser (user.email, user.contrasena);

            if (authenticatedUser == null)
            {
                return Unauthorized(); // O cualquier otro código o mensaje de error que desees.
            }

            // Puedes devolver información adicional si es necesario
            return Ok(new { email = authenticatedUser.email, rol = authenticatedUser.rol.nombreRol, nombre = authenticatedUser.nombre });
        }
    }
}

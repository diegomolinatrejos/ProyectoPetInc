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
            try
            {
                AdminUsuarios adminUsuarios = new AdminUsuarios();

                adminUsuarios.CreateUsuario(admin);
            }
            catch (Exception ex)
            {
                var x = ex.ToString();
            }

            return "Success";

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

        [HttpPut]
        public string SetPassword(int usuarioId, string newPassword)
        {
            AdminUsuarios adminUsuarios = new AdminUsuarios();
            adminUsuarios.SetPassword(usuarioId, newPassword);
            return "Usuario Actualizado";
        }

        [HttpPut]
        public string UpdateUsuario(Usuario usuario)
        {
            AdminUsuarios adminUsuarios = new AdminUsuarios();
            adminUsuarios.UpdateUsuario(usuario);
            return "Usuario Actualizado";
        }

        [HttpDelete]
        public string DeleteUsuario(string email)
        {
            AdminUsuarios adminUsuarios = new AdminUsuarios();
            adminUsuarios.DeleteUsuarioByEmail(email);
            return "Usuario eliminado";
        }

        [HttpPost]
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

		[HttpPut]
		public IActionResult AssignRolToUsuario(int usuarioId, int rolId)
		{
			try
			{
				AdminUsuarios adminUsuarios = new AdminUsuarios();
				var usuario = adminUsuarios.GetUsuarioById(usuarioId);

				if (usuario != null)
				{
					AdminRol adminRol = new AdminRol();
					var rol = adminRol.GetRolById(rolId);

					if (rol != null)
					{
						usuario.idRol = rol.Id;
						usuario.rol = rol; 

						adminUsuarios.SetRol(usuarioId, rolId);

						return Ok("Rol asignado correctamente al usuario.");
					}
					else
					{
						return NotFound("Rol no encontrado.");
					}
				}
				else
				{
					return NotFound("Usuario no encontrado.");
				}
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}

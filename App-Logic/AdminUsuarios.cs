using DataAccess.Crud;
using DTO.Models;


namespace App_Logic.Admins
{
    public class AdminUsuarios
    {
        public AdminOTP _adminOTP;
        public AdminEmail _adminEmail;
        public AdminUsuarios()
        {
            _adminOTP = new AdminOTP();
            _adminEmail = new AdminEmail();
        }
        public List<Usuario> GetAllUsuarios()
        {
            UsuarioCrud usuarioCrud = new UsuarioCrud();

            return usuarioCrud.RetrieveAll<Usuario>();
        }

        public void CreateUsuario(Usuario usuario)
        {
            usuario.otp = _adminOTP.CreateOTP();
            UsuarioCrud usuarioCrud = new UsuarioCrud();
			usuarioCrud.Create(usuario);
            _ = _adminEmail.SendOTPEmail(usuario.email, usuario.otp);

        }

        public void RecuperarContrasena(Usuario usuario)
        {
            usuario.otp = _adminOTP.CreateOTP();
            _ = _adminEmail.SendOTPEmail(usuario.email, usuario.otp);

        }

        public void SetPassword(int usuarioId, string newPassword)
        {
            UsuarioCrud usuarioCrud = new UsuarioCrud();
            Usuario usuario = usuarioCrud.RetrieveById<Usuario>(usuarioId);

            if (usuario != null)
            {
                // Aquí podrías aplicar lógica adicional, como verificar la complejidad de la contraseña, etc.
                usuario.contrasena = newPassword;

                // Actualizar la contraseña en la base de datos
                usuarioCrud.UpdatePassword(usuario);
                
            }
            
        }

		public void SetRol(int usuarioId, int rolId)
		{
			UsuarioCrud usuarioCrud = new UsuarioCrud();
            Usuario usuario = usuarioCrud.RetrieveById<Usuario>(usuarioId);

            if (usuario != null) 
            {
                usuario.rol.Id = rolId;
                usuarioCrud.UpdateRol(usuario);

			}
		}

		public Usuario GetUsuarioById(int Id)
        {
            UsuarioCrud uCrud = new UsuarioCrud();

            return uCrud.RetrieveById<Usuario>(Id);

        }
        public List<Usuario> GetUsuarioByPhrase(string searchPhrase)
        {
            UsuarioCrud uCrud = new UsuarioCrud();
            return uCrud.RetrieveBySearchPhrase<Usuario>(searchPhrase);
        }

        public void DeleteUsuarioByEmail(string email)
        {
            UsuarioCrud uCrud = new UsuarioCrud();
            uCrud.Delete(new Usuario { email = email });
        }

        public void UpdateUsuario(Usuario usuario)
        {
            UsuarioCrud uCrud = new UsuarioCrud();
            uCrud.Update(usuario);
        }

        


        public Usuario AuthenticateUser(string email, string password)
        {
            UsuarioCrud uCrud = new UsuarioCrud();
            return uCrud.UsuarioAutenticado(email, password);
        }

    }
}

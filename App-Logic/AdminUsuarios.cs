using DataAccess.Crud;
using DTO.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Logic.Admins
{
    public class AdminUsuarios
    {
        public List<Usuario> GetAllUsuarios() 
        {
            UsuarioCrud usuarioCrud = new UsuarioCrud();

            return usuarioCrud.RetrieveAll<Usuario>();
        }

        public void CreateUsuario(Usuario usuario)
        { 
            UsuarioCrud usuarioCrud = new UsuarioCrud();
            usuarioCrud.Create(usuario);
        }

        public Usuario GetUsuarioById(int Id)
        {
            UsuarioCrud uCrud = new UsuarioCrud();

            return uCrud.RetrieveById<Usuario>(Id);

        }
        public List<Usuario> GetUsuarioByPhrase(string searchPhrase)
        {
            UsuarioCrud uCrud = new UsuarioCrud();
            return uCrud.RetrieveBySearchPhrase <Usuario>(searchPhrase);
        }

        public static Usuario AuthenticateUser(string email, string password)
        {
            UsuarioCrud uCrud = new UsuarioCrud();
            return uCrud.UsuarioAutenticado(email, password);
        }

    }
}

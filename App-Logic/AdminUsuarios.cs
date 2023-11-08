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
            /*
             * 1- Recibir un articulo con los datos base
             * 2 - Conectar al API de Regulación y obtener datos para el articulo (ISBN, ISSN, otros...)
             *          2.1 Explorar el API,para verificar la estructura de datos que devuelve
             *          2.2 Modelar esa estructura en nuestra aplicacion (DTO)
             *          2.3 hacer el llamado y mapear los valores a nuestro DTO
             * 3 - Asignar esos datos en mi objeto de articulo (el que recibí por parametro)
             * 4 - Enviar a la BD para que se guarde el articulo completo. 
             */

            AdminRegulation adminReg = new AdminRegulation();

            UsuarioRegulationInfo info = adminReg.GetUsuarioGeneratedInfo();

            var id = info.id;

            //3
            

            //4
            //Se crea primero el author en caso de que aún no exista en DB no dé problema al referenciar
            // por el ID en la tabla Article
            UsuarioCrud usuarioCrud = new UsuarioCrud();
            

            usuarioCrud.Create(usuario);
        }
    }
}

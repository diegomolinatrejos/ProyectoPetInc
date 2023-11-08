using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DataAccess.Crud;

namespace App_Logic.Admins
{
    public class AdminRol
    {
        public List<Rol> GetAllRoles()
        {
            RolCrud rCrud = new RolCrud();

            return rCrud.RetrieveAll<Rol>();
        }

        public void CreateRol(Rol rol)
        {
            RolCrud rCrud = new RolCrud();
            rCrud.Create(rol);

        }

        public Rol GetRolById (int id)
        {
            RolCrud rolCrud = new RolCrud();
            return rolCrud.RetrieveById<Rol>(id);
        }
    }
}

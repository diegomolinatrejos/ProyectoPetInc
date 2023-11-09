using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DataAccess.Crud;

namespace App_Logic.Admins
{
    public class AdminEstado
    {
        public List<Estado> GetAllEstados()
                {
            EstadoCrud eCrud = new EstadoCrud();

            return eCrud.RetrieveAll<Estado>();
        }

        public void CreateEstado(Estado estado)
        {
            EstadoCrud eCrud = new EstadoCrud();
            eCrud.Create(estado);
        }

        public Estado GetEstadoById(int Id)
        {
            EstadoCrud eCrud = new EstadoCrud();

            return eCrud.RetrieveById<Estado>(Id);

        }

    }
}

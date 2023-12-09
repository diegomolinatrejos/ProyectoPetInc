using DataAccess.Crud;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Logic.Admins
{
    public class AdminReservaServicios
    {
        public List<ReservaServicios> GetAllReservaServicios()
        {
            ReservaServiciosCrud rsCrud = new ReservaServiciosCrud();
            return rsCrud.RetrieveAll<ReservaServicios>();
        }

        public void CreateReservaServicio(ReservaServicios reservaServicios)
        {
            ReservaServiciosCrud rsCrud = new ReservaServiciosCrud();
            rsCrud.Create(reservaServicios);
        }

        public List<ReservaServicios> GetServiciosByIdReserva(int idReserva)
        {
            ReservaServiciosCrud rsCrud = new ReservaServiciosCrud();
            return rsCrud.RetrieveAllServiciosByIdReserva(idReserva);
        }

        public void DeleteServicioDeReserva(int id)
        {
            ReservaServiciosCrud rsCrud = new ReservaServiciosCrud();
            rsCrud.Delete(new ReservaServicios { Id = id });
        }
    }
}

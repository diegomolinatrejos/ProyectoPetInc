using DataAccess.Crud;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Logic.Admins
{
    public class AdminReservaPaquetes
    {
        public List<ReservaPaquetes> GetAllReservaPaquetes()
        {
            ReservaPaquetesCrud rpCrud = new ReservaPaquetesCrud();
            return rpCrud.RetrieveAll<ReservaPaquetes>();
        }

        public void CreateReservaPaquete(ReservaPaquetes ReservaPaquetes)
        {
            ReservaPaquetesCrud rpCrud = new ReservaPaquetesCrud();
            rpCrud.Create(ReservaPaquetes);
        }

        public List<ReservaPaquetes> GetPaquetesByIdReserva(int idReserva)
        {
            ReservaPaquetesCrud rpCrud = new ReservaPaquetesCrud();
            return rpCrud.RetrieveAllPaquetesByIdReserva(idReserva);
        }

        public void DeletePaqueteDeReserva(int id)
        {
            ReservaPaquetesCrud rpCrud = new ReservaPaquetesCrud();
            rpCrud.Delete(new ReservaPaquetes { Id = id });
        }
    }
}

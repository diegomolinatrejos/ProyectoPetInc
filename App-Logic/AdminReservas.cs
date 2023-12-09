using DataAccess.Crud;
using DTO.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Logic.Admins
{
    public class AdminReservas
    {

        public List<Reserva> GetAllReservas()
        {
            ReservaCrud rCrud = new ReservaCrud();
            return rCrud.RetrieveAll<Reserva>();
        }
        public void CreateReserva(Reserva reserva)
        {
            ReservaCrud rCrud = new ReservaCrud();
            rCrud.Create(reserva);
        }
        public Reserva GetReservaById(int Id)
        {
            ReservaCrud rCrud = new ReservaCrud();
            return rCrud.RetrieveById<Reserva>(Id);

        }
        public void UpdateReserva(Reserva reserva)
        {
            ReservaCrud rCrud = new ReservaCrud();
            rCrud.Update(reserva);
        }

        public void DeleteReservaById(int Id)
        {
            ReservaCrud rCrud = new ReservaCrud();
            rCrud.Delete(new Reserva { Id = Id });
        }
        public Reserva GetLastReserva()
        {
            ReservaCrud rCrud = new ReservaCrud();
            return rCrud.RetrieveLastReserva <Reserva>();

        }
    }
}

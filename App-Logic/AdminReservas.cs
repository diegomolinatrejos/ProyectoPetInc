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

            return rCrud.RetrieveAll<Reserva>();  // aqui se obtiene objeto grande lista de Reservas puede ser Json o un Objeto reserva tal cual esta en mapper 

            // hay que cambiar la logica en en caso que tal vez no sea ncesario Parse Json
            // trabajarlo para simplificarlo y enviar a la UI Json o un objeto , ustedes me dice que seria con la siguiente forma DTO resumenReservas

            //static string ObtenerResumenReservas(string json)
            //{
            //    var jsonObject = JArray.Parse(json);

            //    var resumenReservas = jsonObject.Select(reserva => new ReservaDTO
            //    {
            //        Id = reserva["id"].Value<int>(),
            //        FechaEntrada = DateTime.Parse(reserva["fechaEntrada"].Value<string>()).ToString("yyyy-MM-dd"),
            //        FechaSalida = DateTime.Parse(reserva["fechaSalida"].Value<string>()).ToString("yyyy-MM-dd"),
            //        IdUsuario = reserva["cliente"]["id"].Value<int>(),
            //        Nombre = reserva["cliente"]["nombre"].Value<string>(),
            //        IdMascota = reserva["mascota"]["id"].Value<int>(),
            //        NombreMascota = reserva["mascota"]["nombreMascota"].Value<string>(),
            //        Especie = reserva["mascota"]["especie"].Value<string>(),
            //        IdDispositivo = reserva["dispositivo"]["id"].Value<int>(),
            //        Total = reserva["total"].Value<decimal>(),
            //        NombreEstado = reserva["estadoReserva"]["nombreEstado"].Value<string>()
            //    }).ToList();

            //    return JsonConvert.SerializeObject(resumenReservas, Formatting.Indented);
            //}
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
        public void DeleteReservaByEmail(string email)
        {
            
        }

    }
}

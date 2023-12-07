using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using DTO.Models;

namespace App_Logic.Admins
{
    public class AdminDispositivo
    {
        public List<Dispositivo> GetAllDispositivos()
        {
            DispositivoCrud dCrud = new DispositivoCrud();
            return dCrud.RetrieveAll<Dispositivo>();
        }

        public void CreateDispositivo(Dispositivo dispositivo)
        {
            DispositivoCrud dCrud = new DispositivoCrud();
            dCrud.Create(dispositivo);
        }

        public Dispositivo GetDispositivoById(int Id)
        {
            DispositivoCrud dCrud = new DispositivoCrud();
            return dCrud.RetrieveById<Dispositivo>(Id);
        }

        public void UpdateDispositivo(Dispositivo dispositivo)
        {
            DispositivoCrud dCrud = new DispositivoCrud();
            dCrud.Update(dispositivo);
        }

    }
}

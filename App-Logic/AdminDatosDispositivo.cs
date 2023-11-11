using DataAccess.Crud;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Logic.Admins
{
    public class AdminDatosDispositivo
    {
        public List<DatosDispositivo> GetAllDatosDispositivo()
        {
            DatosDispositivoCrud ddCrud = new DatosDispositivoCrud();

            return ddCrud.RetrieveAll <DatosDispositivo>();
        }

        public void CreateDatosDispositivo(DatosDispositivo datosDispositivo)
        {
            DatosDispositivoCrud ddCrud = new DatosDispositivoCrud();
            ddCrud.Create(datosDispositivo);
        }
    }
}

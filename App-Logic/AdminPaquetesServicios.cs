using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using DTO;
using DTO.Models;

namespace App_Logic.Admins
{
    public class AdminPaquetesServicios
    {
        public List<PaquetesServicios> GetAllPaquetesServicios()
        {
            PaquetesServiciosCrud psCrud = new PaquetesServiciosCrud();
            return psCrud.RetrieveAll<PaquetesServicios>();
        }

        public void CreatePaquetesServicio(PaquetesServicios serviciopaquete)
        {
            PaquetesServiciosCrud psCrud = new PaquetesServiciosCrud();
            psCrud.Create(serviciopaquete);
        }

        public List<PaquetesServicios> GetServiciosByIdPaquete(int idDispositivo)
        {
            PaquetesServiciosCrud psCrud = new PaquetesServiciosCrud();
            return psCrud.RetrieveAllServiciosByIdPaquete (idDispositivo);
        }

        public void DeleteServicioDePaquete(int id)
        {
            PaqueteCrud uCrud = new PaqueteCrud();
            uCrud.Delete(new PaquetesServicios { Id = id });
        }
    }
}

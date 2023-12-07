using DataAccess.Crud;
using DTO.Models;
using System.Collections.Generic;

namespace App_Logic.Admins
{
    public class AdminServicios
    {
        private ServiciosCrud servicioCrud;

        // Constructor
        public AdminServicios()
        {
            servicioCrud = new ServiciosCrud();
        }

        public List<Servicio> GetAllServicios()
        {
            return servicioCrud.RetrieveAll<Servicio>();
        }

        public void CreateServicio(Servicio servicio)
        {
            servicioCrud.Create(servicio);
        }

        public Servicio GetServicioById(int id)
        {
            return servicioCrud.RetrieveById<Servicio>(id);
        }

        public void DeactivateServicioById(int id)
        {
            servicioCrud.DeactivateServicioById(id);
        }

        public void UpdateServicio(Servicio servicio)
        {
            servicioCrud.Update(servicio);
        }
    }
}

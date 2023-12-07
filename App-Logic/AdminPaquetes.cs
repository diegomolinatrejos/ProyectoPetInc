using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using DTO.Models;

namespace App_Logic.Admins
{
    public class AdminPaquetes
    {
        public List<Paquete> GetAllPaquetes()
        {
            PaqueteCrud paqueteCrud = new PaqueteCrud();
            return paqueteCrud.RetrieveAll<Paquete>();
        }

        public void CreatePaquete(Paquete paquete)
        {
            PaqueteCrud paqueteCrud = new PaqueteCrud();
            paqueteCrud.Create(paquete);
        }

        public Paquete GetPaqueteById(int Id)
        {
            PaqueteCrud paqueteCrud = new PaqueteCrud();
            return paqueteCrud.RetrieveById<Paquete>(Id);
        }

        public void UpdatePaquete(Paquete paquete)
        {
            PaqueteCrud paqueteCrud = new PaqueteCrud();
            paqueteCrud.Update(paquete);
        }

        public void DeletePaqueteByName(string nombre)
        {
            PaqueteCrud uCrud = new PaqueteCrud();
            uCrud.Delete(new Paquete { nombrePaquete = nombre });
        }
    }
}

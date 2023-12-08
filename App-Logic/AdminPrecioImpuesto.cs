using DataAccess.Crud;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App_Logic.Admins
{
    public class AdminPrecioImpuesto
    {
        public List<PrecioImpuesto> GetPrecioImpuesto()
        {
            PrecioImpuestoCrud piCrud = new PrecioImpuestoCrud();
            return piCrud.RetrieveAll<PrecioImpuesto>();
        }

        public void UpdatePrecioImpuesto(PrecioImpuesto precioImpuesto)
        {
            PrecioImpuestoCrud piCrud = new PrecioImpuestoCrud();
            piCrud.Update(precioImpuesto);
        }
    }
}

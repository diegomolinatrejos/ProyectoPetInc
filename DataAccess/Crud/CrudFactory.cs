using DataAccess.Dao;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public abstract class CrudFactory
    {
        protected SqlDao dao;

        public abstract void Create(BaseClass entityDTO);
        public abstract void Update(BaseClass entityDTO);
        public abstract void Delete(BaseClass entityDTO);
        public abstract List<T> RetrieveAll<T>();
        public abstract T RetrieveById<T>(int id);

        //Generics  <T>
    }
}

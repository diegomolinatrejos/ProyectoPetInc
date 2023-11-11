using DataAccess.Dao;
using DataAccess.Mapper;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class RolCrud : CrudFactory
    {
        private RolMapper rolMapper;
        //constructor 
        public RolCrud() : base()
        {
            rolMapper= new RolMapper(); 
            dao= SqlDao.GetInstance();  
        }

        public override void Create(BaseClass entityDTO)
        {
            SqlOperation operation = rolMapper.GetCreateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }

        public override void Delete(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            List<T> lstResults = new List<T>();
            SqlOperation operation = rolMapper.RetrieveAllStatement();
            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = rolMapper.BuildObjects(dataResults);

                foreach (var obj in dtoObjects)
                {
                    lstResults.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            return lstResults;
        }

        public override T RetrieveById<T>(int id)
        {
            var dataResults = dao.ExecuteStoredProcedureWithQuery(rolMapper.RetrieveByIdStatement(id));

            var objArt = rolMapper.BuildObject(dataResults[0]);

            return (T)Convert.ChangeType(objArt, typeof(T));
        }

        public override void Update(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper;
using DTO;
using DTO.Models;

namespace DataAccess.Crud
{
    public class PaqueteCrud : CrudFactory
    {
        private PaqueteMapper paqueteMapper;

        public PaqueteCrud(): base()
        {
            paqueteMapper = new PaqueteMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseClass entityDTO)
        {
            SqlOperation operation = paqueteMapper.GetCreateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }

        public override void Delete(BaseClass entityDTO)
        {
            Paquete paquete = (Paquete)entityDTO;
            SqlOperation operation = paqueteMapper.GetDeleteStatement(paquete);
            dao.ExecuteStoredProcedure(operation);
        }

        public override List<T> RetrieveAll<T>()
        {
            List<T> lstResults = new List<T>();
            SqlOperation operation = paqueteMapper.RetrieveAllStatement();

            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = paqueteMapper.BuildObjects(dataResults);

                foreach (var ob in dtoObjects)
                {
                    lstResults.Add((T)Convert.ChangeType(ob, typeof(T)));
                }
            }
            return lstResults;
        }

        public override T RetrieveByEmail<T>(string email)
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(int id)
        {
            var dataResults = dao.ExecuteStoredProcedureWithQuery(paqueteMapper.RetrieveByIdStatement(id));

            var objArt = paqueteMapper.BuildObject(dataResults[0]);

            return (T)Convert.ChangeType(objArt, typeof(T));
        }

        public override void Update(BaseClass entityDTO)
        {
            Paquete paquete = (Paquete)entityDTO;

            SqlOperation operation = paqueteMapper.GetUpdateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }
    }
}

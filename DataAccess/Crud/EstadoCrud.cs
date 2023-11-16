using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Mapper;
using DataAccess.Dao;

namespace DataAccess.Crud
{
    public class EstadoCrud : CrudFactory
    {
        private EstadoMapper estadoMapper;

        //constructor
        public EstadoCrud(): base()
        {
            estadoMapper = new EstadoMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass entityDTO)
        {
            SqlOperation operation = estadoMapper.GetCreateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }

        public override void Delete(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            List<T> lstResults = new List<T>();
            SqlOperation operation = estadoMapper.RetrieveAllStatement();
            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = estadoMapper.BuildObjects(dataResults);

                foreach (var obj in dtoObjects)
                {
                    lstResults.Add((T)Convert.ChangeType(obj, typeof(T)));
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
            var dataResults = dao.ExecuteStoredProcedureWithQuery(estadoMapper.RetrieveByIdStatement(id));

            var objArt = estadoMapper.BuildObject(dataResults[0]);

            return (T)Convert.ChangeType(objArt, typeof(T));
        }

        public override void Update(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}

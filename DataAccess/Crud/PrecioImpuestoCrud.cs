using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper;
using DTO.Models;

namespace DataAccess.Crud
{
    public class PrecioImpuestoCrud : CrudFactory
    {
        private PrecioImpuestoMapper piMapper;

        public PrecioImpuestoCrud() : base()
        {
            piMapper = new PrecioImpuestoMapper();
            dao=SqlDao.GetInstance();
        }

        public override void Create(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            List<T> lstResults = new List<T>();
            SqlOperation operation = piMapper.RetrieveAllStatement();

            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = piMapper.BuildObjects(dataResults);

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
            throw new NotImplementedException();
        }

        public override void Update(BaseClass entityDTO)
        {
            SqlOperation operation = piMapper.GetUpdateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }
    }
}

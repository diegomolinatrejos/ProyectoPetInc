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
    public class ReservaServiciosCrud : CrudFactory
    {
        private ReservaServiciosMapper rsMapper;

        public ReservaServiciosCrud(): base()
        {
            rsMapper = new ReservaServiciosMapper();
            dao= SqlDao.GetInstance();

        }
        public override void Create(BaseClass entityDTO)
        {
            SqlOperation operation = rsMapper.GetCreateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }

        public override void Delete(BaseClass entityDTO)
        {
            ReservaServicios servicioPaquete = (ReservaServicios)entityDTO;
            SqlOperation operation = rsMapper.GetDeleteStatement(servicioPaquete);
            dao.ExecuteStoredProcedure(operation);
        }

        public override List<T> RetrieveAll<T>()
        {
            List<T> lstResults = new List<T>();
            SqlOperation operation = rsMapper.RetrieveAllStatement();

            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = rsMapper.BuildObjects(dataResults);

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
            throw new NotImplementedException();
        }

        public List<ReservaServicios> RetrieveAllServiciosByIdReserva(int idReserva)
        {
            List<ReservaServicios> lstResults = new List<ReservaServicios>();
            SqlOperation operation = rsMapper.RetrieveByIdStatement(idReserva);

            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = rsMapper.BuildObjects(dataResults);

                foreach (var ob in dtoObjects)
                {
                    lstResults.Add((ReservaServicios)ob);
                }
            }
            return lstResults;
        }
    }
}

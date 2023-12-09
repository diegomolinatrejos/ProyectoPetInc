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
    public class ReservaPaquetesCrud : CrudFactory

    {
        private ReservaPaquetesMapper rpMapper;

        public ReservaPaquetesCrud() : base()
        {
            rpMapper = new ReservaPaquetesMapper();
            dao=SqlDao.GetInstance();
        }

        public override void Create(BaseClass entityDTO)
        {
            SqlOperation operation = rpMapper.GetCreateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }

        public override void Delete(BaseClass entityDTO)
        {
            ReservaPaquetes reservaPaquete = (ReservaPaquetes)entityDTO;
            SqlOperation operation = rpMapper.GetDeleteStatement(reservaPaquete);
            dao.ExecuteStoredProcedure(operation);
        }

        public override List<T> RetrieveAll<T>()
        {
            List<T> lstResults = new List<T>();
            SqlOperation operation = rpMapper.RetrieveAllStatement();

            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = rpMapper.BuildObjects(dataResults);

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

        public List<ReservaPaquetes> RetrieveAllPaquetesByIdReserva(int idReserva)
        {
            List<ReservaPaquetes> lstResults = new List<ReservaPaquetes>();
            SqlOperation operation = rpMapper.RetrieveByIdStatement(idReserva);

            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = rpMapper.BuildObjects(dataResults);

                foreach (var ob in dtoObjects)
                {
                    lstResults.Add((ReservaPaquetes)ob);
                }
            }
            return lstResults;
        }
    }
}

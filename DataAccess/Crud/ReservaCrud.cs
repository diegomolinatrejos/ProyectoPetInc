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
    public class ReservaCrud : CrudFactory
    {
        private ReservaMapper reservaMapper;

        public ReservaCrud(): base()
        {
            reservaMapper = new ReservaMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseClass entityDTO)
        {
            SqlOperation operation = reservaMapper.GetCreateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }

        public override void Delete(BaseClass entityDTO)
        {
            Reserva reserva = (Reserva)entityDTO;
            SqlOperation operation = reservaMapper.GetDeleteStatement(reserva);
            dao.ExecuteStoredProcedure(operation);
        }

        public override List<T> RetrieveAll<T>()
        {
            List<T> lstResults = new List<T>();
            SqlOperation operation = reservaMapper.RetrieveAllStatement();

            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = reservaMapper.BuildObjects(dataResults);

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
            var dataResults = dao.ExecuteStoredProcedureWithQuery(reservaMapper.RetrieveByIdStatement(id));

            var objArt = reservaMapper.BuildObject(dataResults[0]);

            return (T)Convert.ChangeType(objArt, typeof(T));
        }

        public override void Update(BaseClass entityDTO)
        {
            Reserva reserva = (Reserva)entityDTO;

            SqlOperation operation = reservaMapper.GetUpdateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }

        public  T RetrieveLastReserva<T>()
        {
            SqlOperation operation = reservaMapper.RetrieveLastReserva();
            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            var objArt = reservaMapper.BuildObject(dataResults[0]);

            return (T)Convert.ChangeType(objArt, typeof(T));
        }
    }
}

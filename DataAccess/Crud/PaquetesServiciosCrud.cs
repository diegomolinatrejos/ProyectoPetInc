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
    public class PaquetesServiciosCrud : CrudFactory
    {
        private PaquetesServiciosMapper psMapper;

        public PaquetesServiciosCrud() : base()
        {
            psMapper = new PaquetesServiciosMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass entityDTO)
        {
            SqlOperation operation = psMapper.GetCreateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }

        public override void Delete(BaseClass entityDTO)
        {
            PaquetesServicios servicioPaquete = (PaquetesServicios)entityDTO;
            SqlOperation operation = psMapper.GetDeleteStatement(servicioPaquete);
            dao.ExecuteStoredProcedure(operation);
        }

        public override List<T> RetrieveAll<T>()
        {
            List<T> lstResults = new List<T>();
            SqlOperation operation = psMapper.RetrieveAllStatement();

            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = psMapper.BuildObjects(dataResults);

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

        public List<PaquetesServicios> RetrieveAllServiciosByIdPaquete(int idPaquete)
        {
            List<PaquetesServicios> lstResults = new List<PaquetesServicios>();
            SqlOperation operation = psMapper.RetrieveByIdStatement(idPaquete);

            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = psMapper.BuildObjects(dataResults);

                foreach (var ob in dtoObjects)
                {
                    lstResults.Add((PaquetesServicios)ob);
                }
            }
            return lstResults;
        }

    }
}

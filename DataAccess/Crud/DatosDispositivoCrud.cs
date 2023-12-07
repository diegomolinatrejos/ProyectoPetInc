using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DTO.Models;
using DataAccess.Mapper;
using System.Collections;

namespace DataAccess.Crud
{
    public class DatosDispositivoCrud : CrudFactory
    {
        private DatosDispositivoMapper datosDispMapper;

        public DatosDispositivoCrud (): base()
        {
            datosDispMapper = new DatosDispositivoMapper ();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass entityDTO)
        {
            SqlOperation operation = datosDispMapper.GetCreateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }

        public override void Delete(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            List<T> lstResults = new List<T>();
            SqlOperation operation = datosDispMapper.RetrieveAllStatement();

            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = datosDispMapper.BuildObjects(dataResults);

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

        public List<DatosDispositivo> RetrieveAllById(int idDispositivo)
        {
            List<DatosDispositivo> lstResults = new List<DatosDispositivo>();
            SqlOperation operation = datosDispMapper.RetrieveByIdStatement(idDispositivo);

            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = datosDispMapper.BuildObjects(dataResults);

                foreach (var ob in dtoObjects)
                {
                    lstResults.Add((DatosDispositivo)ob);
                }
            }
            return lstResults;
        }
    }
}

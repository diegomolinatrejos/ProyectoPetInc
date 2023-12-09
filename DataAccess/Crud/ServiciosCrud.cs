using DataAccess.Dao;
using DataAccess.Mapper;
using DTO.Models;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class ServiciosCrud : CrudFactory
    {
        private ServicioMapper servicioMapper;

        // Constructor
        public ServiciosCrud() : base()
        {
            servicioMapper = new ServicioMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass entityDTO)
        {
            SqlOperation operation = servicioMapper.GetCreateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }

        public override void Delete(BaseClass entityDTO)
        {
            // Since the deletion operation is not implemented in the provided schema, throw an exception
            throw new System.NotImplementedException("Deletion of servicios is not implemented.");
        }

        public override List<T> RetrieveAll<T>()
        {
            List<T> lstResults = new List<T>();
            SqlOperation operation = servicioMapper.RetrieveAllStatement();

            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = servicioMapper.BuildObjects(dataResults);

                foreach (var ob in dtoObjects)
                {
                    lstResults.Add((T)System.Convert.ChangeType(ob, typeof(T)));
                }
            }
            return lstResults;
        }

        public override T RetrieveById<T>(int id)
        {
            var dataResults = dao.ExecuteStoredProcedureWithQuery(servicioMapper.RetrieveByIdStatement(id));

            var objServicio = servicioMapper.BuildObject(dataResults[0]);

            return (T)System.Convert.ChangeType(objServicio, typeof(T));
        }

        public void DeactivateServicioById(int id)
        {
            SqlOperation operation = servicioMapper.GetDeactivateStatement(id);
            dao.ExecuteStoredProcedure(operation);
        }

        public override void Update(BaseClass entityDTO)
        {
            SqlOperation operation = servicioMapper.GetUpdateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }


        public override T RetrieveByEmail<T>(string email)
        {
            throw new NotImplementedException();
        }
    }



}
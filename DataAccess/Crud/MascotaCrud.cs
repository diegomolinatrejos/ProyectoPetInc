using DataAccess.Dao;
using DataAccess.Mapper;
using DTO.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class MascotaCrud : CrudFactory
    {
        private MascotaMapper mascotaMapper;

        // Constructor
        public MascotaCrud() : base()
        {
            mascotaMapper = new MascotaMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass entityDTO)
        {
            SqlOperation operation = mascotaMapper.GetCreateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }

        public override void Delete(BaseClass entityDTO)
        {
            Mascota mascota = (Mascota)entityDTO;
            SqlOperation operation = mascotaMapper.GetDeleteStatement(mascota);
            dao.ExecuteStoredProcedure(operation);
        }

        public override List<T> RetrieveAll<T>()
        {
            List<T> lstResults = new List<T>();
            SqlOperation operation = mascotaMapper.RetrieveAllStatement();

            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = mascotaMapper.BuildObjects(dataResults);

                foreach (var ob in dtoObjects)
                {
                    lstResults.Add((T)Convert.ChangeType(ob, typeof(T)));
                }
            }
            return lstResults;
        }

        public override T RetrieveById<T>(int id)
        {
            var dataResults = dao.ExecuteStoredProcedureWithQuery(mascotaMapper.RetrieveByIdStatement(id));

            var objMascota = mascotaMapper.BuildObject(dataResults[0]);

            return (T)Convert.ChangeType(objMascota, typeof(T));
        }

        public override void Update(BaseClass entityDTO)
        {
            Mascota mascota = (Mascota)entityDTO;

            SqlOperation operation = mascotaMapper.GetUpdateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }

        public List<T> RetrieveBySearchPhrase<T>(int idDuenno)
        {
            var lstResults = new List<T>();

            var dataResults = dao.ExecuteStoredProcedureWithQuery(mascotaMapper.GetRetrieveByPhraseStatement(idDuenno));

            if (dataResults.Count > 0)
            {
                var objMascotas = mascotaMapper.BuildObjects(dataResults);

                foreach (var mascota in objMascotas)
                {
                    lstResults.Add((T)Convert.ChangeType(mascota, typeof(T)));
                }
            }
            return lstResults;
        }

        public override T RetrieveByEmail<T>(string email)
        {
            throw new NotImplementedException();
        }
    }
}
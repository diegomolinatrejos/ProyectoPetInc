using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DTO.Models;

namespace DataAccess.Mapper
{
    public class DispositivoMapper : ICrudStatements, IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var dispositivo = new Dispositivo()
            {
                Id = int.Parse(objectRow["ID"].ToString()),
                numeroSerie = objectRow["NUMERO_SERIE"].ToString(),
                disponibilidad = int.Parse(objectRow["DISPONIBILIDAD"].ToString())
            };

            return dispositivo;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResult = new List<BaseClass>();

            foreach (var objRow in listRows)
            {
                var dispositivo = BuildObject(objRow);
                lstResult.Add(dispositivo);
            }
            return lstResult;
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_CREATE_DISPOSITIVO";

            Dispositivo dispositivo = (Dispositivo)entityDTO;

            //agregar los parametros al operation
            operation.AddVarcharParam("NUMERO_SERIE", dispositivo.numeroSerie);
            operation.AddIntegerParam("DISPONIBILIDAD", dispositivo.disponibilidad);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_UPDATE_DISPOSITIVO";

            Dispositivo dispositivo = (Dispositivo)entityDTO;

            operation.AddIntegerParam("ID", dispositivo.Id);
            operation.AddVarcharParam("NUMERO_SERIE", dispositivo.numeroSerie);
            operation.AddIntegerParam("DISPONIBILIDAD", dispositivo.disponibilidad);

            return operation;
        }

        public SqlOperation RetrieveAllStatement()
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_ALL_DISPOSITIVOS";

            return operation;
        }

        public SqlOperation RetrieveByIdStatement(int Id)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_DISPOSITIVO_BY_ID";

            operation.AddIntegerParam("DISPOSITIVO_ID", Id);

            return operation;
        }
    }
}

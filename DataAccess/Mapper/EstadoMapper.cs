using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DTO.Models;

namespace DataAccess.Mapper
{
    public class EstadoMapper : ICrudStatements, IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var estado = new Estado()
            {
                Id = int.Parse(objectRow["ID"].ToString()),
                nombreEstado = objectRow["NOMBRE_ESTADO"].ToString()
            };

            return estado;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResult = new List<BaseClass>();

            foreach (var objRow in listRows)
            {
                var estado = BuildObject(objRow);
                lstResult.Add(estado);
            }
            return lstResult;
        }


        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_CREATE_ESTADO";

            Estado estado = (Estado)entityDTO;
            //se agregan los parametros al operation
            operation.AddVarcharParam("NOMBRE_ESTADO", estado.nombreEstado );

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation RetrieveAllStatement()
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_GET_ALL_ESTADOS";

            return operation;
        }

        public SqlOperation RetrieveByIdStatement(int Id)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_ESTADO_BY_ID";

            operation.AddIntegerParam ("ID", Id);

            return operation;
        }
    }
}

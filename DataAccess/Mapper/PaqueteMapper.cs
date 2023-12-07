using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DTO.Models;

namespace DataAccess.Mapper
{
    public class PaqueteMapper : ICrudStatements, IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var paquete = new Paquete
            {
                Id = int.Parse(objectRow["ID"].ToString()),
                nombrePaquete = objectRow["NOMBRE_PAQUETE"].ToString(),
                subtotal= decimal.Parse(objectRow["SUBTOTAL"].ToString()),
                precioTotal= decimal.Parse(objectRow["PRECIO_TOTAL"].ToString())

            };
            var estado = new Estado()
            {
                Id = int.Parse(objectRow["ESTADO"].ToString()),
                nombreEstado = objectRow["NOMBRE_ESTADO"].ToString()
            };

           
            paquete.estado= estado;

            return paquete;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResult = new List<BaseClass>();

            foreach (var objRow in listRows)
            {
                var paquete = BuildObject(objRow);
                lstResult.Add(paquete);
            }
            return lstResult;
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_CREATE_PAQUETE";

            Paquete paquete = (Paquete)entityDTO;

            //agregar los parametros al operation
            operation.AddVarcharParam("NOMBRE_PAQUETE", paquete.nombrePaquete);
            operation.AddDecimalParam("SUBTOTAL", paquete.subtotal);
            operation.AddDecimalParam("PRECIO_TOTAL", paquete.precioTotal);
            operation.AddIntegerParam("ESTADO", paquete.estado.Id);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_DEACTIVATE_PAQUETE_BY_ID";

            Paquete paquete = (Paquete)entityDTO;

            operation.AddIntegerParam("PAQUETE_ID", paquete.Id);

            return operation;

        }

        public SqlOperation GetUpdateStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation RetrieveAllStatement()
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_ALL_PAQUETES";

            return operation;
        }
    

        public SqlOperation RetrieveByIdStatement(int Id)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_PAQUETE_BY_ID";

            operation.AddIntegerParam("PAQUETE_ID", Id);

            return operation;
        }
    }
}

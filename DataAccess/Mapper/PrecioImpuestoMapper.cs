using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DTO.Models;

namespace DataAccess.Mapper
{
    public class PrecioImpuestoMapper : ICrudStatements, IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var precioImpuesto = new PrecioImpuesto()
            {
                Id = int.Parse(objectRow["ID"].ToString()),
                precioBase = decimal.Parse(objectRow["PRECIO_BASE"].ToString()),
                descuentoPaquete = decimal.Parse(objectRow["DESCUENTO_PAQUETE"].ToString()),
                impuesto = decimal.Parse(objectRow["IMPUESTO"].ToString()),
            };

            return precioImpuesto;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResult = new List<BaseClass>();

            foreach (var objRow in listRows)
            {
                var precioImpuesto = BuildObject(objRow);
                lstResult.Add(precioImpuesto);
            }
            return lstResult;
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_UPDATE_PRECIOIMPUESTO";

            PrecioImpuesto precioImpuesto = (PrecioImpuesto)entityDTO;

            operation.AddIntegerParam("ID", precioImpuesto.Id);
            operation.AddDecimalParam("PRECIO_BASE", precioImpuesto.precioBase);
            operation.AddDecimalParam("DESCUENTO_PAQUETE", precioImpuesto.descuentoPaquete);
            operation.AddDecimalParam("IMPUESTO", precioImpuesto.impuesto);

            return operation;
        }

        public SqlOperation RetrieveAllStatement()
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_ALL_PRECIOIMPUESTO";

            return operation;
        }

        public SqlOperation RetrieveByIdStatement(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

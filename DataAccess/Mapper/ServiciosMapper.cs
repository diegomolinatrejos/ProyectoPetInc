using DataAccess.Dao;
using DTO.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class ServicioMapper : ICrudStatements, IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var servicio = new Servicio()
            {
                Id = int.Parse(objectRow["SERVICIO_ID"].ToString()),
                nombreServicio = objectRow["NOMBRE_SERVICIO"].ToString(),
                descripcion = objectRow["DESCRIPCION"].ToString(),
                precio = decimal.Parse(objectRow["PRECIO"].ToString()),
            };

            var estado = new Estado()
            {
                Id = int.Parse(objectRow["SERVICIO_ESTADO"].ToString()),
                nombreEstado = objectRow["SERVICIO_NOMBRE_ESTADO"].ToString()
            };

            servicio.estado = estado;


            return servicio;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResult = new List<BaseClass>();

            foreach (var objRow in listRows)
            {
                var servicio = BuildObject(objRow);
                lstResult.Add(servicio);
            }
            return lstResult;
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_CREATE_SERVICIO";

            Servicio servicio = (Servicio)entityDTO;

            operation.AddVarcharParam("NOMBRE_SERVICIO", servicio.nombreServicio);
            operation.AddVarcharParam("DESCRIPCION", servicio.descripcion);
            operation.AddDecimalParam("PRECIO", servicio.precio);
            operation.AddIntegerParam("ESTADO", servicio.estado.Id);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass entityDTO)
        {
            // No se implementa la eliminación de servicios según el esquema proporcionado
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_UPDATE_SERVICIO";

            Servicio servicio = (Servicio)entityDTO;

            operation.AddIntegerParam("SERVICIO_ID", servicio.Id);
            operation.AddVarcharParam("NOMBRE_SERVICIO", servicio.nombreServicio);
            operation.AddVarcharParam("DESCRIPCION", servicio.descripcion);
            operation.AddDecimalParam("PRECIO", servicio.precio);
            operation.AddIntegerParam("ESTADO", servicio.estado.Id);

            return operation;
        }

        public SqlOperation RetrieveAllStatement()
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_ALL_SERVICIOS";

            return operation;
        }

        public SqlOperation RetrieveByIdStatement(int Id)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_SERVICIO_BY_ID";

            operation.AddIntegerParam("servicio_id", Id);

            return operation;
        }

        public SqlOperation GetDeactivateStatement(int Id)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_DEACTIVATE_SERVICIO_BY_ID";
            operation.AddIntegerParam("servicio_id", Id);
            return operation;
        }
    }
}
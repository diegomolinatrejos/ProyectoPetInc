using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DTO;
using DTO.Models;

namespace DataAccess.Mapper
{
    public class PaquetesServiciosMapper : IObjectMapper, ICrudStatements
    {
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var paqueteServicio = new PaquetesServicios()
            {
                Id = int.Parse(objectRow["ID"].ToString())
            };
            
            var paquete = new Paquete
            {
                Id = int.Parse(objectRow["ID_PAQUETE"].ToString()),
                nombrePaquete = objectRow["NOMBRE_PAQUETE"].ToString(),
                subtotal = decimal.Parse(objectRow["SUBTOTAL"].ToString()),
                precioTotal = decimal.Parse(objectRow["PRECIO_TOTAL"].ToString())

            };
            var estadoPaquete = new Estado()
            {
                Id = int.Parse(objectRow["PAQUETE_ESTADO"].ToString()),
                nombreEstado = objectRow["NOMBRE_ESTADO"].ToString()
            };
            paquete.estado = estadoPaquete;

            var servicio = new Servicio()
            {
                Id = int.Parse(objectRow["SERVICIO_ID"].ToString()),
                nombreServicio = objectRow["NOMBRE_SERVICIO"].ToString(),
                descripcion = objectRow["DESCRIPCION"].ToString(),
                precio = decimal.Parse(objectRow["PRECIO"].ToString()),
            };

            var estadoServicio = new Estado()
            {
                Id = int.Parse(objectRow["SERVICIO_ESTADO"].ToString()),
                nombreEstado = objectRow["SERVICIO_NOMBRE_ESTADO"].ToString()
            };
            servicio.estado = estadoServicio;


            paqueteServicio.paquete = paquete;
            paqueteServicio.servicio = servicio;

            return paqueteServicio;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResult = new List<BaseClass>();

            foreach (var objRow in listRows)
            {
                var paqueteServicio = BuildObject(objRow);
                lstResult.Add(paqueteServicio);
            }
            return lstResult;
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_CREATE_PAQUETECONSERVICIO";

            PaquetesServicios paqueteservicio = (PaquetesServicios)entityDTO;

            operation.AddIntegerParam("ID_PAQUETE", paqueteservicio.paquete.Id);
            operation.AddIntegerParam("ID_SERVICIO", paqueteservicio.servicio.Id);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_DELETE_PAQUETESERVICIO_BY_ID";

            PaquetesServicios paquetesServicios = (PaquetesServicios)entityDTO;

            operation.AddIntegerParam("ID", paquetesServicios.Id); 

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation RetrieveAllStatement()
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_ALL_PAQUETES_SERVICIOS";

            return operation;
        }

        public SqlOperation RetrieveByIdStatement(int IdPaquete)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_SERVICIOS_POR_PAQUETE_ID";
            operation.AddIntegerParam("ID_PAQUETE", IdPaquete);

            return operation;
        }
    }
}

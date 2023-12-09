using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DTO.Models;

namespace DataAccess.Mapper
{
    public class DatosDispositivoMapper : IObjectMapper, ICrudStatements
    {
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var datosDispositivo = new DatosDispositivo()
            {
                Id = int.Parse(objectRow["ID"].ToString()),
                temperatura = objectRow["TEMPERATURA"].ToString(),
                humedadRelativa = objectRow["HUMEDAD_RELATIVA"].ToString(),
                fecha = objectRow["FECHA"].ToString()

            };

            var dispositivo = new Dispositivo()
            {
                Id = int.Parse(objectRow["DISPOSITIVO"].ToString()),
                numeroSerie= objectRow["NUMERO_SERIE"].ToString(),
                disponibilidad = int.Parse(objectRow["DISPONIBILIDAD"].ToString()),

            };

            datosDispositivo.idDispositivo = dispositivo;

            return datosDispositivo;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResult = new List<BaseClass>();

            foreach (var objRow in listRows)
            {
                var datosDisposistivo = BuildObject(objRow);
                lstResult.Add(datosDisposistivo);
            }
            return lstResult;
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_CREATE_DATOS_DISPOSITIVO";

            DatosDispositivo datosDisp = (DatosDispositivo)entityDTO;

            //agregar los parametros al operation
            operation.AddIntegerParam ("Id_Dispositivo", datosDisp.idDispositivo.Id);
            operation.AddVarcharParam("Temperatura",datosDisp.temperatura);
            operation.AddVarcharParam("Humedad_relativa", datosDisp.humedadRelativa);
            operation.AddVarcharParam("Fecha", datosDisp.fecha);

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

            operation.ProcedureName = "PR_GET_DATOS_DISPOSITIVO";

            return operation;
        }

        public SqlOperation RetrieveByIdStatement(int idDispositivo)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_DATOS_DISPOSITIVO_ID";
            operation.AddIntegerParam("ID_DISPOSITIVO", idDispositivo);

            return operation;
        }
    }
}

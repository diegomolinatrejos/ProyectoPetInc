using DataAccess.Dao;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class MascotasMapper : ICrudStatements, IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var mascota = new Mascota()
            {
                //cliente = row["Cliente"].ToString(),
                nombreMascota = row["nombreMascota"].ToString(),
                descripcion = row["descripcion"].ToString(),
                fechaNacimiento = DateTime.Parse(row["fechaNacimiento"].ToString()),
                raza = row["raza"].ToString(),
                agresividad = int.Parse(row["agresividad"].ToString()),
                foto1 = row["foto1"].ToString(),
                foto2 = row["foto2"].ToString(),
                estado = int.Parse(row["estado"].ToString()),
            };

            return mascota;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResult = new List<BaseClass>();

            foreach (var objRow in listRows)
            {
                var mascota = BuildObject(objRow);
                lstResult.Add(mascota);
            }
            return lstResult;
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_CREATE_MASCOTA";

            Mascota mas = (Mascota)entityDTO;

            //operation.AddVarcharParam("Cliente", mas.FirstName);
            operation.AddVarcharParam("descripcion", mas.descripcion);
            operation.AddDateTimeParam("fechaNacimiento", mas.fechaNacimiento);
            operation.AddVarcharParam("raza", mas.raza);
            operation.AddIntegerParam("agresividad", mas.agresividad);
            operation.AddVarcharParam("foto1", mas.foto1);
            operation.AddVarcharParam("foto2", mas.foto2);
            operation.AddIntegerParam("estado", mas.estado);

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
            throw new NotImplementedException();
        }

        public SqlOperation RetrieveByIdStatement(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

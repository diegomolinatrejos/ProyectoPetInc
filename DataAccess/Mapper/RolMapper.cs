using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DTO.Models;

namespace DataAccess.Mapper
{
    public class RolMapper : IObjectMapper, ICrudStatements

    {
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var rol = new Rol()
            {
                Id = int.Parse(objectRow["ID"].ToString()),
                nombreRol = objectRow["NOMBRE_ROL"].ToString()     
            };

            return rol;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResult = new List<BaseClass>();

            foreach (var objRow in listRows)
            {
                var rol = BuildObject(objRow);
                lstResult.Add(rol);
            }
            return lstResult;
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_CREATE_ROL";

            Rol rol = (Rol)entityDTO;
            //se agregan los parametros al operation
            //operation.AddIntegerParam("ID", rol.Id);
            operation.AddVarcharParam("NOMBRE_ROL", rol.nombreRol);

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
            operation.ProcedureName = "PR_GET_ALL_ROLES";

            return operation;
        }

        public SqlOperation RetrieveByIdStatement(int Id)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_ROL_BY_ID";

            operation.AddIntegerParam("RolID", Id);

            return operation;
        }
    }
}

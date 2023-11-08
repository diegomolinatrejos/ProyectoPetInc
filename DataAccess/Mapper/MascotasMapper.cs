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
            throw new NotImplementedException();
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_CREATE_MASCOTA";

            Mascota mas = (Mascota)entityDTO;

            operation.AddVarcharParam("Cliente", mas.FirstName);
            operation.AddVarcharParam("LastName", mas.LastName);
            operation.AddVarcharParam("Charge", mas.Charge);

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

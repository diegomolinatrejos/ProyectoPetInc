using DataAccess.Dao;
using DTO;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DataAccess.Mapper
{
    public class OTPMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var otp = new OTP()
            {
                Id = (int)objectRow["ID"],
                secretPassword = objectRow["SECRET_PASSWORD"].ToString()
            };
            return otp;
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "procedimiento almacenado";

            OTP otp = (OTP)entityDTO;

            //agregar los parametros al operation
            operation.AddIntegerParam("ID_USUARIO", otp.idUsuario);
            operation.AddVarcharParam("OTP", otp.secretPassword);



            return operation;
        }

        public SqlOperation GetRetrieveByEmailStatement(string email)
        {
            var operation = new SqlOperation();

            operation.ProcedureName = "procedimiento almacenado para obtener password por email";
            operation.AddVarcharParam("EMAIL", email);

            return operation;
        }
    }
}

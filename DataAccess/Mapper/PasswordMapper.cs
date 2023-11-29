using DataAccess.Dao;
using DTO;
using DTO.Models;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
	public class PasswordMapper : ICrudStatements, IObjectMapper
	{
		public BaseClass BuildObject(Dictionary<string, object> objectRow)
		{
			var password = new Password()
			{
				Id = (int)objectRow["ID"],
				newPassword = objectRow["NEW_PASSWORD"].ToString()
			};
			return password;
		}

		
		public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
		{
			var listResult = new List<BaseClass>();

			foreach (var row in listRows)
			{
				var newPassword = BuildObject(row);
				listResult.Add(newPassword);
			}

			return listResult;
		}

		public string EncryptPassword(string password)
		{
			var encrypt = MD5.Create();
			var hashedValue = encrypt.ComputeHash(Encoding.UTF8.GetBytes(password));
			return Convert.ToBase64String(hashedValue);
		}

		#region "Sql Statements"
		public SqlOperation GetCreateStatement(BaseClass entityDTO)
		{
			SqlOperation operation = new SqlOperation();
			operation.ProcedureName = "PR_CREATE_PASSWORD";

			Password password = (Password)entityDTO;

			//agregar los parametros al operation
			operation.AddIntegerParam("ID_USUARIO", password.idUsuario);
			operation.AddVarcharParam("CONTRASENA", password.newPassword);



			return operation;
		}

		public SqlOperation GetUpdateStatement(BaseClass entityDTO)
		{
			SqlOperation operation = new SqlOperation();
			operation.ProcedureName = "PR_UPDATE_CONTRASENA";
			Password password = (Password)entityDTO;


			operation.AddIntegerParam("ID_USUARIO", password.idUsuario);
			operation.AddVarcharParam("CONTRASENA", password.newPassword);

			return operation;
		}

		public SqlOperation GetRetrieveByEmailStatement(string email)
		{
			var operation = new SqlOperation();

			operation.ProcedureName = "PR_GET_CONTRASENA_BY_EMAIL";
			operation.AddVarcharParam("EMAIL", email);

			return operation;
		}

		public SqlOperation GetRetrieveByIdStatement(int id)
		{
			var operation = new SqlOperation();

			operation.ProcedureName = "PR_GET_CONTRASENIA_BY_ID";
			operation.AddIntegerParam("ID_USUARIO", id);

			return operation;
		}

		public SqlOperation GetDeleteStatement(BaseClass entityDTO)
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

		

		#endregion
	}
}

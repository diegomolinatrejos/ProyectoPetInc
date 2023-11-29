using DataAccess.Dao;
using DataAccess.Mapper;
using DTO;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
	public class PasswordCrud : CrudFactory
	{
		private PasswordMapper passwordMapper;

		public PasswordCrud() : base()
		{
			passwordMapper = new PasswordMapper();
			dao = SqlDao.GetInstance();
		}
		public override void Create(BaseClass entityDTO)
		{
			var password = (Password)entityDTO;
			var sqlPassword = passwordMapper.GetCreateStatement(password);
			dao.ExecuteStoredProcedure(sqlPassword);
		}

		public override void Delete(BaseClass entityDTO)
		{
			var password = (Password)entityDTO;
			var sqlPassword = passwordMapper.GetDeleteStatement(password);
			dao.ExecuteStoredProcedure(sqlPassword);
		}

		public override List<T> RetrieveAll<T>()
		{
			throw new NotImplementedException();
		}

		public override T RetrieveByEmail<T>(string email)
		{
			var sqlPassword = passwordMapper.GetRetrieveByEmailStatement(email);
			var results = dao.ExecuteStoredProcedureWithQuery(sqlPassword);

			var dic = new Dictionary<string, object>();

			if (results.Count > 0)
			{
				dic = results[0];
				var obj = passwordMapper.BuildObject(dic);
				return (T)Convert.ChangeType(obj, typeof(T));
			}

			return default(T);
		}

		public T RetrieveByUserId<T>(int id)
		{
			var sqlPassword = passwordMapper.RetrieveByIdStatement(id);
			var results = dao.ExecuteStoredProcedureWithQuery(sqlPassword);

			var dic = new Dictionary<string, object>();

			if (results.Count > 0)
			{
				dic = results[0];
				var obj = passwordMapper.BuildObject(dic);
				return (T)Convert.ChangeType(obj, typeof(T));
			}

			return default(T);
		}

		public override T RetrieveById<T>(int id)
		{
			throw new NotImplementedException();
		}

		public override void Update(BaseClass entityDTO)
		{
			var password = (Password)entityDTO;
			var sqlPassword = passwordMapper.GetUpdateStatement(password);
			dao.ExecuteStoredProcedure(sqlPassword);
		}
	}
}

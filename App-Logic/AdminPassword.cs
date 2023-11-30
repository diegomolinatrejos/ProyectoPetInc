using App_Logic.Admins;
using DataAccess.Crud;
using DTO.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace App_Logic
{
	public class AdminPassword
	{
		#region Properties
		public AdminUsuarios adminUsuarios;
		public AdminEmail adminEmail;
		#endregion

		#region Queries
		readonly string updateUserQuery = "UPDATE USUARIOS SET CONTRASENA = @CONTRASENA WHERE ID = @UserID";
		#endregion

		public AdminPassword()
		{
			adminUsuarios = new AdminUsuarios();
			adminEmail = new AdminEmail();
		}

		public async void CreatePassword(Password password)
		{
			PasswordCrud passwordCrud = new PasswordCrud();

			passwordCrud.Create(password);

		}
		public void Create(Password password)
		{
			var crudPassword = new PasswordCrud();

			crudPassword.Create(password);
		}

		public Password RetrieveByUserId(int id)
		{
			var crudPassword = new PasswordCrud();
			var existPassword = crudPassword.RetrieveByUserId<Password>(id);

			if (existPassword == null)
			{
				throw new Exception("La contraseña no existe");
			}

			return existPassword;
		}

		public Password RetrieveByEmail(string email)
		{
			var crudPassword = new PasswordCrud();
			var existPassword = crudPassword.RetrieveByEmail<Password>(email);

			if (existPassword == null)
			{
				throw new Exception("La contraseña no existe");
			}

			return existPassword;
		}


		public void Update(Password password)
		{
			var crudPassword = new PasswordCrud();
			var existPassword = crudPassword.RetrieveByUserId<Password>(password.idUsuario);

			if (existPassword == null)
			{
				throw new Exception("La contraseña no existe");
			}

			crudPassword.Update(password);
		}

		public void Delete(Password password)
		{
			var crudPassword = new PasswordCrud();
			var existPassword = crudPassword.RetrieveByUserId<Password>(password.idUsuario);

			if (existPassword == null)
			{
				throw new Exception("La contraseña no existe");
			}

			crudPassword.Delete(password);
		}

		public bool ValidatePassword(string email, string password)
		{
			var crudPassword = new PasswordCrud();
			var UserPasswordObj = crudPassword.RetrieveByEmail<Password>(email);

			if (UserPasswordObj == null)
			{
				return false;
			}

			password = Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));

			if (password == UserPasswordObj.newPassword)
			{
				return true;
			}

			return false;
		}

		public string GetEncryptedPassword(string password)
		{
			return Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));
		}


		

		private async void SavePasswordToDatabase(int id, string password)
		{
			await using (SqlConnection connection = new SqlConnection("Server=FRED\\SQLEXPRESS;Database=ProyectHotelPetInc;User ID=sa;Password=12345678"))
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand(updateUserQuery, connection))
				{
					command.Parameters.AddWithValue("@UserId", id);
					command.Parameters.AddWithValue("@CONTRASENA", password);

					command.ExecuteNonQuery();
				}
			}
		}
	}
}

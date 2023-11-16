using App_Logic.Admins;
using DTO;
using System.Data.SqlClient;

namespace App_Logic
{
    public class AdminOTP
    {
        #region Properties
        public AdminUsuarios adminUsuarios;
        public AdminEmail adminEmail;
        #endregion

        #region Queries
        readonly string updateuserquery = "UPDATE USUARIOS SET OTP = @OTP WHERE ID = @UserID";
        #endregion

        public AdminOTP()
        {
            adminUsuarios = new AdminUsuarios();
            adminEmail = new AdminEmail();
        }

        public async Task<string> CreateOTP(CreateOtpDto otp)
        {
            Random random = new Random();
            int secretPassword = random.Next(100000, 999999);

            var usuario = adminUsuarios.GetUsuarioById(otp.id);

            SaveOTPToDatabase(usuario.Id, secretPassword);

            await adminEmail.SendOTPEmail(usuario.email, secretPassword);

            return secretPassword.ToString();
        }

        private async void SaveOTPToDatabase(int id, int otp)
        {
            await using (SqlConnection connection = new SqlConnection("Server=FRED\\SQLEXPRESS;Database=ProyectHotelPetInc;User ID=sa;Password=12345678"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(updateuserquery, connection))
                {
                    command.Parameters.AddWithValue("@UserId", id);
                    command.Parameters.AddWithValue("@OTP", otp);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

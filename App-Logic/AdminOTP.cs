using DataAccess.Crud;
using DTO;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace App_Logic
{
    public class AdminOTP
    {
        public List<OTP> GetAllOTP()
        {
            OTPCrud otpCrud = new OTPCrud();

            return otpCrud.RetrieveAll<OTP>();
        }
        public string CreateOTP(OTP otp)
        {
            Random random = new Random();
            int secretPassword = random.Next(100000, 999999);
            return secretPassword.ToString();
        }

        public void SaveOTPToDatabase(string email, string otp)
        {
            using (SqlConnection connection = new SqlConnection("Server=FRED\\SQLEXPRESS;Database=ProyectHotelPetInc;User ID=sa;Password=12345678"))
            {
                connection.Open();

                string query = "UPDATE USUARIOS SET OTP = @OTP WHERE EMAIL = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", email);
                    command.Parameters.AddWithValue("@OTP", otp);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

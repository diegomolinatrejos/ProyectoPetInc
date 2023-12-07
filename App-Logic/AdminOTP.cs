using App_Logic.Admins;
using DTO;
using System.Data.SqlClient;

namespace App_Logic
{
    public class AdminOTP
    {

        public string CreateOTP()
        {
            Random random = new Random();
            int secretPassword = random.Next(100000, 999999);

            return secretPassword.ToString();
        }

        
    }
}

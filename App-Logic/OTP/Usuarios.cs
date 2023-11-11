using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TwoFactor.Clases;

namespace App_Logic.OTP
{
    public class Usuarios
    {
        public Usuarios()
        {
            AccesoDatos.cadenaConexion = @"Data Source=W11-EPV\SQLSERVER;Initial Catalog=EPV;Integrated Security=true;";
        }

        public void SetSecret(string email, string code)
        {
            AccesoDatos.ExecuteQuery($"UPDATE dbo.Usuarios SET TwoFactorSecret='{code}' WHERE email='{email}'");
        }

        public string GetSecret(string email)
        {
            DataTable dt = AccesoDatos.GetTmpDataTable($"SELECT TwoFactorSecret FROM dbo.Usuarios WHERE email='{email}'");
            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0]["TwoFactorSecret"].ToString();
            }
            else
            {
                return "";
            }
        }
    }
}

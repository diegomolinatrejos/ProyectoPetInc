using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Dao
{
    /*
     * Esta clase va a ser la que esté a cargo de hacer la conexión a BD, ejecutar procedimientos y devolver los 
     * resultados de datos en caso de que sea necesario
     */
    public class SqlDao
    {
        private static SqlDao instance = new SqlDao();
        //private string _connectionString = "Server=FRED\\SQLEXPRESS;Database=ProyectHotelPetInc;User ID=sa;Password=12345678";
        //private string _connectionString = "Server=DESKTOP-B5PR9G2;Database=ProyectHotelPetInc;Trusted_Connection=True";
        private string _connectionString = "Server=DESKTOP-B5PR9G2;Database=ProyectHotelPetInc;Trusted_Connection=True";
        //private string _connectionString = "Server=tcp:isa-ieee-dbserver.database.windows.net,1433;Initial Catalog=isa-ieee-db;Persist Security Info=False;User ID=Cenfo_DB;Password=Psw123456*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        //public string _connectionString = "Data Source=DECHEVERRIA;Initial Catalog=ProyectHotelPetInc;User ID=daniel;Password=Daniel123.;"; //String de coneccion local Daniel
        //Patrón de diseño Singleton
        public static SqlDao GetInstance() 
        {
            if (instance == null)
                instance = new SqlDao();
            return instance;
        }

        /**
         * 1 - Metodo que se conecta a la DB, ejecuta el stored procedure cuando este no devuelve datos hacia
         * la capa anterior (C _ U D)
         */
        public void ExecuteStoredProcedure(SqlOperation operation) 
        {
            /**
             * 1 - Se hace la conexion a DB
             * 2 - Se arma el Query(procedure + params)
             * 3 - Se abre la conexion
             * 4 - Se corre el Comand/Procedure
             */

            string connectionString = _connectionString;
            
            //1
            SqlConnection connection = new SqlConnection(connectionString);

            //2
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = operation.ProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            //Agregar los parametros
            foreach (SqlParameter param in operation.parameters)
            {
                command.Parameters.Add(param);
            }

            //3
            connection.Open();

            //4
            command.ExecuteNonQuery();
        }

        /**
         * 2 - Metodo que se conecta a la DB, ejecuta el stored procedure cuando este SI devuelve datos hacia
         * la capa anterior (_ R _ _)
         */
          
        public List<Dictionary<string, object>> ExecuteStoredProcedureWithQuery(SqlOperation operation)
        {

            string connectionString = _connectionString;
            List<Dictionary<string, object>> lstResults = new List<Dictionary<string, object>>();

            //1
            SqlConnection connection = new SqlConnection(connectionString);

            //2
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = operation.ProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            //Agregar los parametros
            foreach (SqlParameter param in operation.parameters)
            {
                command.Parameters.Add(param);
            }

            //3
            connection.Open();
            //leer los resultados de DB
            SqlDataReader reader = command.ExecuteReader();

            //Recorrer el resultado para poder armar la Lista de diccionarios
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Dictionary<string, object> diccObj = new Dictionary<string, object>();

                    for (var fieldCount = 0; fieldCount < reader.FieldCount; fieldCount++)
                    {
                        diccObj.Add(reader.GetName(fieldCount), reader.GetValue(fieldCount));
                    }

                    lstResults.Add(diccObj);
                }
            }
            return lstResults;
        }
    }
}

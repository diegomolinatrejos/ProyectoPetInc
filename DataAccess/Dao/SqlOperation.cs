using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess.Dao
{
    public class SqlOperation
    {
        /**
         * Esta clase me define una operación que se realiza en BD
         * La operacion contiene los datos necesarios para hacer la interacción con la DB
         * los cuales son: Procedimiento_almacenado y los Parámetros
         */

        public string ProcedureName { get; set; }

        public List<SqlParameter> parameters;

        //Constructor
        public SqlOperation() { 
            parameters = new List<SqlParameter>();
        }

        //Metodos para agregar parametros de distintos tipos a la Lista de Parametros

        public void AddVarcharParam(string parameterName, string parameterValue)
        {
            parameters.Add(new SqlParameter("@" + parameterName, parameterValue));
        }

        public void AddIntegerParam(string parameterName, int parameterValue)
        {
            parameters.Add(new SqlParameter("@" + parameterName, parameterValue));
        }

        public void AddDateTimeParam(string parameterName, DateTime parameterValue)
        {
            parameters.Add(new SqlParameter("@" + parameterName, parameterValue));
        }

    }
}

using DataAccess.Dao;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class UsuarioMapper : ICrudStatements, IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var usuario = new Usuario()
            {
                email = row["Email"].ToString(),
                contrasena = row["Contrasena"].ToString(),
                nombre = row["nombre"].ToString(),
                apellido1 = row["apellido1"].ToString(),
                apellido2 = row["apellido2"].ToString(),
                documentoIdentidad = row["documentoIdentidad"].ToString(),
                telefono = row["telefono"].ToString(),
                direccionMapa = row["direccionMapa"].ToString(),
                foto = row["foto"].ToString(),
            };

            var rol = new Rol()
            {
                Id = int.Parse(row["Rol_Id"].ToString()),
                nombreRol = row["nombreRol"].ToString(),   
            };

            usuario.rolInfo = rol;

            return usuario;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResult = new List<BaseClass>();

            foreach (var objRow in listRows)
            {
                var usuario = BuildObject(objRow);
                lstResult.Add(usuario);
            }
            return lstResult;
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_CREATE_USUARIO";

            Usuario usuario = (Usuario)entityDTO;

            //agregar los parametros al operation
            operation.AddVarcharParam("email", usuario.email);
            operation.AddVarcharParam("contrasena", usuario.contrasena);
            operation.AddVarcharParam("nombre", usuario.nombre);
            operation.AddVarcharParam("apellido1", usuario.apellido1);
            operation.AddVarcharParam("apellido2", usuario.apellido2);
            operation.AddVarcharParam("documentoIdentidad", usuario.documentoIdentidad);
            operation.AddVarcharParam("telefono", usuario.telefono);
            operation.AddVarcharParam("direccionMapa", usuario.direccionMapa);
            operation.AddVarcharParam("foto", usuario.foto);
            operation.AddVarcharParam("rol", usuario.rolInfo.nombreRol);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation RetrieveAllStatement()
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "";

            return operation;
        }

        public SqlOperation RetrieveByIdStatement(int Id)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "";

            operation.AddIntegerParam("usuario_id", Id);

            return operation;
        }

        //Método para hacer consultas por diferentes criterios de filtro
        //Cada criterio que queramos evaluar, va a ser un search type y el valor el
        //search phrase
        public SqlOperation GetRetrieveByPhraseStatement(string searchPhrase)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = ""
            };

            operation.AddVarcharParam("searchPhrase", searchPhrase);

            return operation;
        }
    }
}

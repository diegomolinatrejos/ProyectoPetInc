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
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var usuario = new Usuario()
            {
                Id = int.Parse(objectRow["ID"].ToString()),
                email = objectRow["EMAIL"].ToString(),
                contrasena = objectRow["CONTRASENA"].ToString(),
                nombre = objectRow["NOMBRE"].ToString(),
                primerApellido = objectRow["APELLIDO_1"].ToString(),
                segundoApellido = objectRow["APELLIDO_2"].ToString(),
                documentoIdentidad = objectRow["DOCUMENTO_IDENTIDAD"].ToString(),
                telefono = objectRow["TELEFONO"].ToString(),
                direccionMapa = objectRow["DIRECCION_MAPA"].ToString(),
                foto = objectRow["FOTO"].ToString(),
            };

            var rol = new Rol()
            {
                Id = int.Parse(objectRow["ID"].ToString()),
                nombreRol = objectRow["NOMBRE_ROL"].ToString()
            };

            var estado = new Estado()
            { 
                Id = int.Parse(objectRow["ID"].ToString()),
                nombreEstado = objectRow["NOMBRE_ESTADO"].ToString()
            };

            usuario.rol = rol;
            usuario.estadoInfo = estado;

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
            operation.AddVarcharParam("EMAIL", usuario.email);
            operation.AddVarcharParam("CONTRASENA", usuario.contrasena);
            operation.AddVarcharParam("NOMBRE", usuario.nombre);
            operation.AddVarcharParam("APELLIDO1", usuario.primerApellido);
            operation.AddVarcharParam("APELLIDO2", usuario.segundoApellido);
            operation.AddVarcharParam("DOCUMENTOIDENTIDAD", usuario.documentoIdentidad);
            operation.AddVarcharParam("TELEFONO", usuario.telefono);
            operation.AddVarcharParam("DIRECCIONMAPA", usuario.direccionMapa);
            operation.AddVarcharParam("FOTO", usuario.foto);
            operation.AddIntegerParam("ROL", usuario.rol.Id);
            operation.AddIntegerParam("ESTADO", usuario.estadoInfo.Id);


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

            operation.ProcedureName = "PR_GET_ALL_USUARIOS";

            return operation;
        }

        public SqlOperation RetrieveByIdStatement(int Id)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_USUARIO_BY_ID";

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
                ProcedureName = "PR_GET_USUARIO_BY_PHRASE"
            };

            operation.AddVarcharParam("searchPhrase", searchPhrase);

            return operation;
        }
    }
}

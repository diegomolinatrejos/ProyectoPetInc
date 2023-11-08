using DataAccess.Dao;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class UsuarioMapper : IObjectMapper,ICrudStatements
    {
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var Usuario = new Usuario()
            {
                Id = int.Parse(objectRow["ID"].ToString()),
                email = objectRow["EMAIL"].ToString(),
                contrasena = objectRow["CONTRASENA"].ToString(),
                nombre = objectRow["NOMBRE"].ToString(),
                apellido1 = objectRow["APELLIDO_1"].ToString(),
                apellido2 = objectRow["APELLIDO_2"].ToString(),
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

            Usuario.rol = rol;

            return Usuario;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public SqlOperation RetrieveByIdStatement(int Id)
    {
            throw new NotImplementedException();
        }
    }
}

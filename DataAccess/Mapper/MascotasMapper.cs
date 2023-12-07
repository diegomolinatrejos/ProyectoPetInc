using DataAccess.Dao;
using DTO.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class MascotaMapper : ICrudStatements, IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var mascota = new Mascota()
            {
                Id = int.Parse(objectRow["MASCOTA_ID"].ToString()),
                nombreMascota = objectRow["NOMBRE_MASCOTA"].ToString(),
                descripcion = objectRow["DESCRIPCION"].ToString(),
                fechaNacimiento = DateTime.Parse(objectRow["FECHA_NACIMIENTO"].ToString()),
                raza = objectRow["RAZA"].ToString(),
                agresividad = int.Parse(objectRow["AGRESIVIDAD"].ToString()),
                foto1 = objectRow["FOTO_1"].ToString(),
                foto2 = objectRow["FOTO_2"].ToString(),
                especie = objectRow["ESPECIE"].ToString(),

            };

            var estado = new Estado()
            {
                Id = int.Parse(objectRow["MASCOTA_ESTADO"].ToString()),
                nombreEstado = objectRow["MASCOTA_NOMBRE_ESTADO"].ToString()
            };

            mascota.estado = estado;


            var usuarioMapper = new UsuarioMapper();
            var cliente = (Usuario)usuarioMapper.BuildObject(objectRow);  //Aqui se reutiliza el buildObject para crear el cliente dueño de la mascota


            mascota.cliente = cliente;

            return mascota;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResult = new List<BaseClass>();

            foreach (var objRow in listRows)
            {
                var mascota = BuildObject(objRow);
                lstResult.Add(mascota);
            }
            return lstResult;
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_CREATE_MASCOTA";

            Mascota mascota = (Mascota)entityDTO;

            operation.AddIntegerParam("ID_USUARIO", mascota.cliente.Id);
            operation.AddVarcharParam("NOMBRE_MASCOTA", mascota.nombreMascota);
            operation.AddVarcharParam("DESCRIPCION", mascota.descripcion);
            operation.AddDateTimeParam("FECHA_NACIMIENTO", mascota.fechaNacimiento);
            operation.AddVarcharParam("RAZA", mascota.raza);
            operation.AddIntegerParam("AGRESIVIDAD", mascota.agresividad);
            operation.AddVarcharParam("FOTO_1", mascota.foto1);
            operation.AddVarcharParam("FOTO_2", mascota.foto2);
            operation.AddIntegerParam("ESTADO", mascota.estado.Id);
            operation.AddVarcharParam("ESPECIE", mascota.especie);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_DELETE_MASCOTA_BY_ID";

            Mascota mascota = (Mascota)entityDTO;

            operation.AddIntegerParam("mascota_id", mascota.Id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_UPDATE_MASCOTA";

            Mascota mascota = (Mascota)entityDTO;

            operation.AddIntegerParam("mascota_id", mascota.Id);
            operation.AddIntegerParam("ID_USUARIO", mascota.cliente.Id);
            operation.AddVarcharParam("NOMBRE_MASCOTA", mascota.nombreMascota);
            operation.AddVarcharParam("DESCRIPCION", mascota.descripcion);
            operation.AddDateTimeParam("FECHA_NACIMIENTO", mascota.fechaNacimiento);
            operation.AddVarcharParam("RAZA", mascota.raza);
            operation.AddIntegerParam("AGRESIVIDAD", mascota.agresividad);
            operation.AddVarcharParam("FOTO_1", mascota.foto1);
            operation.AddVarcharParam("FOTO_2", mascota.foto2);
            operation.AddIntegerParam("ESTADO", mascota.estado.Id);
            operation.AddVarcharParam("ESPECIE", mascota.especie);

            return operation;
        }

        public SqlOperation RetrieveAllStatement()
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_ALL_MASCOTAS";

            return operation;
        }

        public SqlOperation RetrieveByIdStatement(int Id)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_MASCOTA_BY_ID";

            operation.AddIntegerParam("mascota_id", Id);

            return operation;
        }

        public SqlOperation GetRetrieveByPhraseStatement(int idDuenno)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "PR_GET_MASCOTAS_BY_OWNER_ID"
            };

            operation.AddIntegerParam("duenno_id", idDuenno);

            return operation;
        }
    }
}
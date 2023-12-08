using DataAccess.Dao;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ReservaMapper : ICrudStatements, IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var reserva = new Reserva()
            {
                Id = int.Parse(objectRow["ID"].ToString()),
                fechaEntrada = DateTime.Parse(objectRow["FECHA_ENTRADA"].ToString()),
                fechaSalida = DateTime.Parse(objectRow["FECHA_SALIDA"].ToString()),
                comentario = objectRow["COMENTARIO"].ToString(),
                total = decimal.Parse(objectRow["TOTAL"].ToString()),
                precioBase = decimal.Parse(objectRow["PRECIO_BASE"].ToString()),
                impuesto = decimal.Parse(objectRow["IMPUESTO"].ToString())
            };
            var usuario = new Usuario()
            {
                Id = int.Parse(objectRow["ID_USUARIO"].ToString()),
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
                Id = int.Parse(objectRow["ROL"].ToString()),
                nombreRol = objectRow["NOMBRE_ROL"].ToString()
            };

            var estadoUsuario = new Estado()
            {
                Id = int.Parse(objectRow["ID_ESTADO_USUARIO"].ToString()),
                nombreEstado = objectRow["NOMBRE_ESTADO"].ToString()
            };
            usuario.rol = rol;
            usuario.estadoInfo = estadoUsuario;

            var mascota = new Mascota()
            {
                Id = int.Parse(objectRow["ID_MASCOTA"].ToString()),
                cliente = usuario,
                nombreMascota = objectRow["NOMBRE_MASCOTA"].ToString(),
                descripcion = objectRow["DESCRIPCION"].ToString(),
                fechaNacimiento = DateTime.Parse(objectRow["FECHA_NACIMIENTO"].ToString()),
                raza = objectRow["RAZA"].ToString(),
                agresividad = int.Parse(objectRow["AGRESIVIDAD"].ToString()),
                foto1 = objectRow["FOTO_1"].ToString(),
                foto2 = objectRow["FOTO_2"].ToString(),
                especie = objectRow["ESPECIE"].ToString()
            };
            var estadoMascota = new Estado()
            {
                Id = int.Parse(objectRow["ID_ESTADO_MASCOTA"].ToString()),
                nombreEstado = objectRow["NOMBRE_ESTADO"].ToString()
            };
            mascota.estado = estadoMascota;

            var dispositivo = new Dispositivo()
            {
                Id = int.Parse(objectRow["ID_DISPOSITIVO"].ToString()),
                numeroSerie = objectRow["NUMERO_SERIE"].ToString(),
                disponibilidad = int.Parse(objectRow["DISPONIBILIDAD"].ToString()),
            };
            var estadoReserva = new Estado()
            {
                Id = int.Parse(objectRow["ID_ESTADO_RESERVA"].ToString()),
                nombreEstado = objectRow["NOMBRE_ESTADO"].ToString()
            };

            reserva.cliente = usuario;
            reserva.mascota = mascota;
            reserva.dispositivo = dispositivo;
            reserva.estadoReserva = estadoReserva;

            return reserva;

        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {

            var lstResult = new List<BaseClass>();

            foreach (var objRow in listRows)
            {
                var reserva = BuildObject(objRow);
                lstResult.Add(reserva);
            }
            return lstResult;
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_CREATE_RESERVA";

            Reserva reserva = (Reserva)entityDTO;

            //agregar los parametros al operation
            operation.AddDateTimeParam("FECHA_ENTRADA", reserva.fechaEntrada);
            operation.AddDateTimeParam("FECHA_SALIDA", reserva.fechaSalida);
            operation.AddIntegerParam("ID_USUARIO", reserva.cliente.Id);
            operation.AddIntegerParam("ID_MASCOTA", reserva.mascota.Id);
            operation.AddIntegerParam("ID_DISPOSITIVO", reserva.dispositivo.Id);
            operation.AddVarcharParam("COMENTARIO", reserva.comentario);
            operation.AddDecimalParam("TOTAL", reserva.total);
            operation.AddIntegerParam("ESTADO_RESERVA", reserva.estadoReserva.Id);
            operation.AddDecimalParam("PRECIO_BASE", reserva.precioBase);
            operation.AddDecimalParam("IMPUESTO", reserva.impuesto);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_DEACTIVATE_RESERVA_BY_ID";

            Reserva reserva = (Reserva)entityDTO;

            operation.AddIntegerParam("ID", reserva.Id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_UPDATE_RESERVA";

            Reserva reserva = (Reserva)entityDTO;

            //agregar los parametros al operation
            operation.AddDateTimeParam("FECHA_ENTRADA", reserva.fechaEntrada);
            operation.AddDateTimeParam("FECHA_SALIDA", reserva.fechaSalida);
            operation.AddIntegerParam("CLIENTE", reserva.cliente.Id);
            operation.AddIntegerParam("MASCOTA", reserva.mascota.Id);
            operation.AddIntegerParam("DISPOSITIVO", reserva.dispositivo.Id);
            operation.AddVarcharParam("COMENTARIO", reserva.comentario);
            operation.AddDecimalParam("TOTAL", reserva.total);
            operation.AddIntegerParam("CONFIRMADA", reserva.confirmada);
            operation.AddIntegerParam("ESTADO_RESERVA", reserva.estadoReserva.Id);
            operation.AddDecimalParam("PRECIO_BASE", reserva.precioBase);
            operation.AddDecimalParam("IMPUESTO", reserva.impuesto);


            return operation;
        }

        public SqlOperation RetrieveAllStatement()
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_ALL_RESERVAS";

            return operation;
        }

        public SqlOperation RetrieveByIdStatement(int Id)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_RESERVA_POR_ID";

            operation.AddIntegerParam("ID", Id);

            return operation;
        }
    }
}

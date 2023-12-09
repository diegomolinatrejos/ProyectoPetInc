using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using DataAccess.Dao;
using DTO;
using DTO.Models;

namespace DataAccess.Mapper
{
    public class ReservaServiciosMapper : IObjectMapper, ICrudStatements
    {
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var reservaServicios = new ReservaServicios()
            {
                Id = int.Parse(objectRow["ID"].ToString())
            };
            var reserva = new Reserva()
            {
                Id = int.Parse(objectRow["ID_RESERVA"].ToString()),
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
                foto = objectRow["FOTO_USUARIO"].ToString(),
            };

            var rol = new Rol()
            {
                Id = int.Parse(objectRow["ID_ROL"].ToString()),
                nombreRol = objectRow["NOMBRE_ROL"].ToString()
            };

            var estadoUsuario = new Estado()
            {
                Id = int.Parse(objectRow["ID_ESTADO_USUARIO"].ToString()),
                nombreEstado = objectRow["NOMBRE_ESTADO_USUARIO"].ToString()
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
                foto1 = objectRow["FOTO_MASCOTA_1"].ToString(),
                foto2 = objectRow["FOTO_MASCOTA_2"].ToString(),
                especie = objectRow["ESPECIE"].ToString()
            };
            var estadoMascota = new Estado()
            {
                Id = int.Parse(objectRow["ID_ESTADO_MASCOTA"].ToString()),
                nombreEstado = objectRow["NOMBRE_ESTADO_MASCOTA"].ToString()
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
                nombreEstado = objectRow["NOMBRE_ESTADO_RESERVA"].ToString()
            };

            reserva.cliente = usuario;
            reserva.mascota = mascota;
            reserva.dispositivo = dispositivo;
            reserva.estadoReserva = estadoReserva;

            var servicio = new Servicio()
            {
                Id = int.Parse(objectRow["SERVICIO_ID"].ToString()),
                nombreServicio = objectRow["NOMBRE_SERVICIO"].ToString(),
                descripcion = objectRow["DESCRIPCION_SERVICIO"].ToString(),
                precio = decimal.Parse(objectRow["PRECIO"].ToString()),
            };

            var estadoServicio = new Estado()
            {
                Id = int.Parse(objectRow["SERVICIO_ESTADO"].ToString()),
                nombreEstado = objectRow["SERVICIO_NOMBRE_ESTADO"].ToString()
            };
            servicio.estado = estadoServicio;

            reservaServicios.reserva = reserva;
            reservaServicios.servicio = servicio;

            return reservaServicios;
        }


        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResult = new List<BaseClass>();

            foreach (var objRow in listRows)
            {
                var reservaServicio = BuildObject(objRow);
                lstResult.Add(reservaServicio);
            }
            return lstResult;
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_CREATE_RESERVA_SERVICIO";

            ReservaServicios reservaServicio = (ReservaServicios)entityDTO;

            operation.AddIntegerParam("ID_RESERVA", reservaServicio.reserva.Id);
            operation.AddIntegerParam("ID_SERVICIO", reservaServicio.servicio.Id);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_DELETE_RESERVA_SERVICIO_BY_ID";

            ReservaServicios reservaServicio = (ReservaServicios)entityDTO;

            operation.AddIntegerParam("ID", reservaServicio.Id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation RetrieveAllStatement()
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_ALL_RESERVA_SERVICIOS";

            return operation;
        }

        public SqlOperation RetrieveByIdStatement(int Id)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_SERVICIO_POR_RESERVA_ID";
            operation.AddIntegerParam("ID_RESERVA", Id);

            return operation;
        }
    }
}

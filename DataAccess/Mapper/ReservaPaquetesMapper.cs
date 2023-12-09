using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DTO;
using DTO.Models;

namespace DataAccess.Mapper
{
    public class ReservaPaquetesMapper : IObjectMapper, ICrudStatements
    {
        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            var reservaPaquetes = new ReservaPaquetes()
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

            var paquete = new Paquete
            {
                Id = int.Parse(objectRow["ID_PAQUETE"].ToString()),
                nombrePaquete = objectRow["NOMBRE_PAQUETE"].ToString(),
                subtotal = decimal.Parse(objectRow["SUBTOTAL"].ToString()),
                precioTotal = decimal.Parse(objectRow["PRECIO_TOTAL"].ToString())

            };
            var estadoPaquete = new Estado()
            {
                Id = int.Parse(objectRow["PAQUETE_ESTADO"].ToString()),
                nombreEstado = objectRow["NOMBRE_ESTADO_PAQUETE"].ToString()
            };
            paquete.estado = estadoPaquete;

            reservaPaquetes.reserva = reserva;
            reservaPaquetes.paquete = paquete;

            return reservaPaquetes;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResult = new List<BaseClass>();

            foreach (var objRow in listRows)
            {
                var reservaPaquete = BuildObject(objRow);
                lstResult.Add(reservaPaquete);
            }
            return lstResult;
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_CREATE_RESERVA_PAQUETE";

            ReservaPaquetes reservaPaquete = (ReservaPaquetes)entityDTO;

            operation.AddIntegerParam("ID_RESERVA", reservaPaquete.reserva.Id);
            operation.AddIntegerParam("ID_PAQUETE", reservaPaquete.paquete.Id);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_DELETE_RESERVA_PAQUETE_BY_ID";

            ReservaPaquetes reservaPaquete = (ReservaPaquetes)entityDTO;

            operation.AddIntegerParam("ID", reservaPaquete.Id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation RetrieveAllStatement()
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_ALL_RESERVAS_PAQUETES";

            return operation;
        }

        public SqlOperation RetrieveByIdStatement(int Id)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_PAQUETE_POR_RESERVA_ID";
            operation.AddIntegerParam("ID_RESERVA", Id);

            return operation;
        }
    }
}

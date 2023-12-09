// Código para conectarse a la API y obtener datos de reservas
var dataReservas;

$.ajax({
    url: 'http://localhost:5087/api/Reserva/GetAllReservas',
    type: 'GET',
    success: function (data) {
        dataReservas = data;
        initializeAdminGrid();
    },
    error: function (error) {
        console.error('Error al obtener datos de reservas:', error);
    }
});

// Código para inicializar la cuadrícula de AG Grid para el Administrador
function initializeAdminGrid() {
    var rowData = dataReservas.map(function (reserva) {
        return {
            Id_Reserva: reserva.id,
            Entrada: new Date(reserva.fechaEntrada).toISOString().split('T')[0],
            Salida: new Date(reserva.fechaSalida).toISOString().split('T')[0],
            Id_Usuario: reserva.cliente.id,
            Nombre_Usuario: reserva.cliente.nombre + ' ' + reserva.cliente.apellido1 + ' ' + reserva.cliente.apellido2,
            Id_Mascota: reserva.mascota.id,
            Nombre_Mascota: reserva.mascota.nombreMascota,
            Especie: reserva.mascota.especie,
            Id_Dispositivo: reserva.dispositivo.id,
            Total: reserva.total,
            Estatus: reserva.estadoReserva.nombreEstado
        };
    });

    var gridOptions = {
        columnDefs: [
            { headerName: 'Id_Reserva', field: 'Id_Reserva' },
            { headerName: 'Entrada', field: 'Entrada' },
            { headerName: 'Salida', field: 'Salida' },
            { headerName: 'Id_Usuario', field: 'Id_Usuario' },
            { headerName: 'Nombre_Usuario', field: 'Nombre_Usuario' },
            { headerName: 'Id_Mascota', field: 'Id_Mascota' },
            { headerName: 'Nombre_Mascota', field: 'Nombre_Mascota' },
            { headerName: 'Especie', field: 'Especie' },
            { headerName: 'Id_Dispositivo', field: 'Id_Dispositivo' },
            { headerName: 'Total', field: 'Total' },
            { headerName: 'Estatus', field: 'Estatus' }
        ],
        rowData: rowData
    };

    // Agregar la cuadrícula al elemento con id "myAdminGrid"
    var gridDiv = document.querySelector('#myAdminGrid');
    new agGrid.Grid(gridDiv, gridOptions);
}

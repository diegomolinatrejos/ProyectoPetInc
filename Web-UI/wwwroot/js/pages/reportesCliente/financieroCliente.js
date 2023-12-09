// financieroCliente.js

$(document).ready(function () {
    var idUsuario = $("#idUsuario").data("id");

    // Llamada a la API para obtener todas las reservas del usuario actual
    $.ajax({
        url: API_URL_BASE + '/api/Reserva/GetAllReservas',
        type: 'GET',
        data: { idUsuario: idUsuario },
        success: function (reservas) {
            // Filtrar reservas del usuario actual
            var reservasUsuario = reservas.filter(function (reserva) {
                return reserva.cliente.id === idUsuario;
            });

            // Calcular el total pagado en reservas
            var totalPagado = reservasUsuario.reduce(function (total, reserva) {
                return total + reserva.total;
            }, 0);

            // Mostrar el total pagado en la vista
            $("#egresosTotalesContainer").html("Total Pagado: $" + totalPagado);

            // Preparar datos para la gráfica de barras
            var mascotas = [];
            var compras = [];

            reservasUsuario.forEach(function (reserva) {
                mascotas.push(reserva.mascota.nombreMascota);
                compras.push(reserva.total);
            });

            // Crear la gráfica de barras
            createBarChart(mascotas, compras);

            // Configurar AG-Grid para mostrar las compras totales
            configureAgGrid(reservasUsuario);
        },
        error: function (error) {
            console.error("Error al obtener las reservas:", error);
        }
    });
});

// Función para crear la gráfica de barras
function createBarChart(mascotas, compras) {
    var ctx = document.getElementById('barChart').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: mascotas,
            datasets: [{
                label: 'Compras por mascota',
                data: compras,
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}

// Función para configurar AG-Grid
function configureAgGrid(reservasUsuario) {
    var columnDefs = [
        { headerName: 'Fecha Entrada', field: 'fechaEntrada' },
        { headerName: 'Fecha Salida', field: 'fechaSalida' },
        { headerName: 'Mascota', field: 'mascota.nombreMascota' },
        { headerName: 'Total', field: 'total' }
    ];

    var gridOptions = {
        columnDefs: columnDefs,
        rowData: reservasUsuario,
        domLayout: 'autoHeight'
    };

    // Inicializar AG-Grid
    new agGrid.Grid(document.querySelector('#myGridEgresos'), gridOptions);
}

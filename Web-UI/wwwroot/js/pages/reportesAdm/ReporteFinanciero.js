// Código para conectarse a la API y obtener datos de reservas
var dataReservas;

$.ajax({
    url: API_URL_BASE + '/api/Reserva/GetAllReservas',
    type: 'GET',
    success: function (data) {
        dataReservas = data;
        initializeAdminGrid();
        initCharts(dataReservas);
        displayIngresosTotales(dataReservas);
    },
    error: function (error) {
        console.error('Error al obtener datos de reservas:', error);
    }
});

// Función para inicializar gráficos
function initCharts(dataReservas) {
    // Obtener una lista única de especies de mascotas
    const especiesUnicas = [...new Set(dataReservas.map(x => x.mascota.especie))];

    // Configuración para el gráfico de barras
    const labelsBarras = especiesUnicas;
    const dataBarras = especiesUnicas.map(especie =>
        dataReservas.filter(x => x.mascota.especie === especie).reduce((total, x) => total + x.total, 0)
    );

    const barChartConfig = {
        labels: labelsBarras,
        datasets: [
            {
                label: "Total de Ventas por Especie",
                data: dataBarras,
                backgroundColor: ["rgba(255, 99, 132)", "rgba(54, 162, 235)", "rgba(255, 205, 86)"],
                borderColor: ["rgb(255, 99, 132)", "rgb(255, 159, 64)", "rgb(255, 205, 86)"],
                borderWidth: 1,
            },
        ],
    };

    // Configuración para el gráfico tipo pie
    const labelsPie = especiesUnicas;
    const dataPie = especiesUnicas.map(especie =>
        dataReservas.filter(x => x.mascota.especie === especie).length
    );

    const totalReservas = dataPie.reduce((total, count) => total + count, 0);
    const porcentajesPie = dataPie.map(count => (count / totalReservas) * 100);

    const pieChartConfig = {
        labels: labelsPie,
        datasets: [
            {
                label: "Porcentaje de Ventas",
                data: porcentajesPie,
                backgroundColor: ["rgb(255, 99, 132)", "rgb(54, 162, 235)", "rgb(255, 205, 86)"],
                hoverOffset: 4,
            },
        ],
    };

    // Código para el gráfico de barras
    var barCtx = document.getElementById('barChart').getContext('2d');
    var barChart = new Chart(barCtx, {
        type: 'bar',
        data: barChartConfig,
        options: {
            scales: {
                y: {
                    beginAtZero: true,
                },
            },
        },
    });

    // Código para el gráfico tipo pie
    var pieCtx = document.getElementById('pieChart').getContext('2d');
    var pieChart = new Chart(pieCtx, {
        type: 'pie',
        data: pieChartConfig,
        options: {
            scales: {
                y: {
                    beginAtZero: true,
                },
            },
        },
    });
}

// Nueva función para calcular la sumatoria de totales confirmados
function calcularIngresosPagados(data) {
    const ingresosPagados = data
        .filter(x => x.estadoReserva.nombreEstado === "Pagado")
        .reduce((total, x) => total + x.total, 0);

    return ingresosPagados.toFixed(2);
}

// Función para mostrar los ingresos totales
function displayIngresosTotales(data) {
    const ingresosTotales = calcularIngresosPagados(data);
    const ingresosTotalesContainer = document.getElementById('ingresosTotalesContainer');

    ingresosTotalesContainer.innerHTML = `<h3>El acumulado de ventas totales a la fecha es: ${ingresosTotales}</h3>`;
}

// Función para inicializar la cuadrícula de AG Grid para el Administrador
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

    // Agregar la cuadrícula al elemento con id "myGrid"
    var gridDiv = document.querySelector('#myGrid');
    new agGrid.Grid(gridDiv, gridOptions);
}

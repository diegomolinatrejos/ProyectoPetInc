// dirección de API
const apiUrl = "http://localhost:5087/api/Reserva/GetResumenReservas";
/*const apiUrl = "/api/Reserva/GetResumenReservas";*/

// Nueva función para obtener datos del API
function obtenerDatosDelAPI() {
    // Configurar la solicitud Ajax
    $.ajax({
        url: apiUrl,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            // Imprimir datos en la consola
            console.log('Datos del API:', data);
            // Llamar a la función para inicializar gráficos y cuadrícula con los datos obtenidos
            data = data || []; // Asegurarse de que los datos no sean nulos
            initCharts(data);
            initGrid(data);
        },
        error: function (error) {
            console.error('Error al obtener datos del API:', error);
        }
    });
}


// Función para inicializar gráficos
function initCharts(data) {
    // Obtener una lista única de especies de mascotas
    const especiesUnicas = [...new Set(data.map(x => x.especie))];

    // Configuración para el gráfico de barras
    const labelsBarras = especiesUnicas;

    // Modificación para obtener la cantidad total de dinero por especie
    const dataBarras = especiesUnicas.map(especie =>
        data.filter(x => x.especie === especie).reduce((total, x) => total + x.total, 0)
    );

    const barChartConfig = {
        labels: labelsBarras,
        datasets: [
            {
                label: "Total de Reservas por Especie",
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
        data.filter(x => x.especie === especie).length // Obtener la cantidad de reservas por especie
    );

    const totalReservas = dataPie.reduce((total, count) => total + count, 0);

    // Calcular el porcentaje de reservas por especie
    const porcentajesPie = dataPie.map(count => (count / totalReservas) * 100);

    const pieChartConfig = {
        labels: labelsPie,
        datasets: [
            {
                label: "Porcentaje Reservas",
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
function calcularIngresosConfirmados(data) {
    const ingresosConfirmados = data
        .filter(x => x.nombreEstado === "Confirmada")
        .reduce((total, x) => total + x.total, 0);

    return ingresosConfirmados.toFixed(2);
}

// Función para inicializar la cuadrícula
function initGrid(data) {
    const gridOptions = {
        columnDefs: [
            { headerName: "ID Reserva", field: "id" },
            { headerName: "Fecha Entrada", field: "fechaEntrada" },
            { headerName: "Fecha Salida", field: "fechaSalida" },
            { headerName: "ID Usuario", field: "idUsuario" },
            { headerName: "Nombre Usuario", field: "nombre" },
            { headerName: "ID Mascota", field: "idMascota" },
            { headerName: "Nombre Mascota", field: "nombreMascota" },
            { headerName: "Especie Mascota", field: "especie" },
            { headerName: "ID Dispositivo", field: "idDispositivo" },
            { headerName: "Total", field: "total" },
            { headerName: "Confirmada", field: "nombreEstado" }
        ],
        rowData: data
    };

    const gridDiv = document.querySelector("#myGrid");
    const gridApi = agGrid.createGrid(gridDiv, gridOptions);
    // Mostrar la suma de ingresos confirmados debajo de la tabla
    const ingresosConfirmadosLabel = document.createElement('label');
    ingresosConfirmadosLabel.innerText = "Ingresos totales (Confirmadas): ";

    const ingresosConfirmadosValue = document.createElement('span');
    ingresosConfirmadosValue.innerText = calcularIngresosConfirmados(data);

    const container = document.createElement('div');
    container.appendChild(ingresosConfirmadosLabel);
    container.appendChild(ingresosConfirmadosValue);

    // Insertar el contenedor debajo de la tabla
    gridDiv.parentNode.appendChild(container);
}

// Manejo de eventos
document.addEventListener('DOMContentLoaded', function () {
    obtenerDatosDelAPI();
});

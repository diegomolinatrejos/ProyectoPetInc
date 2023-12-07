// Información en formato JSON
const data = [
    {
        "tipomascota": "perro",
        "porcentajeReservas": 40,
        "montoPorMascota": 240000
    },
    {
        "tipomascota": "gatos",
        "porcentajeReservas": 50,
        "montoPorMascota": 500000
    },
    {
        "tipomascota": "Hamster",
        "porcentajeReservas": 10,
        "montoPorMascota": 80000
    }
];

// Configuración para las gráficas Pie y Barras
const labelsBarras = data.map(x => x.tipomascota);
const dataBarras = data.map(x => x.montoPorMascota);

const barChartConfig = {
    labels: labelsBarras,
    datasets: [
        {
            label: "Monto por Mascota",
            data: dataBarras,
            backgroundColor: ["rgba(255, 99, 132)", "rgba(54, 162, 235)", "rgba(255, 205, 86)"],
            borderColor: ["rgb(255, 99, 132)", "rgb(255, 159, 64)", "rgb(255, 205, 86)"],
            borderWidth: 1
        }
    ]
};

const labelsPie = data.map(x => x.tipomascota);
const dataPie = data.map(x => x.porcentajeReservas);

const pieChartConfig = {
    labels: labelsPie,
    datasets: [
        {
            label: "Porcentaje Reservas",
            data: dataPie,
            backgroundColor: ["rgb(255, 99, 132)", "rgb(54, 162, 235)", "rgb(255, 205, 86)"],
            hoverOffset: 4
        }
    ]
};

// Función para inicializar gráficos
function initCharts() {
    // Código para el gráfico de barras
    var barCtx = document.getElementById('barChart').getContext('2d');
    var barChart = new Chart(barCtx, {
        type: 'bar',
        data: barChartConfig,
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });

    // Código para el gráfico tipo pie
    var pieCtx = document.getElementById('pieChart').getContext('2d');
    var pieChart = new Chart(pieCtx, {
        type: 'pie',
        data: pieChartConfig,
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}

// Función para inicializar la cuadrícula
function initGrid() {
    const gridOptions = {
        columnDefs: [
            { headerName: "Tipo de Mascota", field: "tipomascota" },
            { headerName: "Cantidad de Reservas", field: "porcentajeReservas" },
            { headerName: "Monto por Mascota", field: "montoPorMascota" }
        ],
        rowData: data
    };

    const gridDiv = document.querySelector("#myGrid");
    new agGrid.Grid(gridDiv, gridOptions);
}

// Manejo de eventos
document.addEventListener('DOMContentLoaded', function () {
    initCharts();
    initGrid();
});

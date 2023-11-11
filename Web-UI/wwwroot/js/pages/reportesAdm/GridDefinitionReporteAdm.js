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

// Configuración de la cuadrícula

const gridOptions = {
    columnDefs: [
        { headerName: "Tipo de Mascota", field: "tipomascota" },
        { headerName: "Cantidad de Reservas", field: "porcentajeReservas" },
        { headerName: "Monto por Mascota", field: "montoPorMascota" }
    ],
    rowData: data
};

// Crear la cuadrícula
const gridDiv = document.querySelector("#myGrid");
new agGrid.Grid(gridDiv, gridOptions);


// Crear gráfico de barras
const barChartDiv = document.querySelector("#barChart");
const barChart = new agCharts.AgChart({
    container: barChartDiv,
    data: data,
    series: [{
        type: "column",
        xKey: "tipoMascota",
        yKeys: ["montoPorMascota"],
        yNames: ["Monto"],
    }],
});

// Crear gráfico de pastel
const pieChartDiv = document.querySelector("#pieChart");
const pieChart = new agCharts.AgChart({
    container: pieChartDiv,
    data: data,
    series: [{
        type: "pie",
        angleKey: "porcentajeReservas",
        labelKey: "tipoMascota",
    }],
});
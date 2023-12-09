// Variable para almacenar el intervalo de actualización
var intervaloActualizacion;

// Variable para rastrear el índice de datos a mostrar
var indiceDatosMostrados = 0;

// Variable para la cantidad de datos iniciales a mostrar
var cantidadInicialDatosMostrados = 10;

// Variable que indica si la actualización está pausada
var actualizacionPausada = false;

// Variable para el número de dispositivo predeterminado
var dispositivo = 1;

// Función para iniciar o continuar la actualización
function iniciarOContinuarActualizacion() {
    actualizacionPausada = false;
    // Actualizar la gráfica cada 5 segundos
    intervaloActualizacion = setInterval(function () {
        obtenerYMostrarDatos();
    }, 5000);
}

// Función para pausar la actualización
function pausarActualizacion() {
    actualizacionPausada = true;
    // Limpiar el intervalo de actualización
    clearInterval(intervaloActualizacion);
}

// Función para obtener y mostrar datos
function obtenerYMostrarDatos() {
    $.ajax({
        url: "http://localhost:5087/api/DatosDispositivo/GetDatosDispositivoById?idDispositivo=" + dispositivo,
        method: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            // Extraer y guardar información del JSON
            var dataApi = [];
            data.forEach(function (medicion) {
                var medicionInfo = {
                    temperatura: medicion.temperatura,
                    humedadRelativa: medicion.humedadRelativa,
                    fecha: new Date(medicion.fecha)
                };
                dataApi.push(medicionInfo);
            });

            // Crear nuevo JSON (dataGrafico) con datos convertidos
            var dataGrafico = dataApi.slice(indiceDatosMostrados, indiceDatosMostrados + cantidadInicialDatosMostrados);
            indiceDatosMostrados += cantidadInicialDatosMostrados;

            // Enviar dataGrafico a función de graficar
            graficar(dataGrafico);

            // Si hemos alcanzado el final de los datos, reiniciar el índice
            if (indiceDatosMostrados >= dataApi.length) {
                indiceDatosMostrados = 0;
            }

            // Inicializar la cuadrícula después de obtener los datos
            initGrid(data2);
        },
        error: function (error) {
            console.error("Error al llamar a la API:", error);
        }
    });
}

// Función para graficar
function graficar(dataGrafico) {
    // Obtener el contexto del lienzo
    var ctx = document.getElementById('miGrafico').getContext('2d');

    // Limpiar la gráfica anterior si existe
    if (window.myChart) {
        window.myChart.destroy();
    }

    // Configuración del gráfico
    window.myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: dataGrafico.map(function (medicion) { return new Date(medicion.fecha).toLocaleTimeString(); }),
            datasets: [{
                label: 'Temperatura (°C)',
                yAxisID: 'left-y-axis',
                data: dataGrafico.map(function (medicion) { return medicion.temperatura; }),
                backgroundColor: 'rgba(255, 99, 132, 0.2)',
                borderColor: 'rgba(255, 99, 132, 1)',
                borderWidth: 1
            }, {
                label: 'Humedad Relativa (%)',
                yAxisID: 'right-y-axis',
                data: dataGrafico.map(function (medicion) { return medicion.humedadRelativa; }),
                backgroundColor: 'rgba(54, 162, 235, 0.2)',
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                xAxes: [{
                    type: 'time',
                    position: 'bottom'
                }],
                yAxes: [{
                    id: 'left-y-axis',
                    type: 'linear',
                    position: 'left',
                    ticks: {
                        min: 15,
                        max: 45
                    }
                }, {
                    id: 'right-y-axis',
                    type: 'linear',
                    position: 'right',
                    ticks: {
                        min: 60,
                        max: 100
                    }
                }]
            }
        }
    });
}

// Función para inicializar la cuadrícula
function initGrid(data2) {
    const gridOptions = {
        columnDefs: [
            { headerName: "ID Reserva", field: "Id" },
            { headerName: "Fecha Entrada", field: "FechaEntrada" },
            { headerName: "Fecha Salida", field: "FechaSalida" },
            { headerName: "ID Usuario", field: "IdUsuario" },
            { headerName: "Nombre Usuario", field: "Nombre" },
            { headerName: "ID Mascota", field: "IdMascota" },
            { headerName: "Nombre Mascota", field: "NombreMascota" },
            { headerName: "Especie Mascota", field: "Especie" },
            { headerName: "ID Dispositivo", field: "IdDispositivo" },
            { headerName: "Total", field: "Total" },
            { headerName: "Confirmada", field: "NombreEstado" }
        ],
        rowData: data2
    };

    const gridDiv = document.querySelector("#myGrid");
    agGrid.createGrid(gridDiv, gridOptions);
}

// Asociar eventos a los botones
document.getElementById('iniciarContinuarBtn').addEventListener('click', function () {
    if (!actualizacionPausada) {
        iniciarOContinuarActualizacion();
    }
});

document.getElementById('pausarBtn').addEventListener('click', function () {
    pausarActualizacion();
});

// Datos de prueba para la tabla
var data2 = [
    {
        Id: 1,
        FechaEntrada: "2023-01-01",
        FechaSalida: "2023-01-10",
        IdUsuario: 101,
        Nombre: "Cliente1",
        IdMascota: 201,
        NombreMascota: "Mascota1",
        Especie: "Perro",
        IdDispositivo: 301,
        Total: 150,
        NombreEstado: "Confirmada"
    },
    // Más objetos de prueba aquí...
];

// Llamar a la función para obtener y mostrar datos al cargar la página
obtenerYMostrarDatos();



//// Variable para almacenar el intervalo de actualización
//var intervaloActualizacion;

//// Variable para rastrear el índice de datos a mostrar
//var indiceDatosMostrados = 0;

//// Variable para la cantidad de datos iniciales a mostrar
//var cantidadInicialDatosMostrados = 10;

//// Variable que indica si la actualización está pausada
//var actualizacionPausada = false;

//// Variable para el número de dispositivo predeterminado
//var dispositivo = 1;

//// Función para iniciar o continuar la actualización
//function iniciarOContinuarActualizacion() {
//    actualizacionPausada = false;
//    // Actualizar la gráfica cada 5 segundos
//    intervaloActualizacion = setInterval(function () {
//        obtenerYMostrarDatos();
//    }, 5000);
//}

//// Función para pausar la actualización
//function pausarActualizacion() {
//    actualizacionPausada = true;
//    // Limpiar el intervalo de actualización
//    clearInterval(intervaloActualizacion);
//}

//// Función para obtener y mostrar datos
//function obtenerYMostrarDatos() {
//    $.ajax({
//        url: "http://localhost:5087/api/DatosDispositivo/GetDatosDispositivoById?idDispositivo=" + dispositivo,
//        method: "GET",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (data) {
//            // Extraer y guardar información del JSON
//            var dataApi = [];
//            data.forEach(function (medicion) {
//                var medicionInfo = {
//                    temperatura: medicion.temperatura,
//                    humedadRelativa: medicion.humedadRelativa,
//                    fecha: new Date(medicion.fecha)
//                };
//                dataApi.push(medicionInfo);
//            });

//            // Crear nuevo JSON (dataGrafico) con datos convertidos
//            var dataGrafico = dataApi.slice(indiceDatosMostrados, indiceDatosMostrados + cantidadInicialDatosMostrados);
//            indiceDatosMostrados += cantidadInicialDatosMostrados;

//            // Enviar dataGrafico a función de graficar
//            graficar(dataGrafico);

//            // Si hemos alcanzado el final de los datos, reiniciar el índice
//            if (indiceDatosMostrados >= dataApi.length) {
//                indiceDatosMostrados = 0;
//            }
//        },
//        error: function (error) {
//            console.error("Error al llamar a la API:", error);
//        }
//    });
//}

//// Función para graficar
//function graficar(dataGrafico) {
//    // Obtener el contexto del lienzo
//    var ctx = document.getElementById('miGrafico').getContext('2d');

//    // Limpiar la gráfica anterior si existe
//    if (window.myChart) {
//        window.myChart.destroy();
//    }

//    // Configuración del gráfico
//    window.myChart = new Chart(ctx, {
//        type: 'line',
//        data: {
//            labels: dataGrafico.map(function (medicion) { return new Date(medicion.fecha).toLocaleTimeString(); }),
//            datasets: [{
//                label: 'Temperatura (°C)',
//                yAxisID: 'left-y-axis',
//                data: dataGrafico.map(function (medicion) { return medicion.temperatura; }),
//                backgroundColor: 'rgba(255, 99, 132, 0.2)',
//                borderColor: 'rgba(255, 99, 132, 1)',
//                borderWidth: 1
//            }, {
//                label: 'Humedad Relativa (%)',
//                yAxisID: 'right-y-axis',
//                data: dataGrafico.map(function (medicion) { return medicion.humedadRelativa; }),
//                backgroundColor: 'rgba(54, 162, 235, 0.2)',
//                borderColor: 'rgba(54, 162, 235, 1)',
//                borderWidth: 1
//            }]
//        },
//        options: {
//            scales: {
//                xAxes: [{
//                    type: 'time',
//                    position: 'bottom'
//                }],
//                yAxes: [{
//                    id: 'left-y-axis',
//                    type: 'linear',
//                    position: 'left',
//                    ticks: {
//                        min: 15,
//                        max: 45
//                    }
//                }, {
//                    id: 'right-y-axis',
//                    type: 'linear',
//                    position: 'right',
//                    ticks: {
//                        min: 60,
//                        max: 100
//                    }
//                }]
//            }
//        }
//    });
//}

//// Asociar eventos a los botones
//document.getElementById('iniciarContinuarBtn').addEventListener('click', function () {
//    if (!actualizacionPausada) {
//        iniciarOContinuarActualizacion();
//    }
//});

//document.getElementById('pausarBtn').addEventListener('click', function () {
//    pausarActualizacion();
//});


//var data2 = [
//    {
//        Id: 1,
//        FechaEntrada: "2023-01-01",
//        FechaSalida: "2023-01-10",
//        IdUsuario: 101,
//        Nombre: "Cliente1",
//        IdMascota: 201,
//        NombreMascota: "Mascota1",
//        Especie: "Perro",
//        IdDispositivo: 301,
//        Total: 150,
//        NombreEstado: "Confirmada"
//    },
//    {
//        Id: 2,
//        FechaEntrada: "2023-01-05",
//        FechaSalida: "2023-01-15",
//        IdUsuario: 102,
//        Nombre: "Cliente2",
//        IdMascota: 202,
//        NombreMascota: "Mascota2",
//        Especie: "Gato",
//        IdDispositivo: 302,
//        Total: 120,
//        NombreEstado: "Pendiente"
//    },
//    {
//        Id: 3,
//        FechaEntrada: "2023-02-10",
//        FechaSalida: "2023-02-20",
//        IdUsuario: 103,
//        Nombre: "Cliente3",
//        IdMascota: 203,
//        NombreMascota: "Mascota3",
//        Especie: "AVE",
//        IdDispositivo: 303,
//        Total: 300,
//        NombreEstado: "Confirmada"
//    },
//    {
//        Id: 4,
//        FechaEntrada: "2023-04-10",
//        FechaSalida: "2023-04-20",
//        IdUsuario: 104,
//        Nombre: "Cliente4",
//        IdMascota: 204,
//        NombreMascota: "Mascota4",
//        Especie: "Conejo",
//        IdDispositivo: 304,
//        Total: 180,
//        NombreEstado: "Pendiente"
//    },
//    {
//        Id: 5,
//        FechaEntrada: "2023-04-10",
//        FechaSalida: "2023-04-20",
//        IdUsuario: 105,
//        Nombre: "Cliente4",
//        IdMascota: 205,
//        NombreMascota: "Mascota4",
//        Especie: "Perro",
//        IdDispositivo: 305,
//        Total: 180,
//        NombreEstado: "Pendiente"
//    }

//];
//// Función para inicializar la cuadrícula
//function initGrid(data2) {
//    const gridOptions = {
//        columnDefs: [
//            { headerName: "ID Reserva", field: "Id" },
//            { headerName: "Fecha Entrada", field: "FechaEntrada" },
//            { headerName: "Fecha Salida", field: "FechaSalida" },
//            { headerName: "ID Usuario", field: "IdUsuario" },
//            { headerName: "Nombre Usuario", field: "Nombre" },
//            { headerName: "ID Mascota", field: "IdMascota" },
//            { headerName: "Nombre Mascota", field: "NombreMascota" },
//            { headerName: "Especie Mascota", field: "Especie" },
//            { headerName: "ID Dispositivo", field: "IdDispositivo" },
//            { headerName: "Total", field: "Total" },
//            { headerName: "Confirmada", field: "NombreEstado" }
//        ],
//        rowData: data2 
//    };

//    const gridDiv = document.querySelector("#myGrid");
//    agGrid.createGrid(gridDiv, gridOptions);
//}

//// Llamar a la función para obtener y mostrar datos al cargar la página
//obtenerYMostrarDatos();
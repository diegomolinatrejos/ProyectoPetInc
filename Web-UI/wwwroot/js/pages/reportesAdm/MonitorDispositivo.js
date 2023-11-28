// Variable para almacenar el intervalo de actualización
var intervaloActualizacion;

// Variable para rastrear el índice de datos a mostrar
var indiceDatosMostrados = 0;

// Variable para la cantidad de datos iniciales a mostrar
var cantidadInicialDatosMostrados = 10;

// Variable que indica si la actualización está pausada
var actualizacionPausada = false;

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
        url: "http://localhost:5087/api/DatosDispositivo/GetDatosDispositivo",
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

// Asociar eventos a los botones
document.getElementById('iniciarContinuarBtn').addEventListener('click', function () {
    if (!actualizacionPausada) {
        iniciarOContinuarActualizacion();
    }
});

document.getElementById('pausarBtn').addEventListener('click', function () {
    pausarActualizacion();
});

// Llamar a la función para obtener y mostrar datos al cargar la página
obtenerYMostrarDatos();




//var primerosDatos = [];

//// Primero: Conectar a la API y obtener el JSON
//function obtenerDataAPI() {
//    $.ajax({
//        url: "http://localhost:5087/api/DatosDispositivo/GetDatosDispositivo",
//        method: "GET",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (data) {
//            // Segundo: Extraer y guardar información del JSON
//            var numeroSerie = data[0].idDispositivo.numeroSerie;

//            var dataApi = [];
//            data.forEach(function (medicion) {
//                var medicionInfo = {
//                    temperatura: medicion.temperatura,
//                    humedadRelativa: medicion.humedadRelativa,
//                    fecha: new Date(medicion.fecha)
//                };
//                dataApi.push(medicionInfo);
//            });

//            // Tercero: Crear nuevo JSON (dataGrafico) con datos convertidos
//            var dataGrafico = [];
//            dataApi.forEach(function (medicion) {
//                var medicionGrafico = {
//                    temperatura: parseFloat(medicion.temperatura),
//                    humedadRelativa: parseFloat(medicion.humedadRelativa),
//                    fecha: new Date(medicion.fecha)
//                };
//                dataGrafico.push(medicionGrafico);
//            });

//            // Cuarto: Enviar dataGrafico a función de graficar
//            graficar(dataGrafico);
//        },
//        error: function (error) {
//            console.error("Error al llamar a la API:", error);
//        }
//    });
//}

//// Quinto: Función para graficar
//function graficar(dataGrafico) {
//    // Obtener el contexto del lienzo
//    var ctx = document.getElementById('miGrafico').getContext('2d');

//    // Configuración del gráfico
//    var myChart = new Chart(ctx, {
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

//// Sexto: Llamar a la función para obtener datos de la API
//obtenerDataAPI();

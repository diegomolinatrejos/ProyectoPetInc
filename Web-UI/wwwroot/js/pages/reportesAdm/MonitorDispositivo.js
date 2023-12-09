var intervaloActualizacion;
var indiceDatosMostrados = 0;
var cantidadInicialDatosMostrados = 10;
var actualizacionPausada = false;
var idDispositivo = 1;

var numeroDispositivoInput = document.getElementById('numeroDispositivo');
numeroDispositivoInput.addEventListener('change', function () {
    idDispositivo = parseInt(numeroDispositivoInput.value);
    pausarActualizacion();
    obtenerYMostrarDatos();
});

function iniciarOContinuarActualizacion() {
    actualizacionPausada = false;
    intervaloActualizacion = setInterval(function () {
        obtenerYMostrarDatos();
    }, 5000);
}

function pausarActualizacion() {
    actualizacionPausada = true;
    clearInterval(intervaloActualizacion);
}

function obtenerYMostrarDatos() {
    $.ajax({
        url: API_URL_BASE + "/api/DatosDispositivo/GetDatosDispositivoById?idDispositivo=" + idDispositivo,
        method: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            var dataApi = [];
            data.forEach(function (medicion) {
                var medicionInfo = {
                    temperatura: medicion.temperatura,
                    humedadRelativa: medicion.humedadRelativa,
                    fecha: new Date(medicion.fecha)
                };
                dataApi.push(medicionInfo);
            });

            var dataGrafico = dataApi.slice(indiceDatosMostrados, indiceDatosMostrados + cantidadInicialDatosMostrados);
            indiceDatosMostrados += cantidadInicialDatosMostrados;

            graficar(dataGrafico);

            if (indiceDatosMostrados >= dataApi.length) {
                indiceDatosMostrados = 0;
            }
        },
        error: function (error) {
            console.error("Error al llamar a la API:", error);
        }
    });
}

function graficar(dataGrafico) {
    var ctx = document.getElementById('miGrafico').getContext('2d');
    if (window.myChart) {
        window.myChart.destroy();
    }

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

document.getElementById('iniciarContinuarBtn').addEventListener('click', function () {
    if (!actualizacionPausada) {
        iniciarOContinuarActualizacion();
    }
});

document.getElementById('pausarBtn').addEventListener('click', function () {
    pausarActualizacion();
});

obtenerYMostrarDatos();




function cargarDatosServicioEnFormulario(servicioId) {

    localStorage.setItem('servicioIdSeleccionado', servicioId);

    window.location.href = '/Servicios/EdicionServicios';
}

function cargarServicios() {
    const apiUrl = API_URL_BASE + "/api/Servicios/GetServicios";

    // Utilizar jQuery para realizar la solicitud AJAX
    $.ajax({
        method: 'GET',
        url: apiUrl,
        dataType: 'json'
    })
        .done(function (data) {
            // Limpiar la tabla antes de agregar nuevas filas
            const tablaServiciosBody = $('#tablaServiciosBody');
            tablaServiciosBody.empty();

            // Iterar sobre los servicios y agregar filas a la tabla
            data.forEach(function (servicio) {
                const fila = `
                <tr class="table-active">
                    <td>${servicio.nombreServicio}</td>
                    <td>${servicio.descripcion}</td>
                    <td>₡${servicio.precio}</td>
                    <td>${servicio.estado.nombreEstado}</td>
                    <td>
                        <a href="#" class="btn btn-primary boton-editar" data-id-servicio="${servicio.id}">Editar</a>
                    </td>
                </tr>`;
                tablaServiciosBody.append(fila);
            });

            // Agregar evento click a los botones de editar
            $('.boton-editar').on('click', function (e) {
                e.preventDefault(); // Prevenir el comportamiento predeterminado del enlace
                var servicioId = $(this).data('id-servicio');
                cargarDatosServicioEnFormulario(servicioId);
            });
        })
        .fail(function (error) {
            console.error('Error al cargar los servicios:', error);
        })
        .always(function () {

        });
}


// Llama a la función cargarServicios al cargar el documento
$(document).ready(function () {
    cargarServicios();
});
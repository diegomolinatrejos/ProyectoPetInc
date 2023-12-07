function validarFormularioEdicionServicios() {
    const formularioEdicionServicios = document.getElementById('formularioEdicionServicios');

    formularioEdicionServicios.addEventListener('submit', function (e) {
        e.preventDefault();

        const nombreServicioEditar = document.getElementById('nombreServicioEditar').value.trim();
        const descripcionServicioEditar = document.getElementById('descripcionServicioEditar').value.trim();
        const precioServicioEditar = document.getElementById('precioServicioEditar').value.trim();
        const estadoServicioEditar = document.getElementById('selecionEstado').value.trim();

        if (nombreServicioEditar === '' || descripcionServicioEditar === '' || precioServicioEditar === '') {
            Swal.fire({
                title: 'Error',
                text: 'Por favor completa todos los campos de información, son obligatorios',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
        } else {
            editarServicio();
        }
    });
}

var objServicio;

function cargarDatosServicioEnFormulario(servicioId) {
    const apiUrl = API_URL_BASE + "/api/Servicios/GetServicioPorId?id=" + servicioId;

    $.ajax({
        method: 'GET',
        url: apiUrl,
        dataType: 'json'
    })
        .done(function (servicio) {
            objServicio = servicio;

            $('#nombreServicioEditar').val(servicio.nombreServicio);
            $('#descripcionServicioEditar').val(servicio.descripcion);
            $('#precioServicioEditar').val(servicio.precio);
            $('#selecionEstado').val(servicio.estado.nombreEstado);

            // También puedes mostrar la imagen del servicio si tienes esa funcionalidad

            formularioEdicionServicios.setAttribute('data-servicio-id', servicioId);
        })
        .fail(function (error) {
            console.error('Error al cargar los datos del servicio:', error);
        });
}

function editarServicio() {
    var estado = 1;

    var estadoUpdate = $('#selecionEstado').val();
    if (estadoUpdate === "Inactivo") {
        estado = 2;
    }

    var servicio = {
        id: objServicio.id,
        nombreServicio: $("#nombreServicioEditar").val(),
        descripcion: $("#descripcionServicioEditar").val(),
        precio: parseFloat($("#precioServicioEditar").val()),
        estado: {
            id: estado,
            nombreEstado: estadoUpdate
        }
    };

    const apiUrl = API_URL_BASE + "/api/Servicios/UpdateServicio";

    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        method: 'PUT',
        url: apiUrl,
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(servicio),
        success: function (data) {
            console.log('Servicio actualizado con éxito', data);
            Swal.fire({
                title: 'Éxito!',
                icon: 'success',
                text: 'El servicio se actualizo correctamente.'
            });
        },
        error: function (error) {
            console.error('Error al actualizar el servicio:', error);
            Swal.fire({
                title: 'Error!',
                icon: 'error',
                text: 'Hubo un error al actualizar el servicio.'
            });
        }
    });
}

document.addEventListener('DOMContentLoaded', function () {
    validarFormularioEdicionServicios();
    const servicioIdSeleccionado = localStorage.getItem('servicioIdSeleccionado');
    cargarDatosServicioEnFormulario(servicioIdSeleccionado);
});

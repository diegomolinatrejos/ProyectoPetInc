function validarFormularioReserva(formularioId, mensajeExito) {
    const formulario = document.getElementById(formularioId);

    formulario.addEventListener('submit', function (e) {
        e.preventDefault();

        const fechaEntrada = document.getElementById('fechaEntrada').value.trim();
        const fechaSalida = document.getElementById('fechaSalida').value.trim();
        const comentarios = document.getElementById('comentarios').value.trim();

        if (fechaEntrada === '' || fechaSalida === '' || comentarios === '') {
            mostrarAlertaError('Por favor completa todos los campos de información, son obligatorios');
        } else {
            mostrarAlertaExito(mensajeExito).then((result) => {
                if (result.isConfirmed) {
                    formulario.submit();
                }
            });
        }
    });
}

function mostrarAlertaError(mensaje) {
    return Swal.fire({
        title: 'Error',
        text: mensaje,
        icon: 'error',
        confirmButtonText: 'Aceptar'
    });
}

function mostrarAlertaExito(mensaje) {
    return Swal.fire({
        title: 'Formulario enviado',
        text: mensaje,
        icon: 'success',
        confirmButtonText: 'Aceptar'
    });
}

document.addEventListener('DOMContentLoaded', function () {
    // En la página de Edición de Reserva
    if (document.getElementById('realizarReservaEdicion')) {
        var serviciosTabEdicion = document.querySelector('[href="#contenedorListaServiciosEdicion"]');
        serviciosTabEdicion.click();
    } else {
        // En la página de Realizar Reserva
        var serviciosTab = document.querySelector('[href="#contenedorListaServicios"]');
        serviciosTab.click();
    }
});



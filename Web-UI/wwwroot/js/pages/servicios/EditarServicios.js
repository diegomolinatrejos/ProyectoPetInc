function validarFormularioEdicionServicios() {
    const formularioEdicionServicios = document.getElementById('formularioEdicionServicios');

    formularioEdicionServicios.addEventListener('submit', function (e) {
        e.preventDefault();

        const nombreServicioEditar = document.getElementById('nombreServicioEditar').value.trim();
        const descripcionServicioEditar = document.getElementById('descripcionServicioEditar').value.trim();
        const precioServicioEditar = document.getElementById('precioServicioEditar').value.trim();

        if (nombreServicioEditar === '' || descripcionServicioEditar === '' || precioServicioEditar === '') {
            Swal.fire({
                title: 'Error',
                text: 'Por favor completa todos los campos de información, son obligatorios',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
        } else {
            Swal.fire({
                title: 'Formulario enviado',
                text: 'La información del servicio se ha actualizado correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.isConfirmed) {
                    formularioEdicionServicios.submit();
                }
            });
        }
    });
}







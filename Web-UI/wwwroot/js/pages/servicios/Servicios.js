function validarFormularioRegistroServicios() {
    const formularioRegistroServicios = document.getElementById('formularioRegistroServicios');

    formularioRegistroServicios.addEventListener('submit', function (e) {
        e.preventDefault();

        const nombreServicio = document.getElementById('nombreServicio').value.trim();
        const descripcionServicio = document.getElementById('descripcionServicio').value.trim();
        const precioServicio = document.getElementById('precioServicio').value.trim();
        const fotoServicio = document.getElementById('fotoServicio').value.trim();

        if (nombreServicio === '' || descripcionServicio === '' || precioServicio === '' || fotoServicio === '') {
            Swal.fire({
                title: 'Error',
                text: 'Por favor completa todos los campos de información, son obligatorios',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
        } else {
            Swal.fire({
                title: 'Formulario enviado',
                text: 'El servicio se ha registrado correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.isConfirmed) {
                    formularioRegistroServicios.submit();
                }
            });
        }
    });
}


function validarFormularioEdicionServicios() {
    const formularioEdicionServicios = document.getElementById('formularioEdicionServicios');

    formularioEdicionServicios.addEventListener('submit', function (e) {
        e.preventDefault();

        const nombreServicioEditar = document.getElementById('nombreServicioEditar').value.trim();
        const descripcionServicioEditar = document.getElementById('descripcionServicioEditar').value.trim();
        const precioServicioEditar = document.getElementById('precioServicioEditar').value.trim();
        const fotoServicioEditar = document.getElementById('fotoServicioEditar').value.trim();

        if (nombreServicioEditar === '' || descripcionServicioEditar === '' || precioServicioEditar === '' || fotoServicioEditar === '') {
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

function mostrarImagen(input, idImagen) {
    var reader = new FileReader();
    reader.onload = function (e) {
        document.getElementById(idImagen).src = e.target.result;
        document.getElementById(idImagen).style.display = "inline-block";
    };
    reader.readAsDataURL(input.files[0]);
}

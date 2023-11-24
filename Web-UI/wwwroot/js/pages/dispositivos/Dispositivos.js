function validarFormularioRegistroDispositivos() {
    const formularioRegistroDispositivos = document.getElementById('formularioRegistroDispositivos');

    formularioRegistroDispositivos.addEventListener('submit', function (e) {
        e.preventDefault();

        const nombreDispositivo = document.getElementById('txtInputNombre').value.trim();
        const numeroSerieDispositivo = document.getElementById('txtInputNumero').value.trim();

        if (nombreDispositivo === '' || numeroSerieDispositivo === '') {
            Swal.fire({
                title: 'Error',
                text: 'Por favor completa todos los campos de información, son obligatorios',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
        } else {
            Swal.fire({
                title: 'Formulario enviado',
                text: 'El dispositivo se ha registrado correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.isConfirmed) {
                    formularioRegistroDispositivos.submit();
                }
            });
        }
    });
}

function validarFormularioEdicionDispositivos() {
    const formularioEdicionDispositivos = document.getElementById('formularioEdicionDispositivos');

    formularioEdicionDispositivos.addEventListener('submit', function (e) {
        e.preventDefault();

        const nombreDispositivoEditar = document.getElementById('txtInputNombre').value.trim();
        const numeroSerieDispositivoEditar = document.getElementById('txtInputNumero').value.trim();

        if (nombreDispositivoEditar === '' || numeroSerieDispositivoEditar === '') {
            Swal.fire({
                title: 'Error',
                text: 'Por favor completa todos los campos de información, son obligatorios',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
        } else {
            Swal.fire({
                title: 'Formulario enviado',
                text: 'La información del dispositivo se ha actualizado correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.isConfirmed) {
                    formularioEdicionDispositivos.submit();
                }
            });
        }
    });
}
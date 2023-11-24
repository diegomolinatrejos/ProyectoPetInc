function validarFormularioEdicionPerfil() {
    // Seleccionamos el formulario por su ID
    const formularioEdicionPerfil = document.getElementById('edicionPerfil');

    // Agregamos un evento submit al formulario
    formularioEdicionPerfil.addEventListener('submit', function (e) {
        // Prevenimos el envío del formulario por defecto
        e.preventDefault();

        // Validamos que todos los campos obligatorios estén completos
        const txtInputNombrePerfilEdit = document.getElementById('txtInputNombrePerfilEdit').value.trim();
        const txtInputApellido1PerfilEdit = document.getElementById('txtInputApellido1PerfilEdit').value.trim();
        const txtInputApellido2PerfilEdit = document.getElementById('txtInputApellido2PerfilEdit').value.trim();
        const txtInputDocumentoIdentidadPerfilEdit = document.getElementById('txtInputDocumentoIdentidadPerfilEdit').value.trim();
        const txtInputTelefonoPerfilEdit = document.getElementById('txtInputTelefonoPerfilEdit').value.trim();
        const dateInputFechaNacimientoPerfilEdit = document.getElementById('dateInputFechaNacimientoPerfilEdit').value.trim();
        const txtInputDireccionPerfilEdit = document.getElementById('txtInputDireccionPerfilEdit').value.trim();
        const fileInputFotoPerfilEdit = document.getElementById('fileInputFotoPerfilEdit').value.trim();

        // Validamos la longitud del número de teléfono
        if (txtInputTelefonoPerfilEdit.length !== 8) {
            Swal.fire({
                title: 'Error',
                text: 'El número de teléfono debe tener 8 dígitos',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
            return; // Detenemos la ejecución de la función si la validación falla
        }

        // Validamos la longitud del documento de identidad
        if (txtInputDocumentoIdentidadPerfilEdit.length !== 9) {
            Swal.fire({
                title: 'Error',
                text: 'El documento de identidad debe tener 9 dígitos',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
            return; // Detenemos la ejecución de la función si la validación falla
        }

        // Resto de la validación
        if (
            txtInputNombrePerfilEdit === '' ||
            txtInputApellido1PerfilEdit === '' ||
            txtInputApellido2PerfilEdit === '' ||
            txtInputDocumentoIdentidadPerfilEdit === '' ||
            txtInputTelefonoPerfilEdit === '' ||
            dateInputFechaNacimientoPerfilEdit === '' ||
            txtInputDireccionPerfilEdit === '' ||
            fileInputFotoPerfilEdit === ''
        ) {
            // Si algún campo obligatorio está vacío, mostramos un mensaje de error con SweetAlert
            Swal.fire({
                title: 'Error',
                text: 'Por favor completa todos los campos de información, son obligatorios',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
        } else {
            // Si todos los campos obligatorios están completos, mostramos un mensaje de éxito con SweetAlert y enviamos el formulario
            Swal.fire({
                title: 'Formulario enviado',
                text: 'Tu perfil se ha actualizado correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.isConfirmed) {
                    formularioEdicionPerfil.submit();
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

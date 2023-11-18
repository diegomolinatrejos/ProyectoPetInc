function validarFormularioEdicionPerfil() {
    // Seleccionamos el formulario por su clase
    const formularioEdicionPerfil = document.getElementById('edicionPerfil');

    // Agregamos un evento submit al formulario
    formularioEdicionPerfil.addEventListener('submit', function (e) {
        // Prevenimos el envío del formulario por defecto
        e.preventDefault();

        // Validamos que todos los campos obligatorios estén completos
        const nombrePerfilEdit = document.getElementById('nombrePerfilEdit').value.trim();
        const apellido1PerfilEdit = document.getElementById('apellido1PerfilEdit').value.trim();
        const apellido2PerfilEdit = document.getElementById('apellido2PerfilEdit').value.trim();
        const documentoIdentidadPerfilEdit = document.getElementById('documentoIdentidadPerfilEdit').value.trim();
        const telefonoPerfilEdit = document.getElementById('telefonoPerfilEdit').value.trim();
        const fechaNacimientoPerfilEdit = document.getElementById('fechaNacimientoPerfilEdit').value.trim();
        const direccionPerfilEdit = document.getElementById('direccionPerfilEdit').value.trim();
        const fotoPerfilEdit = document.getElementById('fotoPerfilEdit').value.trim();



        if (telefonoPerfilEdit.length > 8 || telefonoPerfilEdit.length < 8) {
            Swal.fire({
                title: 'Error',
                text: 'El número de teléfono no puede tener más de 8 dígitos o menos de 8 digitos',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
            return; // Detenemos la ejecución de la función si la validación falla
        }

        // Validamos que el número de documento de identidad tenga no más de 9 dígitos
        if (documentoIdentidadPerfilEdit.length > 9 || documentoIdentidadPerfilEdit.length < 9) {
            Swal.fire({
                title: 'Error',
                text: 'El documento de identidad no puede tener más de 9 dígitos o menos de 9 digitos',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
            return; // Detenemos la ejecución de la función si la validación falla
        }


        // Resto de la validación
        if (nombrePerfilEdit === '' || apellido1PerfilEdit === '' || apellido2PerfilEdit === '' ||
            documentoIdentidadPerfilEdit === '' || telefonoPerfilEdit === '' ||
            fechaNacimientoPerfilEdit === '' || direccionPerfilEdit === '' || fotoPerfilEdit === '') {
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

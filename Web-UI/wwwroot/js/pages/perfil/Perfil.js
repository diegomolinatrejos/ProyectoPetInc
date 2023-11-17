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
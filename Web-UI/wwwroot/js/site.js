
function validarFormulario(formularioId) {
    // Seleccionamos el formulario por su ID
    const formulario = document.getElementById(formularioId);

    // Agregamos un evento submit al formulario
    formulario.addEventListener('submit', function (e) {
        // Prevenimos el envío del formulario por defecto
        e.preventDefault();

        // Validamos que todos los campos obligatorios estén completos
        const nombre = document.getElementById('nombre').value.trim();
        const correo = document.getElementById('correo').value.trim();
        const telefono = document.getElementById('telefono').value.trim();
        const mensaje = document.getElementById('mensaje').value.trim();

        if (nombre === '' || correo === '' || mensaje === '' || telefono === '') {
            // Si algún campo obligatorio está vacío, mostramos un mensaje de error con SweetAlert
            Swal.fire({
                title: 'Error',
                text: 'Por favor completa todos los campos obligatorios',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
        } else {
            // Si todos los campos obligatorios están completos, mostramos un mensaje de éxito con SweetAlert y enviamos el formulario
            Swal.fire({
                title: 'Formulario enviado',
                text: 'Gracias por enviar tu información',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.isConfirmed) {
                    formulario.submit();
                }
            });
        }
    });
}

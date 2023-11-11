
// sweet alert
// Seleccionamos el botón por su ID
const botonEnviar = document.getElementById('boton-enviar');

// Agregamos un evento click al botón
botonEnviar.addEventListener('click', function (e) {
    // Prevenimos el envío del formulario por defecto
    e.preventDefault();

    // Validamos que todos los campos obligatorios estén completos
    const nombre = document.getElementById('nombre').value.trim();
    const apellido1 = document.getElementById('apellido1').value.trim();
    const apellido2 = document.getElementById('apellido2').value.trim();
    const identificacion = document.getElementById('identificacion').value.trim();
    const telefono = document.getElementById('telefono').value.trim();
    const email = document.getElementById('email').value.trim();
    const direccion = document.getElementById('direccion').value.trim();
    const fotoUsuario = document.getElementById('fotoUsuario').value.trim();


    if (nombre === '' || apellido1 === '' || apellido2 === '' || identificacion === '' || telefono === '' || email === '' || direccion === '' || fotoUsuario === '') {
        // Si algún campo obligatorio está vacío, mostramos un mensaje de error con SweetAlert
        Swal.fire({ //método de la biblioteca SweetAlert que permite mostrar alertas personalizadas en el navegador
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
                this.form.submit();
            }
        });
    }
});
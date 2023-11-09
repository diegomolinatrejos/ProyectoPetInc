
        // sweet alert
    // Seleccionamos el botón por su ID
    const botonEnviar = document.getElementById('boton-enviar');

    // Agregamos un evento click al botón
    botonEnviar.addEventListener('click', function (e) {
        // Prevenimos el envío del formulario por defecto
        e.preventDefault();

    // Validamos que todos los campos obligatorios estén completos
    const nombre = document.getElementById('nombre').value.trim();
    const correo = document.getElementById('correo').value.trim();
    const telefono = document.getElementById('nombre').value.trim();
    const mensaje = document.getElementById('mensaje').value.trim();


    if (nombre === '' || correo === '' || mensaje === '' || telefono === '') {
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

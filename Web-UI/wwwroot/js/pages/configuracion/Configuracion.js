function validarFormularioConfiguracionBase() {
    const formularioConfiguracionBase = document.getElementById('formularioConfiguracionBase');

    formularioConfiguracionBase.addEventListener('submit', function (e) {
        e.preventDefault();

        const impuesto = document.getElementById('impuesto').value.trim();
        const descuento = document.getElementById('descuento').value.trim();
        const servicio = document.getElementById('servicio').value.trim();

        if (impuesto === '' || descuento === '' || servicio === '') {
            Swal.fire({
                title: 'Error',
                text: 'Por favor completa todos los campos de información, son obligatorios',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
        } else {
            Swal.fire({
                title: 'Formulario enviado',
                text: 'La configuración de precios base se ha guardado correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.isConfirmed) {
                    formularioConfiguracionBase.submit();
                }
            });
        }
    });
}
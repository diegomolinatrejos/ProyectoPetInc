function validarFormularioRegistroMascotas() {
    // Seleccionamos el formulario por su ID
    const formularioRegistroMascotas = document.getElementById('formularioRegistroMascotas');

    // Agregamos un evento submit al formulario
    formularioRegistroMascotas.addEventListener('submit', function (e) {
        // Prevenimos el envío del formulario por defecto
        e.preventDefault();

        // Validamos que todos los campos obligatorios estén completos
        const nombreMascota = document.getElementById('txtInputNombreMascota').value.trim();
        const especieMascota = document.getElementById('txtInputEspecieMascota').value.trim();
        const razaMascota = document.getElementById('txtInputRaza').value.trim();
        const fechaNacimientoMascota = document.getElementById('txtInputFechaNacimiento').value.trim();
        let agresividadMascota = document.getElementById('txtInputAgresividad').value.trim(); // Convertimos a cadena para evitar problemas con parseInt
        const descripcionMascota = document.getElementById('txtInputDescripcion').value.trim();
        const fotoMascota = document.getElementById('fotoMascota').value.trim();
        const fotoMascota2 = document.getElementById('fotoMascota2').value.trim();

        // Validamos que la agresividad sea un número y no mayor a 10
        if (isNaN(agresividadMascota) || agresividadMascota < 0 || agresividadMascota > 10) {
            Swal.fire({
                title: 'Error',
                text: 'La agresividad debe ser un número entre un rango de 0 a 10',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
            return; // Detenemos la ejecución de la función si la validación falla
        }

        // Resto de la validación
        if (nombreMascota === '' || especieMascota === '' || razaMascota === '' || fechaNacimientoMascota === '' || agresividadMascota === '' || descripcionMascota === '' || fotoMascota === '' || fotoMascota2 === '') {
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
                text: 'Su mascota se ha registrado correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.isConfirmed) {
                    formularioRegistroMascotas.submit();
                }
            });
        }
    });
}

function validarFormularioEdicionMascotas() {
    // Seleccionamos el formulario por su ID
    const formularioEdicionMascotas = document.getElementById('formularioEdicionMascotas');

    // Agregamos un evento submit al formulario
    formularioEdicionMascotas.addEventListener('submit', function (e) {
        // Prevenimos el envío del formulario por defecto
        e.preventDefault();

        // Validamos que todos los campos obligatorios estén completos
        const nombreMascotaEditar = document.getElementById('txtInputNombreMascotaEditar').value.trim();
        const especieMascotaEditar = document.getElementById('txtInputEspecieMascotaEditar').value.trim();
        const razaMascotaEditar = document.getElementById('txtInputRazaMascotaEditar').value.trim();
        const fechaNacimientoMascotaEditar = document.getElementById('dateInputFechaNacimientoMascotaEditar').value.trim();
        let agresividadMascotaEditar = document.getElementById('numberInputAgresividadMascotaEditar').value.trim(); // Convertimos a cadena para evitar problemas con parseInt
        const descripcionMascotaEditar = document.getElementById('txtInputDescripcionMascotaEditar').value.trim();
        const fotoMascotaEditar = document.getElementById('fotoMascotaEditar').value.trim();
        const fotoMascotaEditar2 = document.getElementById('fotoMascotaEditar2').value.trim();

        // Validamos que la agresividad sea un número y no mayor a 10
        if (isNaN(agresividadMascotaEditar) || agresividadMascotaEditar < 0 || agresividadMascotaEditar > 10) {
            Swal.fire({
                title: 'Error',
                text: 'La agresividad debe ser un número entre un rango de 0 a 10',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
            return; // Detenemos la ejecución de la función si la validación falla
        }

        // Resto de la validación
        if (nombreMascotaEditar === '' || especieMascotaEditar === '' || razaMascotaEditar === '' || fechaNacimientoMascotaEditar === '' || agresividadMascotaEditar === '' || descripcionMascotaEditar === '' || fotoMascotaEditar === '' || fotoMascotaEditar2 === '') {
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
                text: 'La información de la mascota se ha actualizado correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.isConfirmed) {
                    formularioEdicionMascotas.submit();
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


function validarFormularioRegistroMascotas() {
    // Seleccionamos el formulario por su ID
    const formularioRegistroMascotas = document.getElementById('formularioRegistroMascotas');

    // Agregamos un evento submit al formulario
    formularioRegistroMascotas.addEventListener('submit', function (e) {
        // Prevenimos el envío del formulario por defecto
        e.preventDefault();

        // Validamos que todos los campos obligatorios estén completos
        const nombre = document.getElementById('nombre').value.trim();
        const raza = document.getElementById('raza').value.trim();
        const fechaNacimiento = document.getElementById('fechaNacimiento').value.trim();
        let agresividad = document.getElementById('agresividad').value.trim(); // Convertimos a cadena para evitar problemas con parseInt
        const descripcion = document.getElementById('descripcion').value.trim();
        const fotoMascota = document.getElementById('fotoMascota').value.trim();
        const fotoMascota2 = document.getElementById('fotoMascota2').value.trim();

        // Validamos que la agresividad sea un número y no mayor a 10
        if (isNaN(agresividad) || agresividad < 0 || agresividad > 10) {
            Swal.fire({
                title: 'Error',
                text: 'La agresividad debe ser un número entre un rango de 0 a 10',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
            return; // Detenemos la ejecución de la función si la validación falla
        }

        // Resto de la validación
        if (nombre === '' || raza === '' || fechaNacimiento === '' || agresividad === '' || descripcion === '' || fotoMascota === '' || fotoMascota2 === '') {
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
        const nombreMascotaEditar = document.getElementById('nombreMascotaEditar').value.trim();
        const razaMascotaEditar = document.getElementById('razaMascotaEditar').value.trim();
        const fechaNacimientoMascotaEditar = document.getElementById('fechaNacimientoMascotaEditar').value.trim();
        let agresividadMascotaEditar = document.getElementById('agresividadMascotaEditar').value.trim(); // Convertimos a cadena para evitar problemas con parseInt
        const descripcionMascotaEditar = document.getElementById('descripcionMascotaEditar').value.trim();
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
        if (nombreMascotaEditar === '' || razaMascotaEditar === '' || agresividad === '' || fechaNacimientoMascotaEditar === '' || descripcionMascotaEditar === '' || fotoMascotaEditar === '' || fotoMascotaEditar2 === '') {
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


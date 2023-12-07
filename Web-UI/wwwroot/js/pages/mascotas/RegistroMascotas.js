function validarFormularioRegistroMascotas() {
    const formularioRegistroMascotas = document.getElementById('formularioRegistroMascotas');

    formularioRegistroMascotas.addEventListener('submit', function (e) {
        e.preventDefault();

        const nombreMascota = document.getElementById('txtInputNombreMascota').value.trim();
        const especieMascota = document.getElementById('selectBoxEspecie').value.trim();
        const razaMascota = document.getElementById('txtInputRaza').value.trim();
        const fechaNacimientoMascota = document.getElementById('txtInputFechaNacimiento').value.trim();
        const agresividadMascota = parseFloat(document.getElementById('txtInputAgresividad').value.trim());
        const descripcionMascota = document.getElementById('txtInputDescripcion').value.trim();
        const fotoMascota = document.getElementById('fotoMascota').value.trim();
        const fotoMascota2 = document.getElementById('fotoMascota2').value.trim();

        if (isNaN(agresividadMascota) || agresividadMascota < 0 || agresividadMascota > 10) {
            Swal.fire({
                title: 'Error',
                text: 'La agresividad debe ser un número entre un rango de 0 a 10',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
            return;
        }

        if (nombreMascota === '' || especieMascota === '' || razaMascota === '' || fechaNacimientoMascota === '' || agresividadMascota === '' || descripcionMascota === '' || fotoMascota === '' || fotoMascota2 === '') {
            Swal.fire({
                title: 'Error',
                text: 'Por favor completa todos los campos de información, son obligatorios',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
        } else {
            Swal.fire({
                title: 'Formulario enviado',
                text: 'Su mascota se ha registrado correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.isConfirmed) {
                    registrarMascota();
                }
            });
        }
    });
}


function registrarMascota() {
    var mascota = {
        id: 0,
        cliente: {
            id: 6,
            email: "string",
          contrasena: "string",
          nombre: "string",
          primerApellido: "string",
          segundoApellido: "string",
          documentoIdentidad: "string",
          telefono: "string",
          direccionMapa: "string",
          foto: "string",
        rol: {
            id: 0,
            nombreRol: "string"
        },
        estadoInfo: {
            id: 0,
            nombreEstado: "string"
        },
        otp: 0
        
        },
        nombreMascota: $("#txtInputNombreMascota").val(),
        descripcion: $("#txtInputDescripcion").val(),
        fechaNacimiento: $("#txtInputFechaNacimiento").val(),
        raza: $("#txtInputRaza").val(),
        agresividad: parseInt($("#txtInputAgresividad").val()),
        foto1: "foto1.png",
        foto2: "foto2.png",
        estado: {
            id: 1,
            nombreEstado: "string"
        },
        especie: $("#selectBoxEspecie").val()
    };

    const apiUrl = API_URL_BASE + "/api/Mascotas/CreateMascota";

    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        method: 'POST',
        url: apiUrl,
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(mascota),
        hasContent: true
    }).done(function (data) {
        Swal.fire({
            title: 'Éxito',
            icon: 'success',
            text: 'Mascota registrada exitosamente.'
        });
        // Puedes limpiar el formulario o realizar otras acciones después del registro
    }).fail(function (error) {
        Swal.fire({
            title: 'Error!',
            icon: 'error',
            text: 'Hubo un error al registrar la mascota. Por favor, verifica que todos los campos están completos.'
        });
    });
}



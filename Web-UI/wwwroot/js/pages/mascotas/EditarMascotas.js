function validarFormularioEdicionMascotas() {
    // Seleccionamos el formulario por su ID
    const formularioEdicionMascotas = document.getElementById('formularioEdicionMascotas');

    // Agregamos un evento submit al formulario
    formularioEdicionMascotas.addEventListener('submit', function (e) {
        // Prevenimos el envío del formulario por defecto
        e.preventDefault();

        // Validamos que todos los campos obligatorios estén completos
        const nombreMascotaEditar = document.getElementById('txtInputNombreMascotaEditar').value.trim();
        const especieMascotaEditar = document.getElementById('selectBoxEspecie').value.trim();
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
                    const mascotaIdSeleccionada = localStorage.getItem('mascotaIdSeleccionada');
                    UpdateMascota(mascotaIdSeleccionada);
                       
                }
            });
        }
    });
}

var objMascota;

function cargarDatosMascotaEnFormulario(mascotaId) {
    const apiUrlE = API_URL_BASE + "/api/Mascotas/GetMascotaPorId?id=" + mascotaId;

    $.ajax({
        method: 'GET',
        url: apiUrlE,
        dataType: 'json'
    })
        .done(function (mascota) {

            objMascota = mascota;



            const fechaNacimiento = new Date(mascota.fechaNacimiento);
            const formatoFecha = fechaNacimiento.toISOString().split('T')[0];

            $('#txtInputNombreMascotaEditar').val(mascota.nombreMascota);
            $('#selectBoxEspecie').val(mascota.especie);
            $('#txtInputRazaMascotaEditar').val(mascota.raza);
            $('#dateInputFechaNacimientoMascotaEditar').val(formatoFecha);
            $('#numberInputAgresividadMascotaEditar').val(mascota.agresividad);
            $('#selectBoxEstado').val(mascota.estado.nombreEstado);
            $('#txtInputDescripcionMascotaEditar').val(mascota.descripcion);

            // También puedes mostrar las imágenes si la mascota tiene fotos asociadas
            //mostrarImagen(null, 'imagenMascota', mascota.foto1);
            //mostrarImagen(null, 'imagenMascota2', mascota.foto2);

            // Almacena el ID de la mascota en el formulario para su posterior uso
            formularioEdicionMascotas.setAttribute('data-mascota-id', mascotaId);
        })
        .fail(function (error) {
            console.error('Error al cargar los datos de la mascota:', error);
        });
}

function UpdateMascota(mascotaId) {
    var estado = 1;

    // Verificar el estado seleccionado
    var estadoUpdate = $('#selectBoxEstado').val();
    if (estadoUpdate === "Inactivo") {
        estado = 2;
    }
    
    console.log(objMascota)


    var fechaNacimientoString = $("#dateInputFechaNacimientoMascotaEditar").val();
    var fechaNacimientoObj = new Date(fechaNacimientoString);

    var mascota = {
        id: objMascota.id,
        cliente: {
            id: objMascota.cliente.id,
            email: "string",
            contrasena: "string",
            nombre: "string",
            apellido1: "string",
            apellido2: "string",
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
            otp: "string"

        },
        nombreMascota: $("#txtInputNombreMascotaEditar").val(),
        descripcion: $("#txtInputDescripcionMascotaEditar").val(),
        fechaNacimiento: fechaNacimientoObj,
        raza: $("#txtInputRazaMascotaEditar").val(),
        agresividad: parseInt($("#numberInputAgresividadMascotaEditar").val()),
        foto1: "foto1.png",
        foto2: "foto2.png",
        estado: {
            id: estado,
            nombreEstado: "string"
        },
        especie: $("#selectBoxEspecie").val()
    };

    const apiUrl = API_URL_BASE + "/api/Mascotas/UpdateMascota";

    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        method: 'PUT',
        url: apiUrl,
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(mascota),
        success: function (data) {
            console.log('Mascota actualizada con éxito', data);
        },
        error: function (error) {
            console.error('Error al actualizar la mascota:', error);
        }
    });
}


function validarFormularioEdicionPerfil() {
    // Seleccionamos el formulario por su ID
    const formularioEdicionPerfil = document.getElementById('formularioEdicionPerfil');

    // Agregamos un evento submit al formulario
    formularioEdicionPerfil.addEventListener('submit', function (e) {
        // Prevenimos el envío del formulario por defecto
        e.preventDefault();

        // Validamos que todos los campos obligatorios estén completos
        const correoElectronicoEditar = document.getElementById('txtInputCorreoElectronicoEditar').value.trim();
        const telefonoEditar = document.getElementById('txtInputTelefonoEditar').value.trim();
        const direccionEditar = document.getElementById('txtInputDireccionEditar').value.trim();
        const fotoPerfilEditar = document.getElementById('fotoPerfilEditar').value.trim();

        // Resto de la validación
        if (correoElectronicoEditar === '' || telefonoEditar === '' || direccionEditar === '' || fotoPerfilEditar === '') {
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
                    const usuarioIdSeleccionada = localStorage.getItem('usuarioIdSeleccionada');
                    UpdatePerfil(usuarioIdSeleccionada);

                }
            });
        }
    });
}



function cargarDatosUsuarioEnFormulario(usuarioId) {
    const apiUrlE = API_URL_BASE + "/api/Admin/GetUsuarioPorId?id=" + usuarioId;

    $.ajax({
        method: 'GET',
        url: apiUrlE,
        dataType: 'json'
    })
        .done(function (usuario) {
            

            $('#txtInputCorreoElectronicoEditar').val(usuario.email);
            $('#txtInputTelefonoEditar').val(usuario.telefono);
            $('#txtInputDireccionEditar').val(usuario.direccionMapa);
            $('#fotoPerfilEditar').val(usuario.foto);

            // También puedes mostrar las imágenes si la mascota tiene fotos asociadas
            //mostrarImagen(null, 'imagenMascota', mascota.foto1);
            //mostrarImagen(null, 'imagenMascota2', mascota.foto2);

            // Almacena el ID de la mascota en el formulario para su posterior uso
            formularioEdicionPerfil.setAttribute('data-perfil-id', usuarioId);
        })
        .fail(function (error) {
            console.error('Error al cargar los datos del usuario:', error);
        });
}

function UpdatePerfil(usuarioId) {
    var estado = 1;

    // Verificar el estado seleccionado
    var estadoUpdate = $('#selectBoxEstado').val();
    if (estadoUpdate === "Inactivo") {
        estado = 2;
    }

    var usuario = {
            id: usuarioId,
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

        
        
    };

    const apiUrl = API_URL_BASE + "/api/Admin/UpdateUsuario";

    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        method: 'PUT',
        url: apiUrl,
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(usuario),
        success: function (data) {
            console.log('Usuario actualizado con éxito', data);
        },
        error: function (error) {
            console.error('Error al actualizar el usuario:', error);
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
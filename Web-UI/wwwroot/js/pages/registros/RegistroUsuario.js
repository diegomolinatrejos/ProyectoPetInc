function RegistroUsuario() {
    //Init view nos va a permitir inicializar funciones y eventos
    console.log("entrar metodo")    
    this.InitView = function () {
        $('#btnRegistrar').click(function () {
 
            var view = new RegistroUsuario();
            view.SubmitUserToCreate();
        });
    }

    this.SubmitUserToCreate = function () {
        //usuario
        var usuario = {};
        usuario.email = $('#txtCorreoElectronico').val();
        usuario.contrasena = "132";
        usuario.nombre = $('#txtNombre').val();
        usuario.apellido1 = $('#txtPrimerApellido').val();
        usuario.apellido2 = $('#txtSegundoApellido').val();
        usuario.documentoIdentidad = $('#txtDocumentoIdentidad').val();
        usuario.telefono = $('#txtTelefono').val();
        usuario.direccionMapa = $('#txtDireccion').val();
        usuario.foto = $('#txtFoto').val();

        usuario.rol = {
            "id": 1,
            "nombreRol": "string"
        };

        usuario.estadoInfo = {
            "id": 1,
            "nombreEstado": "string"
        };

        usuario.otp = 0;
   
        

        //llamar al API para crear el usuario
        console.log("usuario", usuario);

        var apiUrl = API_URL_BASE + "/api/Admin/CreateUsuario";

        //Enviar los datos al API para que cree el Usuario
        console.log("usuario", usuario);
        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: apiUrl,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            data: JSON.stringify(usuario),
            hasContent: true

        }).done(function (data) {
            console.log(data);
            Swal.fire({
                title: "Success",
                icon: 'info',
                text: 'El usuario fue creado exitosamente'
            });
        }).fail(function (error) {
            console.log(error);
            Swal.fire({
                title: "Error",
                icon: 'error',
                text: 'Hubo un error al crear el usuario'
            });
        });
    }
}

$(document).ready(function () {
    var view = new RegistroUsuario();
    view.InitView();
});

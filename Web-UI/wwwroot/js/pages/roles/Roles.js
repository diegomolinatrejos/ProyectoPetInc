function AsignacionRoles() {
    //Init view nos va a permitir inicializar funciones y eventos

    this.InitView = function () {
        $('#btnGuardar').click(function () {
            //Llamar el metodo que ejecuta ese click del boton
            var view = new AsignacionRoles();
            view.SubmitRol();
        });

        this.PopulateUsuarios();
        this.PopulateRoles();
    }

    this.SubmitRol = function () {
        var asignacion = {};
        //Usuario
        asignacion.usuarioInfo = {};
        asignacion.usuarioInfo.id = $('#usuarioName').find(":selected").val();


        //AUTHOR_LIST Esta declarada en el file site.js para poder utilizarla globalmente si se necesita
        var usuario = USUARIO_LIST.find(us => {
            return us.id === parseInt($('#usuarioName').val());
        });

        asignacion.usuarioInfo.nombre = usuario.nombre;
        asignacion.usuarioInfo.apellido1 = usuario.apellido1;
        asignacion.usuarioInfo.apellido2 = usuario.apellido2;

        //Rol
        asignacion.rolInfo = {};
        asignacion.rolInfo.id = $('#rolName').find(":selected").val();


        //ROLES_LIST Esta declarada en el file site.js para poder utilizarla globalmente si se necesita
        var usuario = ROL_LIST.find(rol => {
            return rol.id === parseInt($('#rolName').val());
        });

        asignacion.rolInfo.nombreRol = usuario.nombreRol;
        

        //llamar al API para asignar el rol
        

        var apiUrl = API_URL_BASE + "/api/Admin/AssignRolToUsuario";

        //Enviar los datos al API para que cree el Articulo
        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: apiUrl,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            data: JSON.stringify(article),
            hasContent: true
        }).done(function (data) {
            Swal.fire({
                title: "Success",
                icon: 'info',
                text: 'The Article was created succesfully'
            });
        }).fail(function (error) {
            Swal.fire({
                title: "Message",
                icon: 'error',
                text: 'There was an error creating the Article'
            });
        });
    }

    this.PopulateUsuarios = function () {
        var apiUrl = API_URL_BASE + "/api/Admin/GetUsuarios";

        $.ajax({
            url: apiUrl,
            method: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json"
        }).done(function (data) {
            //Guardar la lista y popular el dropdown
            //USUARIO_LIST Esta declarada en el file site.js para poder utilizarla globalmente si se necesita
            USUARIO_LIST = data;

            var select = $('#usuarioName');
            select.find('option').remove();

            for (var row in data) {
                select.append('<option value=' + data[row].id + '>' + data[row].nombre + ' ' + data[row].apellido1 + ' ' + data[row].apellido2 + '</option>')
            }
        }).fail(function (error) {
            alert('ERROR!!');
        });
    }

    this.PopulateRoles = function () {
        var apiUrl = API_URL_BASE + "/api/Rol/GetRoles";

        $.ajax({
            url: apiUrl,
            method: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json"
        }).done(function (data) {
            //Guardar la lista y popular el dropdown
            //ROL_LIST Esta declarada en el file site.js para poder utilizarla globalmente si se necesita
            ROL_LIST = data;

            var select = $('#rolName');
            select.find('option').remove();

            for (var row in data) {
                select.append('<option value=' + data[row].id + '>' + data[row].nombreRol + '</option>')
            }
        }).fail(function (error) {
            alert('ERROR!!');
        });
    }
}

$(document).ready(function () {
    var view = new AsignacionRoles();
    view.InitView();
});
function validarFormularioRegistroServicios() {
    const formularioRegistroServicios = document.getElementById('formularioRegistroServicios');

    formularioRegistroServicios.addEventListener('submit', function (e) {
        e.preventDefault();

        const nombreServicio = document.getElementById('txtInputNombreServicio').value.trim();
        const descripcionServicio = document.getElementById('txtInputDescripcionServicio').value.trim();
        const precioServicio = document.getElementById('txtInputPrecioServicio').value.trim();

        if (nombreServicio === '' || descripcionServicio === '' || precioServicio === '') {
            Swal.fire({
                title: 'Error',
                text: 'Por favor completa todos los campos de información, son obligatorios',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            });
        } else {
            registrarServicio();
        }
    });
}

function registrarServicio() {
    var servicio = {
        id: 0,
        nombreServicio: $("#txtInputNombreServicio").val(),
        descripcion: $("#txtInputDescripcionServicio").val(),
        precio: parseFloat($("#txtInputPrecioServicio").val()),
        estado: {
            id: 1,
            nombreEstado: "string"
        }
    };

    console.log(servicio);

    const apiUrl = API_URL_BASE + "/api/Servicios/CreateServicio";

    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        method: 'POST',
        url: apiUrl,
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(servicio),
        hasContent: true
    }).done(function (data) {
        Swal.fire({
            title: 'Éxito',
            icon: 'success',
            text: 'Servicio registrado exitosamente.',
            didClose: () => {

                document.getElementById('formularioRegistroServicios').submit();
            }
        });
    }).fail(function (error) {
        Swal.fire({
            title: 'Error!',
            icon: 'error',
            text: 'Hubo un error al registrar el servicio.'
        });
    });
}
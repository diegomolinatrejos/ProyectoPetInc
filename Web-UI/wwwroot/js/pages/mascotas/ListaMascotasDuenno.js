function cargarMascotas() {
    var idUsuario = $("#idUsuario").attr("data-id");

    // Mostrar indicador de carga
    // Puedes usar un spinner o cualquier otro indicador visual
    // Muestra un mensaje o icono de carga para informar al usuario que se están cargando los datos
    console.log("ID del usuario:", idUsuario);
    // Realizar la solicitud GET
    const apiUrl = API_URL_BASE + "/api/Mascotas/GetMascotaPorIdDelDuenno?idDuenno=" + idUsuario;

    // Utilizar jQuery para realizar la solicitud AJAX
    $.ajax({
        method: 'GET',
        url: apiUrl,
        dataType: 'json'
    })
        .done(function (data) {
            // Limpiar la tabla antes de agregar nuevas filas
            const tablaMascotasBody = $('#tablaMascotasBody');
            tablaMascotasBody.empty();

            // Iterar sobre las mascotas y agregar filas a la tabla
            data.forEach(function (mascota) {
                const fila = `
                <tr class="table-active">
                    <td>${mascota.nombreMascota}</td>
                    <td>${mascota.raza}</td>
                    <td>${calcularEdad(mascota.fechaNacimiento)}</td>
                    <td>${mascota.agresividad}</td>
                    <td>${mascota.estado.nombreEstado}</td>
                    <td>
                        <a asp-controller="Mascotas" asp-action="EdicionMascotas" type="submit" class="btn btn-primary" id="boton-enviar">Editar</a>
                    </td>
                </tr>`;
                tablaMascotasBody.append(fila);
            });
        })
        .fail(function (error) {
            console.error('Error al cargar las mascotas:', error);
        })
        .always(function () {

        });
}

function calcularEdad(fechaNacimiento) {
    const fechaNacimientoDate = new Date(fechaNacimiento);
    const fechaActual = new Date();

    const milisegundosEnUnDia = 24 * 60 * 60 * 1000;
    const diferenciaEnMilisegundos = fechaActual - fechaNacimientoDate;

    const anios = Math.floor(diferenciaEnMilisegundos / (milisegundosEnUnDia * 365));
    const meses = Math.floor((diferenciaEnMilisegundos % (milisegundosEnUnDia * 365)) / (milisegundosEnUnDia * 30));
    const dias = Math.floor((diferenciaEnMilisegundos % (milisegundosEnUnDia * 30)) / milisegundosEnUnDia);

    let edadTexto = '';

    if (anios > 0) {
        edadTexto += `${anios} ${anios === 1 ? 'año' : 'años'}`;
    }

    if (meses > 0) {
        if (anios > 0) {
            edadTexto += ' ';
        }
        edadTexto += `${meses} ${meses === 1 ? 'mes' : 'meses'}`;
    }

    if (dias > 0) {
        if (anios > 0 || meses > 0) {
            edadTexto += ' ';
        }
        edadTexto += `${dias} ${dias === 1 ? 'día' : 'días'}`;
    }

    console.log(edadTexto);
    return edadTexto.trim();
}

// Llamar a la función para cargar las mascotas al cargar la página
$(document).ready(function () {
    cargarMascotas();
});
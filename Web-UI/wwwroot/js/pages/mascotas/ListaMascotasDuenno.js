function cargarMascotas() {
    var idUsuario = $("#idUsuario").attr("data-id");
    console.log("ID del usuario:", idUsuario);
    const apiUrl = API_URL_BASE + "/api/Mascotas/GetMascotaPorIdDelDuenno?idDuenno=" + idUsuario;

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
                    <td class="hidden">${mascota.id}</td>
                    <td>${mascota.nombreMascota}</td>
                    <td>${mascota.especie}</td>
                    <td>${mascota.raza}</td>
                    <td>${calcularEdad(mascota.fechaNacimiento)}</td>
                    <td>${mascota.agresividad}</td>
                    <td>${mascota.estado.nombreEstado}</td>
                    <td>
                     <a href="#" class="btn btn-primary boton-editar" data-id-mascota="${mascota.id}">Editar</a>
                    </td>
                </tr>`;
                tablaMascotasBody.append(fila);


                $('.boton-editar').on('click', function (e) {
                    e.preventDefault(); // Prevenir el comportamiento predeterminado del enlace
                    var mascotaId = $(this).closest('tr').find('td.hidden').text();

                    console.log(mascotaId);
                    cargarDatosMascotaEnFormulario(mascotaId);
                });
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



function cargarDatosMascotaEnFormulario(mascotaId) {

    localStorage.setItem('mascotaIdSeleccionada', mascotaId);

    window.location.href = '/Mascotas/EdicionMascotas';
}


$(document).ready(function () {
    cargarMascotas();
});


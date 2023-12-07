document.addEventListener('DOMContentLoaded', function () {
    var subtotalA = 0;
    var serviciosSeleccionados = [];

    // Función para cargar servicios y mostrarlos en una tabla
    function cargarServicios() {
        const apiUrl = API_URL_BASE + "/api/Servicios/GetServicios";

        $.ajax({
            method: 'GET',
            url: apiUrl,
            dataType: 'json'
        })
            .done(function (data) {
                const bodyTablaServicios = $('#bodyTablaServicios');
                bodyTablaServicios.empty();

                data.forEach(function (servicio) {
                    const fila = `
                    <tr class="table-active">
                        <td>${servicio.nombreServicio}</td>
                        <td>${servicio.descripcion}</td>
                        <td class="precio-servicio">₡${servicio.precio}</td>
                        <td>
                            <input class="form-check-input checkbox-servicio" type="checkbox" id="checkbox${servicio.id}" data-id-servicio="${servicio.id}">
                        </td>
                    </tr>`;
                    bodyTablaServicios.append(fila);
                });
            })
            .fail(function (error) {
                console.error('Error al cargar los servicios:', error);
            });
    }

    // Función para obtener los servicios seleccionados en la tabla
    // Función para obtener los servicios seleccionados en la tabla
    function obtenerServiciosSeleccionados() {
        serviciosSeleccionados = [];
        subtotalA = 0; // Reinicia el subtotal

        const checkboxes = document.querySelectorAll('.checkbox-servicio:checked');

        checkboxes.forEach(function (checkbox) {
            const servicioId = parseInt(checkbox.dataset.idServicio, 10); // Aqui lo que se hace es que se convierte a integer el id del servicio que se almaceno data-id-servicio="${servicio.id}" de cada fila y de cada servicio
            const servicio = ObtenerServicioId(servicioId);
            serviciosSeleccionados.push(servicio);
            subtotalA += servicio.precio;
        });

        actualizarSubtotalEnFormulario();

        return serviciosSeleccionados;
    }


    //Esta es la logica para traer la info de cada servicio seleccionado // SE PUEDE SIMPLIFICAR OBTENIENDO DATOS DE LA TABLA SIN IR AL API SI DA TIEMPO
    function ObtenerServicioId(servicioId) {
        const apiUrl = API_URL_BASE + "/api/Servicios/GetServicioPorId?id=" + servicioId;

        $.ajax({
            method: 'GET',
            url: apiUrl,
            dataType: 'json'
        })
            .done(function (servicio) {
                objServicio = {
                    id: servicio.id,
                    nombreServicio: servicio.nombreServicio,
                    descripcion: servicio.descripcion,
                    precio: servicio.precio,
                    estado: servicio.estado.id
                };

                return objServicio;
            })
            .fail(function (error) {
                console.error('Error al cargar los datos del servicio:', error);
            });
    }



    // Función para actualizar el campo de subtotal en el formulario
    function actualizarSubtotalEnFormulario() {
        const subtotalInput = document.querySelector('#subtotal');
        subtotalInput.value = `₡${subtotalA.toFixed(2)}`;
    }

    // Función para validar el formulario de creación de paquetes
    function validarFormularioCrearPaquete() {
        const formularioCrearPaquete = document.getElementById('formularioRegistroPaquetes');

        formularioCrearPaquete.addEventListener('submit', function (e) {
            e.preventDefault();

            var nombrePaquete = $("#nombrePaquete").val();

            if (nombrePaquete === '') {
                Swal.fire({
                    title: 'Información Incompleta!',
                    icon: 'error',
                    text: 'Por favor ingrese un nombre para el paquete.'
                });
            } else if (serviciosSeleccionados.length === 0) {
                Swal.fire({
                    title: 'Información Incompleta!',
                    icon: 'error',
                    text: 'Por favor seleccione al menos un servicio para el paquete.'
                });
            } else {
                registrarPaquete();
            }
        });
    }

    // Función para registrar un paquete
    function registrarPaquete() {
        var paquete = {
            id: 0,
            nombrePaquete: $("#nombrePaquete").val(),
            subtotal: subtotalA,
            precioTotal: 0,
            servicios: serviciosSeleccionados,
            estado: {
                id: 1,
                nombreEstado: "string"
            }
        };

        const apiUrl = API_URL_BASE + "/api/Paquete/CreatePaquete";

        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: 'POST',
            url: apiUrl,
            contentType: 'application/json;charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(paquete),
            hasContent: true
        })
            .done(function (data) {
                Swal.fire({
                    title: 'Éxito',
                    icon: 'success',
                    text: 'Paquete registrado exitosamente.',
                    didClose: () => {
                        document.getElementById('formularioRegistroPaquetes').submit();
                    }
                });
            })
            .fail(function (error) {
                Swal.fire({
                    title: 'Error!',
                    icon: 'error',
                    text: 'Hubo un error al registrar el paquete.'
                });
            });
    }

    // Evento al hacer clic en el botón de añadir servicios
    $('#botonServicios').on('click', function (e) {
        e.preventDefault();
        obtenerServiciosSeleccionados();
        Swal.fire({
            title: 'Servicios Añadidos',
            icon: 'success',
            text: 'Los servicios han sido añadidos al paquete.'
        });
    });

    // Llama a las funciones necesarias al cargar el documento
    $(document).ready(function () {
        cargarServicios();
        validarFormularioCrearPaquete();
    });
});
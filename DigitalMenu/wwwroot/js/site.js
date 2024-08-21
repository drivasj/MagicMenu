
function LoadMainPage(controller,action) {
    // Mostrar el indicador de carga (si lo tienes)
    //$('#loading-indicator').show();

    // Construir la URL completa
    //const url = `/${controller}/${action}`;

    const url = window.location.protocol + '//' + window.location.host + '/' + controller + '/' + action;

    fetch(url)
        .then(response => response.text())
        .then(data => {
            // Actualizar el contenido de la sección principal
            $('#content-section').html(data);
            successSwal('');
            // Ocultar el indicador de carga
            //$('#loading-indicator').hide();
        })
        .catch(error => {
            //console.error('Error al cargar la página:', error);
            ErrorSwal('Error al cargar la página:', error);
            // Mostrar un mensaje de error al usuario
            $('#content-section').html('Ocurrió un error al cargar la página.');
        });
}
function successSwal(message) {
    Swal.fire({
        position: "top",
        icon: "success",
        title: message,
        showConfirmButton: false,
        timer: 2500
    });
}

function ErrorSwal(message) {
    Swal.fire({
        position: "top",
        icon: "error",
        title: message,
        showConfirmButton: false,
        timer: 2500
    });
}

function closeModal(idModal) {
    let modal = bootstrap.Modal.getInstance(document.getElementById(idModal));
    modal.hide();
}
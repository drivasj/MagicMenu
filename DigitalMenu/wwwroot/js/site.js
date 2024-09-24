
function LoadMainPage(controller, action) {
    // RemoveMenu();
    Loading();
    const url = window.location.protocol + '//' + window.location.host + '/' + controller + '/' + action;

    fetch(url)
        .then(response => response.text())
        .then(data => {
            RemoveLoading();
            $('#content-section').html(data);
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error al cargar la página:', error);
            $('#content-section').html('Ocurrió un error al cargar la página.');
        });
}

function SessionSigOut() {

    fetch('/Administrator/logout', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: null
    })
}

function successSwal(message) {
    Swal.fire({
        position: "top",
        icon: "success",
        title: message,
        showConfirmButton: false,
        timer: 1500
    });
}

function ErrorSwal(message) {
    Swal.fire({
        position: "top",
        icon: "error",
        title: message,
        showConfirmButton: false,
        timer: 1500
    });
}

function closeModal(idModal) {
    let modal = bootstrap.Modal.getInstance(document.getElementById(idModal));
    modal.hide();
}

function Loading() {
    document.getElementById('staticBackdropLoading').style.display = 'block';
    document.getElementById('staticBackdropLoading').focus({ focusVisible: false });
}

function RemoveLoading() {
    document.getElementById('staticBackdropLoading').style.display = 'none';
}

function RemoveMenu() {

    const offcanvasElement = document.getElementById('OffcanvasMenu');
    const offcanvas = bootstrap.Offcanvas.getInstance(offcanvasElement);

    offcanvas.hide();
}

function HacerAdmin(userName) {
    console.log(userName);
    Loading();
    const data = getModelMenu();

    fetch('/Administrator/HacerAdmin', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            userName: userName.value
        })
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                RemoveLoading();
                successSwal(data.message);
                LoadMainPage('Administrator', 'Users');
            } else {
                RemoveLoading();
                ErrorSwal(data.message);
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
        });
}

function ShowModalBootstrapEvent(elementId, settingModal) {

    var elem = document.getElementById(elementId);

    if (typeof (elem) != 'undefined' && elem != null) {

        elem.addEventListener('hidden.bs.modal', function (event) {
            let firstRemove = false;

            if (elem.hasAttribute("data-modalfirst")) {
                firstRemove = true;
            }

            if (this.id == event.target.id) {
                if (typeof (elem) != 'undefined' && elem != null) elem.parentElement.innerHTML = '';
            }

            if (firstRemove) {
                $(".modal-backdrop fade show").remove();
            }
        });

        if (typeof (settingModal) == 'undefined' || settingModal == null) {

            return new bootstrap.Modal(elem).show();
        }

        return new bootstrap.Modal(elem, settingModal).show();
    }
    else {
        ErrorSwal("Error al intentar iniciar el modal, elemento no encontrado.");
    }
}


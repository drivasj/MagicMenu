
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
        timer: 2500
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

/*
funciones del páginado
*/
function LoadPagedList(controller, action, page, panelUpdate, filter) {
    $.ajax({
        url : window.location.protocol + '//' + window.location.host + '/' + controller + '/' + action,
        type: 'Post',
        data: { filter: filter, page: page, pageInitial: $("#PagedListPageInicial").val() },
        async: true,
        cache: false,
        beforeSend: function () {
            Loading();
        },
        success: function (data) {
            RemoveLoading();
            $("#" + panelUpdate).html(data);
        },
        error: function () {
            RemoveLoading();
            ErrorSwal('warning', 'No se pudo cargar la página');
        }
    });
}

function LoadNextPagedList(controller, action, panelUpdate, filter) {
    var operador1, operador2;
    operador1 = parseInt($("#PagedListPageInicial").val());
    operador2 = 10;
    var result = operador1 + operador2;
    $.ajax({
        url: window.location.protocol + '//' + window.location.host + '/' + controller + '/' + action,
        type: 'Post',
        data: { filter: filter, page: result, pageInitial: result },
        async: true,
        cache: false,
        beforeSend: function () {
            Loading();
        },
        success: function (data) {
            RemoveLoading();
            $("#" + panelUpdate).html(data);
        },
        error: function () {
            RemoveLoading();
            ErrorSwal('warning', 'No se pudo cargar la página LoadNextPagedList');
        }
    });
}

function LoadLastPagedList(controller, action, panelUpdate, filter) {
    var operador1, operador2, operador3, resta, multiplicacion, pageResult;
    operador1 = parseInt($("#PagedListPageTotal").val());
    operador2 = 10;
    operador3 = 1;
    resta = operador1 / operador2;
    multiplicacion = Math.floor(resta) * operador2;
    pageResult = multiplicacion + operador3;
    $.ajax({
        url : window.location.protocol + '//' + window.location.host + '/' + controller + '/' + action,
        type: 'Post',
        data: { filter: filter, page: operador1, pageInitial: pageResult },
        async: true,
        cache: false,
        beforeSend: function () {
            Loading();
        },
        success: function (data) {
            RemoveLoading();
            $("#" + panelUpdate).html(data);
        },
        error: function () {
            RemoveLoading();
            ErrorSwal('warning', 'No se pudo cargar la página LoadLastPagedList');
        }
    });
}

function LoadFirstPagedList(controller, action, panelUpdate, filter) {

    $.ajax({
        url: window.location.protocol + '//' + window.location.host + '/' + controller + '/' + action,
        type: 'Post',
        data: { filter: filter, page: 1, pageInitial: 1 },
        async: true,
        cache: false,
        beforeSend: function () {
            Loading();
        },
        success: function (data) {
            RemoveLoading();
            $("#" + panelUpdate).html(data);
        },
        error: function () {
            RemoveLoading();
            ErrorSwal('warning', 'No se pudo cargar la página LoadFirstPagedList');
        }
    });
}

function LoadPreviousPagedList(controller, action, panelUpdate, filter) {
    var operador1, operador2;
    operador1 = parseInt($("#PagedListPageInicial").val());
    operador2 = 10;
    var result = operador1 - operador2;

    $.ajax({
        url: window.location.protocol + '//' + window.location.host + '/' + controller + '/' + action,
        type: 'Post',
        data: { filter: filter, page: result, pageInitial: result },
        async: true,
        cache: false,
        beforeSend: function () {
            Loading();
        },
        success: function (data) {
            RemoveLoading();
            $("#" + panelUpdate).html(data);
        },
        error: function () {
            RemoveLoading();
            ErrorSwal('warning', 'No se pudo cargar la página LoadPreviousPagedList');
        }
    });
}

///////////Metodos boton regresar////////////////

var dataBack = {};

function ResetDataBack() {
    if (dataBack === undefined || dataBack === null) {
        dataBack = {};
    }

    dataBack.Paged = {};
    dataBack.Filter = {};
    dataBack.typeRequest = '';
    dataBack.URL = '';
}

function AddDataBackPaged(numrow, page, pageInitial) {
    if (dataBack === undefined || dataBack === null || $.isEmptyObject(dataBack)) {
        ResetDataBack();
    }

    if (typeof numrow === "number" && typeof page === "number" && typeof pageInitial === "number") {
        dataBack.Paged = {};
        dataBack.Paged = {
            numrow: numrow,
            page: page,
            pageInitial: pageInitial
        };
    }
    else {
        delete dataBack.Paged;
    }
}

function AddDataBackURL(url, dataRequest = {}, typeRequest = '') {
    ResetDataBack();

    if (typeof dataRequest === "object") {
        dataBack.Filter = {};
        dataBack.Filter = dataRequest;
    }
    else {
        delete dataBack.Filter;

        ErrorSwal("error", "Error en el modulo de navegación. Puede presentar problemas al continuar. AddDataBackURL");

        return;
    }

    if (typeof url === "string") {
        dataBack.URL = "";
        dataBack.URL = url;

        dataBack.typeRequest = "";

        switch (typeRequest.toUpperCase()) {
            case "GET":
                dataBack.typeRequest = "Get";
                break;
            default:
                dataBack.typeRequest = "Post";
        }
    }
    else {
        delete dataBack.URL;
        delete dataBack.typeRequest;

        ErrorSwal("error", "Error en el modulo de navegación. Puede presentar problemas al continuar. AddDataBackURL");
    }
}

function ValidateDataBack() {
    if (dataBack === undefined || dataBack === null) {
        return false;
    }

    if (typeof dataBack !== "object") {
        return false;
    }

    if (!dataBack.hasOwnProperty('URL') || typeof dataBack.URL !== "string" || dataBack.URL === "") {
        return false;
    }

    if (!dataBack.hasOwnProperty('Filter') || typeof dataBack.Filter !== "object") {
        return false;
    }

    if (!dataBack.hasOwnProperty('Paged') || typeof dataBack.Paged !== "object") {
        return false;
    }

    return true;
}

function GetURLDataBack() {
    if (dataBack.hasOwnProperty('Paged') && !$.isEmptyObject(dataBack.Paged)) {
        return dataBack.URL + 'Paged';
    }

    return dataBack.URL;
}

function GetTypeRequestDataBack() {
    return dataBack.typeRequest;
}

function GetDataDataBack() {
    if (dataBack.hasOwnProperty('Paged') && !$.isEmptyObject(dataBack.Paged)) {
        return Object.assign({}, dataBack.Filter, dataBack.Paged);
    }

    return Object.assign({}, dataBack.Filter);
}

function ExecuteRequestUrlBack(urlParameters = {}) {

    if (!$.isEmptyObject(urlParameters)) {
        $.ajax({
            url: urlParameters.url,
            type: urlParameters.typeRequest,
            async: true,
            cache: false,
            beforeSend: function () {
                Loading();
            },
            success: function (data) {
                RemoveLoading();

              //  $("#MainContainer").html(data);
                $('#content-section').html(data);

            },
            error: function () {
                RemoveLoading();
                ErrorSwal('warning', 'No se puede realizar la operación, intente nuevamente. ExecuteRequestUrlBack' );
            }
        });

        return;
    }

    $.ajax({
        url: GetURLDataBack(),
        type: GetTypeRequestDataBack(),
        data: GetDataDataBack(),
        async: true,
        cache: false,
        beforeSend: function () {
            Loading();
        },
        success: function (data) {
            RemoveLoading();

            //$("#MainContainer").html(data);
            $('#content-section').html(data);
        },
        error: function () {
            RemoveLoading();
            ErrorSwal('warning', 'No se puede realizar la operación, intente nuevamente. ExecuteRequestUrlBack');
        }
    });
}

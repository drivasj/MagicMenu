function saveUser() {
    Loading();
    const data = modelUser();

    fetch('/Administrator/SaveUser', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: data
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                RemoveLoading();
                successSwal(data.message);
                closeModal("ModalNewUser");
                LoadMainPage('Administrator', 'Users');
            } else {
                RemoveLoading();
                ErrorSwal(data.message);
                closeModal("ModalNewUser");
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
            closeModal("ModalNewUser");
        });
}

function editUser() {
    Loading();
    const data = modelUserEdit();

    fetch('/Administrator/EditUser', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: data
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                RemoveLoading();
                successSwal(data.message);
                closeModal("ModalUserdetail");
                LoadMainPage('Administrator', 'Users');
            } else {
                RemoveLoading();
                ErrorSwal(data.message);
                closeModal("ModalNewUser");
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
            closeModal("ModalNewUser");
        });
}

//function ShowDetailUser(idUser) {
//    $.ajax({
//        url: '/Administrator/ShowDetailUser',
//        type: 'POST',
//        async: true,
//        data: { idUser: idUser },
//        cache: false,
//        beforeSend: function () {
//            Loading();
//        },
//        success: function (data) {
//            RemoveLoading();

//            $("#DetailUserContainer").html(data);
//            ShowModalBootstrapEvent('ModalUserdetail', null);
//        },
//        error: function () {
//            RemoveLoading();
//            $("#DetailUserContainer").remove();
//            ErrorSwal('No se puede realizar la operación.');
//        }
//    });
//}

async function ShowDetailUser(idUser) {
    try {
        Loading();

        const response = await fetch('/Administrator/ShowDetailUser', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: new URLSearchParams({ idUser }).toString()
        });

        if (response.ok) {
            const data = await response.text();
            $("#DetailUserContainer").html(data);
            ShowModalBootstrapEvent('ModalUserdetail', null);
        } else {
            $("#DetailUserContainer").remove();
            ErrorSwal('No se puede realizar la operación.');
        }

        RemoveLoading();
    } catch (error) {
        RemoveLoading();
        ErrorSwal('No se puede realizar la operación.');
    }
}

function modelUser() {

    return JSON.stringify({
        FirstName: $("#name").val(),
        MiddleName: $("#middleName").val(),
        LastName: $("#lastName").val(),
        MotherName: $("#motherName").val(),
        DocumentNR: $("#document").val(),
        Phone: $("#phone").val(),
        Email: $("#email").val(),
        IdRole: $("#role").val(),
        UserName: $("#userName").val(),
        Adress: $("#adress").val()
    });
}

function modelUserEdit() {

    return JSON.stringify({
        FirstName: $("#nameEdit").val(),
        IdEmployee: $("#idEmployee").val(),
        MiddleName: $("#middleNameEdit").val(),
        UserName: $("#userNameEdit").val(),
        Email: $("#emailEdit").val()
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
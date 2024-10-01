
function saveUser() {
    let control = validateUser();

    if (control) {
        _saveUser();
    } else {
        $(".needs-validation").addClass("was-validated");
    }
}
function _saveUser() {
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

function EditUser() {
    let control = validateUser();

    if (control) {
        _EditUser();
    } else {
        $(".needs-validation").addClass("was-validated");
    }
}

function _EditUser() {
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
                closeModal("ModalUserdetail");
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
            closeModal("ModalUserdetail");
        });
}

function validateUser() {

    let control = true;

    $(".needs-validation").addClass("was-validated");

    if ($("#name").val() == 0) {
        control = false;
        ErrorSwal("Seleccione una aplicación");
    }

    if ($("#lastName").val() == "") {
        control = false;
    }

    if ($("#document").val() == "") {
        control = false;
    }

    if ($("#phone").val() == "") {
        control = false;
    }

    if ($("#email").val() == "") {
        control = false;
    }

    if ($("#role").val() == "") {
        control = false;
    }

    if ($("#userName").val() == "") {
        control = false;
    }

    return control;
}

async function ShowCreateUser() {
    $(".textNewUser").val("");
    try {
        Loading();

        const response = await fetch('/Administrator/ShowCreateUser', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        });

        if (response.ok) {
            console.log("response Ok");
            const data = await response.text();
            $("#DetailUserContainer").html(data);
            ShowModalBootstrapEvent('ModalNewUser', null);
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
        MotherLastName: $("#motherName").val(),
        Document: $("#document").val(),
        Phone: $("#phone").val(),
        Email: $("#email").val(),
        IdRole: $("#role").val(),
        UserName: $("#userName").val(),
        Adress: $("#adress").val()
    });
}

function modelUserEdit() {

    return JSON.stringify({
        IdEmployee: $("#idEmployee").val(),
        FirstName: $("#name").val(),
        MiddleName: $("#middleName").val(),
        LastName: $("#lastName").val(),
        MotherName: $("#motherName").val(),
        MotherLastName: $("#motherName").val(),
        Document: $("#document").val(),
        Phone: $("#phone").val(),
        Email: $("#email").val(),
        IdRole: $("#role").val(),
        UserName: $("#userName").val(),
        Adress: $("#adress").val()
    });
}

function UpdateStateUser(idUser) {
    Swal.fire({
        title: "Do you want to save the changes?",
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: "Save",
        denyButtonText: `Don't save`
    }).then((result) => {
        if (result.isConfirmed) {
            _UpdateStateUser(idUser);
        } else if (result.isDenied) {
            Swal.fire("Changes are not saved", "", "info");
        }
    });
}

function _UpdateStateUser(idUser) {
    Loading();

    fetch('/Administrator/UpdateStateUser', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ IdEmployee: idUser })
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
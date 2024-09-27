function saveRole() {
    let control = validateRol();

    if (control) {
        _saveRole();
    } else {
        $(".needs-validation").addClass("was-validated");
    }
}

function _saveRole() {
    Loading();
    const data = modelRole();

    fetch('/Administrator/SaveRole', {
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
                closeModal("ModalNewRole");
                LoadMainPage('Administrator', 'Roles');
            } else {
                RemoveLoading();
                ErrorSwal(data.message);
                closeModal("ModalNewRole");
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
            closeModal("ModalNewRole");
        });
}

function EditRole() {
    let control = validateRol();

    if (control) {
        _editRole();
    } else {
        $(".needs-validation").addClass("was-validated");
    }
}

function _editRole() {
    Loading();
    const data = modelRole();

    fetch('/Administrator/EditRole', {
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
                closeModal("ModalDetailRole");
                LoadMainPage('Administrator', 'Roles');
            } else {
                RemoveLoading();
                ErrorSwal(data.message);
                closeModal("ModalDetailRole");
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
            closeModal("ModalDetailRole");
        });
}

function validateRol() {

    let control = true;

    $(".needs-validation").addClass("was-validated");

    if ($("#nameRol").val() == "") {
        control = false;
    }
    if ($("#description").val() == "") {
        control = false;
    }
 
    return control;
}

function modelRole() {
    return JSON.stringify({
        IdRole: $("#idrol").val(),
        Name: $("#nameRol").val(),
        Description: $("#description").val()      
    });
}

async function ShowDetailRol(idRol) {
    try {
        Loading();

        const response = await fetch('/Administrator/ShowDetailRol', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: new URLSearchParams({ idRol }).toString()
        });

        if (response.ok) {
            const data = await response.text();
            $("#DetailRolContainer").html(data);
            ShowModalBootstrapEvent('ModalDetailRole', null);
        } else {
            $("#DetailRolContainer").remove();
            ErrorSwal('No se puede realizar la operación.');
        }

        RemoveLoading();
    } catch (error) {
        RemoveLoading();
        ErrorSwal('No se puede realizar la operación.');
    }
}

async function ShowCreateRole() {
    $(".textNewMenu").val("");
    try {
        Loading();

        const response = await fetch('/Administrator/ShowCreateRole', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        });

        if (response.ok) {
            console.log("response Ok");
            const data = await response.text();
            $("#DetailRolContainer").html(data);
            ShowModalBootstrapEvent('ModalNewRole', null);
        } else {
            $("#DetailRolContainer").remove();
            ErrorSwal('No se puede realizar la operación.');
        }

        RemoveLoading();
    } catch (error) {
        RemoveLoading();
        ErrorSwal('No se puede realizar la operación.');
    }
}

function UpdateStateRole(idRole) {
    Swal.fire({
        title: "Do you want to save the changes?",
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: "Save",
        denyButtonText: `Don't save`
    }).then((result) => {
        if (result.isConfirmed) {
            _UpdateStateRole(idRole);
        } else if (result.isDenied) {
            Swal.fire("Changes are not saved", "", "info");
        }
    });
}

function _UpdateStateRole(idRole) {
    Loading();

    fetch('/Administrator/UpdateStateRole', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ IdRole: idRole })
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                RemoveLoading();
                successSwal(data.message);
                LoadMainPage('Administrator', 'Roles');
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
async function ShowCreateVariable() {
    $(".textNewVariable").val("");
    try {
        Loading();

        const response = await fetch('/Administrator/ShowCreateVariable', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        });

        if (response.ok) {
            console.log("response Ok");
            const data = await response.text();
            $("#DetailVariableContainer").html(data);
            ShowModalBootstrapEvent('ModalNewVariable', null);
        } else {
            $("#DetailVariableContainer").remove();
            ErrorSwal('No se puede realizar la operación.');
        }

        RemoveLoading();
    } catch (error) {
        RemoveLoading();
        ErrorSwal('No se puede realizar la operación.');
    }
}
function saveVariable() {
    let control = validateVariable();

    if (control) {
        _saveVariable();
    } else {
        $(".needs-validation").addClass("was-validated");
    }
}
function _saveVariable() {
    Loading();
    const data = modelSystemVariable();

    fetch('/Administrator/SaveMenu', {
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
                closeModal("ModalNewVariable");
                LoadMainPage('Administrator', 'SystemVariable');
            } else {
                RemoveLoading();
                ErrorSwal(data.message);
                closeModal("ModalNewVariable");
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
            closeModal("ModalNewVariable");
        });
}
async function ShowDetailVariable(idVariable) {
    try {
        Loading();

        const response = await fetch('/Administrator/ShowDetailVariable', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: new URLSearchParams({ idVariable }).toString()
        });

        if (response.ok) {
            const data = await response.text();
            $("#DetailVariableContainer").html(data);
            ShowModalBootstrapEvent('ModalDetailVariable', null);
        } else {
            $("#DetailVariableContainer").remove();
            ErrorSwal('No se puede realizar la operación.');
        }

        RemoveLoading();
    } catch (error) {
        RemoveLoading();
        ErrorSwal('No se puede realizar la operación.');
    }
}
function EditVariable() {
    let control = validateVariable();

    if (control) {
        _EditVariable();
    } else {
        $(".needs-validation").addClass("was-validated");
    }
}
function _EditVariable() {
    Loading();
    const data = modelSystemVariable();

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
                closeModal("ModalDetailVariable");
                LoadMainPage('Administrator', 'SystemVariable');
            } else {
                RemoveLoading();
                ErrorSwal(data.message);
                closeModal("ModalDetailVariable");
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
            closeModal("ModalDetailVariable");
        });
}
function validateVariable() {

    let control = true;

    $(".needs-validation").addClass("was-validated");

    if ($("#typesystemvariableId").val() == 0) {
        control = false;
        ErrorSwal("Seleccione un typesystemvariable");
    }

    if ($("#name").val() == "") {
        control = false;
    }

    if ($("#description").val() == "") {
        control = false;
    }

    return control;
}
function modelSystemVariable() {
    return JSON.stringify({
        IdSystemVariable: $("#idSystemVariable").val(),
        TypesystemvariableId: $("#typesystemvariableId").val(),
        Name: $("#name").val(),
        Description: $("#description").val(),
        ValueString: $("#valueString").val(),
        ValueNumeric: $("#valueNumeric").val()
    });
}

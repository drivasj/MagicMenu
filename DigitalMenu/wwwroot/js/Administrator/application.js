﻿function saveApplication() {
    Loading();
    const data = modelApplication();

    fetch('/Administrator/SaveApplication', {
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
                closeModal("ModalNewApplication");
                LoadMainPage('Administrator','Application');
            } else {
                RemoveLoading();
                ErrorSwal(data.message);
                closeModal("ModalNewApplication");
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
            closeModal("ModalNewApplication");
        });
}

function modelApplication() {
    return JSON.stringify({
        Name: $("#nameApplication").val(),
        Description: $("#description").val(),
        Display: $("#display").val(),
        Icon: $("#icon").val(),
        IdApplication: $("#idApp").val()
    });
}

async function ShowDetailApplication(idApp) {
    try {
        Loading();

        const response = await fetch('/Administrator/ShowDetailApplication', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: new URLSearchParams({ idApp }).toString()
        });

        if (response.ok) {
            const data = await response.text();
            $("#DetailAppContainer").html(data);
            ShowModalBootstrapEvent('ModalDetailApplication', null);
        } else {
            $("#DetailAppContainer").remove();
            ErrorSwal('No se puede realizar la operación.');
        }

        RemoveLoading();
    } catch (error) {
        RemoveLoading();
        ErrorSwal('No se puede realizar la operación.');
    }
}

function editApplication() {
    Loading();
    const data = modelApplication();

    fetch('/Administrator/EditApp', {
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
                closeModal("ModalDetailApplication");
                LoadMainPage('Administrator', 'Application');
            } else {
                RemoveLoading();
                ErrorSwal(data.message);
                closeModal("ModalDetailApplication");
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
            closeModal("ModalDetailApplication");
        });
}

function Tryme(idApp) {
    Swal.fire({
        title: "Do you want to save the changes?",
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: "Save",
        denyButtonText: `Don't save`
    }).then((result) => {
        if (result.isConfirmed) {
            DisableApplication(idApp);
        } else if (result.isDenied) {
            Swal.fire("Changes are not saved", "", "info");
        }
    });
}

function DisableApplication(idApp) {
    Loading();

    fetch('/Administrator/DisableApplication', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ IdApplication: idApp })
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                RemoveLoading();
                successSwal(data.message);
                LoadMainPage('Administrator', 'Application');
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

function OpenModalNewApplication() {
    $(".textNewApp").val("");
}


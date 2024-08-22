function saveRole() {
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

function modelRole() {
    return JSON.stringify({
        Name: $("#nameRol").val(),
        Description: $("#description").val()      
    });
}

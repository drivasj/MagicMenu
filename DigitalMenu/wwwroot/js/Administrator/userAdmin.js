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
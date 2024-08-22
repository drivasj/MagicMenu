function saveApplication() {
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
        Icon: $("#icon").val()
    });
}

function saveRole() {
    const model = modelRole();

    $.ajax({
        url: "/Administrator/SaveRole",
        type: "POST",
        data: { model: model },
        contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        async: true,
        dateType: 'json',
        cache: false,
        //beforeSend: function () {
        //    //Loading();
        //},
        success: function (data) {
            if (data.success) {
                closeModalNewRole();
                successSwal(data.message);
            } else {
                closeModalNewRole();
                ErrorSwal(data.message);
            }
        },
        error: function () {
            closeModalNewRole();
            ErrorSwal(data.message);
        }
    });
}

function modelRole() {

    const model = {

        Name: $("#nameRol").val(),
        Description: $("#description").val()        
    }
    return model;
}

function closeModalNewRole() {
    let modalNewMenu = bootstrap.Modal.getInstance(document.getElementById('ModalNewRole'));
    modalNewMenu.hide();
}
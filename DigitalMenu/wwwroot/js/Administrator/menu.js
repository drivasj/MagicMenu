
function saveMenu() {
    const model = modelMenu();

    $.ajax({
        url: "/Menu/SaveMenu",
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
                closeModalNewMenu();
                successSwal(data.message);
            } else {
                closeModalNewMenu();
                ErrorSwal(data.message);
            }
        },
        error: function () {
            closeModalNewUser();
            ErrorSwal(data.message);
        }
    });
}

function modelMenu() {

    const model = {

        ApplicationId: $("#idApplication").val(),
        Area: $("#area").val(),
        Controller: $("#controller").val(),
        Action: $("#action").val(),
        Name: $("#nameMenu").val(),
        Description: $("#description").val(),
    }
    return model;
}

function closeModalNewMenu() {
    let modalNewMenu = bootstrap.Modal.getInstance(document.getElementById('ModalNewMenu'));
    modalNewMenu.hide();
}
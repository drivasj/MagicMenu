
function saveApplication() {
    const model = modelApplication();

    $.ajax({
        url: "/Administrator/Application",
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
                closeModalNewApplication();
                successSwal(data.message);
            } else {
                closeModalNewApplication();
                ErrorSwal(data.message);
            }
        },
        error: function () {
            closeModalNewApplication();
            ErrorSwal(data.message);
        }
    });
}

function modelApplication() {

    const model = {

        Name: $("#idApplication").val(),
        Description: $("#area").val(),
        Display: $("#controller").val(),
        Icon: $("#icon").val()  
    }
    return model;
}

function closeModalNewApplication() {
    let modalNewMenu = bootstrap.Modal.getInstance(document.getElementById('ModalNewApplication'));
    modalNewMenu.hide();
}
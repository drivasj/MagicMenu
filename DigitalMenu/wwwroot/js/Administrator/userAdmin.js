
function saveUser() {
    const model = modelUser();

    $.ajax({
        url: "/UserAdmin/SaveUser",
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
                closeModalNewUser();
                successSwal(data.message);
            } else {
                closeModalNewUser();
                ErrorSwal(data.message);
            }          
        },
        error: function () {
            closeModalNewUser();
            ErrorSwal(data.message);
        }
    });
}

function modelUser() {

    const model = {

        FirstName : $("#name").val(),
        MiddleName: $("#middleName").val(),
        LastName: $("#lastName").val(),
        MotherName : $("#motherName").val(),
        DocumentNR: $("#document").val(),
        Phone: $("#phone").val(),
        Email: $("#email").val(),
        IdRole: $("#role").val(),
        UserName: $("#userName").val(),
        Adress: $("#adress").val()

    }
    return model;
}

function closeModalNewUser() {
    let modalNewUser = bootstrap.Modal.getInstance(document.getElementById('ModalNewUser'));
    modalNewUser.hide();
}
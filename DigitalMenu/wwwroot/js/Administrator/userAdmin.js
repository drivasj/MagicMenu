
function saveUser() {
    const model = modelUser();

    $.ajax({
        url: "/UserAdmin/SaveUser",
        type: "POST",
        data: { model: model },
        async: true,
        cache: false,
        //beforeSend: function () {
        //    //Loading();
        //},
        success: function (data) {
            alert("Register save");
        },
        error: function () {
            alert("Error");
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

function saveUser() {
    conts
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

        name = $("#userName").val(),
        middleName = $("#password").val(),
        middleName = $("#password").val(),
        middleName = $("#password").val(),
        middleName = $("#password").val(),
        name = $("#userName").val(),
        name = $("#userName").val(),
        name = $("#userName").val()
    }

    return model;
}
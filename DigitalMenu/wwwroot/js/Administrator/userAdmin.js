
function saveUser() {

    const userName = $("#userName").val();
    const password = $("#password").val();

    $.ajax({
        url: "/UserAdmin/SaveUser",
        type: "POST",
        data: {
            userName: userName,
            password: password
        },
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
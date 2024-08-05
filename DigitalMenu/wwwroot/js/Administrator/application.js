function saveApp() {

    const model = modelApp()

    $.ajax({
        url: "/Application/SaveApp",
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


function modelApp() {

    const model = {
        Name: $("#name").val(),
        Description: $("#description").val(),
        Display: $("#display").val(),
        Icon: $("#icon").val(),
    }

    return model;
}

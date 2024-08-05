function saveMenu() {

    const model = modelMenu()

    $.ajax({
        url: "/Menu/SaveMenu",
        type: "POST",
        data: { model: model},
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


function modelMenu() {

    const model = {
        IdApplication: $("#idApplication").val(),
        Area: $("#area").val(),
        Controller: $("#controller").val(),
        Action: $("#action").val(),
        Name: $("#name").val(),
        Description: $("#description").val()
    }

    return model;
}

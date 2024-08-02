const roleViewModel = {
    name : $("#name").val(),
    description : $("#description").val()
}

function saveRole() {

    $.ajax({
        url: "/Role/SaveRole",
        type: "POST",
        data: {
            name: roleViewModel.name,
            description: roleViewModel.description
        },
        async: true,
        cache: false,
        beforeSend: function () {
            //Loading();
        },
        success: function (data) {
            alert("Register save");
        },
        error: function () {
            alert("Register save");
        }
    });
}


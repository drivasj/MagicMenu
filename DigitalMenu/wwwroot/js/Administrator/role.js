function saveRole() {

    const name = $("#name").val();
    const description = $("#description").val();

    $.ajax({
        url: "/Role/SaveRole",
        type: "POST",
        data: {
            name: name,
            description: description
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
            alert("Error");
        }
    });
}


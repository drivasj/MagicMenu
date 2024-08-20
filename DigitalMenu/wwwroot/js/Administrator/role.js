
function saveRole() {
    const model = modelRole();

    $.ajax({
        url: "/Administrator/SaveRole",
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
                closeModalNewRole();
                successSwal(data.message);
            } else {
                closeModalNewRole();
                ErrorSwal(data.message);
            }
        },
        error: function () {
            closeModalNewRole();
            ErrorSwal(data.message);
        }
    });
}

function modelRole() {

    const model = {

        Name: $("#nameRol").val(),
        Description: $("#description").val()        
    }
    return model;
}

function closeModalNewRole() {
    let modalNewMenu = bootstrap.Modal.getInstance(document.getElementById('ModalNewRole'));
    modalNewMenu.hide();
}

function guardarDatos() {
    const rolId = document.getElementById('roles').value;
    const menuId = document.getElementById('menus').value;

    fetch('/Home/GuardarDatos', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ rolId, menuId })
    })
        .then(response => response.json())
        .then(data => {
            // Manejar la respuesta del servidor
            console.log(data);
        })
        .catch(error => {
            console.error('Error:',error);
        });
}
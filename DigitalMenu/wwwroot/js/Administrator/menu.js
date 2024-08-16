
async function saveMenu() {
    const model = modelMenu();

    $.ajax({
        url: "/Administrator/SaveMenu",
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
                closeModalNewMenu();
                successSwal(data.message);
            } else {
                closeModalNewMenu();
                ErrorSwal(data.message);
            }
        },
        error: function () {
            closeModalNewUser();
            ErrorSwal(data.message);
        }
    });
}

function modelMenu() {

    const model = {

        ApplicationId: $("#idApplication").val(),
        Area: $("#area").val(),
        Controller: $("#controller").val(),
        Action: $("#action").val(),
        Name: $("#nameMenu").val(),
        Description: $("#description").val(),
    }
    return model;
}

function closeModalNewMenu() {
    let modalNewMenu = bootstrap.Modal.getInstance(document.getElementById('ModalNewMenu'));
    modalNewMenu.hide();
}

function enviarDatos() {

    var idRolAdminValue = $("#idrolAdmin").val();

    fetch('/Administrator/ProcesarDatos', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ idRolAdmin: idRolAdminValue })
    })
        .then(response => response.json())
        .then(data => {
            successSwal(data.mensaje);
        })
        .catch(error => {
            ErrorSwal(data.message);
        });
}

async function cargarMenuSA(rolId) {
    fetch('/Administrator/GetMenuRol', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ idRolAdmin: rolId })
    })
        .then(response => response.json())
        .then(data => {
            const selectMenus = document.getElementById('menus');
            selectMenus.innerHTML = '';
            data.forEach(listMenuSinAsingnar => {
                const option = document.createElement('option');
                option.value = listMenuSinAsingnar.IdMenu;
                option.text = listMenuSinAsingnar.Name;
                selectMenus.appendChild(option);
            });
        })
        .catch(error => {
            console.error('Error:', error);
        });
}



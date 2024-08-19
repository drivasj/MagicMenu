const { error } = require("jquery");

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

async function saveRolMenu() {

    const rolId = $("#roles").val();
    const menuId = $("#menus").val("#");

    fetch('/Administrator/SaveMenuRol', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ rolId, menuId })
    })
        .then(response => reponse.json())
        .then(data => {          
            successSwal(data.message); //Manejar la respuesta del servidor
        })
        .catch(error => {
           
            ErrorSwal('Error: ', error); //Mensaje de error
        });
}


function closeModalNewMenu() {
    let modalNewMenu = bootstrap.Modal.getInstance(document.getElementById('ModalNewMenu'));
    modalNewMenu.hide();
}

async function cargarMenus(rolId) {

    fetch('/Administrator/GetMenuRol', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ rolId: rolId })
    })
        .then(response => response.json())
        .then(data => {
            const selectMenus = document.getElementById('menus');
            selectMenus.innerHTML = '';
            const optioninitial = document.createElement('option');
            optioninitial.value = "#";
            optioninitial.text = "Seleccionar un menú";
            selectMenus.appendChild(optioninitial);

            data.forEach(menus => {
                const option = document.createElement('option');
                option.value = menus.IdMenu;
                option.text = menus.Name;
                selectMenus.appendChild(option);
            });
        })
        .catch(error => {
            console.error('Error:', error);
        });
}
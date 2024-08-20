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
                closeModalNewMenu("ModalNewMenu");
                successSwal(data.message);
            } else {
                closeModalNewMenu("ModalNewMenu");
                ErrorSwal(data.message);
            }
        },
        error: function () {
            closeModalNewMenu();
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

function saveRolMenu() {

    const data = getRolMenu();

    fetch('/Administrator/SaveMenuRol', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: data
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                successSwal(data.message);
                closeModal("ModalRolMenu");
            } else {
                ErrorSwal(data.message);
                closeModal("ModalRolMenu");
            }
        })
        .catch(error => {
            ErrorSwal('Error: ', error);
            closeModal("ModalRolMenu");
        });
}

function getRolMenu() {

    return JSON.stringify({
        RoleId: $("#roles").val(),
        MenuId: $("#menus").val()
    });
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
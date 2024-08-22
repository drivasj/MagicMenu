function saveMenu() {
    Loading();
    const data = getModelMenu();
    
    fetch('/Administrator/SaveMenu', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: data
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                RemoveLoading();
                successSwal(data.message);
                closeModal("ModalNewMenu");
                LoadMainPage('Administrator', 'Menu');
            } else {
                RemoveLoading();
                ErrorSwal(data.message);
                closeModal("ModalNewMenu");
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
            closeModal("ModalNewMenu");
        });
}

function getModelMenu() {
    return JSON.stringify({
        ApplicationId: $("#idApplication").val(),
        Area: $("#area").val(),
        Controller: $("#controller").val(),
        Action: $("#action").val(),
        Name: $("#nameMenu").val(),
        Description: $("#description").val()
    });
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
async function ShowDetailMenu(idMenu) {
    try {
        Loading();

        const response = await fetch('/Administrator/ShowDetailMenu', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: new URLSearchParams({ idMenu }).toString()
        });

        if (response.ok) {
            const data = await response.text();
            $("#DetailMenuContainer").html(data);
            ShowModalBootstrapEvent('ModalDetailMenu', null);
        } else {
            $("#DetailMenuContainer").remove();
            ErrorSwal('No se puede realizar la operación.');
        }

        RemoveLoading();
    } catch (error) {
        RemoveLoading();
        ErrorSwal('No se puede realizar la operación.');
    }
}

function saveMenu() {
    let control = true;

    $(".needs-validation").addClass("was-validated");


    if ($("#controller").val() == "") {
        control = false;
    }

    if ($("#action").val() == "") {
        control = false;
    }

    if ($("#nameMenu").val() == "") {
        control = false;
    }

    if (control) {
        _saveMenu();
    } else {
        $(".needs-validation").addClass("was-validated");
    }
}

function _saveMenu() {
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

function EditMenu() {
    let control = true;

    $(".needs-validation").addClass("was-validated");

    if ($("#controller").val() == "") {
        control = false;
    }

    if ($("#action").val() == "") {
        control = false;
    }

    if ($("#nameMenu").val() == "") {
        control = false;
    }

    if (control) {
        _EditMenu();
    } else {
        $(".needs-validation").addClass("was-validated");
    }
}

function _EditMenu() {
    Loading();
    const data = getModelMenu();

    fetch('/Administrator/EditMenu', {
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
                closeModal("ModalDetailMenu");
                LoadMainPage('Administrator', 'Menu');
            } else {
                RemoveLoading();
                ErrorSwal(data.message);
                closeModal("ModalDetailMenu");
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
            closeModal("ModalDetailApplication");
        });
}

function getModelMenu() {
    return JSON.stringify({
        IdMenu: $("#idMenu").val(),
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

async function ShowCreateMenu() {
    $(".textNewMenu").val("");
    try {
        Loading();

        const response = await fetch('/Administrator/ShowCreateMenu', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        });

        if (response.ok) {
            console.log("response Ok");
            const data = await response.text();
            $("#DetailMenuContainer").html(data);
            ShowModalBootstrapEvent('ModalNewMenu', null);
        } else {
            $("#DetailMenuContainer").remove();
            ErrorSwal('No se puede realizar la operación.');
        }

        RemoveLoading();
    } catch (error) {
        RemoveLoading();
        ErrorSwal('No se puede realizar la operación.');
    }
}
async function ShowCreateProductCategory() {
    $(".textNewApp").val("");
    try {
        Loading();

        const response = await fetch('/Product/ShowCreateProductCategory', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        });

        if (response.ok) {
            const data = await response.text();
            $("#DetailPCContainer").html(data);
            ShowModalBootstrapEvent('ModalNewProductCategory', null);
        } else {
            $("#DetailPCContainer").remove();
            ErrorSwal('No se puede realizar la operación.');
        }

        RemoveLoading();
    } catch (error) {
        RemoveLoading();
        ErrorSwal('No se puede realizar la operación.');
    }
}

function saveProductCategory() {

    let control = true;

    $(".needs-validation").addClass("was-validated");

    if ($("#nameProductCategory").val() == "") {
        control = false;
    }

    if (control) {
        _saveProductCategory();
    } else {
        $(".needs-validation").addClass("was-validated");
    }
}

function _saveProductCategory() {
    Loading();
    const data = modelProductCategory();

    fetch('/Product/SaveProductCategory', {
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
                closeModal("ModalNewProductCategory");
                LoadMainPage('Product', 'Category');
            } else {
                RemoveLoading();
                ErrorSwal(data.message);
                closeModal("ModalNewProductCategory");
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
            closeModal("ModalNewProductCategory");
        });
}

function modelProductCategory() {
    return JSON.stringify({
        Name: $("#nameProductCategory").val(),
        Description: $("#description").val(),      
    });
}
﻿async function ShowCreateProduct() {
    $(".textNewMenu").val("");
    try {
        Loading();

        const response = await fetch('/Product/ShowCreateProduct', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        });

        if (response.ok) {
            const data = await response.text();
            $("#DetailProductContainer").html(data);
            ShowModalBootstrapEvent('ModalNewProduct', null);
        } else {
            $("#DetailProductContainer").remove();
            ErrorSwal('No se puede realizar la operación.');
        }

        RemoveLoading();
    } catch (error) {
        RemoveLoading();
        ErrorSwal('No se puede realizar la operación.');
    }
}

async function ShowDetailProduct(idProduct) {
    try {
        Loading();

        const response = await fetch('/Product/ShowDetailProduct', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: new URLSearchParams({ idProduct }).toString()
        });

        if (response.ok) {
            const data = await response.text();
            $("#DetailProductContainer").html(data);
            ShowModalBootstrapEvent('ModalDetailProduct', null);
        } else {
            $("#DetailProductContainer").remove();
            ErrorSwal('No se puede realizar la operación.');
        }

        RemoveLoading();
    } catch (error) {
        RemoveLoading();
        ErrorSwal('No se puede realizar la operación.');
    }
}

function saveProduct() {
    let control = validateProduct();

    if (control) {
        _saveProduct();
    } else {
        $(".needs-validation").addClass("was-validated");
    }
}

function _saveProduct() {
    Loading();
    const data = modelProduct();

    fetch('/Product/saveProduct', {
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
                closeModal("ModalNewProduct");
                LoadMainPage('Product', 'Products');
            } else {
                RemoveLoading();
                ErrorSwal(data.message);
                closeModal("ModalNewProduct");
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
            closeModal("ModalNewProduct");
        });
}

function EditProduct() {
    console.log("Editar");
    let control = validateProduct();

    if (control) {
        _editProduct();
    } else {
        $(".needs-validation").addClass("was-validated");
    }
}

function _editProduct() {
    Loading();
    const data = modelProduct();

    fetch('/Product/EditProduct', {
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
                closeModal("ModalDetailProduct");
                LoadMainPage('Product', 'Products');
            } else {
                RemoveLoading();
                ErrorSwal(data.message);
                closeModal("ModalDetailProduct");
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
            closeModal("ModalDetailProduct");
        });
}

function UpdateStateProduct(idProduct) {
    Swal.fire({
        title: "Do you want to save the changes?",
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: "Save",
        denyButtonText: `Don't save`
    }).then((result) => {
        if (result.isConfirmed) {
            _UpdateStateProduct(idProduct);
        } else if (result.isDenied) {
            Swal.fire("Changes are not saved", "", "info");
        }
    });
}

function _UpdateStateProduct(idProduct) {
    Loading();

    fetch('/Product/UpdateStateProduct', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ IdProduct: idProduct })
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                RemoveLoading();
                successSwal(data.message);
                LoadMainPage('Product', 'Products');
            } else {
                RemoveLoading();
                ErrorSwal(data.message);
            }
        })
        .catch(error => {
            RemoveLoading();
            ErrorSwal('Error: ', error);
        });
}


function validateProduct() {

    let control = true;

    $(".needs-validation").addClass("was-validated");


    if ($("#code").val() == "") {
        control = false;
    }

    if ($("#productCategoryId").val() == 0) {
        control = false;
        ErrorSwal("Debe seleccionar una categoria");
    }

    //if ($("#statusPromotion").val() == 0) {
    //    control = false;
    //    ErrorSwal("Seleccione si el producto estara en promoción");
    //}

    if ($("#idCompany").val() == 0) {
        control = false;
        ErrorSwal("Debe seleccionar una compania");
    }

    if ($("#nameProduct").val() == "") {
        control = false;
    }

    if ($("#price").val() == "") {
        control = false;
    }

    if ($("#stock").val() == "") {
        control = false;
    }

    if ($("#productTaxId").val() == 0) {
        control = false;
        ErrorSwal("Debe seleccionar una Tasa de impuesto");
    }

    if ($("#urlImage").val() == "") {
        control = false;
    }

    return control;
}

function modelProduct() {
    return JSON.stringify({
        IdProduct: $("#idProduct").val(),
        Code: $("#code").val(),
        productCategoryId: $("#productCategoryId").val(),
        IdCompany: $("#idCompany").val(),
        NameProduct: $("#nameProduct").val(),
        Description: $("#description").val(),
        Price: $("#price").val(),
        Stock: $("#stock").val(),
        ProductTaxId: $("#productTaxId").val(),
        UrlImage: $("#urlImage").val()
    });
}

async function SearchProductCode() {
    try {
        var filter = $("#filter").val();

        if (filter != "") {
            Loading();

            const response = await fetch('/Product/SearchProductCode', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                body: new URLSearchParams({ filter }).toString()
            });

            if (response.ok) {
                const data = await response.text();
                $("#content-section").html(data);
            } else {
                $("#content-section").remove();
            }
            RemoveLoading();
        } else {
            ErrorSwal("Debe ingresar un codigo de producto");
        }

    } catch (error) {
        RemoveLoading();
        ErrorSwal('No se puede realizar la operación.');
    }
}

async function FilterClearSearchProduct() {
    try {
        Loading();

        const response = await fetch('/Product/Products', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        });

        if (response.ok) {
            const data = await response.text();
            $("#content-section").html(data);
        } else {
            $("#content-section").remove();
        }
        RemoveLoading();


    } catch (error) {
        RemoveLoading();
        ErrorSwal('No se puede realizar la operación.');
    }
}

async function FilterStatusProduct() {

    var filter = $("#idTypeStatus").val();
    console.log(filter);

    if (filter != "") {
        try {
            Loading();

            const response = await fetch('/Product/SearchProductStatus', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                
                body: new URLSearchParams({ filter })
            });

            if (response.ok) {
                const data = await response.text();
                $("#content-section").html(data);
            } else {
                $("#content-section").remove();
            }
            RemoveLoading();

        } catch (error) {
            RemoveLoading();
            ErrorSwal('No se puede realizar la operación.');
        }
    } else {
        ErrorSwal("Debe ingresar un codigo de producto");
    }
}
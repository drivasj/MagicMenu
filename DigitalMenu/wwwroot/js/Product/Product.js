async function ShowCreateProduct() {
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
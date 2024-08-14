function successSwal(message){
    Swal.fire({
        position: "top",
        icon: "success",
        title: message,
        showConfirmButton: false,
        timer: 2500
    });
}

function ErrorSwal(message) {
    Swal.fire({
        position: "top",
        icon: "error",
        title: message,
        showConfirmButton: false,
        timer: 2500
    });
}
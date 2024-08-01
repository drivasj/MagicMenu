const roleViewModel = {
    name : $("#name").val(),
    description : $("#description").val()
}

// Save Role

async function saveRole() {

    const data = JSON.stringify({
        Name: roleViewModel.name,
        Description: roleViewModel.description
    });

    const response = await fetch("/Role/SaveRole", {
        method: 'POST',
        body: data,
        headers: {
            'Content-Type': 'application/json'
        }
    });

    if (response.ok) {
        alert("Register save");
    } else {
        alert("Error");
    }
}


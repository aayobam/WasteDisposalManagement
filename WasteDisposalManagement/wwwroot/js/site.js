// index page navbar selection.
function indexNav() {
    const toggleButton = document.getElementsByClassName("toggle-button")[0];
    const mobileNav = document.getElementById('mobile-nav');

    toggleButton.addEventListener('click', () => {
        mobileNav.classList.toggle('hide');
    });
}
indexNav();


function loginFormValidation() {
    let loginEmail = document.getElementById("login-email")
    let loginPassword = document.getElementById("login-password")
    if (loginEmail == "") {
        let label = document.getElementById("fname-label")
        firstname.style.borderColor = "#FF7A7A";
        firstname.appendChild(linebreak);
        label.innerHTML = "Firstname cannot be empty."
        return false
    }
}


function validateForm() {
    let firstname = document.getElementById("fname");
    let lastname = document.getElementById("lname");
    let Phone_number = document.getElementById("phone-no");
    let address = document.getElementById("address");
    let linebreak = document.createElement("br");

    // validate first name field.
    if (firstname.value == "") {
        let label = document.getElementById("fname-label")
        firstname.style.borderColor = "#FF7A7A";
        firstname.appendChild(linebreak);
        label.innerHTML = "Firstname cannot be empty."
        return false
    }

    // validate last name field.
    else if (lastname.value == "") {
        let label = document.getElementById("lname-label")
        lastname.style.borderColor = "#FF7A7A";
        lastname.appendChild(linebreak);
        label.innerHTML = "Lastname cannot be empty."
        return false
    }

    // validate first phone number field.
    else if (Phone_number.value == "" || Phone_number.value < 11) {
        let label = document.getElementById("phone_no-label")
        email.style.borderColor = "#FF7A7A";
        email.appendChild(linebreak);
        label.innerHTML = "Email cannot be empty."
        return false
    }

    // validate password field.
    else if (address.value == "") {
        let label = document.getElementById("address-label")
        password.style.borderColor = "#FF7A7A";
        password.appendChild(linebreak);
        label.innerHTML = "password cannot be empty";
        return false;
    }
    else {
        return true
    };
}

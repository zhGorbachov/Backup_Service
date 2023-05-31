// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
$(document).ready(function(){
    const token = localStorage.getItem("Bearer");
    console.log(token)
    if (token)
    {
        document.getElementById("userInfo").style.display = "block";
        document.getElementById("LoginButtonLayout").style.display = "none";
        document.getElementById("RegistrationButtonLayout").style.display = "none";
        
        // $.ajaxSetup({
        //     method: "GET",
        //     headers: {
        //         "Accept": "application/json",
        //         'Authorization': 'Bearer ' + token
        //     }
        // });
    }
    else {
        window.confirm("You are not authorized");    
    
    }
})

function setCustomHeaders(url) {
    const token = localStorage.getItem("Bearer");
    fetch(url, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        }
    })
        .then(response => response.json())
        .then(data => {
            // Process the received data
            console.log(data);
        })
        .catch(error => {
            // Handle any errors
            console.error('Error:', error);
        });
}

function exitAccount(){
    var token = localStorage.getItem("Bearer");

    if (token){
        document.getElementById("userInfo").addEventListener("click", e => {

            e.preventDefault();
            document.getElementById("userInfo").style.display = "none";
            document.getElementById("LoginButtonLayout").style.display = "block";
            document.getElementById("RegistrationButtonLayout").style.display = "block";
            localStorage.removeItem("Bearer");
        });
    }
}

function checkAuthorized(firstUrl, secondUrl){
    const token = localStorage.getItem("Bearer");

    if (token)
    {
        window.location.href = firstUrl;
    }
    else {
        Swal.fire({
            title: 'You arent authorized', 
            text : 'You need to create an account or log into exist.', 
            icon: 'error',
            confirmButtonText: 'Ok',
            cancelButtonText: 'Cancel'})
            .then((result) =>{
            if (result.isConfirmed) {
                window.location.href = secondUrl;
            }
        });
    }
};

async function getTokenAsync(){
    var tokenKey = "Bearer";
    console.log("A")
        const formData = new FormData();
        formData.append("grant_type", "password");
        formData.append("login", document.getElementById("login").value);
        formData.append("password", document.getElementById("password").value);

    console.log("A")
        const response = await fetch("/token", {
            method: "POST",
            headers: {"Accept": "application/json"},
            body: formData
        });
    console.log("A")
        const data = await response.json();
        if (response.ok === true) {

            localStorage.setItem(tokenKey, data.bearer);
            console.log("Bearer " + data.bearer);
        }
        else {
            console.log("Error: ", response.status, data.errorText);
        }
}

function alertNoFile(){
    Swal.fire({
        title: "Files are empty",
        icon: "error",
        timer: 5000
    });
}
function alertPassword(){
    Swal.fire({
        title: "Passwords are not same",
        icon: "error",
        confirmButtonText: 'Ok',
        timer: 5000
    });
}
// Write your JavaScript code.

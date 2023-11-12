// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
$(document).ready(function(){
    const token = localStorage.getItem("Bearer");
    console.log(token)
    if (token)
    {
        checkAuthorized();
        
        $.ajaxSetup({
            method: "GET",
            headers: {
                "Accept": "application/json",
                'Authorization': 'Bearer ' + token
            }
        });
        console.log("Working")
    }
    else {
        console.log("You are not authorized")   
    
    }
})

function exitAccount(){
    var token = localStorage.getItem("Bearer");

    if (token){
        document.getElementById("userInfo").addEventListener("click", e => {

            e.preventDefault();
            document.getElementById("userInfo").style.display = "none";
            document.getElementById("LoginButtonLayout").style.display = "block";
            document.getElementById("RegistrationButtonLayout").style.display = "block";
            localStorage.removeItem("Bearer");
            localStorage.removeItem("Id");
        });
    }
    // else {
    //     Swal.fire({
    //         title: 'You arent authorized',
    //         text : 'You need to create an account or log into exist.',
    //         icon: 'error',
    //         confirmButtonText: 'Ok',
    //         cancelButtonText: 'Cancel'})
    //         });
    // }
}

function checkAuthorized(){
    document.getElementById("userInfo").style.display = "block";
    document.getElementById("LoginButtonLayout").style.display = "none";
    document.getElementById("RegistrationButtonLayout").style.display = "none";
}

// function registrateAccount(){
//     console.log("A")
//     $.ajax({
//       method: "POST",
//       url: "/Registration",
//         data: {
//           Login: document.getElementById("login").value,
//             Password: document.getElementById("password").value
//         },
//         success: (response) => {
//           console.log(response)
//             Swal.fire({
//                 title: response,
//                 icon: "error",
//                 confirmButtonText: 'Ok',
//                 timer: 2000
//         })
//       },
//         error: (error) => {
//           console.log(error)
//         }
//     })
//    
// }

async function getTokenAsync(){
    var tokenKey = "Bearer";
        const formData = new FormData();
        formData.append("grant_type", "password");
        formData.append("login", document.getElementById("login").value);
        formData.append("password", document.getElementById("password").value);

        const response = await fetch("/token", {
            method: "POST",
            headers: {"Accept": "application/json"},
            body: formData
        });
        var loginA = document.getElementById("login").value
        var data1 = {
            login: loginA
        }
        let id = $.ajax({
            method: 'GET',
            headers: {"Accept": "application/json"},
            data: {login: loginA},
            url: "/GetAccountIdByLogin",
            success: function (response){
                
            },
            error: function (error){
                console.log(error)
            }
        })
        const data = await response.json();
        if (response.ok === true) {
            localStorage.setItem("Nickname", loginA)
            localStorage.setItem(tokenKey, data.bearer);
            console.log("Bearer " + data.bearer);

            setTimeout(function() {
                window.location.href = "../Home"
            }, 1000)
        }
        else {
            Swal.fire({
            title: "Wrong login or password",
            icon: "error",
            confirmButtonText: 'Ok',
            timer: 2000
        });
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

function uploadingPageButton(){
    var fileInput = document.getElementById('fileInput');
    var files = fileInput.files;
    var formData = new FormData();
    console.log(files)
    if (files.length == 0){
        alertNoFile();
        setTimeout(function (){
                window.location.href = "/Home"},
            1000)
        return;
    }

    for (var i = 0; i < files.length; i++) {
        formData.append('files', files[i]);
    }
    const token = localStorage.getItem("Bearer")
    $.ajax('/UploadFiles', {
        method: "POST",
        data: formData,
        headers: {
            "Accept": "application/json",
            'Authorization': 'Bearer ' + token
        },
        contentType: false,
        processData: false,
        cache: false,
        success: function(response) {
            document.body.innerHTML = ''
            performAjaxRequest('Home/DownloadingFilePage/')
        },
        error: function (error){
            console.log(error)
        }
    })
}

function performAjaxRequest(url, parameters = null) {
    const token = localStorage.getItem("Bearer");
    if (token) {
        $.ajax({
            url: url,
            type: 'GET',
            body: parameters,
            headers: {
                'Authorization': "Bearer " + token
            },
            success: function (response) {
                console.log(response);
                const observer = new MutationObserver(() => {
                    console.log("observer")
                    checkAuthorized();
                })

                observer.observe(document, {childList: true, subtree: true})
                setTimeout(() => {
                    observer.disconnect()
                }, 10000)

                document.write(response);
            },
            error: function (error) {
                console.error(error);
            }
        })
    }
    else{
        Swal.fire({
            title: 'You arent authorized',
            text : 'You need to create an account or log into exist.',
            icon: 'error',
            confirmButtonText: 'Ok',
            cancelButtonText: 'Cancel'})
    }
}


// Write your JavaScript code.

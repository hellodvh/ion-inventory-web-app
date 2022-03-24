// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/* Apply active-link class to nav-link and update the css styling */
document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('.nav-link').forEach(link => {
        if (link.getAttribute('href').toLowerCase() === location.pathname.toLowerCase()) {
            link.classList.add('active-link');
        } else {
            link.classList.remove('active-link');
        }
    });
})

//Toast for verification code info
$(document).ready(function () {
    $("#myBtnToast1").click(function () {
        $('.toast1').toast('show');
    });
});

$(document).ready(function () {
    $("#myBtnToast2").click(function () {
        $('.toast2').toast('show');
    });
});

$(document).ready(function () {
    $("#myBtnToast3").click(function () {
        $('.toast3').toast('show');
    });
});


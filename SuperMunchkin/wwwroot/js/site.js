// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Navigation bar
$(document).ready(function () {
    var fixHeight = function () {
        $(".navbar-nav").css("max-height", document.documentElement.clientHeight - 150);
    }
    fixHeight();
    $(window).resize(function () {
        fixHeight();
    });
    $(".navbar .navbar-toggler").on("click", function () {
        fixHeight();
    });
    $(".navbar-toggler, .overlay").on("click", function () {
        $(".mobileMenu, .overlay").toggleClass("open");
    });
});

// Popup with munchkin names
function showPopup(id) {
    var popup = document.getElementById(id);
    popup.classList.replace("d-none", "d-inline-block");
    popup.style.marginLeft = -(popup.offsetWidth / 2) + 'px';
    popup.style.marginTop = -(popup.offsetHeight / 2) + 'px';
}
function hidePopup(id) {
    document.getElementById(id).classList.replace("d-inline-block", "d-none");
}

// Swap battling munchkin
function swapDisplay(display, hide) {
    document.getElementById(display).classList.replace("d-none", "d-inline");
    document.getElementById(hide).classList.replace("d-inline", "d-none");
    sessionStorage.setItem('active' + display.toString().substring(0, display.length - 1), display);
}

if (sessionStorage.activeMonster) {
    if (sessionStorage.activeMonster == 'Monster2') {
        document.getElementById('Monster1').classList.replace("d-inline", "d-none");
        document.getElementById('Monster2').classList.replace("d-none", "d-inline");
    }
}

if (sessionStorage.activeMunchkin) {
    if (sessionStorage.activeMunchkin == 'Munchkin2') {
        document.getElementById('Munchkin1').classList.replace("d-inline", "d-none");
        document.getElementById('Munchkin2').classList.replace("d-none", "d-inline");
    }
}

function clearSession() {
    sessionStorage.clear();
}
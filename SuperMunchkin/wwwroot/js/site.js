// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

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

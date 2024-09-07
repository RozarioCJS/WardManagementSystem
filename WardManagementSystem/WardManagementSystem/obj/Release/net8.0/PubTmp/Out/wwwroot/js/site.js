"use strict"
$(document).ready(function () {
    $(".clickable-row").click(function () {
        window.location = $(this).data("href");
    });
    $("#ShowCustomAlert").click(function () {
        $("#customAlert").toggle();
    });
    $("#customAlert").click(function () {
        $(this).hide();
    });

    var currentPageUrl = window.location.href;

    $(".nav-pills li a").each(function () {
        var linkUrl = $(this).attr("href");

        if (currentPageUrl.indexOf(linkUrl) !== -1) {
            $(this).addClass("active");
        }
    });
    $("#ShowOrderForm").click(function () {
        $("#order-form").show();
    });
});
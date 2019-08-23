$(document).ready(function () {
    $(".sec").each(function () {
        $(this).click(function () {
            //setTimeout(function () {
            //    $("#map").append("<div id='Clicker' class='btn-custom' style='position:absolute;right:20px;top:270px;font-size:20px;color:white; cursor:pointer;'>Bize Ulaşın</div>");
            //    $("#Clicker").click(function () {

            //    });
            //}, 400);
            $("#popupBack").width($(window).width());
            $("#popupBack").height($(window).height());
            $("#popupBack").fadeIn("slow");
            $("#popupcontent").css("left", (($(window).width() - $("#popupcontent").width()) / 2).toString() + "px");
            $("#popupcontent").css("top", (($(window).height() - $("#popupcontent").height()) / 2).toString() + "px");
            $("#popupcontent").fadeIn("slow");
            $("#popcloser").fadeIn("slow");
            $("#popcloser").css("left", ((($(window).width() - $("#popupcontent").width()) / 2) +
                $("#popupcontent").width()).toString() + "px");
            $("#popcloser").css("top", (($(window).height() - $("#popupcontent").height()) / 2).toString() + "px");
            $("#popcloser").click(function () {
                $("#popupBack").fadeOut("fast");
                $("#popupcontent").fadeOut("fast");
                $("#popcloser").fadeOut("fast");
            });
        });
    });
   
});
/* Bootstrap Carousel */
$(document).ready(function () {
    $('.carousel-inner .item:first-child').addClass('active');
});

$('.carousel').carousel({
    interval: 8000,
    pause: "hover"
});

/* Navigation Menu */

ddlevelsmenu.setup("ddtopmenubar", "topbar");

/* Dropdown Select */

/* Navigation (Select box) */

// Create the dropdown base

$("<select />").appendTo(".navis");

// Create default option "Go to..."

$("<option />", {
    "selected": "selected",
    "value": "",
    "text": "Menu"
}).appendTo(".navis select");

// Populate dropdown with menu items

$(".navi a").each(function () {
    var el = $(this);
    $("<option />", {
        "value": el.attr("href"),
        "text": el.text()
    }).appendTo(".navis select");
});

$(".navis select").change(function () {
    window.location = $(this).find("option:selected").val();
});



/* Scroll to Top */


$(".totop").hide();

$(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $('.totop').fadeIn();
        }
        else {
            $('.totop').fadeOut();
        }
    });

    $('.totop a').click(function (e) {
        e.preventDefault();
        $('body,html').animate({ scrollTop: 0 }, 500);
    });

});


/* Support */

$("#slist a").click(function (e) {
    e.preventDefault();
    $(this).next('p').toggle(200);
});

/* Careers */

$('#myTab a').click(function (e) {
    e.preventDefault()
    $(this).tab('show')
})


/* Ecommerce sidebar */

$(document).ready(function () {
    $('.sidey .nav').navgoco();
});
/*zoom*/
$(".zoom").elevateZoom({
    constrainType: "height",
    constrainSize: 200,
    lensSize: 100,
    zoomType: "window",
    containLensZoom: true,
    cursor: 'pointer',
    gallery: 'gal1',
    galleryActiveClass: 'active',
    loadingIcon: 'http://www.elevateweb.co.uk/spinner.gif'
});

//pass the images to Fancybox 
$(".zoom").bind("click", function(e) { var ez = $('.zoom').data('elevateZoom');	$.fancybox(ez.getGalleryList()); return false; });

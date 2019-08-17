/* ==================================================
         servicess
======================================   */

$(function () {

    new WOW().init();

});

/*========================================
            pop up
=============================*/
$(function () {

    $('#top-8-org').magnificPopup({
        delegate: 'a', // child items selector, by clicking on it popup will open
        type: 'image',
        // other options
        gallery: {
            enabled: true
        }
    });

});


/* =========================================
                  owl carousel 
=========================================*/

$(function () {
    $("#reviewer-content").owlCarousel({
        item: 3,
        autoplay: true,
        smartSpeed: 700,
        loop: true,
    });
});

/*================================================
counter 
===========================*/
$(function () {

    $('.counter').counterUp({
        delay: 10,
        time: 2000
    });

});





/*====================================================
                        NAVIGATION
====================================================*/
// Show/Hide transparent black navigation
$(function () {

    $(window).scroll(function () {

        if ($(this).scrollTop() < 50) {
            // hide nav
            $("nav").removeClass("vesco-top-nav");
            $(".btn-fixed").fadeOut();

        } else {
            // show nav
            $("nav").addClass("vesco-top-nav");
            $(".btn-fixed").fadeIn();
        }
    });
});
// Smooth scrolling
$(function () {

    $("a.smooth-scroll").click(function (event) {

        event.preventDefault();

        // get/return id like #about, #work, #team and etc
        var section = $(this).attr("href");

        $('html, body').animate({
            scrollTop: $(section).offset().top - 64
        }, 1250, "easeInOutExpo");
    });
});

// Close mobile menu on click
/*
$(function(){
    
    $(".navbar-collapse ul li a").on("click touch", function(){
       
        $(".navbar-toggle").click();
    });
});*/














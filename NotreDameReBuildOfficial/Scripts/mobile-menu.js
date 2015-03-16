$(document).ready(function ($) {

    $(window).resize(function() {
        // This will fire each time the window is resized:
        if ($(window).width() >= 920) {
            //if larger
            $('#navigation').show();
            $('#navigation ul li ul').show();
        }else{
            //if smaller
            $('#navigation').hide();
            //hide secondary links
            $('#navigation ul li ul').hide();
        }
    }).resize();

    //toggle opening of menu
    $('#hamburger').click(function () {
        $('#navigation').fadeToggle(500);
    });

    //open secondary links on mobile - if ul li position is relative (on desktop) do not run this function
    //if ul li position is any other (mobile(initial)) allow accordion function to occur
    jQuery("#navigation ul li a").on("click", function (e) {
        if ($("#navigation ul li").css("position") === "relative") {
            return false;
        }
        $(this).next('ul').slideToggle();
    });

});
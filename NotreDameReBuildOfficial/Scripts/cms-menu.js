//Hide secondary content
$('.secondary').hide();

//for each dropdown div, assign variable
$('.dropdown').each(function () {
    var $dropdown = $(this);

    //when a left menu item within a dropdown div is clicked
    $('.left-mnu-itm', $dropdown).on('click', function () {
        $div = $('.secondary', $dropdown); //creae a set by assigning variable to secondary content in dropdown div
        $div.slideToggle(300); //show/hide secondary content on click
        $('.secondary').not($div).slideUp(300); //hide secondary content if another dropdown is clicked and not in the current toggle set

        //var $arrow = $('.dropdown a').find($('.fa'));
        //$arrow.each(function () {
        //    var $toggle = $(this);

        //    if ($($arrow, $toggle).hasClass('fa-sort-desc')) {
        //        ($arrow, $toggle).addClass('fa-sort-asc');
        //    }
        //});
         

        return false;

    });
});
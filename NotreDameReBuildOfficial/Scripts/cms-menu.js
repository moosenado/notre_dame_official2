//Hide secondary content
$('.secondary').hide();

//for each dropdown div, assign variable
$('.dropdown').each(function () {
    var $dropdown = $(this);

    //when a left menu item within a dropdown div is clicked
    $('.left-mnu-itm', $dropdown).on('click', function () {
        $div = $('.secondary', $dropdown); //create a set by assigning variable to secondary content in dropdown div

        //show/hide secondary content on click
        $div.slideToggle(300);

        $('.secondary').not($div).slideUp(300); //hide secondary content if another dropdown is clicked and not in the current toggle set
            
        return false;

    });

});
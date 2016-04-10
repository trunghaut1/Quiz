(function ($) {

    //Parallax Image
    $window = $(window);

    $('#cover').each(function () {

        var $scroll = $(this);

        $(window).scroll(function () {

            var yPos = -($window.scrollTop() / 6);

            // background position
            var coords = '50% ' + yPos + 'px';

            // move the background
            $scroll.css({ backgroundPosition: coords });
        });
    });

    // Parallax Video
    /*
    $window = $(window);
    
    $('#cover .videoWrapper').each(function() {
       
        var $scroll = $(this);

        $(window).scroll(function() {
            
            var yPos = ($window.scrollTop() / 7);

            // background position
            var coords = ' ' + yPos + '%';

            // move the background
            $scroll.css({ "top": coords });
        }); 
    });  
    */


}(jQuery));
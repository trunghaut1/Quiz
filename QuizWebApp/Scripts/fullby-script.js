(function ($) {

    /*
	//slider
	$('.carousel').carousel({
	    pause: "false"
	});
	*/

    //image fade
    $('.item img').hide().one("load", function () {
        $(this).fadeIn(500);
    }).each(function () {
        if (this.complete) $(this).trigger("load");
    });

    //tab sidebar
    $('#myTab a').click(function (e) {
        e.preventDefault()
        $(this).tab('show')
    });

    $('.gallery').each(function () {

        $(this).magnificPopup({
            gallery: { enabled: true },
            delegate: 'a', // child items selector, by clicking on it popup will open
            type: 'image',
            // other options
        });
    });


    // widget bar show/hide panel

    $(".widget-bar-button").click(function () {
        $(".widget-bar").toggleClass("show-widget-bar");
        $(".widget-bar-button").toggleClass("animate-widget-button").promise().done(function () {

            //apply only on mobile
            function checkSize() {
                if ($(window).width() > 480) {
                    //$("html, body").animate({ scrollTop: 0 });				        
                } else {
                    $("html, body").animate({ scrollTop: $('.widget-bar').offset().top - 150 }, 'slow');
                }
            }
            checkSize();
        });
    });

    $(window).resize(function () {
        checkSize();
    });


    // widget bar scroll

    var $bl = $(".widget-bar"),
        $th = $(".container-widget"),
        blW = $bl.outerWidth(),
        blSW = $bl[0].scrollWidth,
        wDiff = (blSW / blW) - 1,  // widths difference ratio
        mPadd = 60,  // Mousemove Padding
        damp = 20,  // Mousemove response softness
        mX = 0,   // Real mouse position
        mX2 = 0,   // Modified mouse position
        posX = 0,
        mmAA = blW - (mPadd * 2), // The mousemove available area
        mmAAr = (blW / mmAA);    // get available mousemove fidderence ratio

    $bl.mousemove(function (e) {
        mX = e.pageX - this.offsetLeft;
        mX2 = Math.min(Math.max(0, mX - mPadd), mmAA) * mmAAr;
    });

    setInterval(function () {
        posX += (mX2 - posX) / damp; // zeno's paradox equation "catching delay"    
        $th.css({ marginLeft: -posX * wDiff });
    }, 10);

}(jQuery));
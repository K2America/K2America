jQuery(function() {
    var html = jQuery('html, body'),
        navContainer = jQuery('.nav-container'),
        navToggle = jQuery('.nav-toggle'),
        navDropdownToggle = jQuery('.has-dropdown');

    // Nav toggle
    navToggle.on('click', function(e) {
        var jQuerythis = jQuery(this);
        e.preventDefault();
        jQuerythis.toggleClass('is-active');
        navContainer.toggleClass('is-visible');
        html.toggleClass('nav-open');

        var userAgent = navigator.userAgent || navigator.vendor || window.opera;

    // iOS detection from: http://stackoverflow.com/a/9039885/177710
    if(jQuerythis.hasClass('is-active'))
    {
      if (/iPad|iPhone|iPod/.test(userAgent) && !window.MSStream) {
      
        $('.new').click();
        
      }  
    }

    });
  
    // Nav dropdown toggle
    navDropdownToggle.on('click', function() {
        var jQuerythis = jQuery(this);
        jQuerythis.toggleClass('is-active').children('ul').toggleClass('is-visible');
    });
  
    // Prevent click events from firing on children of navDropdownToggle
    navDropdownToggle.on('click', '*', function(e) {
        e.stopPropagation();
    });
});


var ww = document.body.clientWidth;

jQuery(document).ready(function() {

 jQuery('.menu li a.parent').after('<span class="new"></span>');
  jQuery(".nav li a").each(function() {
    if (jQuery(this).next().length > 0) {
      jQuery(this).addClass("parent");
    };
  })
  
  adjustMenu();
})

jQuery(window).bind('resize orientationchange', function() {
  ww = document.body.clientWidth;
  adjustMenu();
});

var adjustMenu = function() {
  if (ww < 768) {
    jQuery(".nav li").unbind('mouseenter mouseleave');
    jQuery(".new").unbind('click').bind('click', function(e) {
      e.preventDefault();
      jQuery(this).parent("li").toggleClass("hover");
    });
  } 
  else if (ww >= 768) {
    jQuery(".nav li").removeClass("hover");
    jQuery(".new").unbind('click');
    jQuery(".nav li").unbind('mouseenter mouseleave').bind('mouseenter mouseleave', function() {
      jQuery(this).toggleClass('hover');
    });
  }
}





    jQuery(document).ready(function() {
      jQuery("#owl-demo").owlCarousel({
        autoPlay: 3000,
        items : 1,
        itemsDesktop : [1199,1],
        itemsDesktopSmall : [979,1],
        itemsTablet : [768,1],
        itemsMobile : [479,1],
        navigation : true,
      });

    });

    jQuery(document).ready(function() {
      jQuery("#pro-slider").owlCarousel({
        autoPlay: 3000,
        items : 3,
        itemsDesktop : [1199,3],
        itemsDesktopSmall : [979,3],
        itemsTablet : [768,2],
        itemsMobile : [479,1],
        navigation : true,
      });

    });


    jQuery(document).ready(function(){
        jQuery(window).scroll(function(){
         if(jQuery(this).scrollTop()>100){
          jQuery('.scroll-top').fadeIn();
         }
         else{
          jQuery('.scroll-top').fadeOut();
         }
        });
        jQuery('.scroll-top').click(function(){
         jQuery("html, body").animate({scrollTop:0},600);return false;
        });
    });



        

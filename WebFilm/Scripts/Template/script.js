$(document).ready(function(){
});

/**
 * Auto scale background image parent element <section class="fc-auto-scale-bg"></section>
 * Children element <img src="" class="fc-auto-scale-img" />
 */
$(document).ready(function(){ $('.fc-auto-scale-bg').each(function() { var bg = $(this).children('.fc-auto-scale-img'); var h = bg.height(); var w = bg.width(); $(this).children('.fc-auto-scale-img').css('display', 'none'); $(this).css('background', 'url("'+bg.attr('src')+'") center center no-repeat'); if( $(this).width() / $(this).height() < w / h ) $(this).css('background-size','auto 100%'); else $(this).css('background-size','100% auto'); }); });
$(window).resize(function(){ $('.fc-auto-scale-bg').each(function() { $(this).children('.fc-auto-scale-img').css('display','block'); var bg = $(this).children('.fc-auto-scale-img'); var h = bg.height(); var w = bg.width(); $(this).children('.fc-auto-scale-img').css('display','none'); if( $(this).width() / $(this).height() < w / h ) $(this).css('background-size','auto 100%'); else $(this).css('background-size','100% auto'); }); });

$(window).load(function(){
	/**
	 * Detect landscape or portrait cropped image
	 * Landscape by default - Portrait is modified
	 */
	$('*[class*=fc-crop-center-img]').each(function() {
		var ratio = $(this).width() / $(this).height();
		var img = $(this).children('img');
		// if (img.height() > img.width()) $(this).removeClass('fc-crop-center-img-h').addClass('fc-crop-center-img-v');
		if ((img.width() / img.height()) <= ratio) $(this).removeClass('fc-crop-center-img-h').addClass('fc-crop-center-img-v');
	});
});

/**
 * Scroll to top button
 */
$(window).load(function(){
	$(window).scroll(function() {
		if($(this).scrollTop() > 1000)	$('#goTop').stop().animate({ bottom: '20px' }, 500);
		else 							$('#goTop').stop().animate({ bottom: '-100px' }, 500);
	});
	$('#goTop').click(function() { $('html, body').stop().animate({ scrollTop: 0 }, 500, function() { $('#goTop').stop().animate({ bottom: '-100px' }, 500); }); });
});
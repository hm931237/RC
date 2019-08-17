const progressbar = $('.progressBar');
const fieldsets = $('fieldset');

$('.next').click(function() {
  const currentFieldset = $(this).parent();
  const nextFieldset = $(this).parent().next();
  
  $('.progressBar li').eq($('fieldset').index(nextFieldset)).addClass('active');
  
  currentFieldset.css({'display': 'none'});
  nextFieldset.css({'display': 'block'});
})

$('.previous').click(function() {
  const currentFieldset = $(this).parent();
  const prevFieldset = $(this).parent().prev();
  
  $('.progressBar li').eq($('fieldset').index(currentFieldset)).removeClass('active');
  
  currentFieldset.css({'display': 'none'});
  prevFieldset.css({'display': 'block'});
})

/* work time in org */
$(document).ready(function () {
    $('.time').timepicker();
});


/* date of birth in user form */

$('#basicExample .date').datepicker({
    'format': 'm/d/yyyy',
    'autoclose': true
});

// initialize datepair
$('#basicExample').datepair();

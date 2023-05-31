$('.main :radio').on('click', function () {
	let selector = $(this).parent().text();
	// alert($('[class="text"]').length);
	switch (selector) {
		case '*':
			removeStyles();
			$('*').addClass('red-border');
			break;
		case '#id':
			removeStyles();
			$('#top-footer').addClass('bg-red arrow');
			location.href = '#top-footer';
			break;
		case '.className':
			removeStyles();
			$('.column').addClass('red-border');
			break;
		case 'tagName':
			removeStyles();
			$('p').addClass('shadow');
			break;
		case 'first, second, ...':
			removeStyles();
			$('p, h1, h2').addClass('gray-border');
			break;
		case 'outer inner':
			removeStyles();
			$('.column .text').addClass('gray-border shadow');
			break;
		case 'parent > child':
			removeStyles();
			$('.container > div').addClass('bg-red shadow');
			break;
		case 'prev + next':
			removeStyles();
			$('h3+p').addClass('bg-green');
			break;
		case 'prev ~ next':
			removeStyles();
			$('p ~ img').addClass('gray-border shadow');
			break;
		case '[name]':
			removeStyles();
			location.href = '#top-footer';
			$('[href]').addClass('bg-red arrow');			
			break;
		case '[name = value]':
			removeStyles();
			$('[class="text"]').addClass('bg-gray');
			break;
		case '[name != value]':
			removeStyles();
			$('p[class!="text"]').addClass('bg-green');
			break;
		case '[name ^= value]':
			removeStyles();
			$('[class ^="text"]').addClass('bg-green');
			break;
		case '[name $= value]':
			removeStyles();
			$('img[src $= "500x300"]').addClass('gray-border');
			break;
		case '[first][second][...]':
			removeStyles();
			$('input[type="radio"][name="selector"]').addClass('shadow');
			break;
		case ':first-child':
			removeStyles();
			$('.column:first-child').addClass('bg-red shadow');
			break;
		case ':last-child':
			removeStyles();
			$('.column:last-child').addClass('bg-red shadow');
			break;
		case ':nth-child(2n+1)':
			removeStyles();
			$('.column:nth-child(2n+1)').addClass('bg-blue shadow');
			break;
		case ':only-child':
			removeStyles();
			location.href = '#top-footer';
			$('footer a:only-child').addClass('bg-red arrow');
			break;
		case ':only-of-type':
			removeStyles();
			location.href = '#top-footer';
			$('footer:only-of-type').addClass('bg-gray arrow');
			break;
		case ':first-of-type':
			removeStyles();
			$('.text:first-of-type').addClass('bg-gray');
			break;
		case ':last-of-type':
			removeStyles();
			$('.text:last-of-type').addClass('bg-gray');
			break;
		case ':nth-last-of-type(2)':
			removeStyles();
			$('.text:nth-last-of-type(2)').addClass('bg-gray');
			break;
		case ':nth-of-type(even)':
			removeStyles();
			$('.column:nth-of-type(even)').addClass('bg-gray');
			break;
			/*--	jQuery-selectors(filters) --*/
		case ":first":
			removeStyles();
			$('.column:first').addClass('bg-red');
			break;
		case ":last":
			removeStyles();
			$('.column:last').addClass('bg-blue');
			break;
		case ":not(selector)":
			removeStyles();
			$('.column:not(.column-selected)').addClass('bg-green shadow');
			break;
		case ":even":
			removeStyles();
			$('.column:even').addClass('bg-gray');
			break;
		case ":odd":
			removeStyles();
			$('.column:odd').addClass('bg-red shadow');
			break;
		case ":eq(n)":
			removeStyles();
			$('.column:eq(1)').addClass('bg-gray shadow');
			break;
		case ":gt()":
			removeStyles();
			$('.column:gt(2)').addClass('bg-pink shadow');
			break;
		case ":lt()":
			removeStyles();
			$('.column:lt(4)').addClass('bg-blue shadow');
			break;
		case ":header":
			removeStyles();
			$(':header').addClass('bg-gray shadow');
			break;
		case ":visible":
			removeStyles();
			$('div:visible').addClass('bg-green shadow');
			break;
		case ":hidden":
			removeStyles();
			alert($('#contact-form :hidden').text());
			alert($('#contact-form :hidden').val());
			break;
		case ":root":
			removeStyles();
			$(':root').addClass('bg-red');
			break;
			/*--Forms --*/
		case ":button":
			removeStyles();
			location.href = '#contacts';
			$(':button').addClass('shadow');
			break;
		case ":checkbox":
			removeStyles();
			location.href = '#contacts';
			$(':checkbox').addClass('shadow');
			break;
		case ":checked":
			removeStyles();
			location.href = '#contacts';
			$(':checked').addClass('shadow');
			break;
		case ":enabled":
			removeStyles();
			location.href = '#contacts';
			$(':enabled:not(:radio)').prop('disabled', true).addClass('disabled');
			$('#disabled').prop('disabled', false).parent().removeClass('disabled');
			break;
		case ":disabled":
			$('#disabled').prop('disabled', true).parent().addClass('disabled');
			location.href = '#contacts';
			break;
		case ":input":
			removeStyles();
			location.href = '#contacts';
			$(':input').addClass('bg-green shadow');
			break;
		case ":radio":
			removeStyles();
			$(':radio').addClass('shadow');
			break;
		case ":submit":
			removeStyles();
			location.href = '#contacts';
			$(':submit').addClass('shadow');
			break;
		case ":reset":
			removeStyles();
			location.href = '#contacts';
			$(':reset').addClass('shadow bg-gray');
			break;
		case ":text":
			removeStyles();
			location.href = '#contacts';
			$(':text').addClass('bg-blue');
			break;
	}
});

function removeStyles() {
	$('*').removeClass('red-border gray-border bg-blue bg-red bg-green bg-gray bg-pink shadow disabled arrow');
	$(':disabled').prop('disabled', false);
}

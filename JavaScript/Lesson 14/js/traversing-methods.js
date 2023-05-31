$('.main :radio').on('click', function () {
    let method = $(this).parent().text();
    console.log(method);
    switch (method) {
        case 'add()': removeStyles();
            $('.column h3').add('p').addClass('red-border'); break;
        case 'addBack()': removeStyles();
            $('.column').find('p').addBack().addClass('red-border');break;
        case 'contents()': removeStyles();
            $('.column-selected').contents().addClass('shadow'); break;
        case 'children()': removeStyles();
            $('.column-selected').children().addClass('red-border'); break;
        case 'filter()': removeStyles();
            $('.column img').filter('.snow').addClass('gray-border shadow'); break;
        case 'find()': removeStyles();
            $('.column').find('.text').addClass('shadow'); break;
        case 'end()': removeStyles();
            $('.column').find('.text').addClass('shadow')
                .end().find('img').addClass('shadow'); break;
        case 'closest()': removeStyles();
            $('.column').closest('.container').addClass('gray-border'); break;
        case 'parent()': removeStyles();
            $('.column').parent().addClass('red-border'); break;
        case 'parents()': removeStyles();
            $('.column').parents('article').addClass('bg-red shadow'); break;
        case 'parentsUntil()': removeStyles();
            $('.column').parentsUntil('.container').addClass('bg-blue'); break;
        case 'offsetParent()': removeStyles(); $('.column-selected').offsetParent().addClass('gray-border'); break;
        case 'next()': removeStyles();
            $('.column-selected').next().addClass('bg-green'); break;
        case 'nextAll()': removeStyles();
            $('.column-selected').nextAll().addClass('bg-red shadow'); break;
        case 'nextUntil()': removeStyles();
            $('.column p').nextUntil('img').addClass('shadow'); break;
        case 'prev()': removeStyles();
            $('.column-selected').prev().addClass('bg-blue'); break;
        case 'prevAll()': removeStyles();
            $('.column-selected').prevAll().addClass('bg-red shadow'); break;
        case 'prevUntil()': removeStyles();
            $('.column p').prevUntil('img').addClass('shadow'); break;
        case 'first()': removeStyles();
            $('.column').first().addClass('bg-red'); break;
        case 'last()': removeStyles();
            $('.column').last().addClass('bg-green'); break;
        case 'siblings()': removeStyles();
            $('.column p:first-of-type').siblings().addClass('gray-border'); break;
        case 'slice()': removeStyles();
            $('.column').slice(1, 4).addClass('bg-red shadow'); break;
        case 'has()': removeStyles();
            $('.column').has('img.snow').addClass('bg-blue'); break;
        case 'is()': removeStyles();
            $('.column').each(function (i, elem) {
                if ($(this).is(':nth-child(2n)')) $(this).addClass('bg-red');
            }); break;
        case 'each()': removeStyles();
            $('.column p').each(function (ind, elem) {
                let pText = $(elem).text();
                $(elem).html('<span class="bold">' + ind + ') </span>' + pText);
            }); break;
        case 'map()': removeStyles();
            $('.container:eq(1)').prepend('<p class="text-center"><strong>Photo titles:</strong> ' +
                $('.column img').map(function (ind, elem) {
                    return $(elem).attr('alt');
                }).get().join(', ') + '</p>'); break;
        case 'eq()': removeStyles();
            $('.column').eq(1).addClass('bg-blue'); break;
        case 'not()': removeStyles();
            $('.column').not(':nth-child(2)').addClass('bg-green'); break;
        case 'wrap()': removeStyles();
            $('.column').wrap('<div class="bg-green shadow"></div>'); break;
        case 'wrapAll()': removeStyles();
            $('.column').wrapAll('<div class="bg-red shadow"></div>'); break;
        case 'Reset styles': window.location.reload();
    }
});

function removeStyles() {
    $('*').removeClass('red-border gray-border bg-blue bg-red bg-green shadow');
}


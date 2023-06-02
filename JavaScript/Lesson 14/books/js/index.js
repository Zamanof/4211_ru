$("#date-now").text(new Date().getFullYear())

$(".menu li a").click(function (){
    $(this)
        .closest(".menu")
        .find(".active")
        .removeClass('active')
    $(this).addClass('active')
})

// $("input:text").on("keydown input paste", function (){
//     console.log($(this).val());
// })

$(".accordion-header").on("click", function () {
    let activeHeader = $(this)
        .hasClass('active')? $(this) : $(this).parent().find('.accordion-header.active');
    if (!$(this).hasClass("active")){
        activeHeader.next().slideUp(200).removeClass('active');
        activeHeader.removeClass('active')
        $(this).addClass('active')
            .next()
            .slideToggle(500)
            .addClass('active')
    }
    else {
        activeHeader.next().slideToggle(200).removeClass('active');
        activeHeader.removeClass('active')
    }
})

let sectionMore = $("#see-more")
let topCoord = $(window).height() - sectionMore.outerHeight()
$(window).on("resize", function (){
    topCoord = $(window).height() - sectionMore.outerHeight()
    if(!sectionMore.hasClass('closed')){
        sectionMore.css('top', topCoord)
    }
})

$(".close-green, #not-now").click(function (){
    let section = $(this).parents('section')
    let target = $(".close-green")
    if(section.hasClass('closed')){
        section.animate({
            top: topCoord
        }, 400)
        target.html("&times;")
    }
    else{
        section.animate({
            top: "97vh"
        }, 400)
        target.html("&#9650;")
    }
    section.toggleClass("closed")
})

let textAnim = [
    "Read our books",
    "Subscribe",
    "Learn about new books",
    "Add book to our library"
]

let textId = null
let textIndex = 0

$("#start-stop").on('click',showAnimatedText)

function showAnimatedText(){
    $(this).next().addClass('fromTopToDown')
    textId = setInterval(function (){
        $('#text-change').text(textAnim[textIndex])
        textIndex %= textAnim.length
        textIndex++;
    }, 2000)
    $("#start-stop").html("&times;")
        .off('click', showAnimatedText)
        .on('click', stopAnimatedText)
}

function stopAnimatedText(){
    $('#text-change').text('')
    $(this).next().removeClass('fromTopToDown')
    clearInterval(textId)
    $("#start-stop").html("!")
        .off('click', stopAnimatedText)
        .on('click', showAnimatedText)
}

setTimeout(function (e){
    let data = $("[data-popup]")
    popupShow(data)
}, 10000)

$("body").on("click", '[data-popup]', popupShow)

function popupShow(e){
    console.log("Hello")
    e.preventDefault;
    let id = $(e.data('popup'))
    id.fadeIn(600)
}
$('.popup-close').click(function (){
    $(this).closest('.popup-wrapper').fadeOut(400)
})
// const info = document.getElementById("info")

// const info = document.querySelector("#info")
// info.innerText = "Hello"

// $(document).ready(()=>{
//
// })

// $('#info').text("Hello World")

const info = $("#info")
info.text("Salam")
info.css({
    color: "blue",
    fontSize:"50px"})

// info.addClass('text-format')
// info.removeClass('bg-red')

$("#add").on("click", ()=>{
    info.addClass('text-format')
    info.removeClass('bg-red')
})

$("#remove").on("click", ()=>{
    info.removeClass('text-format')
    info.addClass('bg-red')
})

// $(":button").prop('disabled', false)
// $("button:disabled").prop('disabled', false)
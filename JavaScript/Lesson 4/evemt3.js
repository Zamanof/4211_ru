myDiv.addEventListener("mousemove",
    (e)=>{
    // myDiv.style.width = e.pageX + "px";
    // myDiv.style.height = e.pageY + "px";
        info.innerText = `x = ${e.pageX}  y = ${e.pageY}`

})


myDiv.addEventListener("mouseenter",
    (e)=>{
        myDiv.style.background = "red";
        // info.innerText = "mouseenter"
    })

myDiv.addEventListener("mouseleave",
    (e)=>{
        myDiv.style.background = "#0a4c8e";
        // info.innerText = "mouseLeave"
    })
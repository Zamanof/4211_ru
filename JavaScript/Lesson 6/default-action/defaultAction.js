const bg_colors = ['red', 'green', 'blue']
myBody.onmousedown = (e)=>{
    e.preventDefault()
    myBody.style.backgroundColor = bg_colors[e.which - 1]
}

myBody.oncontextmenu = ()=>false


// myBody.addEventListener("click", (e)=>{
//     alert("Hi")
//     console.log("Hi")
//     // console.log(e.which)
//     // info.innerText = e.which;
// })
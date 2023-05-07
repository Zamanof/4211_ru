// sayAleykum = ()=>{
//     alert("Aleykum")
// }
//
//
// mydiv.onclick = sayAleykum

myEventHandler = (e)=>{
    result.innerText = `
    ${e.target.nodeName}
     screenX: ${e.screenX}  screenY: ${e.screenY}
     pageX: ${e.pageX}  pageY: ${e.pageY}
     clientX: ${e.clientX}  clientY: ${e.clientY}`
}

// mybody.onclick = (e)=>{
//     result.innerText = `
//     ${e.target.nodeName}
//      screenX: ${e.screenX}  screenY: ${e.screenY}
//      pageX: ${e.pageX}  pageY: ${e.pageY}
//      clientX: ${e.clientX}  clientY: ${e.clientY}
//     `
//      // console.log(e)
// }

// screenX, screenY
// pageX, pageY
// clientX, clientY


myEvent = "click"
mybody.addEventListener(myEvent , myEventHandler)

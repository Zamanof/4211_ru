outer.onmouseenter = ()=>{
    enter.innerText = "outer"
    console.log("outer div onmouseenter")
}

outer.onmouseover = ()=>{
    over.innerText = "outer"
    console.log("outer div onmouseover")
}

inner.onmouseenter = ()=>{
    enter.innerText = "inner"
    console.log("inner div onmouseenter")
}

inner.onmouseover = ()=>{
    over.innerText = "inner"
    console.log("inner div onmouseover")
}
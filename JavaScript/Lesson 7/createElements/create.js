// createElement
// appendChild
// insertBefore
// removeChild

createNode = ()=>{
    let paragraph = document.createElement("p")
    paragraph.innerText = "Hello"
    paragraph.style.background = "red"
    myBody.appendChild(paragraph)
}
let n = 1

createLi = ()=>{
    let e = document.createElement("li");
    e.innerText = `new ${n++}`;
    return e;
}

addElement = ()=>{
    lst.appendChild(createLi());
}

insertElement = ()=>{
    let first = lst.childNodes[0]
    lst.insertBefore(createLi(), first)
}

removeElement = ()=> {
    lst.removeChild(lst.childNodes[1])
}


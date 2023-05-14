getDOMTree = ()=>{
    let doc = document.documentElement.childNodes
    let txt = ''
    for (let i = 0; i < doc.length; i++){
        if(doc[i].nodeName === '#text') continue
        txt += `${i+1}. ${doc[i].nodeName}
        `
        if (doc[i].hasChildNodes()){
            let nodes = doc[i].childNodes
            n = 1
            for (let j = 0; j < nodes.length; j++){
                if(nodes[j].nodeName === '#text') continue
                txt += `- ${n++}. ${nodes[j].nodeName}
        `
            }
        }
    }
    info.innerText = txt
}
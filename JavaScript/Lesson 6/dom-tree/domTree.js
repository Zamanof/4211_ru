// getDOMTree = ()=>{
//     let doc = document.documentElement.childNodes
//     let txt = ''
//     let n1 = 1
//     for (let i = 0; i < doc.length; i++){
//         if(doc[i].nodeName === '#text') continue
//         txt += `${n1++}. ${doc[i].nodeName}
//         `
//         if (doc[i].hasChildNodes()){
//             let nodes = doc[i].childNodes
//             let n2 = 1
//             for (let j = 0; j < nodes.length; j++){
//                 if(nodes[j].nodeName === '#text') continue
//                 txt += `_${n2++}. ${nodes[j].nodeName}
//         `
//             }
//         }
//     }
//     info.innerText = txt
// }


 let txt = ''
body = document.documentElement.childNodes[2]
myDiv = body.childNodes[1]
ul = myDiv.childNodes[1]

// console.log(ul.parentNode)
console.log(ul.firstChild)
console.log(ul.lastChild)
console.log(ul.firstChild.nextSibling)


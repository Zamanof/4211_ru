let submitButton
    = document.getElementById("submit-btn")

// submitButton.onclick = ()=>{
//     let name
//         = document.getElementById("name-input")
//
//     let lastname
//         = document.getElementById("lastname-input")
//
//     let sendData = `name=${encodeURIComponent(name)}
//     lastname=${encodeURIComponent(lastname)}`
//
//     let request;
//     request = new XMLHttpRequest();
//     request.open("POST", "handle.php")
//     request.setRequestHeader('Content-Type',
//         'application/x-www-form-urlencoded')
//     request.send(sendData)
// }



// submitButton.onclick = ()=>{
//     let myform =
//         document.getElementById("infoForm")
//
//     let sendData = new FormData(myform)
//     sendData.append("myKey", "myValue")
//
//     let request;
//     request = new XMLHttpRequest();
//     request.open("POST", "handle.php")
//     request.setRequestHeader('Content-Type',
//         'multipart/form-data')
//     request.send(sendData)
// }

submitButton.onclick = ()=>{
    let myname
        = document.getElementById("name-input")

    let mylastname
        = document.getElementById("lastname-input")

    let data = {
        name: myname,
        lastname: mylastname
    }
    myJson = JSON.stringify(data, null, 2)

    let request;
    request = new XMLHttpRequest();
    request.open("POST", "handle.php")
    request.setRequestHeader('Content-Type',
        'application/json')
    request.send(myJson)
}
// IE5 - IE6
// let request = ActiveXObject("Microsoft.XMLHTTP");

// let request = new XMLHttpRequest();

let request;

if (window.XMLHttpRequest){
    request = new XMLHttpRequest();
}
else {
    request = ActiveXObject("Microsoft.XMLHTTP");
}

// .open(method, URL [, async, user, password])

// onreadystatechange
// 0  - request non initialize
// 1  - request initialized
// 2  - request is sent
// 3  - request is handling
// 4  - request handle is ready, server response received


request.open("GET", "http://www.omdbapi.com/?t=Arshin+mal+alan&apikey=124df000")
let info = document.getElementById('info')
request.responseType = 'json'
request.onreadystatechange = ()=>{
    console.log(`state = ${request.readyState} ${request.status}`)
    if (request.readyState === 4 && request.status === 200){
        // info.innerText = "Server response received"
        let movie = request.response
        console.log(movie)
        moveInfo = `Title: ${movie.Title}
         Year: ${movie.Year}
         Year: ${movie.Genre}`
        info.innerText = moveInfo
    }
}

request.onload = ()=>{
    if (request.status == 200){
        console.log("Already OK")
    }
}

request.onprogress = ()=>{
    console.log("handle")
}

request.onerror= ()=>{
    console.log("Error")
    info.innerText = "Server is not response!"
}


request.send()



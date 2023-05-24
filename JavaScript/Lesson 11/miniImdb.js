let title = document.getElementById('title')
let year = document.getElementById('year')
let genre = document.getElementById('genre')
let director = document.getElementById('director')
let movieInput = document.getElementById('movieInput')
let getBtn = document.getElementById('getMovie')
let poster = document.getElementById("poster")
let request;

if (window.XMLHttpRequest){
    request = new XMLHttpRequest();
}
else {
    request = ActiveXObject("Microsoft.XMLHTTP");
}
request.responseType = 'json'
const getMovie = ()=> {
    queryText = movieInput.value
    request.open("GET", `http://www.omdbapi.com/?t=${queryText}&apikey=124df000`)
    request.send()
    movieInput.value = ''
}

request.onload = ()=>{
    let movie = request.response
    if (request.status === 200){
        title.innerText = `Movie title: ${movie.Title}`
        year.innerText = `Year: ${movie.Year}`
        genre.innerText = `Genre: ${movie.Genre}`
        director.innerText = `Director: ${movie.Director}`
        poster.src = movie.Poster
    }

}

// request.onreadystatechange = ()=>{
//     if (request.readyState === 4 && request.status !== 200){
//         console.log(onerror)
//         title.innerText = `Movie title: not`
//         year.innerText = `Year: undefined`
//         genre.innerText = `Genre: undefined`
//         director.innerText = `Director: undefined`
//     }
// }


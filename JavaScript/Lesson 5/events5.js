// setTimeout(func, time)
// setInterval(func, time)

// clearTimeout(handle)
// clearInterval(handle)

let left = 0;

function move(){
    left += 1;
    circle.style.left = `${left}px`
    left %= 500
}

// setInterval(move, 1)
// setTimeout(move, 1000)

let interval = setInterval(move, 1)

circle.onclick =()=>{
    clearInterval(interval)
}
// document.addEventListener("DOMContentLoaded",()=>{
//     alert("Hi")
//
// })

// myScript = ()=>{
//     alert("Hi")
// }
// alert("Hi")

const width = 700
const height = 472

let count = 0

const getRandomNumber =
    (size)=> Math.floor(Math.random() * size)

let target = {
    x: getRandomNumber(width),
    y: getRandomNumber(height)
}


getDistance = (e)=>{
    const diffX = e.offsetX - target.x;
    const diffY = e.offsetY - target.y;
    return Math.hypot(diffX, diffY)
    // return Math.sqrt(Math.pow(diffX, 2) + Math.pow(diffY, 2))

}


getDistanceHint = (distance)=>{

    if (distance < 10) return "Огонь";
    else if (distance < 20) return "Горячо";
    else if (distance < 40) return "Жарко";
    else if (distance < 80) return "Тепло";
    else if (distance < 160) return "Холодно";
    else if (distance < 320) return "Очень холодно";
    else return "Мороз";

}

getColor = (distance)=>{
    let color
    if (distance < 10)  color= "red";
    else if (distance < 20) color = "orange";
    else if (distance < 40) color = "gold";
    else if (distance < 80) color = "yellow";
    else if (distance < 160) color =  "cyan";
    else if (distance < 320) color = "blue";
    else color = "darkblue";
    return color;
}

map.onclick = (e)=>{
    count++;
    let dst = getDistance(e);
    let dstHint = getDistanceHint(dst);
    distance.innerText = dstHint;
    distance.style.color = getColor(dst)
    map.style.boxShadow = `1px 2px 26px 0px ${getColor(dst)}`
    if (dst < 8) alert(`Вы нашли этот клад за ${count} попыток`)
}

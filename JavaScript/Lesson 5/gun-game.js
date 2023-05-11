let bulletX = 50;

let isFly = false

const moveBullet = ()=>{
    if(isFly){
        bulletX += 10
        if (bulletX >= 500){
            bulletX = 50
            isFly = false
        }
        else{
            setTimeout(moveBullet, 100)
        }
        bullet.style.left = `${bulletX}px`
    }
}

shot = (e)=>{
    if(e.code == "Space"){
        isFly = !isFly
        moveBullet()
    }
}
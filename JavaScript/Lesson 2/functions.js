// const salam =  () => {
//     return 25;
// }
// foo(5, salam())
// function foo(start, end){
//     for (i = start; i < end; i++){
//         console.log(i)
//     }
// }


const sumThreeValue = (val1, val2, val3)=>{
    console.log(val3)
    if(val3 === undefined){
        val3 = 0;
    }
    return val1 + val2 + val3;
}


const sumThreeValue1 =
    (val1 = 2, val2, val3=0)=>{
    return val1 + val2 + val3;
}
// console.log(sumThreeValue(25,  20, 30))
// console.log(sumThreeValue(25,  20))
// console.log(sumThreeValue1(25)) // Problem
// console.log(sumThreeValue1(25, 65, 78))


// function summ (){
//     console.log(arguments)
//     sum = 0
//     console.log(arguments.length)
//     for(i = 0; i < arguments.length; i++){
//         sum += arguments[i];
//     }
//     return sum
// }
//
//
// console.log(summ(2, 3, 8, 9, 5))

// spread operator and rest parameter

// const bar = (...params)=>{
//     sum = 0
//     for(i = 0; i < params.length; i++){
//         sum += params[i];
//     }
//     return sum
// }
//
// console.log(bar(2, 3, 8, 7))



// const sum2 = (a, b, ...params)=>{
//     console.log(a)
//     console.log(b)
//     console.log(params)
//     sum = 0
//     for(i = 0; i < params.length; i++){
//         sum += params[i];
//     }
//     return sum
// }
//
// console.log(sum2(2, 3, 5, 87, 78))


// Деструктризация
// const sum2 = (...params)=>{
//     let[name, ...others] = params
//     console.log(name)
//     console.log(others)
//
//     sum = 0
//     for(i = 0; i < others.length; i++){
//         sum += others[i];
//     }
//     return sum
// }
//
// console.log(sum2("Nadir", 3, 5, 87, 78))


let arr = [25, 68]
let[a, b, ...c] = arr
console.log(a)
console.log(b)
console.log(c)
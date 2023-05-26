// ES 6 - новинки

// let const

// var WIDTH = 35
// WIDTH = "Salam"
// const HEIGHT = 40

// Symbol

// let symb1 = Symbol("id")
// let symb2 = Symbol("id")
//
// console.log(symb1 === symb2)
// console.log(symb1)

// const obj = {
//     field1: "Value",
//     [Symbol("any")] : "Any Value"
// }

// console.log(Object.keys(obj))
// console.log(Object.getOwnPropertyNames(obj))


// arrow function

// Function declaration
// function foo(){
//     console.log("function Foo")
// }

// Function Expression
// let bar = function (){
//     console.log("function Bar")
// }
//
// foo()
// bar()
//
// let arrow = ()=>{
//     console.log("function arrow")
// }
// arrow()

// let sumFunc = function (a, b){
//     return a + b
// }
// let sum = (a, b)=> a + b
//
// let pow2 = value => value * value
//
// console.log(pow2(5))

let arr = [5, 6, 78, 9, -45, 69, -78]

// arr.map((item)=>{
//     console.log(item)
// })

let new_arr =
    arr.map((item)=> item ** 2)
// console.log(new_arr)

// let pos_arr =
//     arr.filter( item => item > 0)

// let pos_arr =
//     arr.filter(function (item){
//         return item > 0
//     })

// function pred (item){
//     return item > 0
// }
//
// let pos_arr = arr.filter(pred)
// console.log(pos_arr)

// function myFunc(){
//     console.log(this)
// }
//
// console.log(this)
// myFunc()

// let human = {
//     name: "Leonardo",
//     lastname: "Splinterson",
//     info: function (){
//         console.log(this.name)
//     }
// }
//
// // console.log(human.info())
//
// human.info()

// let human = {
//     name: "Leonardo",
//     lastname: "Splinterson",
//     hobbies: ["Draw", "Pizza",
//     "Sakura",  "Katana", "Sake", "Sushi"],
//     info: function (){
//         var thisName = this.name
//         this.hobbies.forEach(
//             function (item){
//             console.log(`${thisName} - ${item}`)
//         })
//     }
// }

// let human = {
//     name: "Leonardo",
//     lastname: "Splinterson",
//     hobbies: ["Draw", "Pizza",
//     "Sakura",  "Katana", "Sake", "Sushi"],
//     info: function (){
//         myfunc = function (item){
//             console.log(`${this.name} - ${item}`)
//         }
//         this.hobbies.forEach(function (i){
//             myfunc(i)
//         })
//     }
// }


let human = {
    name: "Leonardo",
    lastname: "Splinterson",
    hobbies: ["Draw", "Pizza",
    "Sakura",  "Katana", "Sake", "Sushi"],
    info: ()=>{
        console.log(this)
        this.hobbies.forEach((item)=>{
            console.log(`${this.name} - ${item}`)
        })
    }
}

// human.forEach((x)=>{
//     console.log(x)
// })

Object.getOwnPropertyNames(human).forEach((x)=>{
    console.log(`${x} - ${human[x]}`)
})


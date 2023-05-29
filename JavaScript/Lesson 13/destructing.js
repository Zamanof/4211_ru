// const Car = {
//     model: "Any Moddel",
//     marka: "Any Marka",
//     year: 1999
// }
//
// const foo  = (car)=>{
//     console.log(`${car.model} ${car.marka} - ${car.year}`)
// }
//
// // const {model, marka, year} = Car
//
// const bar = ({model, marka, year})=>{
//     console.log(`${model} ${marka} - ${year}`)
// }
//
// // foo(Car)
// // bar(Car)
//
// // const {model, marka, year, engine = 2.0} = Car
// //
// // console.log(engine)
//
// const other = ({model, year })=>{
//     console.log(model)
//     console.log(year)
// }
//
// other(Car)


// arrays

const arr = [25, 98, 78, 356, 112, 12]

// const [numb1, , numb3] = arr
//
// console.log(numb1)
//
// console.log(numb3)

// const [value1,,, ...others] = arr
// console.log(value1)
// console.log(others)
//
// const someFunc = ()=> {
//
//     return [5, 3, 98]
//
// }
//
// const [a, b, c= 25] = someFunc()
// console.log(a)
// console.log(b)
// console.log(c)


const func = (a, b=25)=>{
    return a + b
}

console.log(func(5))
console.log(func(5, 15))
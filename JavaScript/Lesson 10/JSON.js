// myJson = `{
// "name" : "Nadir",
// "lastname" : "Zamanov",
// "age" : 42,
// "languages" :["Azerbaijani", "Russian"],
// "contacts":{
// "phoneNumber": "+994505518013",
// "mail" : "zamanov@itstep.org"
// }
// }`
//
//
// let student = {
//     "name" : "Nadir",
//     "lastname" : "Zamanov",
//     "age" : 42,
//     "languages" :["Azerbaijani", "Russian"],
//     "contacts":{
//         "phoneNumber": "+994505518013",
//         "mail" : "zamanov@itstep.org"
//     },
//     showInfo: ()=>{console.log(`${student.name} ${student.lastname}`)
//     }
// }
//
// // student.showInfo()
//
// let jsonFile = JSON.stringify(student)
// console.log(jsonFile)
//
// let student1 = JSON.parse(jsonFile)
//
// console.log(student1)


// let obj1 ={foo:"bar"}
// let obj2 ={foo:"span"}
//
// obj1.parent = obj2
// obj2.child = obj1
//
// console.log(obj2)
// let json = JSON.stringify(obj2)
// console.log(json)


// let student = {
//     "name" : "Nadir",
//     "lastname" : "Zamanov",
//     "age" : 42,
//     isOld : false
//     ,
//     "languages" :["Azerbaijani", "Russian"],
//     "contacts":{
//         "phoneNumber": "+994505518013",
//         "mail" : "zamanov@itstep.org"
//     },
//     showInfo: ()=>{console.log(`${student.name} ${student.lastname}`)
//     }
//
// }
// const check = (key, value)=>{
//     if (key = "age" && value < 0){
//         return undefined
//     }
//     return value
// }
// let jsonFile = JSON.stringify(student, check, 2)
//
// console.log(jsonFile)
//
// const checkIsOld = (key, value)=>{
//     if (key === 'isOld' && value === true){
//         return undefined
//     }
//     return value
// }
// let newStudent = JSON.parse(jsonFile, checkIsOld)
//
// console.log(newStudent["isOld"])



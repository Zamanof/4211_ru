// const checkForm = (e) =>{
//     let login = document.getElementById("inputLogin").value;
//     if (login.length <= 6){
//         alert("Login must be 6 symbols")
//         return
//     }
//     document.getElementById("signForm").submit()
// }

const checkFormSubmit = (e) =>{
    let login = document.getElementById("inputLogin").value;
    if (login.length <= 6){
        alert("Login must be 6 symbols")
        return false
    }
    if(/^[0-9]/.test(login)){
        alert("Нельзя начинать логин с цифры")
        return false
    }
    let pass = document.getElementById("inputPassword").value
    if (!/[a-z]+/.test(pass)){
        alert("Пароль должень содержать как минимум одну маленкую букву")
        return false
    }
    if (!/[A-Z]+/.test(pass)){
        alert("Пароль должень содержать как минимум одну большую букву")
        return false
    }

}
// let e = 5
// console.log(checkFormSubmit(e))
/*
\d - любая цифра
\s - space symbol
\w - символ допустимый в тексте
.  - любой один символ
\D - не цифра
\S - not space symbol
\W -  символ допустимый в тексте

[a-z] - диапазон от a до z ( [A-Z] ,[0-9])
[^a-z] - все кроме от a до z
[aft] - один из указанных

? - 0 или 1 раз
+ - 1 и более раз
* - 0 и более раз
{2} - ровно 2 раза
{2, } - 2 и более раз
{2, 5} - от 2 до 5-и раз
 */

// "/^\+994\d{9}$/
// - должна начинатся на +994
// - 9 цифр после


// text = "Hi. Im 1 filankes 124.25.36.125 .I Age 42. Height 172.982.25.63"

// temp = /\d+/g

// console.log(temp.exec(text))
// console.log(temp.exec(text))
// console.log(temp.exec(text))

// console.log(text.match(temp))
// console.log(text.match(/[a-zA-Z]{2,}/g))
// console.log(text.match(/(2[0-5]{2}\.|1?[0-9]{1,2}\.){3}(2[0-5]{2}|1?[0-9]{1,2})/g))
// console.log(text.match(temp))

// text = text.replace(/[0-9]/g, '*')
// console.log(text)
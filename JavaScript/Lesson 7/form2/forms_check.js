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
}

/*
\d - любая цифра
\s - space symbol
\w - символ допустимый в тексте
.  - любой один символ
\D - не цифра
\S - not space symbol
\W -  символ допустимый в тексте
 */
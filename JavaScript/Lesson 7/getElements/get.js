// getElementsByName()
// getElementsByTagName()
// getElementsByClassName()
// getElementById()


// querySelectorAll()
// * - all elements
// P - all p tags
// #id_name  - id="id_name"
// .class_name - class = "class_name"
// [name = "name1"] - name = "name1"
// [type="password"] - type="password"
// [checked] - <tag checked>
// div.cl - all div tags with class="cl"
// div, a - all div and a tags
// div a - a tag elements in div

let lst = document.getElementById("lst")
lst.style.listStyle = "none"

let allLi = lst.getElementsByTagName("LI")

// console.log(allLi)

for (const item of allLi) {
    item.style.color = "blue"
}

redClass = document.getElementsByClassName("red")

for (const item of redClass) {
    item.style.background = "red"
    item.style.fontSize = "40px"
}

btns = document.getElementsByName("btn")
console.log(btns)
btns[0].style.padding = "20px"

clRed = document.querySelector(".red")

// nextLi = clRed.nextSibling
// nextLi.style.border = "10px solid black"

// for (const item of clRed) {
//     item.style.border = "10px solid black"
// }
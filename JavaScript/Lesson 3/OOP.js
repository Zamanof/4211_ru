// let numb = 5
// backtick - `
// Template literals/strings `${}`
// let message =`My age is ${numb}`

// OOP

// const person1 = {
//     name:"John",
//     surname:"Doe",
//     age: 25,
//     showInfo: function (){
//         document.write(
//             `
//             <p>First Name: ${person1.name}</p>
//             <p>Last Name: ${person1.surname}</p>
//             <p>Age: ${person1.age}</p>
//             <hr/>
//             `
//         )
//     }
// }
//
// person1.showInfo()
// const person2 = {
//     name:"Ivan",
//     surname:"Ivanov",
//     age: 30,
//     showInfo: function (){
//         document.write(
//             `
//             <p>First Name :${person2.name}</p>
//             <p>Last Name: ${person2.surname}</p>
//             <p>Age: ${person2.age}</p>
//             <hr/>
//             `
//         )
//     }
// }
//
// person2.showInfo()

// function constructor
// function Person(name, surname, age){
//     this.name = name;
//     this.surname = surname;
//     this.age = age;
//     Person.prototype.showInfo = function (){
//         document.write(            `
//             <p>First Name: ${this.name}</p>
//             <p>Last Name: ${this.surname}</p>
//             <p>Age: ${this.age}</p>
//             <hr/>
//             `);
//     }
// }
//
// const per1 = new Person("Nadir", "Zamanov", 42)
// const per2 = new Person("John", "Doe", 25)
//
// per1.showInfo()
// per2.showInfo()

// class
// class Car{
//     constructor(model, marka, year) {
//         this.marka = marka;
//         this.model = model;
//         this.year = year;
//     }
//     showInfo(){
//         document.write(
//             `
//             <p>Marka: ${this.marka}</p>
//             <p>Model: ${this.model}</p>
//             <p>Year: ${this.year}</p>
//             <hr/>
//             `
//         )
//     }
//     toString(){
//         return `
// This is Car object <br/>
// Marka: ${this.marka} <br/>
// Model: ${this.model}`
//     }
// }
//
// const car1 = new Car("ZAZ", 965, 1960)
// car1.showInfo()
//
// document.write(`<h1>${car1}</h1>`)


//OOP Principles

//encapsulation

// class Book{
//     #isbn
//     #page
//     constructor(author, name, page) {
//         this.author = author;
//         this.name = name;
//         this.page = page;
//         this.#isbn = this.page + " - " + Math.floor(Math.random() * 100000000)
//     }
//     set page(value){
//         if (value <= 0){
//             alert("Page count is positive number")
//             this.#page = 0
//         }
//         else{
//             this.#page = value
//         }
//     }
//     get page(){
//         return this.#page
//     }
//     // set isbn(value){
//     //     this.#isbn = value
//     // }
//     get isbn(){
//         return this.#isbn
//     }
// }
//
// const book1 = new Book(
//     " Antoine de Saint-Exupery",
//     "The Little Prince",
//     96
//     )
//
// book1.isbn = "1607963183"
// document.write(book1.isbn)
// document.write('<br/>')
// document.write(book1.page)



// Наследование

class Weapon{
    constructor(name, damage, weigth) {
        this.name = name;
        this.damage = damage;
        this.weight = weigth;
    }
    showInfo()
    {
        console.log(`
name: ${this.name} 
damage: ${this.damage}
weight: ${this.weight}`)
    }
}

class Sword extends Weapon{
    constructor(name, damage, weight, material) {
        super(name, damage, weight);
        this.material = material
    }
    attack(){
        console.log(`this ${this.name} attacked. Damage is ${this.damage}`)
    }
    showInfo(){
        super.showInfo()
        console.log("material:"  + this.material)
    }
}


const excalibur = new Sword(
    "Excalibur",
    1250,
    8,
    "vebranium")

const damoclis_gladius = new Sword(
    "Damoclis gladius",
    398,
    3,
    "Myolnir")

excalibur.attack()
excalibur.showInfo()

damoclis_gladius.showInfo()
damoclis_gladius.attack()
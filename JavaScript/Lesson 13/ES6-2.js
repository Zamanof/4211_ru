import {Human} from "./Human.js";
import {Student} from "./Student.js";

const human1 = new Human(
    "Nadir", "Zamanov", 42)
// human1.showInfo()

// human1.showInfo()

// const someObject = {
//     name: "Name",
//     lastname: "Lastname",
//     age: 42,
//     showInfo: function (){
//         console.log(`${this.name}  ${this.lastname} - ${this.age}`)
//     }
// }

// someObject.showInfo()


//
const student1 = new Student("Salam", "Salamzadeh",
    25, "FBMS 1_23_4")

// student1.showInfo()

// setters and getters

class Car{
    #field = 5
    constructor(model, marka, year) {
        this._model = model
        this._marka = marka
        if (year > 1894 && year < 2023){
            this._year = year
        }
        else{
            this._year = 1900
        }

    }
    static count = 0
    set year(year){
        if (year > 1894 && year < 2023){
            this._year = year
        }
        else {
            // this._year = 1900
            console.log("Incorrect date")
        }
    }
    get year(){
        return this._year
    }

}
//
//
const car = new Car("Salam", "Salamzade", 6598)
car.year = 1985
// console.log(car.year)
console.log(car._year)

const info = ({name, groupName})=>{
    console.log(name)
    console.log(groupName)
}

// info(student1)


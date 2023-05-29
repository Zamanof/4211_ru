class Human {
    constructor(name, lastname, age) {
        this.name = name
        this.lastname = lastname
        this.age = age
    }
    showInfo  (){
        // return (`${this.name}  ${this.lastname} - ${this.age}`)
        console.log(`${this.name}  ${this.lastname} - ${this.age}`)
    }
}



export {Human}


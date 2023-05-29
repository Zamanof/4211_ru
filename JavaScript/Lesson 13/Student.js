import {Human} from "./Human.js";

export class Student extends Human{
    constructor(name, lastname, age, groupName) {
        super(name, lastname, age);
        this.groupName = groupName
    }
    showInfo(){

        // return (super.showInfo() + ` group name - ${this.groupName}`)
        super.showInfo()
        console.log(`group name - ${this.groupName}`)
    }
}
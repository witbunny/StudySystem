export { getName, login }

import { Score, record } from './score.js';

class User {
    constructor(id, name, password) {
        this.id = id;
        this.name = name;
        this.password = password;
        User.allInstances.push(this);
    }

    static getNameById(id) {
        var name;
        User.allInstances.forEach(function (value) {
            if (value.id == id) {
                name = value.name;
            }
        });
        return name;
    }

    static login(name, password) {
        var id;
        User.allInstances.forEach(function (value) {
            if (value.name === name && value.password === password) {
                id = value.id;
            }
        });
        return id;
    }
}

User.allInstances = [];

var leo = new User(1, 'leo', '1234');
var ana = new User(2, 'ana', '1234');

var getName = User.getNameById;
var login = User.login;



//var leo1 = new Score(leo.name, 85);
//var leo2 = new Score(leo.name, 95);
//var leo3 = new Score(leo.name, 75);
//leo1.save();
//leo2.save();
//leo3.save();

//var ana1 = new Score(ana.name, 69);
//var ana2 = new Score(ana.name, 99);
//ana1.save();
//ana2.save();

//console.log(record());


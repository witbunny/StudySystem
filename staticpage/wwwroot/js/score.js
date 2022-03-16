export { Score, bestOfAll as record }

import { getName, login } from "./user.js";

class Score {
    constructor(name, score) {
        this.datetime = new Date();
        this.playName = name;
        this.score = score;
    }

    static getBest(name) {
        var best;
        Score.allInstances.get(name).forEach(function (value) {
            if (best == undefined) {
                best = value;
            } //else continue
            if (value.score > best.score) {
                best = value
            } //else nothing
        });
        return best;
    }

    save() {
        var hasScore = Score.allInstances.get(this.playName);
        if (hasScore == undefined) {
            Score.allInstances.set(this.playName, []);
        } //else continue
        Score.allInstances.get(this.playName).push(this);
    }
}

Score.allInstances = new Map();

let bestOfAll = function () {
    var bestScore;
    var userScore;
    Score.allInstances.forEach(function (value, key) {
        userScore = Score.getBest(key).score;
        if (bestScore == undefined) {
            bestScore = userScore;
        } //else continue
        if (userScore > bestScore) {
            bestScore = userScore
        } //else nothing
    });
    return bestScore;
}

var leo1 = new Score('leo', 85);
var leo2 = new Score('leo', 95);
var leo3 = new Score('leo', 75);
leo1.save();
leo2.save();
leo3.save();

var ana1 = new Score('ana', 69);
var ana2 = new Score('ana', 99);
ana1.save();
ana2.save();

//console.log(getName(2));
//console.log(login('leo', '1234'));



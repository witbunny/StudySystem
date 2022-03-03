(function () {
    var oBell = document.getElementById("bell");
    var iId = setInterval(function () {
        if (oBell.classList.contains("lightblue")) {
            oBell.classList.replace("lightblue", "darkblue");
        }
        else {
            oBell.classList.replace("darkblue", "lightblue");
        }
    }, 1000);
}) ();
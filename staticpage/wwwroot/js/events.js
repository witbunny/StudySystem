(function () {
    var aBtn = document.getElementsByTagName("button");
    aBtn[0].onclick = function () {
        history.back();
    };
    aBtn[1].onclick = function () {
        history.forward();
    };
})();

(function () {
    var oA = document.getElementsByTagName("a")[0];
    var oInput = document.getElementsByTagName("input")[0];
    var oBtn = document.getElementById("go");
    oA.onclick = function (event) {
        event.preventDefault();
        oInput.value = oA.href;
    }
    oBtn.onclick = function () {
        open(oInput.value);
    }
})();
(function () {
    var oUp = document.getElementById("select-all-up");
    var oDown = document.getElementById("select-all-down");

    var aCheckbox = [];
    var aInput = document.getElementsByTagName("input");
    for (var i = 0; i < aInput.length; i++) {
        if (aInput[i].type === "checkbox" && aInput[i].name.startsWith("Messages")) {
            aCheckbox.push(aInput[i]);
        }
    }

    oUp.onclick = selectAll;
    oDown.onclick = selectAll;
    function selectAll() {
        var isChecked = this.checked;
        for (var i = 0; i < aCheckbox.length; i++) {
            aCheckbox[i].checked = isChecked;
        }
        oUp.checked = isChecked;
        oDown.checked = isChecked;
    }
})();
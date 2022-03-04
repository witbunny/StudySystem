(function () {
    var oRegister, oSubmit, oReset;
    var aForm = document.getElementsByTagName("form");
    for (var i = 0; i < aForm.length; i++) {
        if (aForm[i].action.endsWith("/Register")) {
            oRegister = aForm[i];
        }
    }
    var aInput = oRegister.getElementsByTagName("input");
    for (var i = 0; i < aInput.length; i++) {
        if (aInput[i].type === "submit") {
            oSubmit = aInput[i];
        }
        if (aInput[i].type === "reset") {
            oReset = aInput[i];
        }
    }

    var oIName = document.getElementById("Register_InvitedName");
    var oICode = document.getElementById("Register_InvitedCode");
    var oName = document.getElementById("Register_Name");
    var oPassword = document.getElementById("Register_Password");
    var oCPassword = document.getElementById("Register_ConfirmPassword");
    var oCaptchaCode = document.getElementById("Register_CaptchaCode");

    //oIName.onkeyup = function () {
    //    checkEmpty("* 邀请人不能为空");
    //};

    //oICode.onkeyup = function () {
    //    checkEmpty("* 邀请码不能为空");
    //};
    //oICode.onkeyup = function () {
    //    checkFour("* 长度为4个");
    //};
    oIName.addEventListener("keyup", function () {
        checkEmpty("* 邀请人不能为空");
    });

    oICode.addEventListener("keyup", function () {
        checkEmpty("* 邀请码不能为空");
    });
    oICode.addEventListener("keyup", function () {
        checkFour("* 长度为4个");
    });

    oName.addEventListener("keyup", function () {
        checkEmpty("* 用户名不能为空");
    });

    oPassword.addEventListener("keyup", function () {
        checkEmpty("* 密码不能为空");
    });
    oPassword.addEventListener("keyup", function () {
        checkMoreFour("* 长度不小于4个");
    });

    oCPassword.addEventListener("keyup", function () {
        checkEmpty("* 确认密码不能为空");
    });
    oCPassword.addEventListener("keyup", function () {
        checkSame("* 必须和密码相同");
    });

    oCaptchaCode.addEventListener("keyup", function () {
        checkEmpty("* 验证码不能为空");
    });
    oCaptchaCode.addEventListener("keyup", function () {
        checkFour("* 长度为4个");
    });

    function checkEmpty(errorMessage) {
        var target = event.target;
        var warning = nextSpan(event.target);
        checkWith(r => r.value == "", target, warning, errorMessage);
    }
    function checkFour(errorMessage) {
        var target = event.target;
        var warning = nextSpan(event.target);
        if (target.value.length > 0) {
            checkWith(r => r.value.length != 4, target, warning, errorMessage);
        }
    }
    function checkMoreFour(errorMessage) {
        var target = event.target;
        var warning = nextSpan(event.target);
        if (target.value.length > 0) {
            checkWith(r => r.value.length < 4, target, warning, errorMessage);
        }
    }
    function checkSame(errorMessage) {
        var target = event.target;
        var warning = nextSpan(event.target);
        if (target.value.length > 0) {
            checkWith(r => r.value != oPassword.value, target, warning, errorMessage);
        }
    }

    function checkWith(invalid, resc, span, errorMessage) {
        if (invalid(resc)) {
            resc.classList.remove("input-validation-valid");
            resc.classList.add("input-validation-error");
            span.classList.remove("field-validation-valid");
            span.classList.add("field-validation-error");
            span.innerText = errorMessage;
        }
        else {
            resc.classList.remove("input-validation-error");
            resc.classList.add("input-validation-valid");
            span.classList.remove("field-validation-error");
            span.classList.add("field-validation-valid");
            span.innerText = "";
        }
    }
    function nextSpan(obj) {
        //return (obj.nextElementSibling.tagName == "SPAN") ?
        //    obj.nextElementSibling :
        //    obj.nextElementSibling.nextElementSibling;
        if (obj.nextElementSibling.tagName == "SPAN") {
            return obj.nextElementSibling;
        }
        else if (obj.parentElement.nextElementSibling.tagName == "SPAN") {
            return obj.parentElement.nextElementSibling;
        }
        else {
            return obj.nextElementSibling.nextElementSibling;
        }
    }
})();
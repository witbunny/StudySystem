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
    var oRToken = document.getElementsByName("__RequestVerificationToken")[0];
    var oInvitedList = oIName.nextElementSibling;
    

    function checkEmpty(errorMessage) {
        var target = event.target;
        var warning = nextSpan(event.target);
        checkWith(r => r.value === "", target, warning, errorMessage);
    }
    function checkFour(errorMessage) {
        var target = event.target;
        var warning = nextSpan(event.target);
        if (target.value.length > 0) {
            checkWith(r => r.value.length !== 4, target, warning, errorMessage);
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
            checkWith(r => r.value !== oPassword.value, target, warning, errorMessage);
        }
    }

    function checkWith(invalid, resc, span, errorMessage) {
        if (invalid(resc)) {
            checkInvalid(resc, span, errorMessage);
        }
        else {
            checkValid(resc, span);
        }
    }
    function checkValid(resc, span) {
        resc.classList.remove("input-validation-error");
        resc.classList.add("input-validation-valid");
        span.classList.remove("field-validation-error");
        span.classList.add("field-validation-valid");
        span.innerText = "";
    }
    function checkInvalid(resc, span, errorMessage) {
        resc.classList.remove("input-validation-valid");
        resc.classList.add("input-validation-error");
        span.classList.remove("field-validation-valid");
        span.classList.add("field-validation-error");
        span.innerText = errorMessage;
    }
    function nextSpan(obj) {
        //return (obj.nextElementSibling.tagName == "SPAN") ?
        //    obj.nextElementSibling :
        //    obj.nextElementSibling.nextElementSibling;
        if (obj.nextElementSibling.tagName === "SPAN") {
            return obj.nextElementSibling;
        }
        else if (obj.parentElement.nextElementSibling.tagName === "SPAN") {
            return obj.parentElement.nextElementSibling;
        }
        else {
            return obj.nextElementSibling.nextElementSibling;
        }
    }

    

    //oSubmit.onclick = function (event) {
    //    event.preventDefault();

    //    var xhttp = new XMLHttpRequest();

    //    //xhttp.open("GET", "/Register?id=2");
    //    //xhttp.send();

    //    xhttp.open("POST", "/Register");
    //    xhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    //    xhttp.send("Register.InvitedName=asd");

    //    //xhttp.onload = function () {
    //    //    console.log(xhttp.response);
    //    //};

    //    xhttp.onreadystatechange = function () {
    //        if (this.readyState === 4 && this.status === 200) {
    //            console.log(xhttp.response);
    //        }
    //        //console.log(xhttp.readyState);
    //    };
    //};

    
    oIName.addEventListener("blur", function () {
        if (this.value === "") {
            checkEmpty("*js 邀请人不能为空");
            return;
        }

        var xhttp = new XMLHttpRequest();

        xhttp.open("POST", "/Register");
        xhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

        var sendString = `ajax=invite&${oIName.name}=${oIName.value}&${oRToken.name}=${oRToken.value}`;
        xhttp.send(sendString);

        xhttp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                var alist = JSON.parse(this.response);
                
                if (alist.length === 0) {
                    checkInvalid(oIName, nextSpan(oIName), "*js 邀请人不存在");
                    return;
                }

                var html = "";
                for (var i = 0; i < alist.length; i++) {
                    html += `<div class="form-inline">
                            <div class="form-check mr-4">
                                <label class="form-check-label">
                                    <input class="form-check-input" type="radio" name="invited-list" value="${alist[i].name}">${alist[i].name}
                                </label>
                            </div>
                            <a href>
                                <span class="fa fa-hand-o-right"></span>主页
                            </a>
                        </div>`;
                }

                oInvitedList.innerHTML = `<div class="px-2 pt-3 label-normal">
                        ${html}
                    </div>`;

                var aRadio = document.getElementsByName("invited-list");
                var oDiv = aRadio[0].parentElement.parentElement.parentElement.parentElement;

                oDiv.onchange = function (event) {
                    oIName.value = event.target.value;
                };

                aRadio[0].checked = true;
                oIName.value = aRadio[0].value;
            }
        };
    });
    oIName.addEventListener("focus", function () {
        oInvitedList.innerHTML = "";
        checkValid(this, nextSpan(this));
    });
    oIName.addEventListener("keyup", function (event) {
        if (event.keyCode === 9 || event.keyCode === 16) {
            return;
        }
        checkEmpty("*js 邀请人不能为空");
    });

    oICode.addEventListener("blur", function () {
        checkEmpty("*js 邀请码不能为空");
        checkFour("*js 长度为4个");
    });
    oICode.addEventListener("focus", function () {
        checkValid(this, nextSpan(this));
    });
    oICode.addEventListener("keyup", function (event) {
        if (event.keyCode === 9 || event.keyCode === 16) {
            return;
        }
        checkEmpty("*js 邀请码不能为空");
        checkFour("*js 长度为4个");
    });

    oName.addEventListener("blur", function () {
        if (this.value === "") {
            checkEmpty("*js 用户名不能为空");
            return;
        }

        var xhttp = new XMLHttpRequest();

        xhttp.open("POST", "/Register");
        xhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

        var sendString = `ajax=name&${oName.name}=${oName.value}&${oRToken.name}=${oRToken.value}`;
        xhttp.send(sendString);

        xhttp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                var oUser = JSON.parse(this.response);

                if (oUser !== null) {
                    checkInvalid(oName, nextSpan(oName), "*js 用户名已注册");
                }
            }
        };
    });
    oName.addEventListener("focus", function () {
        checkValid(this, nextSpan(this));
    });
    oName.addEventListener("keyup", function (event) {
        if (event.keyCode === 9 || event.keyCode === 16) {
            return;
        }
        checkEmpty("*js 用户名不能为空");
    });

    oPassword.addEventListener("blur", function () {
        checkEmpty("*js 密码不能为空");
        checkMoreFour("*js 长度不小于4个");
    });
    oPassword.addEventListener("focus", function () {
        checkValid(this, nextSpan(this));
    });
    oPassword.addEventListener("keyup", function (event) {
        if (event.keyCode === 9 || event.keyCode === 16) {
            return;
        }
        checkEmpty("*js 密码不能为空");
        checkMoreFour("*js 长度不小于4个");
    });

    oCPassword.addEventListener("blur", function () {
        checkEmpty("*js 确认密码不能为空");
        checkSame("*js 必须和密码相同");
    });
    oCPassword.addEventListener("focus", function () {
        checkValid(this, nextSpan(this));
    });
    oCPassword.addEventListener("keyup", function (event) {
        if (event.keyCode === 9 || event.keyCode === 16) {
            return;
        }
        checkEmpty("*js 确认密码不能为空");
        checkSame("*js 必须和密码相同");
    });

    oCaptchaCode.addEventListener("blur", function () {
        checkEmpty("*js 验证码不能为空");
        checkFour("*js 长度为4个");
    });
    oCaptchaCode.addEventListener("focus", function () {
        checkValid(this, nextSpan(this));
    });
    oCaptchaCode.addEventListener("keyup", function (event) {
        if (event.keyCode === 9 || event.keyCode === 16) {
            return;
        }
        checkEmpty("*js 验证码不能为空");
        checkFour("*js 长度为4个");
    });

    //oIName.onkeyup = function () {
    //    checkEmpty("* 邀请人不能为空");
    //};

    //oICode.onkeyup = function () {
    //    checkEmpty("* 邀请码不能为空");
    //};
    //oICode.onkeyup = function () {
    //    checkFour("* 长度为4个");
    //};
    
})();
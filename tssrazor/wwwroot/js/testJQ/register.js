$(document).ready(function () {
    var $form = $('form');
    var $input = $form.find('input');
    var $invited = $form.find('#Register_InvitedName');
    var $name = $form.find('#Register_Name');
    var $token = $form.find('[name="__RequestVerificationToken"]');
    var $searchInvited = $form.find('[wtb-search-invited]');

    $input.blur(function (event) {
        check(event.target);
    }).focus(function (event) {
        turnValid(event.target);
    });
    $form.keyup(function (event) {
        if (event.keyCode === 9 || event.keyCode === 16) {
            return;
        }
        check(event.target);
    });

    $invited.blur(function () {
        var $this = $(this);
        if ($this.val() === '') {
            return;
        }

        $.ajax({
            url: '/Register',
            method: 'POST',
            data: `ajax=invite&${$invited.prop('name')}=${$invited.val()}&${$token.prop('name')}=${$token.val()}`,

            beforeSend: function () {
                console.log("beforesend");
            },
            success: function (data) {
                if (data.length === 0) {
                    turnInvalid($this, '*jq 邀请人不存在');
                    return;
                }

                var html = "";
                for (var i = 0; i < data.length; i++) {
                    html += `<div class="form-inline">
                            <div class="form-check mr-4">
                                <label class="form-check-label">
                                    <input class="form-check-input" type="radio" name="invited-list" value="${data[i].name}">${data[i].name}
                                </label>
                            </div>
                            <a href>
                                <span class="fa fa-hand-o-right"></span>主页
                            </a>
                        </div>`;
                }

                $searchInvited.html(`<div class="px-2 pt-3 label-normal">
                        ${html}
                    </div>`);

                $searchInvited.change(function (event) {
                    $this.val(event.target.value);
                });

                var $first = $searchInvited.find('[name="invited-list"]').first();
                $first.prop('checked', true);
                $this.val($first.val());
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR);
                console.log(textStatus);
                console.log(errorThrown);
            },
            complete: function () {
                console.log("complete");
            }
        });
    }).focus(function () {
        $searchInvited.html('');
    });

    $name.blur(function () {
        var $this = $(this);
        if ($this.val() === '') {
            return;
        }

        $.ajax({
            url: '/Register',
            method: 'POST',
            data: `ajax=name&${$name.prop('name')}=${$name.val()}&${$token.prop('name')}=${$token.val()}`,

            beforeSend: function () {
                console.log("beforesend");
            },
            success: function (data) {
                if (data !== null) {
                    turnInvalid($this, '*jq 用户名已注册')
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR);
                console.log(textStatus);
                console.log(errorThrown);
            },
            complete: function () {
                console.log("complete");
            }
        });
    });

    function check(ctr) {
        var $ctr = $(ctr);
        var $tip = $($ctr.attr('wtb-val-msg'));
        var $comp = $($ctr.attr('wtb-val-comp'));

        var emptyMsg = $ctr.attr('wtb-val-empty');
        var fourMsg = $ctr.attr('wtb-val-four');
        var morefourMsg = $ctr.attr('wtb-val-morefour');
        var sameMsg = $ctr.attr('wtb-val-same');

        if (emptyMsg !== undefined) {
            checkWith(c => c.val() === '', $ctr, $tip, emptyMsg);
        }
        if (fourMsg !== undefined && $ctr.val() !== '') {
            checkWith(c => c.val().length !== 4, $ctr, $tip, fourMsg);
        }
        if (morefourMsg !== undefined && $ctr.val() !== '') {
            checkWith(c => c.val().length < 4, $ctr, $tip, morefourMsg);
        }
        if (sameMsg !== undefined && $ctr.val() !== '') {
            checkWith(c => c.val() !== $comp.val(), $ctr, $tip, sameMsg);
        }
    }
    function turnValid(ctr) {
        var $ctr = $(ctr);
        var $tip = $($ctr.attr('wtb-val-msg'));
        checkValid($ctr, $tip);
    }
    function turnInvalid(ctr, msg) {
        var $ctr = $(ctr);
        var $tip = $($ctr.attr('wtb-val-msg'));
        checkInvalid($ctr, $tip, msg);
    }

    function checkWith(invalid, ctr, tip, msg) {
        if (invalid(ctr)) {
            checkInvalid(ctr, tip, msg);
        }
        else {
            checkValid(ctr, tip);
        }
    }
    function checkValid(ctr, tip) {
        ctr.removeClass('input-validation-error').addClass('input-validation-valid');
        tip.removeClass('field-validation-error').addClass('field-validation-valid');
        tip.text('');
    }
    function checkInvalid(ctr, tip, msg) {
        ctr.removeClass('input-validation-valid').addClass('input-validation-error');
        tip.removeClass('field-validation-valid').addClass('field-validation-error');
        tip.text(msg);
    }


    //wtb - val - empty="xxx"
    //wtb - val - four="xxx"
    //wtb - val - same="xxx"
    //wtb - val - morefour="xxx"

    //wtb - val - comp='#id'
    //wtb - val - msg='#id'
});
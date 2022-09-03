jQuery(function ($) {

    'use strict';

    (function () {
        $(window).load(function () {
            $('#pre-status').fadeOut();
            $('#st-preloader').delay(350).fadeOut('slow');
        });
    }());

    (function () {
        // E-mail validation via regular expression
        function isValidEmailAddress(emailAddress) {
            var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
            return pattern.test(emailAddress);
        };

        $('#subscribe').ajaxChimp({
            language: 'es',
            url: 'http://xxx.xxx.list-manage.com/subscribe/post?u=xxx&id=xxx'
        });

        $.ajaxChimp.translations.es = {
            'submit': 'Submitting...',
            0: '<i class="fa fa-check"></i> We will be in touch soon!',
            1: '<i class="fa fa-warning"></i> You must enter a valid e-mail address.',
            2: '<i class="fa fa-warning"></i> E-mail address is not valid.',
            3: '<i class="fa fa-warning"></i> E-mail address is not valid.',
            4: '<i class="fa fa-warning"></i> E-mail address is not valid.',
            5: '<i class="fa fa-warning"></i> E-mail address is not valid.'
        }

    }());

    //報名表成功訊息按鈕
    (function () {
        if ($("#MessageBox").length > 0 && ("#MessageBox").valueOf() != null && ("#MessageBox").valueOf() != "") {
            $("#mask").show();
            $("#messages").show();
        }

    }());

    //登入成功訊息燈箱
    (function () {
        if ($("#MessageBoxLogin").length > 0 && ("#MessageBoxLogin").valueOf() != null && ("#MessageBoxLogin").valueOf() != "") {
            $("#mask").show();
            $("#messagesLogin").show();
        }
    }());
});

//DataTable
$(document).ready(function () {
    $('#dataTable').DataTable({
        responsive: true,
        order: [[2, 'desc']],
        language: {
            "emptyTable": "無紀錄",
            "lengthMenu": "顯示前 _MENU_ 位會員🎓 ",
            "info": " 總計 _TOTAL_ 位會員🎓  ",
            "infoEmpty": "顯示第 0 到第 0 位會員🎓 ，共計 0 位會員🎓 ",
            "search": "🔎搜尋: ",
            "paginate": {
                "first": "第一頁",
                "last": "最後一頁",
                "next": "下一頁",
                "previous": "前一頁"
            }
        }
    });

    //管理者的DataTable
    $('#dataTableManager').DataTable({
        responsive: true,
        order: [[4, 'desc']],
        language: {
            "emptyTable": "無留言紀錄",
            "lengthMenu": "顯示前 _MENU_ 則紀錄🎓 ",
            "info": " 總計 _TOTAL_ 則紀錄🎓  ",
            "infoEmpty": "顯示第 0 到第 0 位會員🎓 ，共計 0 則紀錄🎓 ",
            "search": "🔎搜尋: ",
            "paginate": {
                "first": "第一頁",
                "last": "最後一頁",
                "next": "下一頁",
                "previous": "前一頁"
            }
        }
    });


});


//刪除資料取消
function CancelDelete() {
    $("#deleteOrNot").hide();
    $("#mask").hide();
}

//刪除資料燈箱打開
function ShowDelete(clicked_id) {
    $("#mask").show();
    $(".deleteFunc").attr('id', clicked_id);
    $("#deleteOrNot").show();
}

//刪除確定跑Controller
function confirmDelete(id) {
    $.ajax({
        // edit to add steve's suggestion.
        url: '/Home/Delete/' + id,
        success: function (data) {
            location.reload(true);
        }
    });
}

//刪除成功燈箱關閉
function OKgood() {
    $("#mask").hide();
    $("#deleteSuccess").hide();
    $("#sendForgotPassEmailSuccess").hide();
}

//刪除成功訊息燈箱
(function () {
    if ($('#DeleteMessageBox').length > 0 && ('#DeleteMessageBox').valueOf() != null && ('#DeleteMessageBox').valueOf() != "") {
        $("#mask").show();
        $("#deleteSuccess").show();
        //清除DeleteSession
        $.ajax('/Home/CleanDeleteSession');
    }
}());

//編輯成功訊息燈箱打開
(function () {
    if ($('#EditSuccessMessageBox').length > 0 && ('#EditSuccessMessageBox').valueOf() != null && ('#EditSuccessMessageBox').valueOf() != "") {
        $("#mask").show();
        $("#editSuccessBox").show();
    }
}());

(function () {
    //報名表單匿名
    $("#CheckBox").change(function () {
        if (this.checked) {
            $('#InputDiv').html("<input placeholder='乂卍煞采o戀羽卍乂' type='text' class='form-control user_name' name='Name' id='user_name2' tabindex='1' autofocus hidden >")
            $('#user_name').remove();
            $('#user_name2').show();
            $('#user_name2').attr("required", true);
        }
        else {
            $('#InputDiv').html("<input type='text' class='form-control user_name' name='Name' id='user_name' tabindex='1' value='" + $('#txtSessionName').val() + "' required  autofocus readonly >")
            $('#user_name2').remove();
            $('#user_name').show();
        }
    });
}());

//報名表單純祝福
(function () {
    var initialVal = $('#PeopleNumber').val();
    $("#JustBless").change(function () {
        if (this.checked) {
            $('#PeopleNumber').remove();
        }
        else {
            $('#AddPeopleNumber').html('<input name="PeopleNumber" type="number" class="form-control PeopleNumber" id="PeopleNumber" placeholder="1~5" min="1" max="5" value="' + initialVal + '" required>');
        }
    });
}());

//打開忘記密碼燈箱
function ForgetPassModal() {
    $("#mask").show();
    $("#forgetPass").show();
}


//忘記密碼寄出成功訊息燈箱
(function () {
    if ($('#SendForgotPassMailMessageBox').length > 0 && ('#SendForgotPassMailMessageBox').valueOf() != null && ('#SendForgotPassMailMessageBox').valueOf() != "") {
        $("#mask").show();
        $("#sendResetPassSuccessBox").show();
    }
}());

//打開忘記密碼燈箱
function ReWriteAccount() {
    $("#sendResetPassSuccessBox").hide();
    $("#forgetPass").show();
}

//忘記密碼燈箱取消
function CancelResetPass() {
    $("#forgetPass").hide();
    $("#mask").hide();
}

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

    //訊息按鈕
    (function () {

        if ($("#MessageBox").length > 0 && ("#MessageBox").valueOf() != null && ("#MessageBox").valueOf() != "") {
            $("#mask").show();
            $("#messages").show();
        }

    }());

    (function () {
        if ($("#MessageBox").length > 0 && ("#MessageBox").valueOf() != null && ("#MessageBox").valueOf() != "") {
            $("#mask").show();
            $("#messages").show();
        }
    }());
});

//DataTable
$(document).ready(function () {
    $('#dataTable').DataTable({
        responsive: true,
        order: [[4, 'desc']],
        language: {
            "emptyTable": "無紀錄",
            "lengthMenu": "顯示前 _MENU_ 位會員🎓 ",
            "info": " 總計 _TOTAL_ 位會員🎓  ",
            "infoEmpty": "顯示第 0 到第 0 位會員🎓 ，共計 0 位會員🎓 ",
            "search": "🔎搜尋:",
            "paginate": {
                "first": "第一頁",
                "last": "最後一頁",
                "next": "下一頁",
                "previous": "前一頁"
            }
        }
    });
});




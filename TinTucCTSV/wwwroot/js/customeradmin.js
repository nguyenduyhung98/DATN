$(function() {
    $("#checkall").change(function() {
        if ($(this).prop("checked") == true) {
            $("input[name = list]").prop("checked", true);
        } else {
            $("input[name = list]").prop("checked", false);
        }
    });
});
$(document).ready(function () {
    $("#btn_check").click(function () {
        var test_value = $("#img-check").val();
        var extension = test_value.split('.').pop().toLowerCase();

        if ($.inArray(extension, ['png', 'gif', 'jpeg', 'jpg']) == -1) {
            alert("File ảnh không hợp lệ!");
            return false;
        }
    });
});
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function() {
    $("#nav-personnel-tab").click(function() {
        $("#nav-personnel-tab").show(function() {
            $.ajax({
                url: "Student/Account/ListAccount",
                type: "Get",
                success: function(result) {
                    $("#nav-tabContent").html(result);
                }
            });
        });
    });
    //Click hiển thị thông tin các biểu mẫu
    $("#nav-contact-tab").ready(function() {
        $("#nav-contact-tab").show(function() {
            $.ajax({
                url: "Student/Home/FormHome",
                type: "Get",
                success: function(result) {
                    $("#nav-tabContent").html(result);
                }
            });
        });
    });

    $("#tab-Reply").ready(function() {
        $("#tab-Reply").show(function() {
            $.ajax({
                url: "../ReplyPost",
                type: "Get",
                success: function(result) {
                    $("#tab-Reply").html(result);
                }
            });
        });
    });
});
function validateForm() {
    // Bước 1: Lấy giá trị của username và password
    var contentReply = document.getElementById('contentVali').value;

    // Bước 2: Kiểm tra dữ liệu hợp lệ hay không
    if (contentReply == '') {
        alert('Chưa nhập nội dung bình luận');
    }
    else {
        return true;
    }

    return false;
}

//----------Kiểm tra định dạng file hình ảnh
$(document).ready(function () {
    $("#btn_check").click(function () {
        var test_value = $("#btn_check").val();
        var extension = test_value.split('.').pop().toLowerCase();

        if ($.inArray(extension, ['png', 'gif', 'jpeg', 'jpg']) == -1) {
            alert("File ảnh không hợp lệ!");
            return false;
        }
    });
});
//----------Kiểm tra định dạng file documnet
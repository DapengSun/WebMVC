$(function () {
    SessionExpire();
});

/**
 * 是否为登录超时跳转到登录页
 */
function SessionExpire() {
    var Expireflag = GetQueryString("session");
    if (Expireflag != null || Expireflag != undefined || Expireflag != "") {
        if (Expireflag == "false"){
            alert("登录已超时，请重新登录！");
        }
    }
}

/**
 * 登录按钮点击事件
 */
$('#login-button').click(function (event) {
    UserLogin(event)
});

function delayer() {
    window.location.href = "/Main/Index";
}

/**
 * 用户登陆
 */
function UserLogin(event) {
    var Username = $("#Username").val();
    var Password = $("#Password").val();

    data = {
        Username: Username,
        Password: Password
    };

    $.ajax({
        type: "post",
        url: "/Account/UserLogin",
        data: data,
        async: false,
        dataType: "json",
        success: function (msg) {
            if (msg.Success) {
                event.preventDefault();
                $('form').fadeOut(500);
                $('.wrapper').addClass('form-success');
                setTimeout("delayer()", 3000);
            } else {
                alert(msg.ErrorMessage);
            }
        },
        error: function (msg) { }
    })
}

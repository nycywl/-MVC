$(document).ready(function () {
    $('#loginButton').on('click', function () {
        var username = $('#username').val();
        var password = $('#password').val();
        loginUser(username, password);
    });
});

function loginUser(username, password) {
    var loginData = {
        Username: username,
        Password: password
    };

    $.ajax({
        url: '/Account/login',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(loginData),
        success: function (response) {
            console.log('登入成功：', response);
            redirectToAdminPage();
        },
        error: function (xhr, status, error) {
            console.error('登入失敗：', xhr.responseText);
        }
    });
}

function redirectToAdminPage() {
    window.location.href = '/admin/index';
}
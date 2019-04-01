$(function () {
    $("#errorMessageName").hide();
    $("#errorMessagePassword").hide();
    $("#LoginButton").on("click", function () {
        if (nameValid() && passwordValid()) {
            $.ajax({
                method: "GET",
                url: "Login/Login",
                dataType: "script",
                data: {
                    userName: $("#userName").val(),
                    userPassword: $("#userPassword").val()
                }
            });
        }
    });
});

function nameValid() {
    if ($("#userName").val().length === 0) {
        $("#errorMessageName").show();
        return false;
    } else {
        return true;
    }
}

function passwordValid() {
    if ($("#userPassword").val().length === 0) {
        $("#errorMessagePassword").show();
        return false;
    } else {
        return true;
    }
}
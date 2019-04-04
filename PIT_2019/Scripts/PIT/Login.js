$(function () {
    $("#errorMessageName").hide();
    $("#errorMessagePassword").hide();
    $("#errorMessageJson").hide();
    $("#LoginButton").on("click", function () {
        if (nameValid() && passwordValid()) {
            $.ajax({
                method: "GET",
                url: "Login/Login",
                dataType: "json",
                data: {
                    userName: $("#userName").val(),
                    userPassword: $("#userPassword").val()
                },
                success: function (data) {
                    if (!data.Success) {
                        $("#errorMessageJson").text(data.Message);
                        $("#errorMessageJson").show();
                    } else {
                        window.location = "Order/Index";
                    }
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
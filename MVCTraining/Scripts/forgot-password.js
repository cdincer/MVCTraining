$(function()
{
    var pwdLinkHover = $('#pwdLink').hover(onCloseLogin);
    var pwdLinkHover = $('#resetPwd').click(onResetpassword);


    function onCloseLogin()
    {
        $('div[data-login-user-area]').removeClass('open');

    }

    function onResetpassword()
    {
        var email = $('.modal-dialog .reset-email').val();
        var antiforgery = $('[name="__RequestVerificationToken"]').val();
        var url = "/Account/ForgotPasswordConfirmation";

        //alert(email + " " + antiforgery + " " + url);

        $.post("/Account/ForgotPassword", new {__RequestVerificationToken:antiforgery,email: email},
            function (data)
            { 
                location.href = url;
            }).fail(function xhr,status,error){ location.href=url; });
    }

});
$(function () {

    var registerUserCheckBox = $('#AcceptUserAgreement').click(
        onToggleRegisterUserDisabledClick);

    function onToggleRegisterUserDisabledClick()
    {
        $('.register-user-panel button').toggleClass('disabled');
    }


    var registerUserButton = $('.register-user-panel button').click(
        onRegisterUserClick);

    function onRegisterUserClick()
    {
        var url = '/Account/RegisterUserAsync';
        var AntiForgeryToken = $('[name="__RequestVerificationToken"]').val();

        var name = $('register-user-panel .first-name').val();
        var email = $('register-user-panel .email').val();
        var pwd = $('register-user-panel .password').val();

        $.post(url, {
            __RequestVerificationToken: AntiForgeryToken, email: email, name: name, password: pwd,acceptUserAgreement: true}, 
        function (data)
        {
            alert('Post succesful');
        }).fail(function (xhr, status, error) { alert('Post unsuccesful'); })
    
    
    }
});
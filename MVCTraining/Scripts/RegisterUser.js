$(function () {

    var registerUserCheckBox = $('#AcceptUserAgreement').click(
        onToggleRegisterUserDisabledClick);

    function onToggleRegisterUserDisabledClick()
    {
        $('.register-user-panel button').toggleClass('disabled');
    }

});
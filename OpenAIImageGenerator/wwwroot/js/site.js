// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(() => {

    $('#generate').click(function () {

        var info = {};
        info.n = parseInt($('#quantity').val());
        info.prompt = $('#txt').val();
        info.size = $('#size').find(":selected").val();

        $.ajax({
            url: '/Home/GeneratedImage',
            method: 'post',
            contentType: 'application/json',
            data: JSON.stringify(info)

        }).done(function (data) { 

            $.each(data.data, function () {
                $('#Imagedisplay').append('<div class="col-md-5" style="padding-top:12px">' + '<img class="p-12" src = "' + this.url + '"/>' + '</div>')
            });
        });
    });
});
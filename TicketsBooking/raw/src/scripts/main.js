$(window).on('load', function () {
    // $('#loader').fadeOut(); // will first fade out the loading animation
    // $('#preloader').delay(350).fadeOut('slow'); // will fade out the white DIV that covers the website.
    // $('body').delay(350).css({'overflow': 'visible'});
});

$(document).ready(function () {


    $('#signup-form').on('submit', function (e) {
        e.preventDefault();
        var data = $(this).serialize();
        // var requestUrl = $('#requestUrl').val();
        var requestUrl = 'https://httpbin.org/post';
        $.ajax({
            type: "POST",
            url: requestUrl,
            data: data,
            success: function (response) {
                if (response.status) {
                    $('body').append(
                        '<div class="popup-form">\n' +
                        '    <div class="popup-form-block">\n' +
                        '        <p class="popup-form-block-text">' + response.message + '</p>\n' +
                        '        <span class="popup-form-block-button">Close</span>\n' +
                        '    </div>\n' +
                        '</div>');
                } else {
                    $('body').append(
                        '<div class="popup-form failed">\n' +
                        '    <div class="popup-form-block">\n' +
                        '        <p class="popup-form-block-text">Something was wrong!</p>\n' +
                        '        <span class="popup-form-block-button">Close</span>\n' +
                        '    </div>\n' +
                        '</div>');
                }
                $('body .popup-form').fadeIn(400);
                e.preventDefault();

            },
            error: function () {
                $('body').append(
                    '<div class="popup-form failed">\n' +
                    '    <div class="popup-form-block">\n' +
                    '        <p class="popup-form-block-text">Something was wrong! Please, try again later</p>\n' +
                    '        <span class="popup-form-block-button">Close</span>\n' +
                    '    </div>\n' +
                    '</div>');
                $('body .popup-form').fadeIn(400);
                e.preventDefault();
            }
        });
    });


    $('body').on('click', '.popup-form-block-button', function () {
        setTimeout(function () {
            $('body .popup-form').fadeOut(400);
        });
        setTimeout(function () {
            $('body .popup-form').remove();
        }, 1000);
    });

});
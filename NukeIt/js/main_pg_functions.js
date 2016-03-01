/**
 * Created by Anuradha Sanjeewa on 10/11/2015.
 */
function toggle_mute() {
    $(function () {
        if ($("#aud").prop('muted')) {
            // un muting
            $("#aud").prop('muted', false);
            $('#aud_logo').removeClass('glyphicon glyphicon-volume-up').addClass('glyphicon glyphicon-volume-off');
            $.cookie("aud", 1, {path: '/'});
        } else {
            //muting
            $("#aud").prop('muted', true);
            $('#aud_logo').removeClass('glyphicon glyphicon-volume-off').addClass('glyphicon glyphicon-volume-up');
            $.cookie("aud", 0, {path: '/'});
        }
    });
}

$(document).ready(function(){
    //
    //$(window).blur(function(){
    //    if ($("#aud").prop('muted')){
    //        // Do nothing
    //    }else{
    //        if (typeof c == 'undefined') {
    //            toggle_mute();
    //        } else {
    //            if (c == 0) {
    //                toggle_mute();
    //            }
    //        }
    //    }
    //
    //});
    //
    //$(window).focus(function(){
    //
    //    var c = $.cookie("aud");
    //    if (typeof c == 'undefined') {
    //        toggle_mute();
    //    } else {
    //        if (c == 0) {
    //            toggle_mute();
    //        }
    //    }
    //
    //});

});
$(function () {
    // recover the previous audio status from the cookies
    var c = $.cookie("aud");
    if (typeof c == 'undefined') {
        // Do nothing
    } else {
        if (c == 0) {
            toggle_mute();
        }
    }
});
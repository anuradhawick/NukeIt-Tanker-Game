<?php
/**
 * Created by PhpStorm.
 * User: Anuradha Sanjeewa
 * Date: 11/11/2015
 * Time: 17:59
 */
?>
<?php
/**
 * Created by PhpStorm.
 * User: Anuradha Sanjeewa
 * Date: 11/11/2015
 * Time: 17:38
 */
?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <?php require dirname(__FILE__) . '/../../headers.php'; ?>
</head>
<body>
<?php
require dirname(__FILE__) . '/../../loader.php';
require dirname(__FILE__) . '/../../navbar.php';
require dirname(__FILE__) . '/../../audio.php';
require dirname(__FILE__) . '/../../bkgimg.php';
?>
<script !src="">
    var scrollToElement = function (el, ms) {
        var speed = (ms) ? ms : 600;
        $('html,body').animate({
            scrollTop: $(el).offset().top - 100
        }, speed);
    }
</script>
<div class="container">
    <div class="well" style="margin-top: 40px ;background-color: rgba(245, 245, 245, 0.8); height: 100%">
        <p style="font-size: 2em" class="text-center">Game AI</p>
    </div>
    <div class=" well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 class="text-center">Table of Content</h3>
        <hr>
        <button class="btn btn-default btn-block" onclick="scrollToElement('#base', 600);"><strong>Basic Logic</strong></button>
        <button class="btn btn-default btn-block" onclick="scrollToElement('#coin', 600);"><strong>Reaching coins</strong></button>
        <button class="btn btn-default btn-block" onclick="scrollToElement('#life', 600);"><strong>Reaching life packs</strong></button>
        <button class="btn btn-default btn-block" onclick="scrollToElement('#brick', 600);"><strong>Attacking bricks</strong></button>
        <button class="btn btn-default btn-block" onclick="scrollToElement('#shoot', 600);"><strong>Attacking opponents</strong></button>
        <button class="btn btn-default btn-block" onclick="scrollToElement('#move', 600);"><strong>Motion</strong></button>
        <hr>
    </div>
    <div class="well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 id="base" class="text-center">
            -- Basic Logic --

        </h3>
        <hr>
        <img id="c_img" src="flow_charts/base.jpg" alt="">
        <hr>
    </div>
    <div class="well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 id="coin" class="text-center">
            -- Reaching coins --

        </h3>
        <hr>
        <img id="c_img" src="flow_charts/coins.jpg" alt="">
        <hr>
    </div>
    <div class="well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 id="life" class="text-center">
            -- Reaching life packs --

        </h3>
        <hr>
        <img id="c_img" src="flow_charts/lifepack.jpg" alt="">
        <hr>
    </div>
    <div class="well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 id="brick" class="text-center">
            -- Attacking Bricks --

        </h3>
        <hr>
        <img id="c_img" src="flow_charts/brick.jpg" alt="">
        <hr>
    </div>
    <div class="well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 id="shoot" class="text-center">
            -- Attacking opponents --

        </h3>
        <hr>
        <img id="c_img" src="flow_charts/shoot.jpg" alt="">
        <hr>
    </div>
    <div class="well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 id="move" class="text-center">
            -- Motion --

        </h3>
        <hr>
        <img id="c_img" src="flow_charts/motion.jpg" alt="">
        <hr>
    </div>
    <div class="well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <hr>
        <p class="text-center">&copy; NukeIt Games</p>
    </div>
</div>
<style>
    #moveup {
        position: fixed;
        right: 10px;
        bottom: 10px;
        z-index: 1000;
    }
    #c_img{
        display: block;
        margin: 0 auto;
    }
</style>
<script>
    $(document).ready(function () {
        $(document).on('scroll', function () {
            if ($(window).height() / 2 < $(window).scrollTop()) {
                $('#moveup').show('slow');
            } else {
                $('#moveup').hide('slow');
            }
        });
        $("#clk").on('click', function () {
            scrollToTop();
        });
    });
    function scrollToTop() {
        $('html, body').animate({scrollTop: 0}, 'slow');
    }
</script>
<div id="moveup" hidden>
    <a id="clk" class="btn btn-default btn-lg">
        <span class="glyphicon glyphicon-circle-arrow-up"></span>
    </a>
</div>
</body>
</html>


<?php
/**
 * Created by IntelliJ IDEA.
 * User: Anuradha
 * Date: 2/24/2016
 * Time: 3:32 PM
 */

?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <?php require dirname(__FILE__) . '/../../headers.php'; ?>
    <script src="slider/modernizr.custom.46884.js"></script>
    <script type="text/javascript" src="slider/jquery.slicebox.js"></script>
    <link rel="stylesheet" href="slider/slicebox.css">
    <link rel="stylesheet" href="slider/custom.css">
</head>
<body>
<?php
require dirname(__FILE__) . '/../../loader.php';
require dirname(__FILE__) . '/../../navbar.php';
require dirname(__FILE__) . '/../../audio.php';
require dirname(__FILE__) . '/../../bkgimg.php';
?>

<div class="container">
    <div class="well col-sm-12" style="margin-top: 40px ;background-color: rgba(245, 245, 245, 0.8); height: 100%">
        <p style="font-size: 2em" class="text-center">Game Play</p>
<!--    </div>-->
<!--    <div class=" well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">-->
        <div class="wrapper">

            <ul id="sb-slider" class="sb-slider" style="max-width: 700px; overflow: hidden;">
                <li class="" style="display: none;">
                    <a href="" target="_blank"><img src="play_images/1.jpg" alt="image1"></a>
                    <div class="sb-description">
                        <h3>Game Initiation</h3>
                    </div>
                </li>
                <li class="" style="display: none;">
                    <a href="" target="_blank"><img src="play_images/2.jpg" alt="image2"></a>
                    <div class="sb-description">
                        <h3>Starting the game</h3>
                    </div>
                </li>
                <li class="" style="display: none;">
                    <a href="" target="_blank"><img src="play_images/3.jpg" alt="image2"></a>
                    <div class="sb-description">
                        <h3>Game play with objects</h3>
                    </div>
                </li>
                <li class="" style="display: none;">
                    <a href="" target="_blank"><img src="play_images/4.jpg" alt="image2"></a>
                    <div class="sb-description">
                        <h3>Gaming score board</h3>
                    </div>
                </li>
                <li class="" style="display: none;">
                    <a href="" target="_blank"><img src="play_images/5.jpg" alt="image2"></a>
                    <div class="sb-description">
                        <h3>End of the game</h3>
                    </div>
                </li>
            </ul>

            <div id="shadow" class="shadow" style="display: block;"></div>

            <div id="nav-arrows" class="nav-arrows" style="display: block;">
                <a href="#">Next</a>
                <a href="#">Previous</a>
            </div>

<!--        </div>-->
<!--        <div class="col-sm-12">-->
<!--            <hr>-->
            <p class="text-center">&copy; NukeIt Games</p>
        </div>

    </div>
</div>
<script type="text/javascript">
    $(function() {

        var Page = (function() {

            var $navArrows = $( '#nav-arrows' ).hide(),
                $shadow = $( '#shadow' ).hide(),
                slicebox = $( '#sb-slider' ).slicebox( {
                    onReady : function() {

                        $navArrows.show();
                        $shadow.show();

                    },
                    orientation : 'r',
                    cuboidsRandom : true
                } ),

                init = function() {

                    initEvents();

                },
                initEvents = function() {

                    // add navigation events
                    $navArrows.children( ':first' ).on( 'click', function() {

                        slicebox.next();
                        return false;

                    } );

                    $navArrows.children( ':last' ).on( 'click', function() {

                        slicebox.previous();
                        return false;

                    } );

                };

            return { init : init };

        })();

        Page.init();

    });
</script>
</body>
</html>


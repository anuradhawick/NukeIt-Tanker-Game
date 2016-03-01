<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <?php require dirname(__FILE__) . '/headers.php'; ?>
</head>
<body id="body">
<?php
require dirname(__FILE__) . '/loader.php';
require dirname(__FILE__) . '/navbar.php';
require dirname(__FILE__) . '/audio.php';
require dirname(__FILE__) . '/video.php';
?>


<div class="container">
    <div class="well" style="margin-top: 40px ;background-color: rgba(245, 245, 245, 0.8); height: 100%">
        <p style="font-size: 2em" class="text-center">Are you ready to Nuke away your enemy?</p>
    </div>
    <div class=" well col-sm-5" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8); height: 100%; height: 450px">
        <h3 class="text-center">
            Proudly presented by NukeIt...
        </h3>
        <hr>
        <p class="text-center">Programming challenge II: module University of
            Moratuwa.</p>
        <hr>
        <p>Designed and presented by...</p>
        <hr>
        <ul>
            <li><a href="http://facebook.com/anuradha.sanjeewa" target="_blank">Anuradha Wickramarachchi</a>
                <ul>
                    <li><a href="https://github.com/anuradhawick" target="_blank">Github</a></li>
                    <li><a href="https://www.linkedin.com/in/anuradhawick" target="_blank">LinkedIn</a></li>
                </ul>
            </li>
            <li><a href="https://www.facebook.com/ravidu.lashan.9" target="_blank">Ravidu Lashan</a>
                <ul>
                    <li><a href="https://github.com/ravidulashan" target="_blank">Github</a></li>
                    <li><a href="https://www.linkedin.com/in/ravidulashan" target="_blank">LinkedIn</a></li>
                </ul>
            </li>
        </ul>
        <hr>
        <p class="text-center">&copy; NukeIt Games</p>
    </div>
    <div class="well col-sm-7" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8); height: 100%; height: 450px">
        <h3 class="text-center">
            Where the challenge begins...
        </h3>
        <hr>

        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
                <li data-target="#myCarousel" data-slide-to="3"></li>
            </ol>
            <style>
                #him {
                    margin: 0 auto;
                }
            </style>
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <img id="him" src="images/1.jpg">
                </div>

                <div class="item">
                    <img id="him" src="images/2.jpg">
                </div>

                <div class="item">
                    <img id="him" src="images/3.jpg">
                </div>

                <div class="item">
                    <img id="him" class="text-center" src="images/4.jpg">
                </div>

            </div>

        </div>
    </div>
</div>

</body>
</html>
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

<div class="container">
    <div class="well" style="margin-top: 40px ;background-color: rgba(245, 245, 245, 0.8); height: 100%">
        <p style="font-size: 2em" class="text-center">Tech Information</p>
    </div>
    <div class=" well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 class="text-center">
            Technologies used...
        </h3>
        <hr>
        <div class="col-sm-5">
            <h3 class="text-center">
                Using XNA Game Engine
            </h3>

            <p class="text-center">
                The graphics are rendered from the XNA game engine.
            </p>
        </div>
        <div class="col-sm-7">
            <img style="display: block; margin: 0 auto;" src="xnalogo.png" alt="">
        </div>
        <div class="col-sm-12">
            <hr>
        </div>
        <div class="col-sm-5">
            <h3 class="text-center">
                Programming
            </h3>

            <p class="text-center">
                The game AI is programmed using C# programming language with the aid of .NET frameword for better
                performance and responsiveness of the UI.
            </p>
        </div>
        <div class="col-sm-7">
            <img style="display: block; margin: 0 auto;" src="csharp.png" alt="">
        </div>
        <div class="col-sm-12">
            <hr>
            <p class="text-center">&copy; NukeIt Games</p>
        </div>

    </div>
</div>
</body>
</html>


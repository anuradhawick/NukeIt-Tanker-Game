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
    <?php require dirname(__FILE__) . '/../headers.php'; ?>
</head>
<body>
<?php
require dirname(__FILE__) . '/../loader.php';
require dirname(__FILE__) . '/../navbar.php';
require dirname(__FILE__) . '/../audio.php';
require dirname(__FILE__) . '/../bkgimg.php';
?>

<div class="container">
    <div class="well" style="margin-top: 40px ;background-color: rgba(245, 245, 245, 0.8); height: 100%">
        <p style="font-size: 2em" class="text-center">Information</p>
    </div>
    <div class=" well col-sm-5" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8); height: 100%; height: 450px">
        <h3 class="text-center">
            Module Information...
        </h3>
        <hr>
        <ul>
            <li>Module Code: CS2212</li>
            <li>Module Title: Programming Challenge II</li>
            <li>Credids: 1.0</li>
            <li>GPA/NGPA: NGPA</li>
            <li>Subject Coordinator:
                <ul>
                    <li>Dr. Surangika Ranathunga</li>
                    <li>Mr. Sandamal Weerasinghe</li>
                </ul>
            </li>
            <li>Lecturers:
                <ul>
                    <li>Dr. Surangika Ranathunga</li>
                    <li>Mr. Sandamal Weerasinghe</li>
                </ul>
            </li>
        </ul>
        <br>
        <hr>
        <p class="text-center">&copy; NukeIt Games</p>
    </div>
    <div class="well col-sm-7" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8); height: 100%; height: 450px">
        <h3 class="text-center">
            Task to perform...
        </h3>
        <hr>
        <div class="text-justify">
            <strong>Overview</strong>
            <br>
            NukeIt is a cross domain tanker game which includes software engineering,databases, Networking, Graphics and
            AI.
            <br>
            All the clients connect to a one server and play until one player emerge as a winner by defeating other
            tanks or the tank having the highest score for the time.
            <br>
            <br>
            <strong>The game objective</strong>
            <br>
            clients acting as "tanks" accumulating points while making sure of their own survival.
            The tanks are capable of shooting shells (bullets) and these bullets will move 3 times faster than a tank.
            The environment is made out of four kinds of blocks
            <ul>
                <li>Brick wall</li>
                <li>Stone wall</li>
                <li>Water</li>
                <li>Blank cell</li>
            </ul>
        </div>
    </div>
</div>
</body>
</html>

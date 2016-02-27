<?php
/**
 * Created by PhpStorm.
 * User: Anuradha Sanjeewa
 * Date: 11/11/2015
 * Time: 16:56
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
        <p style="font-size: 2em" class="text-center">Makers profile</p>
    </div>
    <div class=" well col-sm-5" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8); height: 100%; height: 450px">
        <h3 class="text-center">
            <?php
            if (isset($_REQUEST['name'])) {
                if ($_REQUEST['name'] == 'anu') {
                    echo 'Anuradha Wickramarachchi';
                } else {
                    echo 'Ravidu Lashan';
                }
            } else {
                echo 'Anuradha Wickramarachchi';
            }
            ?>
        </h3>
        <hr>
        <p class="text-center">Undergraduate of university of Moratuwa Sri Lanka</p>
        <hr>
        <ul>
            <?php if (isset($_REQUEST['name']) && $_REQUEST['name'] == 'anu' || !isset($_REQUEST['name'])) { ?>
                <li>Online presence
                    <ul>
                        <li><a href="https://github.com/anuradhawick" target="_blank">Github</a></li>
                        <li><a href="https://www.linkedin.com/in/anuradhawick" target="_blank">LinkedIn</a></li>
                        <li><a href="http://facebook.com/anuradha.sanjeewa" target="_blank">FaceBook</a></li>
                    </ul>
                </li>
                <?php
            } else if (isset($_REQUEST['name']) && $_REQUEST['name'] == 'ravi') {
                ?>
                <li>Online presence
                    <ul>
                        <li><a href="https://github.com/ravidulashan" target="_blank">Github</a></li>
                        <li><a href="https://www.linkedin.com/in/ravidulashan" target="_blank">LinkedIn</a></li>
                        <li><a href="https://www.facebook.com/ravidu.lashan.9" target="_blank">FaceBook</a></li>
                    </ul>
                </li>
            <?php } ?>
        </ul>
        <hr>
        <ul>
            <?php if (isset($_REQUEST['name']) && $_REQUEST['name'] == 'anu' || !isset($_REQUEST['name'])) { ?>
                <li>Education
                    <ul>
                        <li>BSc(Hons) ug</li>
                        <li>CIMA advanced dip in MA</li>
                        <li>Diploma in AutoCAD</li>
                    </ul>
                </li>
                <?php
            } else if (isset($_REQUEST['name']) && $_REQUEST['name'] == 'ravi') {
                ?>
                <li>Education
                    <ul>
                        <li>BSc(Hons) ug</li>
                        <li>OCPJP 6</li>
                        <li>Diploma in JSAD (PCJT)</li>
                    </ul>
                </li>
            <?php } ?>
        </ul>
        <hr>

    </div>
    <style>
        img {
            margin: 0 auto;
        }
    </style>
    <div class="well col-sm-7" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8); height: 100%; height: 450px">
        <hr>
        <?php if (isset($_REQUEST['name']) && $_REQUEST['name'] == 'anu' || !isset($_REQUEST['name'])) { ?>
            <div class="item">
                <img style="display: block; margin: 0 auto;" src="anuradha.jpg" alt="" class="img-thumbnail">
            </div>
            <?php
        } else if (isset($_REQUEST['name']) && $_REQUEST['name'] == 'ravi') {
            ?>
            <div class="item">
                <img style="display: block; margin: 0 auto;" src="ravidu.jpg" alt="" class="img-thumbnail">
            </div>
        <?php } ?>
        <hr>
        <p class="text-center">&copy; NukeIt Games</p>
    </div>
</div>

</body>
</html>

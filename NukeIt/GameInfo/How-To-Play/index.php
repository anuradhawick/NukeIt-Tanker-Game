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
<body id="top">
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
        <p style="font-size: 2em" class="text-center">Game Play Information</p>
    </div>
    <div class=" well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 class="text-center">Table of Content</h3>
        <hr>
        <button class="btn btn-default btn-block" onclick="scrollToElement('#jointhegame', 600);"><strong>Join the
                game</strong></button>
        <button class="btn btn-default btn-block" onclick="scrollToElement('#joinacc', 600);"><strong>Joining
                Acceptance</strong></button>
        <button class="btn btn-default btn-block" onclick="scrollToElement('#gameinit', 600);"><strong>Game
                Initiation</strong></button>
        <button class="btn btn-default btn-block" onclick="scrollToElement('#movenshoot', 600);"><strong>Moving and
                Shooting</strong></button>
        <button class="btn btn-default btn-block" onclick="scrollToElement('#obsta', 600);"><strong>Obstacles/
                Warning Commands</strong></button>
        <button class="btn btn-default btn-block" onclick="scrollToElement('#benbroad', 600);"><strong>General
                broadcast</strong></button>
        <button class="btn btn-default btn-block" onclick="scrollToElement('#aqcoin', 600);"><strong>Acquiring
                Coins</strong></button>
        <button class="btn btn-default btn-block" onclick="scrollToElement('#aqlife', 600);"><strong>Life
                Packs</strong></button>
        <hr>
    </div>
    <div class=" well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 id="jointhegame" class="text-center">
            -- Join to the game --
        </h3>
        <hr>
        <br>

        <p>
            The following messages are exchanged between the server and the client during the initial stage of the game
        </p>
        <br>
        <ul>
            <li>The initial message from the client to join the game<strong>
                    <pre>JOIN#</pre>
                </strong></li>
            <li>The maximum number of players are already added<strong>
                    <pre>PLAYERS_FULL#</pre>
                </strong></li>
            <li>The player is already added<strong>
                    <pre>ALREADY_ADDED#</pre>
                </strong></li>
            <li>The player tries to join an already started game<strong>
                    <pre>GAME_ALREADY_STARTED#</pre>
                </strong></li>
        </ul>
        <hr>
    </div>
    <div class=" well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 id="joinacc" class="text-center">
            -- Joining Acceptance --
        </h3>
        <hr>
        <br>

        <p>
            Once the game starts the following message will be sent from the server to the user
        </p>
        <br>
        <strong>
            <pre>S:P&lt;num&gt;: &lt; player location  x&gt;,&lt; player location  y&gt;:&lt;Direction&gt;#</pre>
        </strong>
        <hr>
    </div>
    <div class=" well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 id="gameinit" class="text-center">
            -- Game Initiation --
        </h3>
        <hr>
        <br>

        <p>
            Once the game starts the below message is sent to all the clients. This message contains the
        </p>
        <br>
        <strong>
            <pre>I:P&lt;num&gt;: &lt; x&gt;,&lt;y&gt;;&lt; x&gt;,&lt;y&gt;;&lt; x&gt;,&lt;y&gt;.....&lt; x&gt;,&lt;y&gt;: &lt; x&gt;,&lt;y&gt;;&lt; x&gt;,&lt;y&gt;;&lt; x&gt;,&lt;y&gt;.....&lt; x&gt;,&lt;y&gt;: &lt; x&gt;,&lt;y&gt;;&lt; x&gt;,&lt;y&gt;;&lt; x&gt;,&lt;y&gt;.....&lt; x&gt;,&lt;y&gt;#</pre>
        </strong>
        <ul>
            <li>
                player name
            </li>
            <li>
                brick coordinates
            </li>
            <li>
                stone coordinates
            </li>
            <li>
                water coordinates
            </li>
        </ul>


        <hr>
    </div>
    <div class=" well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 id="movenshoot" class="text-center">
            -- Moving and Shooting --
        </h3>
        <hr>
        <ul>
            <li>To move up
                <strong>
                    <pre>UP#</pre>
                </strong>
            </li>
            <li>To move down
                <strong>
                    <pre>DOWN#</pre>
                </strong>
            </li>
            <li>To move right
                <strong>
                    <pre>RIGHT#</pre>
                </strong>
            </li>
            <li>To move left
                <strong>
                    <pre>LEFT#</pre>
                </strong>
            </li>
            <li>To shoot
                <strong>
                    <pre>SHOOT#</pre>
                </strong>
            </li>
        </ul>


        <hr>
    </div>
    <div class=" well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 id="obsta" class="text-center">
            -- Obstacles/ Warning Commands --
        </h3>
        <hr>
        <ul>
            <li>There is a brick wall or a stone wall
                <strong>
                    <pre>OBSTACLE#</pre>
                </strong>
            </li>
            <li>The cell is currently occupied by another tank
                <strong>
                    <pre>CELL_OCCUPIED#</pre>
                </strong>
            </li>
            <li>You are already dead and cannot move
                <strong>
                    <pre>DEAD#</pre>
                </strong>
            </li>
            <li>The command was send too quickly. Only one command per second.
                <strong>
                    <pre>TOO_QUICK#</pre>
                </strong>
            </li>
            <li>The requested cell is out of the board
                <strong>
                    <pre>INVALID_CELL#</pre>
                </strong>
            </li>
            <li>The has already finished
                <strong>
                    <pre>GAME_HAS_FINISHED#</pre>
                </strong>
            </li>
            <li><strong>
                    <pre>GAME_NOT_STARTED_YET#</pre>
                </strong>
            </li>
            <li>The player has not joined the game
                <strong>
                    <pre>NOT_A_VALID_CONTESTANT#</pre>
                </strong>
            </li>
        </ul>


        <hr>
    </div>
    <div class=" well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 id="benbroad" class="text-center">
            -- General broadcast --

        </h3>
        <hr>
        <strong>
            <pre>G:P1;&lt; player location x&gt;,&lt; player location y&gt;;&lt;Direction&gt;;&lt; whether shot&gt;;&lt;health&gt;;&lt; coins&gt;;&lt; points&gt;: &hellip;. P5;&lt; player location x&gt;,&lt; player location y&gt;;&lt;Direction&gt;;&lt; whether shot&gt;;&lt;health&gt;;&lt; coins&gt;;&lt; points&gt;: &lt; x&gt;,&lt;y&gt;,&lt;damage-level&gt;;&lt; x&gt;,&lt;y&gt;,&lt;damage-level&gt;;&lt; x&gt;,&lt;y&gt;,&lt;damage-level&gt;;&lt; x&gt;,&lt;y&gt;,&lt;damage-level&gt;&hellip;..&lt; x&gt;,&lt;y&gt;,&lt;damage-level&gt;#</pre>
        </strong>
        <ul>
            <li>State data for player 1</li>
            <li> State data for player 5</li>
            <li> damage level</li>
        </ul>
        <hr>
    </div>
    <div class=" well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 id="aqcoin" class="text-center">
            -- Acquiring Coins --

        </h3>
        <hr>
        <strong>
            <pre>C:&lt;x&gt;,&lt;y&gt;:&lt;LT&gt;:&lt;Val&gt;#</pre>
        </strong>
        <ul>
            <li>Location - x
                <strong>
                    <pre>x - &lt;int&gt; </pre>
                </strong></li>
            <li>Location - y
                <strong>
                    <pre>y - &lt;int&gt; </pre>
                </strong></li>
            <li>Life time of the entity -
                <strong>
                    <pre>LT - &lt;int&gt; </pre>
                </strong></li>
            <li>Value -
                <strong>
                    <pre>Val - &lt;int&gt; </pre>
                </strong></li>
        </ul>
        <hr>
    </div>
    <div class=" well col-sm-12" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8);">
        <h3 id="aqlife" class="text-center">
            -- Life Packs --

        </h3>
        <hr>
        <strong>
            <pre>L:&lt;x&gt;,&lt;y&gt;:&lt;LT&gt;#</pre>
        </strong>

        <ul>
            <li>Location - x
                <strong>
                    <pre>x - &lt;int&gt; </pre>
                </strong>
            </li>
            <li>Location - y
                <strong>
                    <pre>y - &lt;int&gt;</pre>
                </strong>
            </li>
            <li>Life time of the entity -
                <strong>
                    <pre>LT - &lt;int&gt;</pre>
                </strong>
            </li>
        </ul>
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


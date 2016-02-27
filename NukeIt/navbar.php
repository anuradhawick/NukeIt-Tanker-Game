<?php
/**
 * Created by PhpStorm.
 * User: Anuradha Sanjeewa
 * Date: 10/11/2015
 * Time: 12:30
 */
?>
<nav id="navbar" style="z-index: 101" class="navbar navbar-inverse navbar-fixed-top">
    <div class="container-fluid">
        <div>
            <ul class="nav navbar-nav">
                <li><a id="home" href="/NukeIt/">Home</a></li>
                <li><a href="/NukeIt/Info">Information</a></li>
                <li><a href="/NukeIt/GameInfo/AI">AI <span style="color: #ff713f;">(new)</span></a></li>
                <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Details <span style="color: #ff713f;">(new)</span><span
                            class="caret"></span></a>
                    <ul class="dropdown-menu">
                        <li><a href="/NukeIt/GameInfo/Game">Game</a></li>
                        <li><a href="/NukeIt/GameInfo/How-To-Play">How to play</a></li>
                        <li><a href="/NukeIt/GameInfo/Tech">Technologies <span style="color: #ff713f;">(updated)</span></a></li>
                        <li><a href="/NukeIt/GameInfo/Game-Play">Game Play <span style="color: #ff713f;">(new)</span></a></li>
                    </ul>
                </li>
                <li><a href="/NukeIt/contact-us">Contact Us</a></li>
                <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Contributors <span
                            class="caret"></span></a>
                    <ul class="dropdown-menu">
                        <li><a href="/NukeIt/About-Us?name=anu">Anuradha</a></li>
                        <li><a href="/NukeIt/About-Us?name=ravi">Ravidu</a></li>
                    </ul>
                </li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
                <li><a onclick="toggle_mute()" href="javascript:void(0)"><span id="aud_logo" class="glyphicon glyphicon-volume-off"></span> </a></li>
            </ul>
        </div>
    </div>
</nav>

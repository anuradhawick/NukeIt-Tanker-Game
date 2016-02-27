<?php
/**
 * Created by PhpStorm.
 * User: Anuradha Sanjeewa
 * Date: 10/11/2015
 * Time: 12:42
 */
?>
<style>
    video#bgvid {
        position: fixed;
        top: 50%;
        left: 50%;
        min-width: 100%;
        min-height: 100%;
        width: auto;
        height: auto;
        z-index: -100;
        -webkit-transform: translateX(-50%) translateY(-50%);
        transform: translateX(-50%) translateY(-50%);
        background-size: cover;
    }
</style>
<script>
</script>
<video autoplay loop id="bgvid" muted>
    <source src="/NukeIt/video/tanks%20vid.mp4" type="video/mp4">
</video>

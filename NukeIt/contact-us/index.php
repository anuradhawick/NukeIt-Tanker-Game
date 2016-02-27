<?php
/**
 * Created by PhpStorm.
 * User: Anuradha Sanjeewa
 * Date: 10/11/2015
 * Time: 15:22
 */
?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <?php
    require dirname(__FILE__) . '/../headers.php';
    ?>
</head>
<body>
<?php
require dirname(__FILE__) . '/../loader.php';
require dirname(__FILE__) . '/../navbar.php';
require dirname(__FILE__) . '/../audio.php';
require dirname(__FILE__) . '/../bkgimg.php';
?>
<script>
    $(document).ready(function(){
        $('#msgform').on('submit',function(){
            var msg = $('#msg').val();
            var email = $("#email").val();
            var name = $("#name").val();
            $.post('/NukeIt/mailer/mail.php',{
                msg:msg,
                email:email,
                name:name
            },function(data,status){
                if(status=='success'){
                    alert('We got your message and we\' respond to you soon. Thanks')
                }
            });
        });
    });
</script>
<div class="container">
    <div class="well" style="margin-top: 40px ;background-color: rgba(245, 245, 245, 0.8); height: 100%">
        <p style="font-size: 2em" class="text-center">Contact the makers...</p>
    </div>
    <div class=" well col-sm-5" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8); height: 100%; height: 450px">
        <h3 class="text-center">
            Contact us in person...
        </h3>
        <hr>
        <p class="text-center"><a href="http://facebook.com/anuradha.sanjeewa" target="_blank">Anuradha
                Wickramarachchi</a></p>
        <hr>
        <p>Phone: <a href="tel:0712165724">0712165724</a></p>

        <p>Email: <a href="mailto:anuradha@cse.mrt.ac.lk">anuradha@cse.mrt.ac.lk</a></p>

        <hr>
        <p class="text-center"><a href="https://www.facebook.com/ravidu.lashan.9" target="_blank">Ravidu Lashan</a></p>
        <hr>
        <p>Phone: <a href="tel:0713925453">0713925453</a></p>

        <p>Email: <a href="mailto:ravidu_lashan.13@cse.mrt.ac.lk">ravidu_lashan.13@cse.mrt.ac.lk</a></p>
        <hr>
        <p class="text-center">&copy; NukeIt Games</p>
    </div>
    <div class="well col-sm-7" style="font-size: 12pt; background-color: rgba(245, 245, 245, 0.8); height: 100%; height: 450px">
        <h3 class="text-center">
            Contact us here...
        </h3>
        <hr>
        <form id="msgform" role="form" onsubmit="return false;">
            <div class="form-group">
                <label for="name">Name:</label>
                <input type="text" class="form-control" id="name" required>
            </div>
            <div class="form-group">
                <label for="email">Email address:</label>
                <input type="email" class="form-control" id="email" required>
            </div>
            <div class="form-group">
                <label for="msg">Query:</label>
                <textarea type="text" class="form-control" id="msg" style="max-height: 100px; max-width: 630px" required></textarea>
            </div>
            <button type="submit" class="btn btn-default">Submit</button>
        </form>


    </div>
</div>
</body>
</html>

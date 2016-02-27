<?php
/**
 * Created by PhpStorm.
 * User: Anuradha Sanjeewa
 * Date: 10/11/2015
 * Time: 17:17
 */
?>

<html>
<head>
    <title>NukeIt Tanker Game</title>
</head>
<body style='background-color: rgba(245, 245, 245, 0.6);'>
<?php
$name = 'asdasd';
$email = 'asd@asd.com';
$msg;
?>
<div>
    <div style='margin-top: 40px ;background-color: rgba(245, 245, 245, 0.6); height: 100%'>
        <p style='font-size: 2em'>System Generated Mail</p>
    </div>
    <div style='background-color: rgba(245, 245, 245, 0.6);'>
        <h3>Subject: Contact mail from the website</h3>
        <hr>
        <h3>From: <?php echo $name; ?></h3>
        <hr>
        <h3>Email: <?php echo $email; ?></h3>
        <hr>
        <h3>Message:</h3>
        <h4><?php echo $msg; ?></h4>

        <p>&copy; NukeIt Games</p>
    </div>
</div>

</body>
</html>

<?php
/**
 * Created by PhpStorm.
 * User: Anuradha Sanjeewa
 * Date: 10/11/2015
 * Time: 17:05
 */
header('Location: /NukeIt/mailer/response.php');
function sendEmail($msg)
{
    $to1 = 'anuradhawick@gmail.com';//$_REQUEST['to'];
    $to2 = 'ravidu0915@gmail.com';
    $from = 'nukeit@quarksis.com';//$_REQUEST['from'];
    $replyto = 'noreply@quarksis.com';//$_REQUEST['replyto'];
    $subject = 'NukeIt Contact Page';
    $message = $msg;
    $headers = "MIME-Version: 1.0" . "\r\n";
    $headers .= "Content-type:text/html;charset=UTF-8" . "\r\n";
    $headers .= "From: " . $from . "\r\n" .
        'Reply-To: ' . $replyto . "\r\n" .
        'X-Mailer: PHP/' . phpversion();

    $mail = mail($to1, $subject, $message, $headers);
    $mail1 = mail($to2, $subject, $message, $headers);
    if ($mail && $mail1) {
        echo json_encode(TRUE);
    } else {
        echo json_encode(FALSE);
    }

}

if (isset($_REQUEST['msg'])) {
    $name = $_REQUEST['name'];
    $email = $_REQUEST['email'];
    $msg = $_REQUEST['msg'];
    $msgsend = "
<div>
    <div style='margin-top: 40px ;background-color: rgba(245, 245, 245, 0.6); height: 100%'>
        <p style='font-size: 2em'>System Generated Mail</p>
    </div>
    <div style='background-color: rgba(245, 245, 245, 0.6);'>
        <h3>Subject: Contact mail from the website</h3>
        <hr>
        <h3>From: ". $name."</h3>
        <hr>
        <h3>Email: ". $email."</h3>
        <hr>
        <h3>Message:</h3>
        <h4>". $msg."</h4>

        <p>&copy; NukeIt Games</p>
    </div>
</div>

</body>
</html>

</body>
</html>
";
    sendEmail($msgsend);
}





?>

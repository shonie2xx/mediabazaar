<?php
// Import PHPMailer classes into the global namespace
// These must be at the top of your script, not inside a function
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\SMTP;
use PHPMailer\PHPMailer\Exception;
include("connectionDb.php");

// Load Composer's autoloader
//require 'vendor/autoload.php';

require '../PHPMailer/src/Exception.php';
require '../PHPMailer/src/PHPMailer.php';
require '../PHPMailer/src/SMTP.php';

// Instantiation and passing `true` enables exceptions
$mail = new PHPMailer(true);


	if(isset($_POST["RequestPass"]))
	{
		
		if(empty($_POST["email"]) || empty($_POST["email_1"]))
		{
			//$message = '<p>All fields are required</p>';
			echo '<script> alert("All fields are required");window.location="ForgotPass.php"</script>';

		}
		if($_POST["email"] == $_POST["email_1"])
		{
			$query = "SELECT * FROM employees WHERE Email = :Email ";
			$statement = $conn->prepare($query);
			$statement->execute(
				array(
					'Email' => $_POST["email"]
				)

				);
				$count = $statement->rowCount();
				if($count > 0)
				{
					$query = "SELECT Password FROM employees WHERE Email = :Email";
    				$stmn = $conn->prepare($query);
    				$stmn->execute(
        				array(
            				'Email' => $_POST["email"]
        				)
    				);
					$pass = $stmn->fetchAll();
					foreach($pass as $passForeach)
            		{
                		$passToString = $passForeach[0];
					}
					//checks
					//$passToString = strval($pass[0]);
					//print_r($pass);
					//echo $passToString;
					//echo $pass[0];
					try {
						//Server settings
						//$mail->SMTPDebug = SMTP::DEBUG_SERVER;                      // Enable verbose debug output
						$mail->isSMTP();                                            // Send using SMTP
						$mail->Host       = 'smtp.gmail.com';                    // Set the SMTP server to send through
						$mail->SMTPAuth   = true;                                   // Enable SMTP authentication
						$mail->Username   = 'mediabazaarproject@gmail.com';                     // SMTP username
						$mail->Password   = 'TestPassForOurProject';                               // SMTP password
						$mail->SMTPSecure = "tls";        // Enable TLS encryption; `PHPMailer::ENCRYPTION_SMTPS` encouraged
						$mail->Port       = 587;                                    // TCP port to connect to, use 465 for `PHPMailer::ENCRYPTION_SMTPS` above
					
						//Recipients
						$mail->setFrom('no-reply@gmail.com', 'MediaBazaar');
						$mail->addAddress($_POST["email"], '');     // Add a recipient
						//$mail->addReplyTo('gamecharmtestsmtp@gmail.com', 'Information');
						//$mail->addCC('cc@example.com');
						//$mail->addBCC('bcc@example.com');
					
						// Content
						$mail->isHTML(true);                                  // Set email format to HTML
						$mail->Subject = 'Password recovery';
						$mail->Body    = 'Here is your password: '.$passToString.'';
						$mail->AltBody = 'This is the body in plain text for non-HTML mail clients';
					
						$mail->send();
						echo '<script> alert("If you are registered in our database, you will receive Email with your password");window.location="ForgotPass.php"</script>';
						//echo 'Message has been sent';
					} catch (Exception $e) {
						echo "Message could not be sent. Mailer Error: {$mail->ErrorInfo}";
					}
				}
		}
		else
		{
			echo '<script> alert("Please confirm your email");window.location="ForgotPass.php"</script>';
		}
		
		//$message = $message->getMessage();
	}


?>
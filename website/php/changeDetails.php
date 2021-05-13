<?php
require_once("returnconn.php");
session_start();
$email = $_SESSION['Email'];
$id= $_SESSION['ID'];
$newpassword = $_POST['pass'];
$newpassword_1 = $_POST['pass_1'];
$email = $_POST['email'];
$email_1 = $_POST['email_1'];
$address = $_POST['address'];
$city = $_POST['city'];
$zipcode = $_POST['zipcode'];
$bsn = $_POST['bsn'];
$fte = $_POST['fte'];


try{
    if(isset($_SESSION['ID'])){
      if(!empty($_POST['pass']))
      {
        if($newpassword == $newpassword_1 && $email == $email_1){
          $sql = "UPDATE employees SET Password = :password, Email = :email, Address = :address, City = :city, Zipcode = :zipcode, BSN = :bsn, FTE = :fte  WHERE ID = :id" ;
          $stmt = $conn->prepare($sql);
          $stmt->execute([':password' => $newpassword,':id' =>$id, ':email' => $email,':address' =>$address, ':city' =>$city, ':zipcode' =>$zipcode,':bsn' =>$bsn,':fte' =>$fte]);
          header('Location: ../pages/Profile.php');
        }
        else{
          echo "<script>window.alert('Passwords or Emails are not the same');</script>";

        }
      }
      else
      {
        if($email == $email_1)
        {
          $sql = "UPDATE employees SET Email = :email, Address = :address, City = :city, Zipcode = :zipcode, BSN = :bsn, FTE = :fte  WHERE ID = :id" ;
          $stmt = $conn->prepare($sql);
          $stmt->execute([':id' =>$id, ':email' => $email,':address' =>$address, ':city' =>$city, ':zipcode' =>$zipcode,':bsn' =>$bsn,':fte' =>$fte]);
          header('Location: ../pages/Profile.php');
        }
        else
        {
          echo "<script>window.alert('Emails are not the same');</script>";

        }
      }

    }
    else{
      echo "MUST BE logged in";
    }
}
catch(PDOException $e){
  echo $e->getMessage();
}

?>

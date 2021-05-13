<?php
session_start();
$firstname = $_SESSION['FirstName'];
$oldpassword = $_POST['oldpassword'];
$newpassword = $_POST['newpassword'];
$cpassword = $_POST['cnewpassword'];


try{
    $conn = new PDO("mysql:host=localhost;dbname=website-project","root","");
    $conn->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);

    if(isset($_SESSION['FirstName'])){
        if($newpassword == $cpassword){
          $sql = "UPDATE employees SET Password = :password WHERE FirstName = :firstname" ;
          $stmt = $conn->prepare($sql);
          $stmt->execute([':password' => $newpassword,':firstname' =>$firstname]);
          header('Location: ../pages/shiftsPage.php');
        }
        else{
          echo "Password doesn't match ";
        }
    }
    else{
      echo "Username have to be logged in.";
    }
}
catch(PDOException $e){
  echo $e->getMessage();
}

?>

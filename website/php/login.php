<?php
include 'autoload.inc.php';
session_start();

$email = $_POST['email'];
$password = $_POST['password'];

try{

  $conn = new PDO("mysql:host=localhost;dbname=website-project","root","");
    $conn->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);


  $sql = "SELECT * FROM employees WHERE Email = :email AND Password = :password";

  $sth = $conn -> prepare($sql);
  $sth->execute([':email' => $email, ':password' => $password]);

  if($sth ->rowCount() > 0)
  {
    $result = $sth->fetch();
    $_SESSION['ID'] = $result['ID'];
    $_SESSION['FirstName'] = $result['FirstName'];
    $_SESSION['LastName'] = $result['LastName'];
    $_SESSION['Address'] = $result['Address'];
    $_SESSION['Zipcode'] = $result['Zipcode'];
    $_SESSION['City'] = $result['City'];
    $_SESSION['FTE'] = $result['FTE'];
    $_SESSION['BSN'] = $result['BSN'];
    $_SESSION['Department'] = $result['Department'];
    header('Location: ../pages/shiftsPage.php');

  }
  else{
    echo "<script>alert('incorrect credentials')</script>";
        echo "<script>location.href='/index.php'</script>";
  }
}
catch(PDOException $e){
  echo $e->getMessage();
}
?>

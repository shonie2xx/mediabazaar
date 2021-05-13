<?php
session_start();
//include_once '../php/connectionDb.php';
include_once '../php/autoload.inc.php';
?>

<html>
<body>
      <head>
        <link href = "../css/style.css" type = "text/css" rel = "stylesheet">
        </head>

        <header>
          <h1>Change Password</h1>
        </header>

        <div class="firstnameOfTheUser">

            Welcome
               <?php
               if(isset($_SESSION['FirstName']))
               echo($_SESSION['FirstName']);
               else{
                 echo "";
                 header("location: index.php");
               }
               ?>
        </div>
<form action = '../php/changePassword.php' method='POST'>
  Old password:      <input type = 'text' name = 'oldpassword' required><p>
  New password :     <input type = 'password' name = 'newpassword' required><br>
  Confirm password:  <input type = 'password' name = 'cnewpassword' required><p>
      <input type = 'submit' name = 'submitNewPass' value = 'Change Password'>
    </form>

</body>
</html>

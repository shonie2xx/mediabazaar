<?php

session_start();

?>

<html>
      <head>
        <link href = "../css/style.css" type="text/css" rel = "stylesheet">
        </head>

<body>


  <div id="login">
    <div class="containerChangeCredentials">
      <div id="logo">
        <img src="../img/password.png" alt="">
      </div>
      <form id="loginBox" class="input-group" method="POST" action= "../php/changeDetails.php">
        <div>
          <label for="email"><b>Email</b></label>
          <input type = "text" class="text-input" placeholder="Enter your new email" value="<?php echo $_SESSION['Email'];?>"  name="email" required>
        </div>
        <div>
          <label for="email_1"><b>Confirm Email</b></label>
          <input type = "text" class="text-input" placeholder="Confirm your email" value="<?php echo $_SESSION['Email'];?>" name = "email_1" required>
        </div>
        <div>
          <label for="address"><b>Address</b></label>
          <input type = "text" class="text-input" placeholder="Enter your new " value="<?php echo $_SESSION['Address'];?>"  name="address" required>
        </div>
        <div>
          <label for="city"><b>City</b></label>
          <input type = "text" class="text-input" placeholder="Enter your new " value="<?php echo $_SESSION['City'];?>"  name="city" required>
        </div>
        <div>
          <label for="zipcode"><b>Zipcode</b></label>
          <input type = "text" class="text-input" placeholder="Enter your new " value="<?php echo $_SESSION['Zipcode'];?>"  name="zipcode" required>
        </div>
        <div>
          <label for="bsn"><b>BSN</b></label>
          <input type = "text" class="text-input" placeholder="Enter your new " value="<?php echo $_SESSION['BSN'];?>"  name="bsn" required>
        </div>
        <div>
          <label for="fte"><b>FTE</b></label>
          <input type = "text" class="text-input" placeholder="Enter your new " value="<?php echo $_SESSION['FTE'];?>"  name="fte" required>
        </div>


        <div>
          <label for="pass"><b>New Password</b></label>
          <input type = "password" class="text-input" placeholder="Enter your new password" name="pass" >
        </div>
        <div>
          <label for="pass"><b>Confirm Password</b></label>
          <input type = "password" class="text-input" placeholder="Confirm your password" name = "pass_1" >
        </div>
        <button class="primary-btn" type = "submit" name = "Change">Change Details</button>
        <div class="links">
        <a href="Profile.php">Back</a>
      </div>
      <br>
      </form>
      
    </div>
</div>


<!--<script src="../JS/index.js"></script> -->

</body>
</html>
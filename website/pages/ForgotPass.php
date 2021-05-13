<?php
include("../php/PHPMailer.php")
?>
<html>
      <head>
        <link href = "../css/style.css" type="text/css" rel = "stylesheet">
        </head>

<body>


  <div id="login">
    <div class="containerlogin">
      <div id="logo">
        <img src="../img/password.png" alt="">
      </div>
      <form id="loginBox" class="input-group" method="POST">
        <div>
          <label for="email"><b>Email</b></label>
          <input type = "text" class="text-input" placeholder="Enter your email" name="email" required>
        </div>
        <div>
          <label for="email"><b>Confirm Email</b></label>
          <input type = "password" class="text-input" placeholder="Confirm your email" name = "email_1" required>
        </div>
        <button class="primary-btn" type = "submit" name = "RequestPass">Request Password</button>
      </form>
      <div class="links">
        <a href="../index.php">Login</a>
      </div>
    </div>
</div>


<!--<script src="../JS/index.js"></script> -->

</body>
</html>
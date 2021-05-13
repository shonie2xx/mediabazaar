<?php
session_start();

 ?>


<html>
      <head>
        <link href = "css/style.css" type="text/css" rel = "stylesheet">
        </head>

<body>


  <div id="login">
    <div class="containerlogin">
      <div id="logo">
        <img src="img/shop.png" alt="">
      </div>
      <form id="loginBox" class="input-group" action= "php/login.php" method="POST">
        <div>
          <label for="email"><b>Email</b></label>
          <input type = "text" class="text-input" placeholder="Enter your email" name="email" required>
        </div>
        <div>
          <label for="password"><b>Password</b></label>
          <input type = "password" class="text-input" placeholder="Enter your password" name = "password" required>
        </div>
        <button class="primary-btn" type = "submit">Login</button>
      </form>
      <div class="links">
        <a href="pages/ForgotPass.php">Forgot Pass</a>
      </div>
    </div>
</div>


<!--<script src="../JS/index.js"></script> -->

</body>
</html>

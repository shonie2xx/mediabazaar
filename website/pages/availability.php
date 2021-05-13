<?php
//include_once '../php/init.php';
include_once '../php/autoload.inc.php';
?>
<html>
<body>
  <head>
    <link href = "../css/style.css" type = "text/css" rel = "stylesheet">
  </head>

  <form action="../php/insertAvailability.php" method="POST">
    <div class = "availability_box">

      <h2>Dismission/Availability</h2>
      <p>Description</p>
      <textarea name="reasontext" rows="10" cols="30" required></textarea>
      <p>From</p>
      <input type="date" name="fromDate" required>
      <p>To</p>
      <input type="date" name="toDate" required>
      <!--<p><input class="primary-btn" type="submit" value="Submit"></p> -->
      <button class="available-btn" type = "submit">Insert</button>
    </div>
  </form>

  <input class ="btnlogout" value="Back" onclick="location='shiftsPage.php'" />


</body>

</html>

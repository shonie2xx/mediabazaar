<?php
session_start();
include_once '../php/returnconn.php';
include_once '../php/autoload.inc.php';
if(isset($_SESSION['ID']))
{
?>
<html>
<body>
      <head>
        <link href = "../css/style.css" type = "text/css" rel = "stylesheet">
        </head>



        <?php
        $readonly = "";
        function ReadOnly()
        {
          return $readonly;
        }
        function SetReadOnlyFalse()
        {
          $readonly = 'false';
        }
        function SetReadOnlyTrue()
        {
          $readonly = 'true';
        }
        SetReadOnlyTrue();
        $sql = "SELECT FirstName, LastName, Email, Department, Position,  ContractEnd, Nationality, Password FROM employees WHERE ID = :id;";



             $resultcheck = $conn -> prepare($sql);
             $resultcheck->execute([':id' => $_SESSION['ID']]);

             if($resultcheck->rowCount() > 0)
             {

                  while($row = $resultcheck->fetch()){
                    // echo $row['FirstName'] ;
                    // echo "<br>";
                    // echo $row['LastName'];
                    // echo "<br>";
                    // echo $row['Email'];
                    // echo "<br>";
                    // echo $row['Nationality'];
                    // echo "<br>";
                    // echo $row['Department'];
                    // echo "<br>";
                    // echo $row['Position'];
                    // echo "<br>";
                    // echo $row['ContractEnd'];
                    // echo "<br>";
                    // echo "<br>";

                    $_SESSION['Email'] = $row['Email'];


                    echo "<div class='Profile_box'>
                    <h1>".$row['FirstName']." ".$row['LastName']."</h1>
                    <p class='title'>".$row['Position']."</p>
                    <p class='title'>".$row['Department']."</p>
                    <p>Nationality: ".$row['Nationality']."</p>
                    <p>Email: ".$row['Email']."</p>
                    <p>Contract Ends:</p>
                    <p>".$row['ContractEnd']."</p>
                    <p><a href ='ChangeDetails.php' class='btn-secondary'>Change Details</a></p>
                    <p><a href ='../php/logout.php' class='btn-secondary'>Log out</a></p>

                  
                  </div>
                  ";
                  ?>

                    <div>
                      <input class ="btnlogout" value="Back" onclick="location='shiftsPage.php'" />
                    </div>

                  <?php
                  }

             }
            }
            else
            {
              echo "Log in first";
            }

        ?>




</body>
</html>

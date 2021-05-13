<?php
   try{
     $idempl = $_SESSION['ID'];
     $sql = "SELECT * FROM schedule_employee WHERE employee_id = :id;";
     $search = $conn -> prepare($sql);
     $search->execute([':id' => $idempl]);
     $row = $search->fetch();
     $scheduleId = $row["schedule_id"];

     $sql2 = "SELECT * FROM schedule WHERE Id = :id;";
     $result = $conn -> prepare($sql2);
     $result -> execute([':id' => $scheduleId]);

     if($result->rowCount() > 0)
     {
     //  while($row = mysqli_fetch_assoc($result)){
         while($row = $result->fetch()){
           if($row["shiftNumb"] == 1)
           {
             $row["shiftNumb"] = "From 8 to 12:30";
           }
           if($row["shiftNumb"] == 2)
           {
             $row["shiftNumb"] = "From 12:30 to 17:00";
           }
           if($row["shiftNumb"] == 3)
           {
             $row["shiftNumb"] = "From 17:00 to 21:00";
           }
         echo "</tr><td>" . $row["shiftNumb"] . "<tds><td>". $row["Date"] . "</td><td>" . $row["Department"] . "</td><td>";
        }
       }
       echo "</table>";
     }
      catch(PDOException $e){
  echo $e->getMessage();
}
 ?>

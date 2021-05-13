<?php

class Availability extends Dbh{

/*  public function check($id,$startDay,$endDate)
  {
    $sql = "SELECT * FROM availability WHERE employee_id = ? ";
    $stmt=$this->connect()->prepare($sql);
    $stmt->execute([$id,$day]);
    $result = $stmt->rowCount();
    //echo $result;
    if($result>0)
    {
      return false;
    }
    else{
      return true;
    }
  }
*/
  public function insertAvailability($id,$firstname,$lastname,$description,$dateStart,$dateEnd)
  {
    try{
      $sql = "INSERT INTO availability(employee_id,first_name,last_name,description,startDate,endDate) VALUES(:empId,:firstname,:lastname,:description,:startDate,:endDate)";
      $sth = $this->connect()->prepare($sql);
      $sth->execute([':empId' =>$id,':firstname'=>$firstname,':lastname'=>$lastname ,':description' => $description,':startDate' => $dateStart,':endDate' => $dateEnd]);
      header('Location: ../pages/shiftsPage.php');
    }
    catch(PDOExeption $e)
    {echo $e -> getMessage();}
  }
}
 ?>

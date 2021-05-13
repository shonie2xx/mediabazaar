<?php
class ShiftControl extends Dbh{

  public function GetShifts(){
    $sql = "SELECT * FROM schedule";
    $stmt = $this->connect()->query($sql);
    $shifts=array();
      while($row = $stmt->fetch()){
      $shift=new Shift($row['Department'],$row['ID'],$row['Date'],$row['Storefloor'],$row['shiftNumb']);
      $shifts[]=$shift;

    }
    return $shifts;
  }

  public function DisplayShifts($id){
    $shifts=$this->GetShifts();
    $sql = "SELECT * FROM schedule_employee WHERE employee_id = ?";
    $stmt = $this->connect()->prepare($sql) ;
    $stmt->execute([$id]);
    if($stmt->rowCount() > 0)
    {
      $sNumber;
        while($row = $stmt->fetch()){
          foreach($shifts as $value){
            if($row['schedule_id']==$value->GetID()){
              if($value->GetShiftNumber() == 1)
              {
                $sNumber = "From 8:30 to 12:30";
              }
              if($value->GetShiftNumber() == 2)
              {
                $sNumber = "From 12:30 to 17:00";
              }
              if($value->GetShiftNumber() == 3)
              {
                $sNumber = "From 17:00 to 21:00";
              }
              if($value->GetShiftNumber() == 4)
              {
                $sNumber = "From 8:30 to 17:00";
              }
              if($value->GetShiftNumber() == 5)
              {
                $sNumber = "From 12:30 to 21:00";
              }
              if($value->GetShiftNumber() == 6)
              {
                $sNumber = "From 8:30 to 21:00";
              }
              if($value->GetShiftNumber() == 7)
              {
                $sNumber = "Null";
              }
               echo "</tr><td>" . $sNumber . "</td><td>". $value->GetDate() . "</td><td>" . $value->GetDepartment() . "</td><td>";
            }
          }
        }
      }
  }
}

 ?>

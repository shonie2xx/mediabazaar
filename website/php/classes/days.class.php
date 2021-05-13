<?php

class Days extends Dbh{


  public function getShift($id,$day)
  {
    $sql = "SELECT * FROM preference where employee_id = ? and dayOfWeek = ?";
    $stmt = $this->connect()->prepare($sql);
    $stmt->execute([$id,$day]);
    return $stmt;
  }
  public function checkFreeShift($id,$day)
  {
    $sql = "SELECT * FROM preference WHERE employee_id = ? AND dayOfWeek = ?";
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

  public function submitDay($id,$shiftNumber,$dayOfWeek)
  {
      $check = $this->checkFreeShift($id,$dayOfWeek);
        if($check)
        {
          try
          {
          $sql = "INSERT INTO preference(employee_id,shiftNumber,dayOfWeek) VALUES(:employee_id,:shiftNumber,:dayOfWeek)";
          $sth = $this->connect()->prepare($sql);
          $sth->execute([':employee_id' => $id,':shiftNumber'=>$shiftNumber,':dayOfWeek'=>$dayOfWeek]);
          }
            catch(PDOExeption $e)
            {
              echo $e->getMessage();
            }
        }
        else{
          try{
            $sql = "UPDATE preference SET shiftNumber = :shiftNumber WHERE employee_id = :id AND dayOfWeek = :dayOfWeek";
            $sth = $this->connect()->prepare($sql);
            $sth->execute([':id' => $id,':shiftNumber' => $shiftNumber, ':dayOfWeek' => $dayOfWeek]);
          }
          catch(PDOExeption $e)
          {
            echo $e->getMessage();
          }
        }
  }

  public function submitFloor($id,$shiftNumber,$storefloor,$dayOfWeek)
  {
      $check = $this->checkFreeShift($id,$dayOfWeek);
        if($check)
        {
          try
          {
          $sql = "INSERT INTO preference(employee_id,shiftNumber,dayOfWeek,StoreFloor) VALUES(:employee_id,:shiftNumber,:dayOfWeek,:storefloor)";
          $sth = $this->connect()->prepare($sql);
          $sth->execute([':employee_id' => $id,':shiftNumber'=>$shiftNumber,':storefloor'=>$storefloor,':dayOfWeek'=>$dayOfWeek]);
          }
            catch(PDOExeption $e)
            {
              echo $e->getMessage();
            }
        }
        else{
          try{
            $sql = "UPDATE preference SET shiftNumber = :shiftNumber, StoreFloor = :storefloor WHERE employee_id = :id AND dayOfWeek = :dayOfWeek";
            $sth = $this->connect()->prepare($sql);
            $sth->execute([':id' => $id,':shiftNumber' => $shiftNumber,':storefloor'=>$storefloor, ':dayOfWeek' => $dayOfWeek]);
          }
          catch(PDOExeption $e)
          {
            echo $e->getMessage();
          }
        }
  }


}
?>

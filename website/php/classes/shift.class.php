<?php
class Shift{
    private $department;
    private $ID;
    private $date;
    private $storefloor;
    private $shiftNumber;

  public function __construct($dep,$id,$dt,$stFloor,$shNumb){
    $this->department=$dep;
    $this->ID=$id;
    $this->date=$dt;
    $this->storefloor=$stFloor;
    $this->shiftNumber=$shNumb;
  }
public function GetID(){
  return $this->ID;
}
public function GetDepartment(){
  return $this->department;
}
public function GetStFloor(){
  return $this->storefloor;
}
public function GetDate(){
  return $this->date;
}
public function GetShiftNumber(){
  return $this->shiftNumber;
}
}

?>

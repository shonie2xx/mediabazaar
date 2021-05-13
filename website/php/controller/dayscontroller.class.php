<?php
class DaysController extends Days{
  public function insertDay($id,$shiftnumber,$dayOfWeek)
  {
    $this->submitDay($id,$shiftnumber,$dayOfWeek);
  }

  public function insertFloor($id,$shiftnumber,$storefloor,$dayOfWeek)
  {
    $this->submitFloor($id,$shiftnumber,$storefloor,$dayOfWeek);
  }
}
 ?>

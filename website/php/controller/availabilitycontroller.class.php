<?php
class AvailabilityController extends Availability{
  public function submitAvailability($id,$firstname,$lastname,$description,$dateStart,$dateEnd)
  {
    $this->insertAvailability($id,$firstname,$lastname,$description,$dateStart,$dateEnd);
  }
}
 ?>

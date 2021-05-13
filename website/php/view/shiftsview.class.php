<?php

// to view the shifts
class ShiftsView extends Days {

    public function showDays($id,$dayOfWeek) {

        $result = $this->getShift($id,$dayOfWeek);
        if($result->rowCount() > 0){

          while($row = $result->fetch())
            {
              if($row["shiftNumber"] == 1)
              {
              $row["shiftNumber"] = "From 8 to 12:30";
              }
              if($row["shiftNumber"] == 2)
              {
                $row["shiftNumber"] = "From 12:30 to 17:00";
              }
              if($row["shiftNumber"] == 3)
              {
              $row["shiftNumber"] = "From 17:00 to 21:00";
              }
              if($row["shiftNumber"] == 4)
              {
              $row["shiftNumber"] = "From 8:30 to 17:00";
              }
              if($row["shiftNumber"] == 5)
              {
              $row["shiftNumber"] = "From 12:30 to 21:00";
              }
              if($row["shiftNumber"] == 6)
              {
              $row["shiftNumber"] = "From 8:30 to 21:00";
              }
              if($row["shiftNumber"] == 7)
              {
              $row["shiftNumber"] = "null";
              }
            echo "Your current shifts: " . $row["shiftNumber"];

            }
        }
    }
}
?>

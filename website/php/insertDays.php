<?php
session_start();
$id = $_SESSION['ID'];
$department = $_SESSION['Department'];
$shiftnumber = $_POST['shift'];
$dayOfWeek = $_POST['day'];

include 'autoload.inc.php';

$dayObj = new DaysController();
$dayObj->insertDay($id,$shiftnumber,$dayOfWeek);
if($department == "SALES")
{
    $storefloor = $_POST['floor'];
    $dayObj->insertFloor($id,$shiftnumber,$storefloor,$dayOfWeek);
}





//echo "successful";


$usersObj = new ShiftsView();
$usersObj->showDays($id,$dayOfWeek);


?>

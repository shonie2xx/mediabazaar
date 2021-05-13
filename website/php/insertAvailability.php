<?php
session_start();

$id = $_SESSION['ID'];
$firstname = $_SESSION['FirstName'];
$lastname = $_SESSION['LastName'];
$text = $_POST['reasontext'];
$dateFrom = $_POST['fromDate'];
$dateTo = $_POST['toDate'];

include 'autoload.inc.php';

$availableObj = new AvailabilityController();
$availableObj->submitAvailability($id,$firstname,$lastname,$text,$dateFrom,$dateTo);
 ?>

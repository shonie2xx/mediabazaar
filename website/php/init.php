<?php
session_start();
spl_autoload_register('siteAutoLoader');
function siteAutoLoader($className){
  $path="../php/";
  $extension=".class.php";
  $fullPath=$path . $className. $extension;
  if(!file_exists($fullPath)){
    return false;
  }
  include_once $fullPath;}
 ?>

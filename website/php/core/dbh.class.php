<?php
class Dbh {

    protected function connect() {
        //$conn = new PDO("mysql:host=studmysql01.fhict.local;dbname=dbi434236","dbi434236","baitosho");
        $conn = new PDO("mysql:host=localhost;dbname=website-project","root","");
        $conn->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
        // setting fetch mode to associative array
        $conn-> setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, pDO::FETCH_ASSOC);

        return $conn;
    }

}
 ?>

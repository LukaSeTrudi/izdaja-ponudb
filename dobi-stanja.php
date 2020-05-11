<?php 
include 'connection.php';

$sql = "SELECT stanje FROM stanja";
$result = pg_query($conn, $sql);
$arr = array();
$arr = pg_fetch_all($result);
    echo json_encode($arr);
?>
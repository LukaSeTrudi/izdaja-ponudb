<?php 
include 'connection.php';

$query = "SELECT s.id, s.ime, s.kontakt, t.tip  FROM stranke s INNER JOIN tipi_strank t ON t.id = s.tip_id;";

$result = pg_query($conn, $query);

$arr = array();

if(pg_num_rows($result) > 0){
    $arr = pg_fetch_all($result);
    echo json_encode($arr);
}

?>
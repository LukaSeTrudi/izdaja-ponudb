<?php 
include 'connection.php';

$storitev = $_POST['storitev'];
$opis = $_POST['opis'];
$cena = $_POST['cena'];
$izdal = $_POST['izdal_id'];
$stranka = $_POST['stranka_id'];

$query = "INSERT INTO ponudbe(storitev, opis, cena, izdal_id, stranka_id) VALUES ('$storitev', '$opis',
 $cena, $izdal, $stranka)";

pg_query($conn, $query);

?>
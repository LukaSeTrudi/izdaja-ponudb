<?php 
include 'connection.php';

$storitev = $_POST['storitev'];
$opis = $_POST['opis'];
$cena = $_POST['cena'];
$izdal = $_POST['izdal'];
$stranka = $_POST['stranka'];

$query = "SELECT dodajPonudbo('$storitev', '$opis', '$cena', '$izdal', '$stranka')";
echo $query;
pg_query($conn, $query);

?>

<?php 
include 'connection.php';

$ime = $_POST['ime'];
$tip = $_POST['tip'];
$kontakt = $_POST['kontakt'];

$query = "INSERT INTO stranke(ime, tip_id, kontakt) VALUES ('$ime', $tip, '$kontakt')";

pg_query($conn, $query);

?>
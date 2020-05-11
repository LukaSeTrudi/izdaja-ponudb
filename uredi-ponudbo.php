<?php 
include 'connection.php';

$stanje = $_POST['stanje'];
$ponudba_id = $_POST['ponudba_id'];
$spremenil_id = $_POST['spremenil_id'];
$opis = $_POST['opis'];

$sql = "SELECT spremeniStanje('$stanje', $ponudba_id, $spremenil_id, '$opis')";

pg_query($sql);

?>
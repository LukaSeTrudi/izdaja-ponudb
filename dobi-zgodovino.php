<?php 
include 'connection.php';

$id = $_POST['id'];

$sql = "SELECT zs.id, d.ime, s.stanje, zs.datum, zs.opis FROM zgodovina_stanj zs
INNER JOIN stanja s ON s.id = zs.stanje_id
INNER JOIN ponudba p ON p.id = zs.ponudba_id
INNER JOIN delavci d ON d.id = zs.spremenil_id
WHERE p.id = $id
ORDER BY datum DESC";

$result = pg_query($conn, $sql);

echo json_encode(pg_fetch_all($result));

?>
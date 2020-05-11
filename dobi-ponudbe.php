<?php 

include 'connection.php';

$sql = "SELECT p.id, p.storitev, p.opis, p.cena, zs.datum, d.ime as delavec_ime, s.ime as stranka_ime, st.stanje FROM ponudba p
INNER JOIN stranke s ON s.id = p.stranka_id
INNER JOIN zgodovina_stanj zs ON zs.ponudba_id = p.id
INNER JOIN delavci d ON d.id = zs.spremenil_id
INNER JOIN stanja st ON st.id = zs.stanje_id
WHERE zs.datum = (SELECT zs1.datum FROM zgodovina_stanj zs1 WHERE zs1.ponudba_id = p.id ORDER BY zs1.datum DESC LIMIT 1);";

$result = pg_query($conn, $sql);

echo json_encode(pg_fetch_all($result));

?>
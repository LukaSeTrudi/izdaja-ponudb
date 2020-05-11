<?php 
include 'connection.php';

$id = $_POST['id'];

$sql = "DELETE FROM stranke WHERE id = $id";

pg_query($conn,$sql);

?>
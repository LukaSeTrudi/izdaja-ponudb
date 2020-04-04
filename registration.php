<?php 
include 'connection.php';

$user = $_POST['username'];
$pass = md5($_POST['password']);
$name = $_POST['name'];
$email = $_POST['email'];
$phone = $_POST['phone'];

$query = "INSERT INTO delavci(ime, username, password, email, phone) VALUES ('$name', '$user', '$pass', '$email', '$phone')";

pg_query($conn, $query);

?>
<?php
    $_servername = "ec2-79-125-26-232.eu-west-1.compute.amazonaws.com";
    $_username = "dywvwygvrkyosf";
    $_password = "56f7dddbd5018286f8201ce3d0f557f6608bd18729061f7c90cc42fc48b0d2cb";
    $_db = "dd8d86j4g0t25k";
    // Create connection
    $conn = pg_connect("host=$_servername port=5432 dbname=$_db user=$_username password=$_password");
    // Check connection
    if (!$conn) {
        echo "failed";
    die("Connection failed: " . mysqli_connect_error());
    }
    //echo "Connected successfully";
?>
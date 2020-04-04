<?php 
    $servername = "ec2-79-125-26-232.eu-west-1.compute.amazonaws.com";
    $username = "dywvwygvrkyosf";
    $password = "56f7dddbd5018286f8201ce3d0f557f6608bd18729061f7c90cc42fc48b0d2cb";
    $db = "dd8d86j4g0t25k";
    // Create connection
    $conn = mysqli_connect($servername, $username, $password,$db);
    // Check connection
    if (!$conn) {
        echo "failed";
    die("Connection failed: " . mysqli_connect_error());
    }
    //echo "Connected successfully";
?>
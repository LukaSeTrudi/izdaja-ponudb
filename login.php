<?php 
include 'connection.php';

$user = $_POST['username'];
$pass = md5($_POST['password']);

$query = "SELECT * FROM delavci WHERE username = '$user' AND password='$pass'";

$result = pg_query($conn, $query);
if(pg_num_rows($result) > 0){
    while($row = pg_fetch_row($result)){
        echo $row[0];
    }
} else {
    echo "NO USER";
}

?>
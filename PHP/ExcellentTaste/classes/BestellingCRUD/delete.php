<?php
require_once "../config.php";
if(isset($_GET['id']) && is_numeric($_GET['id'])){
    
    $id = $_GET['id'];
    $delete_user = mysqli_query($connect,"DELETE FROM `reservering` WHERE ReserveringID='$id'");
    
    if($delete_user){
        echo "<script>
        alert('Reservering afgerond.');
        window.location.href = '../etenbestellingen.php';
        </script>";
        exit;
    }else{
       echo "Error"; 
    }
}else{
    // set header response code
    http_response_code(404);
    echo "<h1>404 Page Not Found!</h1>";
}
?>
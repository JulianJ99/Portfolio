<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>    
	<link rel="stylesheet" type="text/css" a href="styles/style.css"/>
    <title>Bestellingen</title>
</head>
 <?php
include_once 'includes/header.php'
?>

<body>
 
 <main>

    <table width='80%'>
 <thead>
    <tr>
        <td>Bestelling ID</td>
        <td>Reservering ID</td>
        <td>Tafel</td>
        <td>Gerecht</td>
        <td>Aantal gerechten</td>
        <td>Prijs</td>
        <td>Datum</td>
    	<td>Tijd</td>
    </tr>
    </thead>
    <tbody>
    <?php   
    //including the database connection file
	require_once "includes/config.php";
  
     $sql = "SELECT bestelling.BestellingID, reservering.ReserveringID, reservering.Tafel, menuitem.Menuitem, bestelling.Aantal, bestelling.Prijs, reservering.Datum, reservering.Tijd FROM bestelling JOIN reservering ON bestelling.Reserveringid = reservering.Reserveringid JOIN menuitem ON bestelling.menuitemcode = menuitem.menuitemcode ORDER BY datum, tijd ASC";
            $result = $mysqli->query($sql);
            if($result->num_rows > 0) {
            while($row = $result->fetch_assoc()) {       	
		echo "<td>".$row['BestellingID']."</td>";
		echo "<td>".$row['ReserveringID']."</td>";
        echo "<td>".$row['Tafel']."</td>";
    	echo "<td>".$row['Menuitem']."</td>";
    	echo "<td>".$row['Aantal']."</td>";
    	echo "<td>".$row['Prijs']."</td>";
    	echo "<td>".$row['Datum']."</td>";
    	echo "<td>".$row['Tijd']."</td>";
    	echo "<td> <a href='BestellingCRUD/edit.php?id=".$row['ReserveringID']."'><button type='button'>Bestelling aanpassen</button></a></td>";
    	echo "</tr>";
     }
    }
     
    ?>
    </tbody>
    </table>
 </main>
</body>
</html>

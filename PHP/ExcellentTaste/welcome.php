<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Hoofdpagina</title>
    <link rel="stylesheet" href="styles/style.css">
    <style type="text/css">
    </style>
</head>
<body>

<?php
include_once 'includes/header.php'
?>

	<main>
        <h2>Excellent Taste</h2>
        <p>Welkom op de site van Excellent Taste. <br/>
        Deze site wordt door de medewerkers gebruikt om reserveringen/bestellingen te regelen en er is ook een menukaart voor hun overzicht.</p>
        Dit is ons menu:
 <table width='80%'>
 <thead>
    <tr>
    	<td>Menuitem</td>
    	<td>Prijs</td>
    	
    </tr>
    </thead>
    <tbody>
    <?php   
    //including the database connection file
	require_once "includes/config.php";
  
     $sql = "SELECT menuitem.Menuitem, menuitem.Prijs, menuitem.Menuitemcode FROM menuitem ORDER BY Prijs DESC";
            $result = $mysqli->query($sql);
            if($result->num_rows > 0) {
            while($row = $result->fetch_assoc()) { 
        ?>
        <input type="hidden" name="hidden_itemcode" id="my_hidden_itemcode" value="<?php echo $row['menuitem.Menuitemcode'];?>"/>     	
		<?php
		echo "<td>".$row['Menuitem']."</td>";
		echo "<td>".$row['Prijs']."</td>";
    	echo "<td> <a href='classes/ProductCRUD/edit.php?id=".$row['Menuitemcode']."'><button type='button'>Prijs aanpassen</button></a></td>";
    	echo "</tr>";
     }
    }
     
    ?>
    </tbody>
    </table>

   </main>    
</body>
</html>
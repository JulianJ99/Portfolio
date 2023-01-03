<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
	<link rel="stylesheet" type="text/css" a href="styles/style.css"/>
<style>
select{
	width:15%;
}
</style>
<title>Bestelling toevoegen</title>
</head>

<body>
<main>
<?php
    //including the database connection file
	require_once "config2.php";





?>
<fieldset>
<?php
 
  $mysqli = "SELECT reservering.Datum, reservering.Tijd, reservering.Aantal, menuitem.Menuitem, menuitem.Prijs, reservering.Tafel, menuitem.Menuitemcode,  reservering.ReserveringID FROM bestelling JOIN reservering ON bestelling.ReserveringID = reservering.ReserveringID JOIN menuitem ON bestelling.Menuitemcode = menuitem.Menuitemcode";
                            $result = $connect->query($mysqli);
                            $result-> fetch_assoc();                          
                            $SELECT = "<select name='Bestelling[]' multiple>";
                            foreach($result as $mysqli)
                            {
                            	
                                $SELECT .= "<option value=".$mysqli['Prijs'].">".$mysqli['Menuitem']."</option>";
                            }
                                $SELECT .= "</select>";
                             
                                echo($SELECT); 
?>
    			<legend>Voeg bestelling toe</legend>
 
                <td><input type='submit' name ='submit' value ='submit'/> </td>
                <?php 
	
				// Check if form is submitted successfully 
					if(isset($_POST["submit"])) 
				{ 
				// Check if any option is selected 
					if(isset($_POST["Bestelling"])) 
				{ 
				// Retrieving each selected option 
				foreach ($_POST['Bestelling'] as $Prijs) 
					print "U heeft $Prijs geselecteerd <br/>"; 
				} 
				else
					echo "Selecteer eerst een gerecht."; 
				} 
?> 
                <td><a href="../index.php"><button type="button">Back</button></a></td>
      
 
</fieldset>

</main>
</body>

</html>

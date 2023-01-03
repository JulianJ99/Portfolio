<?php 
 
require_once "../../includes/config.php";

if($_GET['id']) {
    $id = $_GET['id'];
 
    $sql = "SELECT reservering.ReserveringID, reservering.Tafel, reservering.Datum, reservering.Tijd,  klant.Klantnaam, klant.Telefoon, reservering.Personen, reservering.Klantid FROM reservering JOIN Klant ON reservering.Klantid = klant.Klantid WHERE ReserveringID = {$id}";
    $result = $mysqli->query($sql);
 
    $data = $result->fetch_assoc();
 
    $mysqli->close();
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>ProductPersonen aanpassen</title>
	<link rel="stylesheet" href="../../styles/style.css">
    <style type="text/css">
        legend{
			padding-top:10px;
		}
        fieldset {
            
            width: 80%;
            height: 80%;
            background-color:#CCCC00;
            
        }
        table tr th {
            padding-right:15px;
           	padding-bottom:40px;
           }
        td {
	padding-right:15px;
	padding-bottom:40px;
	}
    </style>
 
</head>
<body>
<?
 include_once 'includes/header.php'
 //reservering.ReserveringID,  reservering.Tafel, reservering.Datum, reservering.Tijd,  klant.Klantnaam, klant.Telefoon, reservering.Personen
?>

<fieldset>
<br/>
    <legend>Edit Product</legend>
 
    <form action="update.php" method="post">
        <table cellspacing="0" cellpadding="0">
            <tr>
                <th>Tafel</th>
                <td><input type="text" name="Tafel" placeholder="Tafel" value="<?php echo $data['Tafel'] ?>" /></td>

				<th>Datum</th>
                <td><input type="text" name="Datum" placeholder="Datum" value="<?php echo $data['Datum'] ?>" /></td>
                
              	<th>Tijd</th>
                <td><input type="text" name="Tijd" placeholder="Tijd" value="<?php echo $data['Tijd'] ?>" /></td>

              	<th>Klantnaam</th>
                <td><input type="text" name="Klantnaam" placeholder="Klantnaam" value="<?php echo $data['Klantnaam'] ?>" /></td>

              	<th>Telefoon</th>
                <td><input type="text" name="Telefoon" placeholder="Telefoon" value="<?php echo $data['Telefoon'] ?>" /></td>

                <th>Personen</th>
                <td><input type="text" name="Personen" placeholder="Personen" value="<?php echo $data['Personen'] ?>" /></td>
            </tr>
            <tr>
                <input type="hidden" name="ReserveringID" value="<?php echo $data['ReserveringID']?>" /><br/>
                <input type="hidden" name="Klantid" value="<?php echo $data['Klantid']?>" /><br/><br/>
                <td><button type="submit">Verandering opslaan</button></td><br/>
                <td><a href="../../welcome.php"><button type="button">Terug</button></a></td>
            </tr>
        </table>
        <br/>
    </form>
</fieldset>
 
</body>
</html>
 
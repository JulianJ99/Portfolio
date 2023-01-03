<html>
<head>
    <title>Speler toevoegen</title>
</head>
 
<body>

<?php
//Include de database verbinding file
include_once("config.php");

if(isset($_POST['Submit'])) {    
    $gerechtcode	 	= $_POST['gerechtcode'];
    $menuitem		 	= $_POST['menuitem'];
    $prijs	 			= $_POST['prijs'];
        
    // Checkt voor lege velden in de submit, geeft dan foutmeldingen en een back knop aan indien nodig
    if(empty($gerechtcode) || empty($menuitem) || empty($prijs)){
            
		if(empty($gerechtcode)) {
            echo "<font color='red'>U heeft geen Gerechtcode ingevuld.</font><br/>";
        }
                           
		if(empty($menuitem)) {
            echo "<font color='red'>U heeft geen Menuitem ingevuld.</font><br/>";
        }
        
        if(empty($prijs)) {
            echo "<font color='red'>U heeft geen Prijs ingevuld.</font><br/>";
        }    


        echo "<br/><a href='javascript:self.history.back();'>Go Back</a>";
    } 
    else { 
     	//Voegt de ingevulde gegevens toe in de tabel volgens de aangemaakte query
        $sql = "INSERT INTO menuitem(menuitemcode, gerechtcode, menuitem, prijs) VALUES(:menuitemcode, :gerechtcode, :menuitem, :prijs)";
        $query = $dbConn->prepare($sql);
        $menuitemcode = create_id();
        $query->bindparam(':menuitemcode', $menuitemcode);  
        $query->bindparam(':gerechtcode', $gerechtcode);
        $query->bindparam(':menuitem', $menuitem);         
        $query->bindparam(':prijs', $prijs);
        $query->execute();
        echo "<font color='green'>Gerecht toegevoegd.";
        echo "<br/><a href='../../clsGerechten.php'>Zie Resultaat</a>";
    }
 }
 			//Maakt een ID aan gebaseerd op bits om ervoor te zorgen dat het let op de AutoIncrement ID van de spelers, 
 			//Dus zal er altijd voor zorgen dat het een nummer voor de laatst toegevoegde ID is zonder dat de gebruiker dat zelf invult
 			function create_id() {
			return sprintf('%04x%04x-%04x-%04x-%04x-%04x%04x%04x', 	// 32 bits for "time_low"
            mt_rand(0, 0xffff), mt_rand(0, 0xffff), 				// 16 bits for "time_mid"
            mt_rand(0, 0xffff), 									// 16 bits for "time_hi_and_version",
            														// four most significant bits 
            														// holds version number 4
	        mt_rand(0, 0x0fff) | 0x4000, 							// 16 bits, 8 bits for "clk_seq_hi_res",
	            													// 8 bits for "clk_seq_low",
																	// two most significant bits holds 
																	// zero and one for variant DCE1.1
	        mt_rand(0, 0x3fff) | 0x8000, 							// 48 bits for "node"
            mt_rand(0, 0xffff), mt_rand(0, 0xffff), mt_rand(0, 0xffff));
		}
		

 
?>
</body>
</html>
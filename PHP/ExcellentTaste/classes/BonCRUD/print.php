<?php
require('../../fpdf/fpdf.php');

//Connect to your database
include('../../fpdf/config.php');

//Select the Products you want to show in your PDF file
if($_GET['id']) {
$id = $_GET['id'];
$sql = "SELECT reservering.Tafel, menuitem.Menuitem, bestelling.Aantal, bestelling.Prijs, reservering.Datum, reservering.Tijd FROM bestelling JOIN reservering ON bestelling.Reserveringid = reservering.Reserveringid JOIN menuitem ON bestelling.menuitemcode = menuitem.menuitemcode ORDER BY datum, tijd ASC WHERE reservering.Reserveringid = {$id}";
$result = $connect->query($sql);
//$number_of_products = mysqli_num_rows($result);

//Initialize the 3 columns and the total
$column_tafel = "";
$column_menuitem = "";
$column_aantal = "";
$column_price = "";
$column_datum = "";
$column_tijd = "";
$total = 0;
}
//For each row, add the field to the corresponding column
while($row = mysqli_fetch_array($result))
{
	
    
    $menuitem = $row["Menuitem"];
    $aantal = $row["Aantal"];
   	//$real_price = $row["Prijs"];
    $price_to_show = $row["Prijs"];
    $tafel = $row["Tafel"];
	$datum = $row["Datum"];	
	$tijd = $row["Tijd"];
	
   
    $column_menuitem = $column_menuitem.$menuitem."\n";
    $column_aantal = $column_aantal.$aantal."\n";
    $column_price = $column_price.$price_to_show."\n";
    $column_tafel = $column_tafel.$tafel."\n";
    $column_datum = $column_datum.$datum."\n";
    $column_tijd = $column_tijd.$tijd."\n";
	//$column_name = $column_name.$name."\n";
    //Sum all the Prices (TOTAL)
    
}
mysqli_close($connect);

//Convert the Total Price to a number with (.) for thousands, and (,) for decimals.

//Create a new PDF file
$pdf=new FPDF();
$pdf->AddPage();

//Fields Name position
$Y_Fields_Name_position = 20;
//Table position, under Fields Name
$Y_Table_Position = 26;

//First create each Field Name
//Gray color filling each Field Name box
$pdf->SetFillColor(232,232,232);
//Bold Font for Field Name
$pdf->SetFont('Arial','B',12);
$pdf->SetY($Y_Fields_Name_position);
$pdf->SetX(10);

$pdf->Ln();
$pdf->SetY(80);
$pdf->SetX(35);
$pdf->Cell(30,6, 'MENUITEM',1);

$pdf->SetY(80);
$pdf->SetX(85);
$pdf->Cell(30,6, 'AANTAL',1);

$pdf->SetY(80);
$pdf->SetX(135);
$pdf->Cell(30,6, 'PRICE',1);


$pdf->SetY(100);
$pdf->SetX(35);
$pdf->Cell(30,6, 'TAFEL',1);

$pdf->SetY(100);
$pdf->SetX(85);
$pdf->Cell(30,6, 'DATUM',1);

$pdf->SetY(100);
$pdf->SetX(135);
$pdf->Cell(30,6, 'TIJD',1);


//$Y_Table_Position
//Now show the table columns
$pdf->SetFont('Arial','',12);
$pdf->Ln();
$pdf->SetY($Y_Table_Position);
$pdf->SetX(15);


$pdf->MultiCell(30,6,$column_menuitem,1);
$pdf->SetY(86);
$pdf->SetX(85);

$pdf->MultiCell(30,6,$column_aantal,1);
$pdf->SetY(86);
$pdf->SetX(135);

$pdf->MultiCell(30,6,$column_price,1,'R');
$pdf->SetY(106);
$pdf->SetX(35);

//$pdf->MultiCell(70,6,'$ '.$total,1,'R');

$pdf->MultiCell(30,6,$column_tafel,1);
$pdf->SetY(106);
$pdf->SetX(85);


$pdf->MultiCell(30,6,$column_datum,1);
$pdf->SetY(106);
$pdf->SetX(135);


$pdf->MultiCell(30,6,$column_tijd,1);
$pdf->SetY(106);
$pdf->SetX(35);


//Create lines (boxes) for each ROW (Product)
//If you don't use the following code, you don't create the lines separating each row
$i = 0;
$pdf->SetY($Y_Table_Position);
while ($i < $number_of_products)
{
    $pdf->SetX(55);
    $pdf->MultiCell(30,6,'',1);
    $i = $i +1;
}

$pdf->Output();

?>

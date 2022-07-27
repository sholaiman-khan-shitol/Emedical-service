<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8">
	<title>loginaction</title>
</head>
<body>
	<?php

		if($_SERVER['REQUEST_METHOD'] === "POST")
		{
			$filename = "data.json";
			$username = $_POST['username'];
			$password = $_POST['Password'];
			if($username === "" || $password === "")
		{
			echo "Please Enter Your Username & password correctly";
			
		}
		  else
		  {
		  	$filename = "data.json";
			$username = $_POST['username'];
			$password = $_POST['Password'];

			$handle = fopen($filename, "r");
			$data = fread($handle, filesize($filename));
			$data = explode("\n",$data);

			$uservalidation = false;

			for($i=0; $i<count($data)-1; $i++)
			{
				$json= json_decode($data[$i]);
				if ( $username === $json->username and $password === $json->password)
				{
					$uservalidation= true;
					break;
				}
			}
			if($uservalidation)
			{   
				session_start();
				$_SESSION['username'] = $username; 
				header("Location:Home.php");
			}
			else  
			{
				echo "login Failed";
			}
		  }
			
		}

	?>
	<a href="http://localhost/project/logout.php">Logout</a>
</body>
</html>
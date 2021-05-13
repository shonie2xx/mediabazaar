<html>
<body>
<head>
  <link href = "../css/style.css" type = "text/css" rel = "stylesheet">
  <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>

  </head>

<h1>Choose preffered shift</h1>



<input class = "btnlogout" value = "Back" onclick="location='shiftsPage.php'"/>

<div class="grid-container">

<?php
session_start();
$department = $_SESSION['Department'];

if($department == "SALES")
{
?>

  <div class="grid-item">
    <p id="monday">Monday</p>
    <select id="mondayfloor">
<option value="1">Hardware</option>
<option value="2">Music, movies and games</option>
<option value="3">Laptops</option>
<option value="4">Household appliances</option>
   </select>
    <select id="mondayshift">
<option value="1">From 8:30 to 12:30</option>
<option value="2">From 12:30 to 17:00</option>
<option value="3">From 17:00 to 21:00</option>
<option value="4">From 8:30 to 17:00</option>
<option value="5">From 12:30 to 21:00</option>
<option value="6">From 8:30 to 21:00</option>
<option value="7">Null</option>
   </select>
   <button type="submit" id="mondaybtn">Submit</button>
   <div id="mondaytxt">
   </div>
  </div>

  <div class="grid-item">
    <p id="tuesday">Tuesday</p>
    <select id="tuesdayfloor">
<option value="1">Hardware</option>
<option value="2">Music, movies and games</option>
<option value="3">Laptops</option>
<option value="4">Household appliances</option>
   </select>
    <select id="tuesdayshift">
    <option value="1">From 8:30 to 12:30</option>
    <option value="2">From 12:30 to 17:00</option>
    <option value="3">From 17:00 to 21:00</option>
    <option value="4">From 8:30 to 17:00</option>
    <option value="5">From 12:30 to 21:00</option>
    <option value="6">From 8:30 to 21:00</option>
    <option value="7">Null</option>
    </select>
    <button type="submit" id="tuesdaybtn">Submit</button>
    <div id="tuesdaytxt">
    </div>
  </div>

  <div class="grid-item">
    <p id="wednesday">Wednesday</p>
    <select id="wednesdayfloor">
    <option value="1">Hardware</option>
    <option value="2">Music, movies and games</option>
    <option value="3">Laptops</option>
    <option value="4">Household appliances</option>
   </select>
    <select id="wednesdayshift">
    <option value="1">From 8:30 to 12:30</option>
    <option value="2">From 12:30 to 17:00</option>
    <option value="3">From 17:00 to 21:00</option>
    <option value="4">From 8:30 to 17:00</option>
    <option value="5">From 12:30 to 21:00</option>
    <option value="6">From 8:30 to 21:00</option>
    <option value="7">Null</option>
    </select>
    <button type="submit" id="wednesdaybtn">Submit</button>
    <div id="wednesdaytxt">
    </div>
  </div>

  <div class="grid-item">
    <p id="thursday">Thursday</p>
    <select id="thursdayfloor">
<option value="1">Hardware</option>
<option value="2">Music, movies and games</option>
<option value="3">Laptops</option>
<option value="4">Household appliances</option>
   </select>
    <select id="thursdayshift">
    <option value="1">From 8:30 to 12:30</option>
    <option value="2">From 12:30 to 17:00</option>
    <option value="3">From 17:00 to 21:00</option>
    <option value="4">From 8:30 to 17:00</option>
    <option value="5">From 12:30 to 21:00</option>
    <option value="6">From 8:30 to 21:00</option>
    <option value="7">Null</option>
    </select>
    <button type="submit" id="thursdaybtn">Submit</button>
    <div id="thursdaytxt">
    </div>
  </div>

  <div class="grid-item">
    <p id="friday">Friday</p>
    <select id="fridayfloor">
<option value="1">Hardware</option>
<option value="2">Music, movies and games</option>
<option value="3">Laptops</option>
<option value="4">Household appliances</option>
   </select>
    <select id="fridayshift">
    <option value="1">From 8:30 to 12:30</option>
    <option value="2">From 12:30 to 17:00</option>
    <option value="3">From 17:00 to 21:00</option>
    <option value="4">From 8:30 to 17:00</option>
    <option value="5">From 12:30 to 21:00</option>
    <option value="6">From 8:30 to 21:00</option>
    <option value="7">Null</option>
    </select>
    <button type="submit" id="fridaybtn">Submit</button>
    <div id="fridaytxt">
    </div>
  </div>

  <div class="grid-item">
    <p id="saturday">Saturday</p>
    <select id="saturdayfloor">
<option value="1">Hardware</option>
<option value="2">Music, movies and games</option>
<option value="3">Laptops</option>
<option value="4">Household appliances</option>
   </select>
    <select id="saturdayshift">
    <option value="1">From 8:30 to 12:30</option>
    <option value="2">From 12:30 to 17:00</option>
    <option value="3">From 17:00 to 21:00</option>
    <option value="4">From 8:30 to 17:00</option>
    <option value="5">From 12:30 to 21:00</option>
    <option value="6">From 8:30 to 21:00</option>
    <option value="7">Null</option>
    </select>
    <button type="submit" id="saturdaybtn">Submit</button>
    <div id="saturdaytxt">
    </div>
  </div>

  <div class="grid-item">
    <p id="sunday">Sunday</p>
    <select id="sundayfloor">
<option value="1">Hardware</option>
<option value="2">Music, movies and games</option>
<option value="3">Laptops</option>
<option value="4">Household appliances</option>
   </select>
    <select id="sundayshift">
    <option value="1">From 8:30 to 12:30</option>
    <option value="2">From 12:30 to 17:00</option>
    <option value="3">From 17:00 to 21:00</option>
    <option value="4">From 8:30 to 17:00</option>
    <option value="5">From 12:30 to 21:00</option>
    <option value="6">From 8:30 to 21:00</option>
    <option value="7">Null</option>
    </select>
    <button type="submit" id="sundaybtn">Submit</button>
    <div id="sundaytxt">
    </div>
  </div>
</div>
  <?php
  
}
else
{



  ?>
<div class="grid-item">
    <p id="monday">Monday</p>
    <select id="mondayshift">
<option value="1">From 8:30 to 12:30</option>
<option value="2">From 12:30 to 17:00</option>
<option value="3">From 17:00 to 21:00</option>
<option value="4">From 8:30 to 17:00</option>
<option value="5">From 12:30 to 21:00</option>
<option value="6">From 8:30 to 21:00</option>
<option value="7">Null</option>
   </select>

   <button type="submit" id="mondaybtn">Submit</button>
   <div id="mondaytxt">
   </div>
  </div>


  <div class="grid-item">
    <p id="tuesday">Tuesday</p>
    <select id="tuesdayshift">
    <option value="1">From 8:30 to 12:30</option>
    <option value="2">From 12:30 to 17:00</option>
    <option value="3">From 17:00 to 21:00</option>
    <option value="4">From 8:30 to 17:00</option>
    <option value="5">From 12:30 to 21:00</option>
    <option value="6">From 8:30 to 21:00</option>
    <option value="7">Null</option>
    </select>
    <button type="submit" id="tuesdaybtn">Submit</button>
    <div id="tuesdaytxt">
    </div>
  </div>

  <div class="grid-item">
    <p id="wednesday">Wednesday</p>
    <select id="wednesdayshift">
    <option value="1">From 8:30 to 12:30</option>
    <option value="2">From 12:30 to 17:00</option>
    <option value="3">From 17:00 to 21:00</option>
    <option value="4">From 8:30 to 17:00</option>
    <option value="5">From 12:30 to 21:00</option>
    <option value="6">From 8:30 to 21:00</option>
    <option value="7">Null</option>
    </select>
    <button type="submit" id="wednesdaybtn">Submit</button>
    <div id="wednesdaytxt">
    </div>
  </div>

  <div class="grid-item">
    <p id="thursday">Thursday</p>
    <select id="thursdayshift">
    <option value="1">From 8:30 to 12:30</option>
    <option value="2">From 12:30 to 17:00</option>
    <option value="3">From 17:00 to 21:00</option>
    <option value="4">From 8:30 to 17:00</option>
    <option value="5">From 12:30 to 21:00</option>
    <option value="6">From 8:30 to 21:00</option>
    <option value="7">Null</option>
    </select>
    <button type="submit" id="thursdaybtn">Submit</button>
    <div id="thursdaytxt">
    </div>
  </div>

  <div class="grid-item">
    <p id="friday">Friday</p>
    <select id="fridayshift">
    <option value="1">From 8:30 to 12:30</option>
    <option value="2">From 12:30 to 17:00</option>
    <option value="3">From 17:00 to 21:00</option>
    <option value="4">From 8:30 to 17:00</option>
    <option value="5">From 12:30 to 21:00</option>
    <option value="6">From 8:30 to 21:00</option>
    <option value="7">Null</option>
    </select>
    <button type="submit" id="fridaybtn">Submit</button>
    <div id="fridaytxt">
    </div>
  </div>

  <div class="grid-item">
    <p id="saturday">Saturday</p>
    <select id="saturdayshift">
    <option value="1">From 8:30 to 12:30</option>
    <option value="2">From 12:30 to 17:00</option>
    <option value="3">From 17:00 to 21:00</option>
    <option value="4">From 8:30 to 17:00</option>
    <option value="5">From 12:30 to 21:00</option>
    <option value="6">From 8:30 to 21:00</option>
    <option value="7">Null</option>
    </select>
    <button type="submit" id="saturdaybtn">Submit</button>
    <div id="saturdaytxt">
    </div>
  </div>

  <div class="grid-item">
    <p id="sunday">Sunday</p>
    <select id="sundayshift">
    <option value="1">From 8:30 to 12:30</option>
    <option value="2">From 12:30 to 17:00</option>
    <option value="3">From 17:00 to 21:00</option>
    <option value="4">From 8:30 to 17:00</option>
    <option value="5">From 12:30 to 21:00</option>
    <option value="6">From 8:30 to 21:00</option>
    <option value="7">Null</option>
    </select>
    <button type="submit" id="sundaybtn">Submit</button>
    <div id="sundaytxt">
    </div>
  </div>

</div>

<?php

}
?>


<script>

  $("#mondaybtn").click(function(){
    var day = $("#monday").text();
    var shift = $("#mondayshift").val();
    var floor = $("#mondayfloor").val();
    $("#mondaytxt").load("../php/insertDays.php",{
      day:day,
      shift:shift,
      floor:floor
    });
});

$("#tuesdaybtn").click(function(){
  var day = $("#tuesday").text();
  var shift = $("#tuesdayshift").val();
  var floor = $("#tuesdayfloor").val();
  $("#tuesdaytxt").load("../php/insertDays.php",{
    day:day,
    shift:shift,
    floor:floor
    
  });
});

$("#wednesdaybtn").click(function(){
  var day = $("#wednesday").text();
  var shift = $("#wednesdayshift").val();
  var floor = $("#wednesdayfloor").val();
  $("#wednesdaytxt").load("../php/insertDays.php",{
    day:day,
    shift:shift,
    floor:floor
  });
});

$("#thursdaybtn").click(function(){
  var day = $("#thursday").text();
  var shift = $("#thursdayshift").val();
  var floor = $("#thursdayfloor").val();
  $("#thursdaytxt").load("../php/insertDays.php",{
    day:day,
    shift:shift,
    floor:floor
  });
});

$("#fridaybtn").click(function(){
  var day = $("#friday").text();
  var shift = $("#fridayshift").val();
  var floor = $("#fridayfloor").val();
  $("#fridaytxt").load("../php/insertDays.php",{
    day:day,
    shift:shift,
    floor:floor
  });
});

$("#saturdaybtn").click(function(){
  var day = $("#saturday").text();
  var shift = $("#saturdayshift").val();
  var floor = $("#saturdayfloor").val();
  $("#saturdaytxt").load("../php/insertDays.php",{
    day:day,
    shift:shift,
    floor:floor
  });
});

$("#sundaybtn").click(function(){
  var day = $("#sunday").text();
  var shift = $("#sundayshift").val();
  var floor = $("#sundayfloor").val();
  $("#sundaytxt").load("../php/insertDays.php",{
    day:day,
    shift:shift,
    floor:floor
  });
});



</script>

</body>
</html>

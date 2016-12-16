<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TournamentPage.aspx.cs" Inherits="PokerTimer.TournamentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Index page</title>
    <link rel="stylesheet" href="Css/style.css"/>
</head>
<script style="text/javascript">
    var countdown = 20 * 60;
    window.setInterval(function()
    {
        countdown -= 1;
        var minute = Math.floor(countdown / 60);
        var second = Math.round(countdown % 60);
        var minuteStr = minute.toString();
        var secondStr = second.toString();
        if (minute < 10) minuteStr = "0" + minuteStr;
        if (second < 10) secondStr = "0" + secondStr;
        document.getElementById("countdown_time").innerHTML = minuteStr + ":" + secondStr;
	    if (countdown == 0) countdown = 20 * 60;
    }, 1000);
</script>

<body class="bg_img">
    <div class="bodyCenter">
    <center>
    <div>
	    <div>
	    <span style="float:left; padding-left:8%; font-size: 25px; font-weight: bold; padding-top: 33px; width: 105px">12:00 am</span>
	    <span style="text-align: center;font-size: 50px;font-weight: bold; font-family: fantasy; color: #43e05e; padding-right:8%; margin-left: -100px;">SATURDAY DEEPSTACK</span>
	    </div>
	    <center><img src="/Images/bar.png" style="width:90%; opacity: 0.6;"/></center>
    </div>
    <div>
	    <table style="width:83%; text-align: center;">
		    <tr>
			    <td style="width:33%">
				    <div style="padding-top: 40px;">
				    <div class="digitBlind">5 000</div>
				    <div class="titleBlind" style="border-bottom: 1px solid #7f7b7b; border-right: 1px solid #7f7b7b;">SMALL</div>
				    </div>
			    </td>
			    <td style="width:33%">
				    <div>
				    <div class="digitBlind" style="font-size: 40px; padding-top:0px;">1 000</div>
				    <div style="margin-left: -2px; margin-right: -2px;border-bottom: 1px solid #7f7b7b;" class="titleBlind">ANTE</div>
				    </div>
			    </td>
			    <td style="width:33%">
				    <div style="padding-top: 40px;">
				    <div class="digitBlind">10 000</div>
				    <div style="border-bottom: 1px solid #7f7b7b; border-left: 1px solid #7f7b7b; " class="titleBlind">BIG</div>
				    </div>
			    </td>
		    </tr>
	    </table>
    </div>
    </center>
    <br>	
    <br>
    <center>
    <table width="90%">
	    <tr>
		    <td style="width:33%"><center><img src="/Images/logo.png" style="width:200px; height: 200px; margin-top:-80px; margin-left: 50px;"/></center></td>
		    <td style="width:33%">
			    <div class="box">
				    <div style="font-size:50px; font-weight:bold; padding-top: 73px;">LEVEL 3</div>
				    <div style="font-size:150px; font-weight:bold;" id="countdown_time">20:00</div>
			    </div>
		    </td>
		    <td style="width:33%"><center><img src="/Images/logo.png" style="width:200px; height: 200px; margin-top:-80px; margin-right: 50px;"/></center></td>
	    </tr>
    </table>
    </center>
    <table style="width: 92%; padding-left:8%; margin-top: -70px;">
	    <tr>
		    <td style="border-bottom: 1px solid #7f7b7b;width:33%">
			    <table style="float:left; text-align:center; width:100%;">
				    <tr>
					    <td>
						    <div class="digitInfomation">5 / 37</div>
						    <div class="titleBlind" style="border-bottom: 1px solid #7f7b7b;">PLAYERS</div>
					    </td>
				    </tr>
				    <tr>
					    <td style="padding-top: 40px;">
						    <div class="digitInfomation">7 500 / 15 000</div>
						    <div class="titleBlind" style="height: 100%;">NEXT BLINDS</div>
					    </td>
				    </tr>
			    </table>
		    </td>
		    <td style="width:33%;text-align:center; border-bottom: 1px solid #7f7b7b;">
				<div>
                <div style="margin-left: -6px; margin-right: -6px; margin-top: 75px; height: 45px; border-bottom: 1px solid #7f7b7b; border-left: 1px solid #7f7b7b; border-right: 1px solid #7f7b7b;"></div>
				<div class="digitInfomation">$100 000</div>
				<div class="titleBlind">PRIZE POOL</div>
				</div>
		    </td>
		    <td style="border-bottom: 1px solid #7f7b7b;width:33%">
			    <table style="float:right; text-align:center; width:100%;">
				    <tr>
					    <td>
						    <div class="digitInfomation">12 000</div>
						    <div class="titleBlind"style="border-bottom: 1px solid #7f7b7b;">AVARAGE STACK</div>
					    </td>
				    </tr>
				    <tr>
					    <td style="padding-top: 40px;">
						    <table style="text-align: center;  margin:auto;">
							    <tr class="digitInfomation">
								    <td>10</td>
								    <td></td>
								    <td>2</td>
							    </tr>
							    <tr class="titleBlind">
								    <td>REBUY</td>
								    <td>&nbsp;/&nbsp;</td>
								    <td>ADD-ON</td>
							    </tr>
						    </table>
					    </td>
				    </tr>
			    </table>
		    </td>
	    </tr>
    </table>
    </div>
</body>
</html>

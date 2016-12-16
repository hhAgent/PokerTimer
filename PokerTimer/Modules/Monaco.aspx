<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Monaco.aspx.cs" Inherits="PokerTimer.Monaco" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MONACO POKER CLUB</title>
    <style>
        .tourline {
            text-align: center;
            font-size: 30px;
            padding-top: 30px;
        }
    </style>
</head>
<body>
    <table border="0" cellpadding="0" cellspacing="0" class="content" style="height: 100%; width: 100%;">
        <tr>
            <td colspan="1" style="background-image: url(Images/bg_banner.png); width: 100%; color:white;">
                <img src="Images/Logo.png" style="width: 150px; height: 150px; float:left;" />
                <img src="Images/rightLogo.png" style="height: 150px;float: right;" />
                <div id="clubTitle" style="font-size: 50px; text-align: center; height: 150px; line-height: 150px;">MONACO POKER CLUB</div>    
            </td>
        </tr>
        <tr>   
            <td>
                <div id="menu" runat="server"></div>                        
            </td>         
        </tr>
        <tr>
            <td colspan="1" class="footer">
                <!--
                <iframe src="Footer.aspx" frameborder="0" width="100%" scrolling="no" height="100%"
                    id="frFooter" name="frFooter"></iframe>
                --->
            </td>
        </tr>
    </table>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="PokerTimer.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MONACO POKER CLUB</title>    
    <style>
        html, body
        {
          height: 100%;
        }
    </style>
</head>
<body>
    <table border="0" class="content" style="height: 100%; width: 100%;">
        <tr>
            <td colspan="2" style="width: 100%;">
                <iframe src="header.html" scrolling="no" style="width: 100%;" frameborder="0" ></iframe>
                <hr />
            </td>
        </tr>        
        <tr>   
            <td id="colMenu" class="menu" valign="top" style="height: 100%; width:43px;">
                <iframe src="Menu.aspx" frameborder="0" id="menu" name="menu" width="100%" height="100%" scrolling="no" marginwidth="0" marginheight="0" allowtransparency="yes">
                </iframe>
            </td>            
            <td>
                <div id="ipHeader" runat="server"></div>
                <iframe src="ListTour.aspx" frameborder="0" id="menu" name="menu" width="100%" height="100%" scrolling="no" marginwidth="0" marginheight="0" allowtransparency="yes">
                </iframe>
            </td>
        </tr>        
    </table>
</body>
</html>

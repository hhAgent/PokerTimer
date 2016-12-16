<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="PokerTimer.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../Css/menu.css" media="screen" />
    <title></title>    
    <script>
        function change2Menu(url)
        {
            window.top.content.location = url;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="cssmenu">
        <ul>
           <li class="active"><a href="#">MAIN MENU</a></li>
           <li><a href="javascript:change2Menu('ListTour.aspx')">Tournament List</a></li>
           <li><a href="javascript:change2Menu('AddTournament.aspx')">Add New</a></li>
        </ul>
    </div>
    </form>

</body>
</html>

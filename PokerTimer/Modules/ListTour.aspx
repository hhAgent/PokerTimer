<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListTour.aspx.cs" Inherits="PokerTimer.ListTour" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        .tourline {
            text-align: center;
            font-size: 30px;
            padding-top: 30px;
        }
    </style>
    <script>
        function GetTournament(id)
        {
            window.top.location = "../TournamentPage.aspx?id=" + id;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="menu" runat="server">
    </div>
    </form>
</body>
</html>

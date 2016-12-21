<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTournament.aspx.cs" Inherits="PokerTimer.AddTournament" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New tournament</title>
    <style>
    @import "http://fonts.googleapis.com/css?family=Montserrat:300,400,700";
    .rwd-table {
      margin: 1em 0;
      min-width: 300px;
      border-collapse: collapse;
    }
    .rwd-table tr {
      border-top: 1px solid #ddd;
      border-bottom: 1px solid #ddd;
    }
    .rwd-table th {
      display: none;
    }
    .rwd-table td {
      display: block;
    }
    .rwd-table td:first-child {
      padding-top: .5em;
    }
    .rwd-table td:last-child {
      padding-bottom: .5em;
    }
    .rwd-table td:before {
      content: attr(data-th) ": ";
      font-weight: bold;
      width: 6.5em;
      display: inline-block;
    }
    @media (min-width: 480px) {
      .rwd-table td:before {
        display: none;
      }
    }
    table td
    {
        vertical-align: top;
    }
    .rwd-table th, .rwd-table td {
      text-align: left;
    }
    @media (min-width: 480px) {
      .rwd-table th, .rwd-table td {
        display: table-cell;
        padding: .25em .5em;
      }
      .rwd-table th:first-child, .rwd-table td:first-child {
        padding-left: 0;
      }
      .rwd-table th:last-child, .rwd-table td:last-child {
        padding-right: 0;
      }
    }

    body {
      padding: 0 2em;
      font-family: Montserrat, sans-serif;
      -webkit-font-smoothing: antialiased;
      text-rendering: optimizeLegibility;
      color: #444;
      background: #eee;
    }

    h1 {
      font-weight: normal;
      letter-spacing: -1px;
      color: #34495E;
    }

    .rwd-table {
      background: #ce4c4a;
      color: #fff;
      border-radius: .4em;
      overflow: hidden;
    }
    .rwd-table input
    {
        height: 30px;
        padding: 0px;
        text-align: right;
        font-size: 15px;
    }
    .rwd-table tr {
      border-color: #6089b1;
    }
    .rwd-table tr:hover {
      background-color:#e26f84;
    }
    .rwd-table th, .rwd-table td {
      margin: .5em 1em;
    }
    @media (min-width: 480px) {
      .rwd-table th, .rwd-table td {
        padding-left: 1em !important;
        padding-right: 1em !important;
        padding-top: 8px !important;
        padding-bottom: 8px !important;
      }
    }
    .rwd-table th, .rwd-table td:before {
      color: #dd5;
    }
    .rwd-table td{
        padding:0px;
        vertical-align: middle;
    }
    #blind-schedule td
    {
        text-align:center;
    }
    #blind-schedule input{
        width:60px;
        text-align: center;
    }

    .myButton {
	    -moz-box-shadow:inset 0px 1px 3px 0px #91b8b3;
	    -webkit-box-shadow:inset 0px 1px 3px 0px #91b8b3;
	    box-shadow:inset 0px 1px 3px 0px #91b8b3;
	    background:-webkit-gradient(linear, left top, left bottom, color-stop(0.05, #768d87), color-stop(1, #6c7c7c));
	    background:-moz-linear-gradient(top, #768d87 5%, #6c7c7c 100%);
	    background:-webkit-linear-gradient(top, #768d87 5%, #6c7c7c 100%);
	    background:-o-linear-gradient(top, #768d87 5%, #6c7c7c 100%);
	    background:-ms-linear-gradient(top, #768d87 5%, #6c7c7c 100%);
	    background:linear-gradient(to bottom, #768d87 5%, #6c7c7c 100%);
	    filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#768d87', endColorstr='#6c7c7c',GradientType=0);
	    background-color:#768d87;
	    -moz-border-radius:5px;
	    -webkit-border-radius:5px;
	    border-radius:5px;
	    border:1px solid #566963;
	    display:block;
        text-align:left;
	    cursor:pointer;
	    color:#ffffff;
	    font-family:Arial;
	    font-size:15px;
	    font-weight:bold;
	    padding:11px 23px;
	    text-decoration:none;
	    text-shadow:0px -1px 0px #2b665e;
        width: 100px;
        text-align: center;
    }
    .myButton:hover {
	    background:-webkit-gradient(linear, left top, left bottom, color-stop(0.05, #6c7c7c), color-stop(1, #768d87));
	    background:-moz-linear-gradient(top, #6c7c7c 5%, #768d87 100%);
	    background:-webkit-linear-gradient(top, #6c7c7c 5%, #768d87 100%);
	    background:-o-linear-gradient(top, #6c7c7c 5%, #768d87 100%);
	    background:-ms-linear-gradient(top, #6c7c7c 5%, #768d87 100%);
	    background:linear-gradient(to bottom, #6c7c7c 5%, #768d87 100%);
	    filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#6c7c7c', endColorstr='#768d87',GradientType=0);
	    background-color:#6c7c7c;
    }
    .myButton:active {
	    position:relative;
	    top:1px;
    }
    </style>
    <script style="text/javascript">
        function isInt(value) {
            return !isNaN(value) &&
                   parseInt(Number(value)) == value &&
                   !isNaN(parseInt(value, 10));
        }

        function validateTotalOfLevels()
        {
            var data = document.getElementById("txtTotalOfLevels").value;
            if (!isInt(data)) 
            {
                alert("Tổng level không phải là số");
                document.getElementById("txtTotalOfLevels").value = "";
                document.getElementById("txtTotalOfLevels").focus();
                return;
            }
            var value = parseInt(data, 10);
            if (value < 0 || value > 50)
            {
                alert("Giá trị tổng level trong khoảng [0, 50]");
                document.getElementById("txtTotalOfLevels").focus();
                return;
            }
            document.getElementById("blindScheduleContent").innerHTML = "";
            var i;
            for (i = 0; i < value; i++)
            {
                document.getElementById("blindScheduleContent").innerHTML += '<tr><td>' + (i + 1) +
                    '</td><td><input name="small_' + i + '" id="small_' + i + '" value="5000"/></td><td><input name="big_' + i + '" id="big_' + i + '" value="10000"/></td><td><input name="ante_' + i + '" id="ante_' + i + '" value="1000"/></td><td name="length_' + i + '" id="length_' + i + '">6</td></tr>';
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <center>
    
    <div>
        <table style="text-align:center;">
            <tr>
                <td colspan="2">
                    <asp:Button CssClass="myButton" runat="server" ID="btnSubmit" Text="Submit"/>
                </td>
            </tr>
            <tr>
                <td>                
                    <div>General Infomation</div>
                    <table class="rwd-table">
                        <tr>
                            <td>Name</td>
                            <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Starting chips</td>
                            <td><asp:TextBox ID="txtStartingChips" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Rebuy</td>
                            <td><asp:TextBox ID="txtRebuy" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Addon</td>
                            <td><asp:TextBox ID="txtAddon" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Starting time</td>
                            <td><asp:TextBox ID="txtStartingTime" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Total of levels</td>
                            <td><asp:TextBox ID="txtTotalOfLevels" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Level time length</td>
                            <td><asp:TextBox ID="txtLevelTimeLength" runat="server"></asp:TextBox> &nbsp;minutes</td>
                        </tr>
                        <tr>
                            <td>Break after</td>
                            <td><asp:TextBox ID="txtBreakLevelRange" runat="server"></asp:TextBox> &nbsp;levels</td>
                        </tr>
                        <tr>
                            <td>Break time</td>
                            <td><asp:TextBox ID="txtBreakTime" runat="server"></asp:TextBox> &nbsp;minutes</td>
                        </tr>
                    </table>
                </td>
                <td>
                    <div>Blind Schedule</div>
                    <table class="rwd-table" id="blind-schedule" style="margin-left: 20px;">
                        <tr>
                            <th>Level</th>
                            <th>Small</th>
                            <th>Big</th>
                            <th>Ante</th>
                            <th>Length</th>
                        </tr>
                        <tbody id="blindScheduleContent" runat="server">
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </center>
    </form>
</body>
</html>

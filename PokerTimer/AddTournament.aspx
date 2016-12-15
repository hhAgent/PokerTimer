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
      background: #34495E;
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
      border-color: #46637f;
    }
    .rwd-table th, .rwd-table td {
      margin: .5em 1em;
    }
    @media (min-width: 480px) {
      .rwd-table th, .rwd-table td {
        padding: 1em !important;
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
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="text-align:center;">
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
                            <td><asp:TextBox ID="txtLevelTimeLength" runat="server"></asp:TextBox></td>
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
                    <table class="rwd-table" id="blind-schedule">
                        <tr>
                            <th>Level</th>
                            <th>Small</th>
                            <th>Big</th>
                            <th>Ante</th>
                            <th>Length</th>
                        </tr>
                        <tr>
                            <td>1</td>
                            <td><input value="5000"/></td>
                            <td><input value="10000"/></td>
                            <td><input value="1000"/></td>
                            <td>6</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

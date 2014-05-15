<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintICard.aspx.cs" Inherits="SI_PrintICard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print I Card</title>
    <script type="text/javascript">
        window.print();
    </script>
    <style>
        table, th, tr {
            border-collapse: collapse;
            text-align: center;
            font-size: 22px;
        }

        h3 {
            background-color: black;
            color: white;
            text-align: center;
            margin-top: 4px;
            width: 552px;
            margin-left: -1px;
        }

        .img1 {
            width: 550px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container" style="width: 1500px; height: 500px; margin: auto;">
            <div style="border: 1px solid black; width: 550px; height: 282px; float: left; margin-left: 8%; margin-top: 50px;">
                <img class="img1" alt="Tech Trishna Header" src="../Images/ems_header.jpg" /><br />
                <br />
                <table style="margin: auto;">
                    <tr>
                        <th>Name:</th>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <th>College:</th>
                        <td>
                            <asp:Label ID="lblCollege" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <th>Branch:</th>
                        <td>
                            <asp:Label ID="lblBranch" runat="server" Text=""></asp:Label></td>
                        <td><b>TTID:<asp:Label ID="lblTTID" runat="server" Text=""></asp:Label>
                        </b></td>
                    </tr>
                    <tr>
                        <th>Year:</th>
                        <td>
                            <asp:Label ID="lblYear" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <th>Contact:</th>
                        <td>
                            <asp:Label ID="lblContact" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
                <h3>Ajay Kumar Garg Engineering College</h3>
            </div>
        </div>
    </form>
</body>
</html>

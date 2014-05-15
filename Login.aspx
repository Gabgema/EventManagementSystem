<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Management System - TechTrishna 14</title>
    <link href="Stylesheets/style-main.css" rel="stylesheet" />
    <style type="text/css">
        #lblResult {
            color: #E11156;
            font-weight: 100;
            font-size:4em;
            font-family: "wf_SegoeUILight","wf_SegoeUI","Segoe UI Light","Segoe WP Light","Segoe UI","Segoe","Segoe WP","Tahoma","Verdana","Arial","sans-serif";
        }
   
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <header>
                <h1>Event Management System</h1>
            </header>
            <section class="content-login">
                <asp:TextBox ID="txtbxUsername" placeholder="Username" runat="server" autofocus></asp:TextBox><br />
                <asp:TextBox ID="txtbxPassword" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox><br />
                <asp:Button CssClass="button" Style="width: 105%;" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /><br />
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </section>
        </div>
        <footer>
            <img src="Images/SI%20FINALEST%20LOGO.png" alt="Software Incubator" />
        </footer>
    </form>
</body>
</html>

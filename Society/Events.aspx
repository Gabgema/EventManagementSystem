<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Events.aspx.cs" Inherits="Society_Events" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Stylesheets/style-socities.css" rel="stylesheet" />
    <style type="text/css">
        #lblSocietyName {
            margin: 0;
            font-size: 50px;
            color: #E11156;
            width: 400px;
            float: left;
            font-weight: 100;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Event Management System</h1>
            <asp:LinkButton ID="lnkbtnLogout" CssClass="btnlogout" OnClick="lnkbtnLogout_Click" Text="Logout" runat="server"></asp:LinkButton>
        </header>
        <section class="content">
            <div class="content-header">
                <h2>
                    <asp:Label ID="lblSocietyName" runat="server" Text=""></asp:Label></h2>
            </div>
            <span>Please Select an Event.</span>
            <asp:Repeater ID="rptrEvents" runat="server" OnItemCommand="rptrEvents_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton Style="text-decoration: none; color: white;" ID="lnkbtnEvent" CommandArgument='<%# Eval("ID") %>' runat="server">
                        <div class="Events"><%# Eval("Name") %></div>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </section>
        <footer>
            <img src="../Images/SI%20FINALEST%20LOGO.png" alt="Software Incubator" />
        </footer>
    </form>
</body>
</html>

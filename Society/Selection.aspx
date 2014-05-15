<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Selection.aspx.cs" Inherits="Society_Selection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Stylesheets/style-socities.css" rel="stylesheet" />
    <style type="text/css">
        #lblEventName {
            margin: 0;
            font-size: 50px;
            color: #E11156;
            width: 400px;
            float: left;
            font-weight: 100;
        }

        .content{
            min-height:700px;
            height:auto;
        }

        a {
            text-decoration: none;
            color: white;
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
                    <asp:Label ID="lblEventName" runat="server" Text=""></asp:Label></h2>
                <article>
                    <i>This is a
                    <asp:Label Font-Size="16px" ID="lblEventType" runat="server"></asp:Label>
                    </i>
                </article>
            </div>
            <a href="Events.aspx" style="text-decoration: none;">
                <div class="prev">&larr;</div>
            </a>
            <span>Please Select An Option.</span>
            <div id="leftContent" style="float: left; width: 400px;">
                <a href="EventRegistration.aspx">
                    <div class="Events">New Registration</div>
                </a>
                <a href="Promotion.aspx">
                    <div class="Events">Promotion</div>
                </a>
                <asp:Panel runat="server" ID="pnlUpdation">
                    <a href="Updation.aspx">
                        <div class="Events">Updation</div>
                    </a>
                </asp:Panel>
            </div>
            <div id="rightContent" style="float:left;width:496px;margin-left:100px;">
                <iframe style="border:none;width:100%;height:500px;" src="Participation.aspx"></iframe>
            </div>
        </section>
        <footer>
            <img src="../Images/SI%20FINALEST%20LOGO.png" alt="Software Incubator" />
        </footer>
    </form>
</body>
</html>

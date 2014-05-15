<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterOrganiser.aspx.cs" Inherits="RegisterOrganiser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EMS 3.0</title>
    <link href="Stylesheets/style-socities.css" rel="stylesheet" />
    <style type="text/css">
        #lblResult {
            color: #E11156;
            font-weight: 100;
            font-size: 4em;
            font-family: "wf_SegoeUILight","wf_SegoeUI","Segoe UI Light","Segoe WP Light","Segoe UI","Segoe","Segoe WP","Tahoma","Verdana","Arial","sans-serif";
        }
         .content
        {
            min-height:650px;
            height:auto;
        }
        .content input[type="text"],.content input[type="password"] {
            width: 96%;
        }

        .button {
            width: 98%;
        }
        select
        {
            width:97.5%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <header>
                    <h1>Event Management System</h1>
                </header>
                <section class="content">
                    <div class="content-header">
                       <h2 style="width:500px;">Register New Organiser</h2>
                    </div>                    
                    <span>Please enter the details below.</span>                    
                            <asp:TextBox ID="txtbxName" placeholder="Enter Your Name" runat="server"></asp:TextBox>                       
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtbxName" ErrorMessage="*"></asp:RequiredFieldValidator>                     
                            <asp:TextBox ID="txtbxUsername" placeholder="Enter Your Username" runat="server"></asp:TextBox>                       
                            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtbxUsername" ErrorMessage="*"></asp:RequiredFieldValidator>                        
                            <asp:TextBox ID="txtbxPassword" placeholder="Enter Your Password" TextMode="Password" runat="server"></asp:TextBox>                        
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtbxPassword" ErrorMessage="*"></asp:RequiredFieldValidator>                        
                            <asp:DropDownList ID="drpdwnlstSocieties" DataTextField="Name" DataValueField="ID" runat="server"></asp:DropDownList>                      
                            <asp:Button ID="btnRegister" CssClass="button" OnClick="btnRegister_Click" runat="server" Text="Register" />                       
                            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>                        
                </section>
                <footer>
                    <img src="../Images/SI%20FINALEST%20LOGO.png" alt="Software Incubator" />
                </footer>                             
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

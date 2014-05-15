<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Promotion.aspx.cs" Inherits="Society_Promotion" %>

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

        .content {
            min-height: 650px;
            height: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div style="background-color: black; opacity: 0.5; width: 100%; height: 100%; z-index: 200; position: absolute; margin: 0; top: 0%; left: 0%;">
                    <img style="top: 36%; position: absolute; left: 46%" src="../Images/ajax-loader.gif" alt="Loading..." />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <header>
            <h1>Event Management System</h1>
            <asp:LinkButton ID="lnkbtnLogout" CssClass="btnlogout" OnClick="lnkbtnLogout_Click" Text="Logout" runat="server"></asp:LinkButton>
        </header>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
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
                    <a href="Selection.aspx" style="text-decoration: none;">
                        <div class="prev">&larr;</div>
                    </a>
                    <span>Please Select the
                <asp:Label ID="lblIDType" runat="server"></asp:Label></span>
                    <div id="leftContent" style="float: left; width: 400px;">
                        <asp:GridView ID="grdvwPromotion" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkbxParticipantID" Checked="false" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Team ID" DataField="TeamID" SortExpression="TeamID" />
                                <asp:BoundField HeaderText="TT ID" DataField="TTID" SortExpression="TTID" />
                                <asp:BoundField HeaderText="Current Level" DataField="CurrentLevel" SortExpression="CurrentLevel" />
                            </Columns>
                        </asp:GridView>
                        <asp:Button Text="" CssClass="button" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                        <asp:Label Text="" ID="lblResult" runat="server" />
                    </div>
                    <div id="rightContent" style="float: left; width: 496px; margin-left: 100px;">
                        <iframe style="border: none; width: 100%; height: 500px;" src="Participation.aspx"></iframe>
                    </div>
                </section>
            </ContentTemplate>
        </asp:UpdatePanel>
        <footer>
            <img src="../Images/SI%20FINALEST%20LOGO.png" alt="Software Incubator" />
        </footer>
    </form>
</body>
</html>

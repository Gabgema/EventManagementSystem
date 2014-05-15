<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewReports.aspx.cs" Inherits="SI_ViewReports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table {
            width: 100%;
        }

        img {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table id="tblReportHeader" runat="server">
            <tr>
                <td colspan="2">
                    <img src="../Images/ems_header.jpg" width="550" alt="Techtrishna 2014" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblLeft" runat="server" Visible="false"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblCenter" runat="server" Visible="false"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            <asp:Label ID="lblRight" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:GridView ID="grdvwReport" runat="server">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>S.NO.</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblSno" Font-Size="18px" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table runat="server" id="tblSpace">
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
        <table runat="server" id="tblFooterReport">
            <tr>
                <td colspan="2">Signature</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td colspan="2">Signature</td>
                <td></td>
            </tr>
            <tr>
                <td colspan="2">Organiser Techtrishna 2014</td>
                <td></td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td colspan="2">Event Organiser</td>
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>

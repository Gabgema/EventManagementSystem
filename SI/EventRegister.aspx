<%@ Page Title="" Language="C#" MasterPageFile="~/SI/MasterPage.master" AutoEventWireup="true" CodeFile="EventRegister.aspx.cs" Inherits="SI_EventRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .content input[type="text"] {
            width: 50%;
        }
    </style>
    <script src="../Scripts/jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.panel :checkbox').each(function () {
                $(this).change(function () {
                    if ($(this).is(":checked")) {
                        $(this).parent().find('span').each(function () {
                            $(this).css("display", "inline");
                        });
                        $(this).parent().find(':text').each(function () {
                            $(this).css("display", "inline");
                        });
                    }
                    else {
                        $(this).parent().find('span').each(function () {
                            $(this).css("display", "none");
                        });
                        $(this).parent().find(':text').each(function () {
                            $(this).css("display", "none");
                        });
                    }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <a href="Home.aspx" style="text-decoration: none;">
        <div class="prev">&larr;</div>
    </a>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlEvents" runat="server"></asp:Panel>
            <asp:Button ID="btnRegister" runat="server" CssClass="button" OnClick="btnRegister_Click" Text="Register" />
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


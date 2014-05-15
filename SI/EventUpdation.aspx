<%@ Page Title="" Language="C#" MasterPageFile="~/SI/MasterPage.master" AutoEventWireup="true" CodeFile="EventUpdation.aspx.cs" Inherits="SI_EventUpdation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <a href="Home.aspx" style="text-decoration: none;">
        <div class="prev">&larr;</div>
    </a>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <span>Please Enter the Team ID below.</span>
            <asp:TextBox runat="server" placeholder="Team ID" required autofocus ID="txtbxTeamID" /><asp:RegularExpressionValidator ControlToValidate="txtbxTeamID" ValidationExpression="\d{4}" ID="revTeamID" runat="server" ErrorMessage="*"></asp:RegularExpressionValidator>
            <asp:Button Text="Submit" CssClass="button" OnClick="btnSubmit_Click" ID="btnSubmit" runat="server" />
            <asp:Panel runat="server" ID="pnlTxtBx">
            </asp:Panel>
            <asp:Button Text="Update" CssClass="button" ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" />
            <asp:Label Text="" ID="lblResult" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


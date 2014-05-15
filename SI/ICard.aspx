<%@ Page Title="" Language="C#" MasterPageFile="~/SI/MasterPage.master" AutoEventWireup="true" CodeFile="ICard.aspx.cs" Inherits="SI_ICard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <style type="text/css">
        .content input[type="text"]
        {
            width:96%;
        }
        .button{
            width:98%;
        }
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <a href="Home.aspx" style="text-decoration: none;">
                <div class="prev">&larr;</div>
            </a>
    <span>Enter the details below.</span> 
    <asp:TextBox ID="txtbxTTID" runat="server" Text="" placeholder="Enter TT ID" />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtbxTTID" ValidationExpression="\d{4}" ErrorMessage="*"></asp:RegularExpressionValidator>
    OR<br />
    <asp:TextBox ID="txtbxEmail" runat="server" placeholder="Enter Email ID"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtbxEmail" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <asp:Button ID="btnGenerateICard" runat="server" Text="GenerateICard" OnClick="btnGenerateICard_Click" CssClass="button" />
    <asp:Label ID="lblResult" runat="server"></asp:Label>
</asp:Content>


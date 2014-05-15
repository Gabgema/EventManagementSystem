<%@ Page Title="" Language="C#" MasterPageFile="~/SI/MasterPage.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="SI_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .content {
            min-height: 2354px;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <a href="Home.aspx" style="text-decoration: none;">
        <div class="prev">&larr;</div>
    </a>
    <span>Select Report Type</span>
    <asp:DropDownList ID="drpdwnlstReportType" OnSelectedIndexChanged="drpdwnlstReportType_SelectedIndexChanged" AutoPostBack="true" runat="server">
        <asp:ListItem Value="1" Text="Event Report" Selected="True"></asp:ListItem>
        <asp:ListItem Value="2" Text="Techtrishna Report"></asp:ListItem>
    </asp:DropDownList>
    <asp:Panel runat="server" ID="pnlEventReport">
        <span>Please Select an event from below.</span>
        <div id="leftContent" style="float: left; width: 400px;">
            <asp:Repeater ID="rptrEvents" runat="server" OnItemCommand="rptrEvents_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton Style="text-decoration: none; color: white;" ID="lnkbtnEvent" CommandArgument='<%# Eval("ID") %>' runat="server">
                        <div class="Events"><%# Eval("Name") %></div>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div id="rightContent" style="float: right; width: 500px; margin-left: 100px;">
            <asp:Panel ID="pnlReport" runat="server">
                <asp:Label ID="lblEventName" runat="server"></asp:Label>
                <span>Select Level</span>
                <asp:DropDownList ID="drpdwnlstLevel" AutoPostBack="true" OnSelectedIndexChanged="drpdwnlstLevel_SelectedIndexChanged" runat="server"></asp:DropDownList>
                <%--<asp:Button ID="btnPDF" runat="server" Text="Save as PDF" CssClass="button" OnClick="btnPDF_Click" />--%>
                <asp:LinkButton ID="lnkbtnPrint" CssClass="button" target="_blank"  OnClick="lnkbtnPrint_Click" runat="server">Print</asp:LinkButton>               
                <iframe runat="server" id="frameReport" style="border:none;width:100%;height:600px;"></iframe>    
            </asp:Panel>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlTechtrishnaReport" Visible="false">
      <span>Group By : </span>
       <asp:CheckBoxList ID ="cblGroupBy" runat="server"></asp:CheckBoxList>
        <asp:GridView ID="gvTTReport" runat="server"></asp:GridView>
        <span></span>
    </asp:Panel>
</asp:Content>


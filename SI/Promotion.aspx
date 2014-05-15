<%@ Page Title="" Language="C#" MasterPageFile="~/SI/MasterPage.master" AutoEventWireup="true" CodeFile="Promotion.aspx.cs" Inherits="SI_Promotion" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                <asp:Label ID="lblEventName" runat="server"></asp:Label>
                <asp:GridView ID="grdvwPromotion" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkbxParticipantID" Checked="false" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Team ID" DataField="TeamID" />
                        <asp:BoundField HeaderText="TT ID" DataField="TTID" />
                        <asp:BoundField HeaderText="Current Level" DataField="CurrentLevel" />
                    </Columns>
                </asp:GridView>
                <asp:Button Text="" CssClass="button" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                <asp:Label Text="" ID="lblResult" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>


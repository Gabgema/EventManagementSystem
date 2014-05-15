<%@ Page Title="" Language="C#" MasterPageFile="~/SI/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="SI_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        #lblResult {
            color: #E11156;
            font-weight: 100;
            font-size: 4em;
            font-family: "wf_SegoeUILight","wf_SegoeUI","Segoe UI Light","Segoe WP Light","Segoe UI","Segoe","Segoe WP","Tahoma","Verdana","Arial","sans-serif";
        }

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <a href="Home.aspx" style="text-decoration: none;">
        <div class="prev">&larr;</div>
    </a>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <span>Please Fill out the details.</span>
            <table id="TableRegister" runat="server">
                <tr>
                    <td>
                        <asp:DropDownList CssClass="tip" ToolTip="Select Your College" ID="DDLCollege" AutoPostBack="true" OnSelectedIndexChanged="DDLCollege_SelectedIndexChanged" DataTextField="CollegeName" DataValueField="CollegeID" AppendDataBoundItems="true" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr runat="server" id="RowCollege" visible="false">
                    <td>
                        <asp:TextBox CssClass="tip" ID="TxtBxCollege" ToolTip="Enter your college name" placeholder="Your College Name" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate="TxtBxCollege" ID="RFVCollege" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr runat="server" id="RowStudentNo">
                    <td>
                        <asp:TextBox CssClass="tip" ID="TxtBxStudentNo" ToolTip="Enter Your Student Number" placeholder="Student Number" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RFVStudentNo" runat="server" ControlToValidate="TxtBxStudentNo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REVStudentNo" runat="server" ControlToValidate="TxtBxStudentNo" ValidationExpression="\d{7}[d|D]?" ErrorMessage="*"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Button ValidationGroup="nothing" CssClass="button" ID="btnGetStudentData" OnClick="btnGetStudentData_Click" runat="server" Text="Check" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TxtBxName" ToolTip="Enter Your Name" placeholder="Name" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RFVName" runat="server" ControlToValidate="TxtBxName" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TxtBxEmail" ToolTip="Enter Your Email" placeholder="Email" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RFVEmail" ControlToValidate="TxtBxEmail" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REVEmail" ControlToValidate="TxtBxEmail" runat="server" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TxtBxContactNo" ToolTip="Enter 10 digit Contact Number" placeholder="Contact Number" Text="" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="REVContactNo" runat="server" ValidationExpression="[7|8|9]\d{9}" ControlToValidate="TxtBxContactNo" ErrorMessage="*"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RFVContactNo" ControlToValidate="TxtBxContactNo" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TxtBxPartnerID" ToolTip="Enter Partner ID like TT1234" placeholder="Partner ID like TT1234" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="REVPartnerID" ValidationExpression="[T|t][T|t]\d{4}" ControlToValidate="TxtBxPartnerID" runat="server" ErrorMessage="*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Gender
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButtonList ToolTip="Select Your Gender" ID="RBLGender" RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem Text="Male" Selected="True" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>Branch
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="DDLBranch_SelectedIndexChanged" ToolTip="Select Your Branch" ID="DDLBranch" DataTextField="BranchName" DataValueField="BranchID" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Year</td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ToolTip="Select Your Year" ID="DDLYear" runat="server">
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ToolTip="Do you want T-Shirt?" ID="CBWantTShirt" Text="Want T-Shirt ?" runat="server" />
                    </td>
                </tr>
                <tr runat="server" id="RowAccomodation" visible="false">
                    <td>
                        <asp:CheckBox ToolTip="Do you want Accomodation?" ID="CBWantAccomodation" Text="Want Accomodation ?" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BtnRegister" CssClass="button" OnClick="BtnRegister_Click" runat="server" Text="Register" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblResult" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


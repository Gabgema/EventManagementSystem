﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventRegistration.aspx.cs" Inherits="Society_EventRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Stylesheets/style-socities.css" rel="stylesheet" />
    <style type="text/css">
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
            min-height: 750px;
            height: auto;
        }

            .content input[type="text"] {
                width: 93%;
            }

        .button {
            width: 99%;
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
                    <span>Please Enter TTID's below.</span>
                    <div id="leftContent">
                        <asp:Panel runat="server" ID="pnlTxtBx">
                        </asp:Panel>
                        <asp:Button Text="Submit" CssClass="button" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                        <asp:Label Text="" ID="lblResult" runat="server" />
                    </div>
                    <div id="rightContent" style="width: 496px;">
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

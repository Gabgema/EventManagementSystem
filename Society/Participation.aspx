<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Participation.aspx.cs" Inherits="Society_Participation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: "wf_SegoeUILight","wf_SegoeUI","Segoe UI Light","Segoe WP Light","Segoe UI","Segoe","Segoe WP","Tahoma","Verdana","Arial","sans-serif";
        }
    </style>
    <script type="text/javascript">
        setTimeout("location.reload(true);", 300000);
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblNumberOfParticipants" runat="server" Text=""></asp:Label>
                <asp:GridView ID="GridView1" runat="server">                    
                </asp:GridView>
    </form>
</body>
</html>

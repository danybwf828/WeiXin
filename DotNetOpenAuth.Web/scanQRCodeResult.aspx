<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="scanQRCodeResult.aspx.cs" Inherits="DotNetOpenAuth.Web.scanQRCodeResult" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>   
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 37px;
        }
        .auto-style3 {
            height: 40%;
        }
        .auto-style4 {
            height: 229px;
        }
    </style>
</head>
<body> 
    <form id="form1" runat="server">
    <div>
        <table class="auto-style1">
            <tr>
                <td colspan="2" class="auto-style3" >
                    </td>
            </tr>
            <tr>
                <td align="right" class="auto-style4">
                </td>
                <td class="auto-style4">
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="35px" Text="会议主题："></asp:Label>
                </td>
                <td>
        <asp:Label ID="Label6" runat="server" Font-Size="35px" Text="Label" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="35px" Text="扫描人："></asp:Label>
                </td>
                <td>
        <asp:Label ID="Label1" runat="server" Font-Size="35px" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="35px" Text="扫描时间："></asp:Label>
                </td>
                <td class="auto-style2">
        <asp:Label ID="Label4" runat="server" Font-Size="35px" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="60px" Height="150px" OnClick="Button1_Click" Text="确认签到" Width="451px" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
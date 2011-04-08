<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Test_Send_Mail.aspx.vb" Inherits="Test_Send_Mail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
 
    <style type="text/css">
        .style1
        {
            width: 42%;
        }
        .style2
        {
            width: 42%;
            height: 35px;
        }
        .style3
        {
            width: 100%;
            height: 35px;
        }
        .style4
        {
            width: 42%;
            height: 37px;
        }
        .style5
        {
            width: 100%;
            height: 37px;
        }
        .style6
        {
            width: 42%;
            height: 39px;
        }
        .style7
        {
            width: 100%;
            height: 39px;
        }
    </style>
 
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table cellpadding="0" style="width:100%">
            <tr>
                <td align="center" class="style1">
                    &nbsp;</td>
                <td align="center" style="width:100%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    Subject :&nbsp;&nbsp; </td>
                <td align="left" class="style3">
                    <asp:TextBox ID="txtSubject" runat="server" Height="24px" Width="283px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    To :&nbsp;&nbsp; </td>
                <td align="left" class="style3">
                    <asp:TextBox ID="txtTo" runat="server" Height="24px" Width="283px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style4">
                    CC :&nbsp;&nbsp; </td>
                <td align="left" class="style5">
                    <asp:TextBox ID="txtCC" runat="server" Height="24px" Width="283px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" class="style6">
                    </td>
                <td align="left" class="style7">
                    <asp:Button ID="btnSendMail" runat="server" Text="Send Mail" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

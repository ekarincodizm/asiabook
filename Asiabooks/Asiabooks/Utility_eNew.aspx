<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Utility_eNew.aspx.vb" Inherits="Utility_eNew" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Asiabooks.Com - eNew</title>
    <link href="App_Themes/page.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=windows-874">
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <table width="600" border="0" align="center" cellpadding="0" cellspacing="0" class="page">
            <tr>
                <td style="width:30px; height:22px;"></td>
                <td style="width:565px">&nbsp;</td>
                <td style="width:31px;"></td>
            </tr>
            <tr>
                <td></td>
                <td>
                <a href="https://www.asiabooks.com/StoreDetail.aspx?ID=20">
                <asp:Image runat="server" ID="ImagePromotion" ImageUrl="https://www.asiabooks.com/images/Asiabooks/Promotion/eNewChildren_570x470.jpg" width="570px" Height="470px"/></a></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td style="height:7px">&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            <a href="https://www.asiabooks.com/StoreDetail.aspx?ID=21">
                            <asp:Image runat="server" ID="ImageEven1" ImageUrl="https://www.asiabooks.com/images/Asiabooks/Promotion/eNew_Marketing30_250x345.jpg" width="250px" height="345px"/></a></td>
                            <td style="width:6px">&nbsp;</td>
                            <td>
                            <a href="https://www.asiabooks.com/StoreDetail.aspx?ID=22">
                            <asp:Image runat="server" ID="ImageEven2" ImageUrl="https://www.asiabooks.com/images/Asiabooks/Promotion/eNews_WEsale.jpg" width="310px" height="345px"/></a></td>
                        </tr>
                    </table></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td align="center"><img src="https://www.asiabooks.com/images/Asiabooks/ReadingTime/Footer_eNew.jpg" width="565px"/></td>
                <td></td>
            </tr>
        </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

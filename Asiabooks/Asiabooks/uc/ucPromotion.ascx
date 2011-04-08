<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucPromotion.ascx.vb" Inherits="uc_ucPromotion" %>
<%@ Register src="ucTop5.ascx" tagname="ucTop5" tagprefix="uc1" %>
<%@ Register src="ucShopping_Cart.ascx" tagname="ucShopping_Cart" tagprefix="uc2" %>
<table cellpadding="0" cellspacing="0" style="width: 201px">
<tr>
    <td align="center">
        <uc2:ucShopping_Cart ID="ucShopping_Cart1" runat="server" />
    </td>
</tr>
<tr>
    <td align="center">&nbsp;</td>
</tr>
<tr>
    <td align="center"><uc1:ucTop5 ID="ucTop51" runat="server" /></td>
</tr>
<tr>
    <td align="center">&nbsp;</td>
</tr>
<tr>
    <td align="center"><asp:ImageButton ID="imgBargain" runat="server" ImageUrl="~/images/Template/Bargain85.JPG" /></td>
</tr>
<tr>
    <td>&nbsp;</td>
</tr>
<tr>
    <td align="center"><asp:ImageButton ID="Image45" runat="server" ImageUrl="~/images/Template/ShockPrice.JPG" /></td>
</tr>
<tr>
    <td>
        &nbsp;</td>
</tr>
<tr>
    <td align="center"><asp:ImageButton ID="imgBook_Month" runat="server" ImageUrl="~/images/Template/BOM.jpg" /></td>
</tr>
<tr>
    <td>&nbsp;</td>
</tr>
</table>
<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucPromotion_eBooks.ascx.vb" Inherits="uc_ucPromotion_eBooks" %>
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
    <td align="center"><a href="Best_Value.aspx"><asp:Image ID="eBooks_Promotion_02" runat="server" ImageUrl="~/images/Template/eBooks_Promotion_02.jpg" /></a></td>
</tr>
<tr>
    <td>
        &nbsp;</td>
</tr>
<tr>
    <td align="center"><a href="Thailand_and_Regional.aspx"><asp:Image ID="eBooks_Promotion_03" runat="server" ImageUrl="~/images/Template/eBooks_Promotion_03.jpg" /></a></td>
</tr>
<tr>
    <td>&nbsp;</td>
</tr>
<tr>
    <td align="center"><a href="Support.aspx"><asp:Image ID="eBooks_Promotion_04" runat="server" ImageUrl="~/images/Template/eBooks_Promotion_04.jpg" /></a></td>
</tr>
<tr>
    <td>&nbsp;</td>
</tr>
    <tr>
    <td align="center"><a href="Privileges.aspx"><asp:Image ID="eBooks_Promotion_5" runat="server" 
            ImageUrl="~/images/Template/eBooks_Promotion_05.jpg" /></a></td>
    </tr>
<tr>
    <td>&nbsp;</td>
</tr>
    <tr>
    <td align="center"><a href="Store_Event.aspx"><asp:Image ID="eBooks_Promotion_6" runat="server" 
            ImageUrl="~/images/Template/eBooks_Promotion_06.jpg" /></a></td>
    </tr>
<tr>
    <td>&nbsp;</td>
</tr>
</table>
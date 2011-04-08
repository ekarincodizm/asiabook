<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucShopping_Cart.ascx.vb" Inherits="uc_ucShopping_Cart" %>
<asp:Panel ID="Panel1" runat="server">

 <table cellpadding="0" cellspacing="0" style="width: 201px">
    <tr>
        <td style="width: 201px" valign="top">
            <asp:Image ID="imgHead" runat="server" 
                ImageUrl="~/images/Template/bar_your_cart_value.gif" />
        </td>
    </tr>
    <tr>
        <td style="width: 201px; height: 83px; background-image: url('images/Template/bg_your_cart_value.gif');" 
            valign="top" align="center">
            <table cellpadding="0" cellspacing="0" style="width:100%">
                <tr>
                    <td align="left" 
                        style=" height:5px;"></td>
                    <td align="right" 
                        style=" height:5px;"></td>
                </tr>
                <tr>
                    <td align="left" 
                        style="font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #808080; height:17px;">
                        &nbsp;&nbsp; Total items in cart</td>
                    <td align="right" 
                        style="font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #2E9645; font-weight: bold; height:17px;">
                        <asp:Label ID="lbl_item" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" 
                        style="font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #808080; height:17px;">
                        &nbsp;&nbsp;&nbsp;Total QTY in cart</td>
                    <td align="right" 
                        style="font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #2E9645; font-weight: bold; height:17px;">
                        <asp:Label ID="lbl_qty" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" 
                        style="font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #808080; height:17px;">
                        &nbsp;&nbsp;&nbsp;Total value Bt.</td>
                    <td align="right" 
                        style="font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #2E9645; font-weight: bold; height:17px;">
                        <asp:Label ID="lbl_amount" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" 
                        style="width: 60%; font-family: arial, Helvetica, sans-serif; font-size: 8pt; color: #666666; height:15px;"></td>
                    <td align="right" 
                        
                        style="width: 40%; font-family: arial, Helvetica, sans-serif; font-size: 8pt; color: #FF6600; font-weight: normal; height:15px;">
                        <asp:Label ID="lbl_Price_US" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="width: 201px" valign="top" align="right">
        <asp:Image ID="imgSeemore" runat="server" 
                ImageUrl="~/images/Template/icon_arrow.gif" />&nbsp;<a href="../shoppingCart_Internet.aspx" runat="server" id="lnkMore" style="text-decoration:none;">See more..</a></td>
    </tr>
    </table>
</asp:Panel>


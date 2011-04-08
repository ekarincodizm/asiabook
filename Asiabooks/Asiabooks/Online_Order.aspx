<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Online_Order.aspx.vb" Inherits="Online_Order" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<a name="top"></a>
    <table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="center" style="width: 100%; height: 20px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="width: 100%; height: 20px;" class="header_other">
                Manual of Online Ordering</td>
        </tr>
        <tr>
            <td align="left" style="width: 100%; height: 27px;" class="font_other">
            We are delighted to be of service to our valuable customer like yourself. For your convenience, we offer you the following services : 
</td>
        </tr>
        <tr>
            <td align="center" style="width: 100%; height: 20px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" style="width: 100%; height: 20px;">
                <table bgcolor="#DDE7E4" cellpadding="0" cellspacing="0" style="width: 53%">
                    <tr>
                        <td align="left" style="width: 3%; height: 16px;">
                            &nbsp;</td>
                        <td align="left" style="width: 25%; height: 16px;">
                        </td>
                        <td align="left" style="width: 25%; height: 16px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 3%; height: 20px;">

                            &nbsp;</td>
                        <td align="left" style="width: 25%; height: 20px;">

                           <asp:Image ID="Image43" runat="server" 
                                ImageUrl="~/images/Asiabooks/arrow_or.gif" /> &nbsp;
                            <asp:LinkButton ID="lnkHowToOrder" runat="server">How to Order</asp:LinkButton>
                                                        </td>
                        <td align="left" style="width: 25%; height: 20px;">
                            <asp:Image ID="Image44" runat="server" 
                                ImageUrl="~/images/Asiabooks/arrow_or.gif" />&nbsp;
                            <asp:LinkButton ID="lnkHowtoShip" runat="server">How to Ship</asp:LinkButton>
                                                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 3%; height: 20px;">
                            &nbsp;</td>
                        <td align="left" style="width: 25%; height: 20px;">
                            <asp:Image ID="Image45" runat="server" 
                                ImageUrl="~/images/Asiabooks/arrow_or.gif" />&nbsp;
                            <asp:LinkButton ID="lnkHowtoPay" runat="server">How to Pay</asp:LinkButton>
                                                        </td>
                        <td align="left" style="width: 25%; height: 20px;">
                            <asp:Image ID="Image46" runat="server" 
                                ImageUrl="~/images/Asiabooks/arrow_or.gif" />&nbsp;
                            <asp:LinkButton ID="lnkHowtoTrack" runat="server">How to Track Your Order</asp:LinkButton>
                                                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 3%; height: 16px;">
                            &nbsp;</td>
                        <td align="left" style="width: 25%; height: 16px;">
                        </td>
                        <td align="left" style="width: 25%; height: 16px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 20px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%; height: 20px;">
                &nbsp;</td>
        </tr>
    </table>
    
    <table border="0" cellpadding="0" cellspacing="0" width="95%">
    <tr valign="top">
        <td rowspan="10" width="10">
            <img alt="" border="0" height="1" src="" width="10" /></td>
        <td width="95%">
            <table border="0" cellpadding="0" cellspacing="0" width="95%">
                <tr>
                    <td class="bkb_18" style="HEIGHT: 15px">
                        <strong><span style="FONT-SIZE: 10pt">How to Order</span></strong></td>
                </tr>
                <tr>
                    <td background="vid:3-3Asiabooks_com%20-%20The%20Bookshop%20Par%20Excellence%20-%20Welcome%20to%20Customer%20Service%20Department_files/dotdot_or.gif" 
                        height="1">
                    </td>
                </tr>
            </table>
            <table bgcolor="#f9f9f9" border="0" bordercolor="#cccccc" cellpadding="5" 
                cellspacing="0" width="95%">
                <tr>
                    <td class="bkb_18" colspan="2" height="10">
                    </td>
                </tr>
                <tr valign="top">
                    <td class="normalb" width="5%">
                        1.
                    </td>
                    <td width="95%">
                        Select your favorite title(s) and click <strong>ADD TO CART</strong>.</td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Image ID="Image1" runat="server" 
                            ImageUrl="~/images/Asiabooks/AddToCart.jpg" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr valign="top">
                    <td class="normalb">
                        2.</td>
                    <td>
                        To confirm order, Click Proceed Payment at the bottom of your Shopping Cart 
                        page.</td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Image ID="Image2" runat="server" 
                            ImageUrl="~/images/Asiabooks/CustomerOrder.jpg" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr valign="top">
                    <td class="normalb">
                        3.</td>
                    <td>
                        Please login if you already have an account with our website.
                        <br />
                        If you are a new customer, please fill in required information to create and 
                        account.</td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Image ID="Image3" runat="server" 
                            ImageUrl="~/images/Asiabooks/CustomerInformation.jpg" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr valign="top">
                    <td class="normalb">
                        4.</td>
                    <td>
                        To complete your order form, please select your <strong>shipping address, 
                        shipment method , billing address and payment method</strong> and then click
                        <strong>Confirm Order</strong>.</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table border="0" cellpadding="0" cellspacing="0" width="95%">
                            <tr>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1. Select Shipping Address</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Image ID="Image4" runat="server" 
                                        ImageUrl="~/images/Asiabooks/ShippingAddress.jpg" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2. Select Shipping Type</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Image ID="Image5" runat="server" 
                                        ImageUrl="~/images/Asiabooks/ShippingType.jpg" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3. Billing Address</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Image ID="Image6" runat="server" 
                                        ImageUrl="~/images/Asiabooks/BillingAddress.jpg" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4. Select Payment Method</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Image ID="Image7" runat="server" 
                                        ImageUrl="~/images/Asiabooks/Payment.jpg" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;5. Click PROCEED PAYMENT</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Image ID="Image8" runat="server" 
                                        ImageUrl="~/images/Asiabooks/ConfirmOrder.jpg" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
            </table>
            <p align="right">
                <a id="howtopay" name="howtopay"></a>&nbsp;<asp:Image ID="Image47" 
                    runat="server" ImageUrl="~/images/bullet_orB.gif" />
&nbsp;<asp:LinkButton ID="lnkTop1" runat="server">back to top</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
            </p>
            <table border="0" cellpadding="0" cellspacing="0" width="95%">
                <tr>
                    <td class="bkb_18">
                        <strong><span style="FONT-SIZE: 10pt">How to PAY</span></strong></td>
                </tr>
                <tr>
                    <td background="vid:3-3Asiabooks_com%20-%20The%20Bookshop%20Par%20Excellence%20-%20Welcome%20to%20Customer%20Service%20Department_files/dotdot_or.gif" 
                        height="1">
                    </td>
                </tr>
            </table>
            <table bgcolor="#f9f9f9" border="0" cellpadding="5" cellspacing="0" width="95%">
                <tr>
                    <td height="10">
                                    <asp:Image ID="Image51" runat="server" 
                                        ImageUrl="~/images/Asiabooks/HowToPay.jpg" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <p align="right">
                <a id="howtoship" name="howtoship"></a>
                <asp:Image ID="Image48" runat="server" ImageUrl="~/images/bullet_orB.gif" />
&nbsp;<asp:LinkButton ID="lnkTop2" runat="server">back to top</asp:LinkButton>
&nbsp;&nbsp;&nbsp;<br />
            </p>
            <table border="0" cellpadding="0" cellspacing="0" width="95%">
                <tr>
                    <td class="bkb_18">
                        <strong><span style="FONT-SIZE: 10pt">How to SHIP </span></strong>
                    </td>
                </tr>
                <tr>
                    <td background="vid:3-3Asiabooks_com%20-%20The%20Bookshop%20Par%20Excellence%20-%20Welcome%20to%20Customer%20Service%20Department_files/dotdot_or.gif" 
                        height="1">
                    </td>
                </tr>
            </table>
            <table bgcolor="#f9f9f9" border="0" cellpadding="5" cellspacing="0" width="95%">
                <tr valign="top">
                    <td valign="top">
                        <table border="0" cellpadding="0" cellspacing="7" width="95%">
                            <tr valign="top">
                                <td width="95%">
                                    <span class="orangeb">Priority Shipping </span>:
                                </td>
                            </tr>
                            <tr valign="top">
                                <td>
                                    <table cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td bgcolor="#dde7e4" colspan="2">
                                                <strong>Domestic address(es)</strong></td>
                                        </tr>
                                        <tr>
                                            <td valign="top" width="50">
                                                EMS :</td>
                                            <td width="500">
                                                - Delivery Time takes 2-4 days after stock availability and payment received.</td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                - We offer by hand delivery to your address in Bangkok using EMS rate.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#dde7e4" colspan="2">
                                                <strong>International address(es)</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                TNT :</td>
                                            <td>
                                                - Delivery Time takes 5-7 days after stock availability and payment received.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        &nbsp;* Shipping rate varies by shipping method and address.</td>
                </tr>
                <tr>
                    <td height="43">
                        &nbsp;</td>
                </tr>
            </table>
            <p align="right">
                <a id="howtotrack" name="howtotrack"></a>
                <asp:Image ID="Image49" runat="server" ImageUrl="~/images/bullet_orB.gif" />
&nbsp;<asp:LinkButton ID="lnkTop3" runat="server">back to top</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
            </p>
            <table border="0" cellpadding="0" cellspacing="0" width="95%">
                <tr>
                    <td class="bkb_18">
                        <strong><span style="FONT-SIZE: 10pt">How to Track Your Order</span></strong></td>
                </tr>
                <tr>
                    <td background="vid:3-3Asiabooks_com%20-%20The%20Bookshop%20Par%20Excellence%20-%20Welcome%20to%20Customer%20Service%20Department_files/dotdot_or.gif" 
                        height="1">
                    </td>
                </tr>
            </table>
            <table bgcolor="#f9f9f9" border="0" cellpadding="5" cellspacing="0" width="95%">
                <tr>
                    <td colspan="2" height="10">
                    </td>
                </tr>
                <tr valign="top">
                    <td class="normalb" valign="top" width="5%">
                        1.
                    </td>
                    <td width="95%">
                        Login to My Asia Books<br />
                        or goto : <a class="sbooktitle" href="https://www.asiabooks.com/member/login.asp">
                        https://www.asiabooks.com/member/login.asp</a></td>
                </tr>
                <tr valign="top">
                    <td class="normalb" valign="top">
                        2.</td>
                    <td>
                        Click at Purchasing History</td>
                </tr>
                <tr valign="top">
                    <td class="normalb" valign="top">
                        3.</td>
                    <td>
                        Choose Your Order No. and Click Tracking Link
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
            </table>
            <p align="right">
                <asp:Image ID="Image50" runat="server" ImageUrl="~/images/bullet_orB.gif" />
&nbsp;
                <asp:LinkButton ID="lnkTop4" runat="server">back to top</asp:LinkButton>
&nbsp;&nbsp; </p>
        </td>
    </tr>
</table>
</asp:Content>


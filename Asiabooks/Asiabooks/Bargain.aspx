<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Bargain.aspx.vb" Inherits="Bargain" title="Untitled Page" %>
<%@ Register src="uc/ucBooks.ascx" tagname="ucBooks" tagprefix="uc1" %>
<%@ Register src="uc/ucPromotion.ascx" tagname="ucPromotion" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
<tr>
    <td align="left" valign="top">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%;">&nbsp;</td>
        </tr>
        <tr>
            <td class="label_head">Bargains at Asia Books - save up to 85%</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="font-family: arial, Helvetica, sans-serif; font-size: 10pt; color: #333333;">
                We offer wide selections of bargain books at very attractive prices. Click on the links below to see what's on offer.</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td style="width: 20%">Bargains Books&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td style="width: 80%"><asp:DropDownList ID="ddlCat" runat="server" AutoPostBack="True" Height="22px" Width="230px" /></td>
                    </tr>
                </table></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><uc1:ucBooks ID="ucBooks1" runat="server" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table></td>
    <td align="right" style="width: 230px;" valign="top"><uc2:ucPromotion ID="ucPromotion1" runat="server" /></td>
</tr>
</table>
</asp:Content>


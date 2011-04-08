<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="BooksNot_Found.aspx.vb" Inherits="BooksNot_Found" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0" style="width: 100%">
<tr>
    <td style="width: 100%">&nbsp;</td>
</tr>
<tr>
    <td style="width: 100%">&nbsp;</td>
</tr>
<tr>
    <td style="width: 100%" align="center">
        <table border="0" cellpadding="0" cellspacing="0" style="width:60%">
        <tr>
            <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
             <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
             <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
        </tr>
        <tr>
            <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
            <td align="center" valign="top" >
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 3%">&nbsp;</td>
                    <td style="width: 94%">&nbsp;</td>
                    <td style="width: 3%">&nbsp;</td>
                </tr>
                <tr>
                    <td align="left" class="font_other" style="width: 3%">&nbsp;</td>
                    <td align="left" class="font_other" style="width: 94%"><asp:Label ID="lblMeassge" runat="server"></asp:Label></td>
                    <td align="left" class="font_other" style="width: 3%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 3%">&nbsp;</td>
                    <td style="width: 94%">&nbsp;</td>
                    <td style="width: 3%">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" style="width: 3%">&nbsp;</td>
                    <td align="center" style="width: 94%"><asp:ImageButton ID="img_submit" runat="server" ImageUrl="~/images/Template/submit_inquiry.gif" />
                        &nbsp;&nbsp;<asp:ImageButton ID="img_search_other" runat="server" ImageUrl="~/images/Template/search_other.gif" /></td>
                    <td align="center" style="width: 3%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 3%">&nbsp;</td>
                    <td style="width: 94%">&nbsp;</td>
                    <td style="width: 3%">&nbsp;</td>
                </tr>
                </table>
            </td>
            <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
        </tr>
        <tr>
            <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
            <td align="left" valign="top" style="height:10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
            <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
        </tr>
        </table></td>
</tr>
<tr>
    <td style="width: 100%">&nbsp;</td>
</tr>
<tr>
    <td style="width: 100%">&nbsp;</td>
</tr>
<tr>
    <td style="width: 100%">&nbsp;</td>
</tr>
</table>
</asp:Content>
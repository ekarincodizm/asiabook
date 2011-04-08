<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="Bestseller.aspx.vb" Inherits="Bestseller" title="Untitled Page" %>
<%@ Register Src="uc/ucBooks.ascx" TagName="ucBooks" TagPrefix="uc3" %>
<%@ Register Src="uc/ucTop5.ascx" TagName="ucTop5" TagPrefix="uc2" %>
<%@ Register Src="uc/ucHotnew_Tilte.ascx" TagName="ucHotnew_Tilte" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
<tr>
    <td align="left" valign="top" style="height:5px;"></td>
    <td align="left" valign="top"></td>
</tr>
<tr>
    <td align="left" valign="top" colspan="2" style="width:100%; height:37px; background-image:url('images/Template/this_week_best.jpg'); background-repeat:no-repeat;"></td>
</tr>
<tr>
    <td align="left" valign="top" colspan="2">
        <table cellpadding="0" cellspacing="0" style="width: 100%; height:145px;">
        <tr>
            <td align="left" style="width: 29px; background-image:url('images/Template/hotnew_title_left.jpg'); background-repeat:no-repeat; background-position:center;"></td>
            <td align="left" valign="top" style="width: 11px; height:145px; background-image:url('images/Template/hotnew_title_start.jpg'); background-repeat:no-repeat;"></td>
            <td align="left" valign="top" style="height:145px; background-image:url('images/Template/hotnew_title_bg.jpg'); background-repeat:repeat-x; "><uc1:ucHotnew_Tilte ID="UcHotnew_Tilte1" runat="server" /></td>
            <td align="left" valign="top" style="width: 10px; height:145px; background-image:url('images/Template/hotnew_title_end.jpg'); background-repeat:no-repeat;"></td>
            <td align="left" style="width: 29px; background-image:url('images/Template/hotnew_title_right.jpg'); background-repeat:no-repeat; background-position:center;"></td>
        </tr>
        </table></td>
</tr>
<tr>
    <td align="right" colspan="2"><asp:Image ID="Image43" runat="server" ImageUrl="~/images/Template/icon_arrow.gif" />
        &nbsp;<a href="#" runat="server" id="lnkMore" style="text-decoration:none;" class="see_more2">See more..</a>&nbsp;&nbsp;</td>
</tr>
<tr>
    <td valign="top" align="left" style="width:100%;">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
        <tr>
            <td style="width:100%; height:31px;">
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td class="font_other" style="width: 250px">See more books in each popular category&nbsp; :</td>
                    <td><asp:DropDownList ID="ddlCat" runat="server" AutoPostBack="True" Height="22px" Width="230px" /></td>
                </tr>
                </table></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><uc3:ucBooks ID="UcBooks1" runat="server" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><uc3:ucBooks ID="UcBooks2" runat="server" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><uc3:ucBooks ID="UcBooks3" runat="server" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><uc3:ucBooks ID="UcBooks4" runat="server" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        </table></td>
    <td style="width: 201px" valign="top" align="right">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 201px;">
        <tr>
            <td style="width: 201px;"><uc2:ucTop5 ID="UcTop5_1" runat="server" /></td>
        </tr>
        <tr>
            <td style="width: 201px; height:23px;">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 201px;"><uc2:ucTop5 ID="UcTop5_2" runat="server" /></td>
        </tr>
        </table></td>
</tr>
<tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
</tr>
</table>
</asp:Content>

<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Magazine.aspx.vb" Inherits="Magazine" title="Untitled Page" %>
<%@ Register Src="uc/ucPromotion.ascx" TagName="ucPromotion" TagPrefix="uc3" %>
<%@ Register Src="uc/ucHotnew_Tilte.ascx" TagName="ucHotnew_Tilte" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="uc/ucMagazine.ascx" tagname="ucMagazine" tagprefix="uc4" %>
<%@ Register src="uc/ucTop5_Magazine.ascx" tagname="ucTop5_Magazine" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" style="width: 100%">
<tr>
    <td style="width:100%;" valign="top" colspan="2">
        &nbsp;</td>
</tr>
<tr>
    <td style="width:100%; height:269px;" valign="top">
        <table cellpadding="0" cellspacing="0" style="width:100%; height:269px;" >
            <tr style="background-image:url('<% getUrl("/images/Template/Magazine_banner_bg.jpg")%>'); height:269px" valign="top">
                <td style="width:456px; height:269px" align="right">
                    <asp:Image ID="Image40" runat="server" 
                        ImageUrl="~/images/Template/Magazine_banner.jpg" />
                </td>
                <td style="height:269px"></td>
                <td align="right">
                    <asp:Image ID="Image1" runat="server" 
                        ImageUrl="~/images/Template/Magazine_banner_right.jpg" />
                   </td>
            </tr>
        </table>
    </td>
    <td style="width:201px" align="right" valign="top">
        <uc2:ucTop5_Magazine ID="ucTop5_Magazine1" runat="server" />
    </td>
</tr>
<tr>
    <td valign="top" style="height: 25px">
        <table cellpadding="0" cellspacing="0" style="width:100%; height:115px;" >
            <tr style="background-image:url('<% getUrl("/images/Template/newsweek/bg_red.gif")%>'); height:115px" valign="top">
                <td style="width:456px; height:115px" align="right">
                    <a href="Magazine_Detail_Internet.aspx?Title_1=MAG9990002"><asp:Image ID="Image41" runat="server" 
                        ImageUrl="~/images/Template/newsweek/newsweek.gif" /></a>
                </td>
                <td style="height:115px"></td>
                <td align="right">
                    <asp:Image ID="Image42" runat="server" 
                        ImageUrl="~/images/Template/newsweek/end.gif" />
                   </td>
            </tr>
        </table>
    </td>
    <td align="center" rowspan="3" style="width: 201px" valign="top">
        <uc3:ucPromotion ID="UcPromotion1" runat="server" /></td>
</tr>
<tr>
    <td valign="top" style="height: 25px">
        <table cellpadding="0" cellspacing="0" style="width: 100%; height: 30px;">
            <tr>
                <td class="font_other" style="width: 260px">
                    See more magazine in each popular category&nbsp; :</td>
                <td>
                    <asp:DropDownList ID="ddlCat" runat="server" Width="230px" AutoPostBack="True" Height="22px" />
                </td>
            </tr>
        </table>
    </td>
</tr>
<tr>
    <td valign="top">
        <table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr style="width:100%">
            <td style="width: 100%">
                <uc4:ucMagazine ID="ucMagazine1" runat="server" />
            </td>
        </tr>
        <tr style="width: 100%">
            <td style="width: 100%;"></td>
        </tr>
        <tr style="width: 100%">
            <td style="width: 100%">
                <uc4:ucMagazine ID="ucMagazine2" runat="server" />
            </td>
        </tr>
        <tr style="width: 100%">
            <td style="width: 100%;"></td>
        </tr>
        <tr style="width: 100%">
            <td style="width: 100%">
                <uc4:ucMagazine ID="ucMagazine3" runat="server" />
            </td>
        </tr>
        <tr style="width: 100%">
            <td style="width: 100%"></td>
        </tr>
        <tr style="width: 100%">
            <td style="width: 100%">
                <uc4:ucMagazine ID="ucMagazine4" runat="server" />
            </td>
        </tr>
        <tr style="width: 100%">
            <td style="width: 100%"></td>
        </tr>
        <tr style="width: 100%">
            <td style="width: 100%">
                <uc4:ucMagazine ID="ucMagazine5" runat="server" />
            </td>
        </tr>
        <tr style="width: 100%">
            <td style="width: 100%">&nbsp;</td>
        </tr>
        </table></td>
    <td>&nbsp;</td>
</tr>
<tr>
<td style="width: 9px">&nbsp;</td>
<td>&nbsp;</td>
</tr>
</table>
</asp:Content>


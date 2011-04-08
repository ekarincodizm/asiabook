<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"  MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="Thailand_Insight.aspx.vb" Inherits="Thailand_Insight" title="Untitled Page" %>
<%@ Register Src="uc/ucPromotion.ascx" TagName="ucPromotion" TagPrefix="uc4" %>
<%@ Register Src="uc/ucBooks.ascx" TagName="ucBooks" TagPrefix="uc5" %>
<%@ Register Src="uc/ucfeatured.ascx" TagName="ucfeatured" TagPrefix="uc3" %>
<%@ Register Src="uc/ucTop5.ascx" TagName="ucTop5" TagPrefix="uc2" %>
<%@ Register Src="uc/ucHotnew_Tilte.ascx" TagName="ucHotnew_Tilte" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
<tr>
    <td></td>
    <td style="width: 201px"></td>
</tr>
<tr>
    <td colspan="2"><asp:Image ID="Image1" runat="server" 
            ImageUrl="~/images/Template/ThailandInsight.jpg" /></td>
</tr>
<tr>
    <td colspan="2">
       <table cellpadding="0" cellspacing="0" style="width: 100%; height:145px">
        <tr>
            <td style="width: 29px;" valign="middle">
                <asp:Image ID="Image42" runat="server" 
                    ImageUrl="~/images/Template/hotnew_title_left.jpg" />
            </td>
            <td style="width: 11px; height:145px" align="right" valign="top">
                <asp:Image ID="Image2" runat="server" 
                    ImageUrl="~/images/Template/hotnew_title_start.jpg" />
               </td>
            <td valign="top" align="center" style="background-image:url('<% getUrl("/images/Template/hotnew_title_bg.jpg")%>'); ">
               <uc1:ucHotnew_Tilte ID="UcHotnew_Tilte1" runat="server" />
            </td>
            <td style="width: 10px; height:145px" valign="top">
            <asp:Image ID="Image4" runat="server" 
                    ImageUrl="~/images/Template/hotnew_title_end.jpg"/>
               </td>
            <td style="width: 29px;" valign="middle">
                <asp:Image ID="Image3" runat="server" 
                    ImageUrl="~/images/Template/hotnew_title_right.jpg" /></td>
        </tr>
    </table></td>
</tr>
<tr>
    <td colspan="2" align="right" valign="top">
        <asp:Image ID="Image17" runat="server" 
            ImageUrl="~/images/Template/icon_arrow.gif" />
&nbsp;<a href="#" runat="server" id="lnkMore" 
        style="text-decoration:none;" class="see_more2">See more..</a>&nbsp;&nbsp;</td>
</tr>
<tr>
    <td colspan="2"><uc3:ucfeatured ID="Ucfeatured1" runat="server" /></td>
</tr>
<tr>
    <td colspan="2"></td>
</tr>
<tr>
    <td valign="top" align="left" style="width:100%">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" style="width: 100%">
                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="font_other" style="width: 250px">
                                See more books in each popular category&nbsp; :</td>
                            <td>
                    <asp:DropDownList ID="ddlCat" runat="server" AutoPostBack="True" Height="22px" Width="230px">
                    </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 100%; height: 20px">
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 100%">
                    <uc5:ucBooks ID="UcBooks1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 100%">
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 100%">
                    <uc5:ucBooks ID="UcBooks2" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 100%">
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 100%">
                    <uc5:ucBooks ID="UcBooks3" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 100%">
                </td>
            </tr>
        </table></td>
    <td style="width: 201px" valign="top" align="right">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 201px" >
            <tr>
                <td style="width: 201px">
                    <uc2:ucTop5 ID="UcTop5_1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 201px; height: 23px">
                    <uc4:ucPromotion ID="UcPromotion1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 201px">
                    &nbsp;</td>
            </tr>
        </table></td>
</tr>
<tr>
    <td></td>
    <td style="width: 201px"></td>
</tr>
</table>
</asp:Content>
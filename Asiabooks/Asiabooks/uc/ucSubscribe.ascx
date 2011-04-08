<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucSubscribe.ascx.vb" Inherits="uc_ucSubscribe" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="ucCaptcha.ascx" tagname="captcha" tagprefix="uc1" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
<asp:UpdatePanel runat="server" ID="upUnsub" UpdateMode="Conditional">
<ContentTemplate>
<table>
<tr>
    <td style="width:134px; height:30px; background-image:url('images/Template/logo_enew.jpg'); background-repeat:no-repeat;"></td>
    <td style="width:110px;">&nbsp;</td>
</tr>
<tr>
    <td align="center" valign="middle" style="width:178px; height:35px; background-image:url('images/Template/txtenew.jpg');">
        <asp:TextBox ID="txtSubscribe" runat="server" CssClass="textbox" Width="140px" /></td>
    <td style="width:110px;"><asp:ImageButton ID="ImageButton17" runat="server" ImageUrl="~/images/Template/btn_subscribe.jpg" /></td>
</tr>
<tr>
    <td style="width:134px;">&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkPopupUnsub" runat="server"
        Font-Names="arial" Font-Size="9pt" ForeColor="#666666">UnSubscribe</asp:LinkButton></td>
    <td style="width:110px;"><asp:HiddenField runat="server" ID="hdSessionNameSubscribe" /></td>
</tr>
</table>
<asp:Panel ID="panEdit" HorizontalAlign="Center" runat="server"  style="display:none" >
<table border="0" cellpadding="0" cellspacing="0" style="background-color:White; width:450px;">
<tr>
    <td align="left" valign="top" style="width:23px; height:20px; background-image: url('images/Template/border/Inner_HeaderLeft.jpg');"></td>
    <td align="left" valign="top" style="background-image: url('images/Template/border/Inner_Header.jpg');"></td>
    <td align="left" valign="top" style="width:23px; height:20px; background-image: url('images/Template/border/Inner_HeaderRight.jpg');"></td>
</tr>
<tr>
    <td align="left" valign="top" style="background-image:url('images/Template/border/Inner_Left.jpg');"></td>
    <td align="left" valign="top">
        <table cellpadding="0" cellspacing="0" style="width: 100%" class"font_other">
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="header_other" colspan="2" style="height: 27px">&nbsp;&nbsp;UnSubscribe</td>
        </tr>
        <tr>
            <td colspan="2" style="height: 10px"></td>
        </tr>
        <tr>
            <td class="font_other" colspan="2">
                &nbsp;&nbsp; Unsubscribe from Asiabooks.com
                <br />
                <br />
                Please provide your email address if you do not wish to receive Asiabooks 
                e-News.</td>
        </tr>
        <tr>
            <td style="width: 40%">&nbsp;</td>
            <td style="width: 60%">&nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="font_other" style="width: 40%; height: 25px;">Email address :&nbsp;&nbsp;</td>
            <td style="width: 60%; height: 25px;"><asp:TextBox ID="txtUnSubscribe" runat="server" style="margin-left: 0px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" class="font_other" style="width: 40%; height: 25px;">&nbsp;</td>
            <td class="font_other" style="width: 60%; height: 25px;">Type the characters you see in this image.</td>
        </tr>
        <tr>
            <td align="right" class="font_other" style="width: 40%; height: 40px;" valign="top">Image verification :&nbsp;&nbsp;</td>
            <td style="width: 60%; height: 40px;"><uc1:captcha ID="SubscribeCaptcha" runat="server" /></td>
        </tr>
        <tr>
            <td align="right" style="width: 40%; height: 17px;"></td>
            <td style="width: 60%; height: 17px;"><asp:LinkButton ID="lnkRefresh_forgot" runat="server" Font-Names="Arial" 
                Font-Size="8pt" ForeColor="Blue">Try a different image.</asp:LinkButton></td>
        </tr>
        <tr>
            <td align="right" class="font_other" style="width: 40%; height: 25px;">Type characters :&nbsp;&nbsp;</td>
            <td style="width: 60%; height: 25px;"><asp:TextBox ID="txtCaptcha" runat="server" Font-Names="Verdana" Font-Size="11px" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 40%; height: 15px;"></td>
            <td style="width: 60%; height: 15px;"></td>
        </tr>
        <tr>
            <td style="width: 40%">&nbsp;</td>
            <td style="width: 60%"><asp:Button ID="btnSave" runat="server" Text="Save" />
                &nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" /></td>
        </tr>
        <tr>
            <td style="width: 40%">&nbsp;</td>
            <td style="width: 60%">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 40%">&nbsp;</td>
            <td style="width: 60%"></td>
        </tr>
        <tr>
            <td style="width: 40%">&nbsp;</td>
            <td style="width: 60%">&nbsp;</td>
        </tr>
        </table></td>
    <td align="left" valign="top" style="background-image:url('images/Template/border/Inner_Right.jpg');" align="right">&nbsp;</td>
</tr> 
<tr>
    <td align="left" valign="top" style="width:23px; height:21px; background-image:url('images/Template/border/Inner_FooterLeft.jpg');"></td>
    <td align="left" valign="top" style="background-image:url('images/Template/border/Inner_Footer.jpg');"></td>
    <td align="left" valign="top" style="width:23px; height:20px; background-image:url('images/Template/border/Inner_FooterRight.jpg');"></td>
</tr>
</table>
<br />      
</asp:Panel>
<asp:LinkButton ID="LinkButton1" runat="server" style="display:none;">LinkButton1</asp:LinkButton>
<asp:ModalPopupExtender ID="mdlPopupSubscrilbe" TargetControlID="LinkButton1" PopupControlID="panEdit"
 CancelControlID="btnCancel"  runat="server" BackgroundCssClass="ModelBackground" >
</asp:ModalPopupExtender>
</ContentTemplate>
</asp:UpdatePanel>
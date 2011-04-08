<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="My_Account.aspx.vb" Inherits="My_Account" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/uc/ucCaptcha.ascx" TagName="captcha" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
<table cellpadding="0" cellspacing="0" style="width: 100%">
<tr>
    <td style="width: 100%; height: 25px;"></td>
</tr>
<tr>
    <td class="label_thailand_title" style="height:33px; text-align:left; background-image: url('images/Template/other_by_author_bg.jpg');">&nbsp;&nbsp; Ordering from AsiaBooks is safe and easy</td>
</tr>
<tr>
    <td style="width: 100%; height: 20px;"></td>
</tr>
<tr>
    <td style="width: 100%">
        <table cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <td style="width: 50%" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%">
                <tr>
                    <td valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                    <td valign="top" style="height:7px; background-image: url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                    <td valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                </tr>
                <tr>
                    <td valign="top" style="width: 9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                    <td align="center" valign="top">
                        <asp:UpdatePanel ID="UpdatePanel_Forgot" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <asp:Panel ID="panel_default_login" runat="server" DefaultButton="b_search">
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="header_other" colspan="2" align="left">&nbsp;Sign In</td>
                        </tr>
                        <tr>
                            <td class="font_other" colspan="2" align="left">&nbsp; If you are already a customer, please login</td>
                        </tr>
                        <tr>
                            <td style="width: 40%">&nbsp;</td>
                            <td style="width: 60%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" class="font_other" style="width: 40%; height: 25px;">User Name&nbsp;:&nbsp;&nbsp;</td>
                            <td style="width: 60%; height: 25px;" align="left"><asp:TextBox ID="tbx_email" runat="server" Font-Names="Verdana" 
                                Font-Size="11px" Width="150px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" class="font_other" style="width: 40%; height: 25px;">Password&nbsp;:&nbsp;&nbsp;</td>
                            <td style="width: 60%; height: 25px;" align="left"><asp:TextBox ID="tbx_pass" runat="server" Font-Names="Verdana" Font-Size="11px" 
                                TextMode="Password" Width="150px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 40%">&nbsp;</td>
                            <td style="width: 60%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 40%">&nbsp;</td>
                            <td style="width: 60%" align="left"><asp:ImageButton ID="b_search" runat="server" 
                                ImageUrl="~/images/bt-login2.jpg" onclick="b_search_Click" /></td>
                        </tr>
                        <tr>
                            <td style="width: 40%; height: 29px;"></td>
                            <td style="width: 60%; height: 29px;" class="font_other" align="left">
                                <asp:LinkButton ID="lnkPopup" runat="server" 
                                Font-Names="arial" Font-Size="9pt" ForeColor="#FF3300" Font-Bold="True">Forgot Password</asp:LinkButton>
                                <asp:HiddenField runat="server" ID="hdSessionNameForgotPass" /></td>
                        </tr>
                        <tr>
                            <td style="width: 40%; height: 20px;" align="left" class="header_other"></td>
                            <td style="width: 60%; height: 20px;"></td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" class="font_other">----------------------------------------------------------------------------</td>
                        </tr>
                            <tr>
                                <td align="center" class="font_other" colspan="2">
                                    &nbsp;</td>
                            </tr>
                        <tr>
                            <td style="width: 40%; height: 136px;"></td>
                            <td style="width: 60%; height: 136px;"></td>
                        </tr>
                            <tr>
                                <td style="width: 40%; ">
                                    &nbsp;</td>
                                <td style="width: 60%; ">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 40%; ">
                                    &nbsp;</td>
                                <td style="width: 60%; ">
                                    &nbsp;</td>
                            </tr>
                        </table></asp:Panel>
                        <asp:Panel ID="panForgot" HorizontalAlign="Center" runat="server" style="display:none">   
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 450px; background-color:White;">
                        <tr>
                            <td align="left" valign="top" style="width:9px; height:7px; background-image: url('images/Template/cart_head_start.jpg');"></td>
                            <td align="left" valign="top" style="background-image: url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                            <td align="left" valign="top" style="width:10px; height:7px; background-image: url('images/Template/cart_head_end.jpg');"></td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                            <td align="right" valign="top"><asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/Template/close.jpg" /></td>
                            <td style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                            <td align="left" valign="top" style="width:430px;">
                                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left" valign="top" class="header_other" style="height:27px;">&nbsp;&nbsp;Forgot Password</td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 10px"></td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left" valign="top" class="font_other">&nbsp;&nbsp;&nbsp;&nbsp;Enter the e-mail 
                                        address or member code associated with your Asiabooks.com account, then click 
                                        Forgot Password.</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top" class="font_other" style="height:25px;">Email address&nbsp;:&nbsp;&nbsp;</td>
                                    <td align="left" valign="top"><asp:TextBox ID="txtmail_forgot" runat="server" Font-Names="Verdana" 
                                        Font-Size="11px" Width="150px"></asp:TextBox></td>
                                </tr>
                                    <tr>
                                        <td align="right" class="font_other" style="height:19px;" valign="top">
                                        </td>
                                        <td align="left" style="font-weight: bold; height: 19px;">
                                            OR</td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="font_other" style="height:25px;" valign="top">
                                            Member code :&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:TextBox ID="txtmember_code_forgot" runat="server" Font-Names="Verdana" 
                                                Font-Size="11px" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>
                                <tr>
                                    <td align="right" valign="top" class="font_other" style="height:25px;">&nbsp;</td>
                                    <td align="left" valign="top">Type the characters you see in this image.</td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top" style="height:40px;" class="font_other">Image verification&nbsp;:&nbsp;&nbsp;</td>
                                    <td align="left" valign="top"><uc1:captcha runat="server" ID="ForgotCaptcha" /></td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top" style="height:17px;"></td>
                                    <td align="left" valign="top"><asp:LinkButton ID="lnkRefresh_forgot" runat="server" Font-Names="Arial" 
                                        Font-Size="8pt" ForeColor="Blue">Try a different image.</asp:LinkButton></td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top" style="height:25px;" class="font_other">Type characters&nbsp;:&nbsp;&nbsp;</td>
                                    <td align="left" valign="top"><asp:TextBox ID="txtCaptcha" runat="server" Font-Names="Verdana" Font-Size="11px" Width="150px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td align="left" valign="top"><asp:ImageButton ID="b_Forgot_Pass" runat="server" ImageUrl="~/images/bt-ForgotPwd.jpg" /></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                </table></td>
                            <td align="left" valign="top" style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                            <td align="left" valign="top" style="height:10px; background-image:url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                            <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                        </tr>
                        </table> 
                        </asp:Panel>
                        <asp:LinkButton ID="LinkButton1" runat="server" style="display:none">LinkButton</asp:LinkButton>
                        <asp:ModalPopupExtender ID="mdlPopupForgotPass" TargetControlID="LinkButton1" PopupControlID="panForgot"
                            CancelControlID="btnCancel" runat="server" BackgroundCssClass="ModelBackground" >
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="panPopUp_Meassge" runat="server" HorizontalAlign="Center" style="display:none">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 400px; background-color: White;">
                        <tr>
                            <td align="left" valign="top" style="width:9px; height:7px; background-image: url('images/Template/cart_head_start.jpg');"></td>
                            <td align="left" valign="top" style="background-image: url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                            <td align="left" valign="top" style="width:10px; height:7px; background-image: url('images/Template/cart_head_end.jpg');"></td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                            <td align="center" valign="top">
                                <table cellpadding="0" cellspacing="0" style="width: 90%" >
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="font_about_us" align="left">Password already sent to your email.,Please 
                                        check password in your email <asp:Label ID="lblemail_member" runat="server" 
                                            Font-Bold="False" ForeColor="#0066FF"></asp:Label>
                                        .</td>
                                </tr>
                                <tr>
                                    <td class="font_other">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="font_other" align="center"><asp:ImageButton ID="img_Meassge" runat="server" ImageUrl="~/images/b_ok.jpg" /></td>
                                </tr>
                                <tr>
                                    <td class="font_other">&nbsp;</td>
                                </tr>
                                </table></td>
                            <td align="left" valign="top" style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                        </tr>
                        <tr>
                           <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                            <td align="left" valign="top" style="height:10px; background-image:url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                            <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                        </tr>
                        </table>
                        </asp:Panel>
                        <asp:ModalPopupExtender ID="mdlPopUp_Meassge" TargetControlID="lnkMeassge" PopupControlID="panPopUp_Meassge"
                            runat="server" BackgroundCssClass="ModelBackground" >
                        </asp:ModalPopupExtender>
                        <asp:LinkButton ID="lnkMeassge" runat="server" style="display:none">LinkButton</asp:LinkButton>
                        </ContentTemplate>
                        </asp:UpdatePanel></td>
                    <td valign="top" style="width: 10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                </tr>
                <tr>
                    <td valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                    <td valign="top" style="height:10px; background-image:url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                    <td valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                </tr>
               </table></td>
            <td style="width: 50%" valign="top">
            <asp:Panel ID="panel_default_register" runat="server" DefaultButton="b_add">
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%">
                <tr>
                    <td valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                    <td valign="top" style="height:7px; background-image: url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                    <td valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                </tr>
                <tr>
                    <td valign="top" style="width: 9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                    <td align="center" valign="top" >
                        <asp:UpdatePanel ID="UpdatePanel_CaptchaRegis" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="header_other" colspan="2" align="left">&nbsp; Register (new account)</td>
                            </tr>
                            <tr>
                                <td class="font_other" colspan="2" align="left">&nbsp;&nbsp;&nbsp; If you are a new customer, please fill in required informations</td>
                            </tr>
                            <tr>
                                <td style="width: 30%">&nbsp;</td>
                                <td style="width: 60%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 40%; height: 25px;">First Name&nbsp;:&nbsp;&nbsp;</td>
                                <td style="width: 60%; height: 25px;" align="left"><asp:TextBox ID="tbx_name" runat="server" 
                                    Font-Names="Verdana" Font-Size="11px" Width="150px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 40%; height: 25px;">Last Name&nbsp;:&nbsp;&nbsp;</td>
                                <td style="width: 60%; height: 25px;" align="left"><asp:TextBox ID="tbx_surname" runat="server" 
                                    Font-Names="Verdana" Font-Size="11px" Width="150px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 40%; height: 25px;">&nbsp;&nbsp;Telephone / 
                                    Mobile <span style="color: #FF0000">**</span> :&nbsp;&nbsp;&nbsp; </td>
                                <td style="width: 60%; height: 25px;" align="left">
                                    <asp:TextBox ID="tbx_tel" runat="server" Font-Names="Verdana" Font-Size="11px" 
                                        Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                                <tr>
                                    <td align="right" class="font_other" style="width: 40%; height: 25px;">
                                        &nbsp;Email&nbsp;:&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td align="left" style="width: 60%; height: 25px;">
                                        <asp:TextBox ID="tbx_email1" runat="server" Font-Names="Verdana" 
                                            Font-Size="11px" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 40%; height: 25px;">Password&nbsp;:&nbsp;&nbsp;</td>
                                <td style="width: 60%; height: 25px;" align="left"><asp:TextBox ID="tbx_pass1" runat="server" 
                                    Font-Names="Verdana" Font-Size="11px" TextMode="Password" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 40%; height: 25px;">Confirm Password&nbsp;:&nbsp;&nbsp;</td>
                                <td style="width: 60%; height: 25px;" align="left"><asp:TextBox ID="tbx_contpass" runat="server" 
                                    Font-Names="Verdana" Font-Size="11px" TextMode="Password" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 40%">&nbsp;</td>
                                <td style="width: 60%" class="font_other">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 40%">&nbsp;</td>
                                <td style="width: 60%" class="font_other" align="left">Type the characters you see in this image.</td>
                            </tr>
                            <tr>
                                <td style="width: 40%; " align="right" class="font_other" valign="top">Image verification&nbsp;:&nbsp;&nbsp;</td>
                                <td style="width: 60%; " valign="top" align="left"><uc1:captcha ID="captchaRegister" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 40%">&nbsp;</td>
                                <td style="width: 60%" align="left"><asp:LinkButton ID="lnkRefresh_Register" runat="server" 
                                    Font-Names="Arial" Font-Size="8pt" ForeColor="Blue">Try a different image.</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td style="width: 40%" align="right" class="font_other">Type characters&nbsp;:&nbsp;&nbsp;</td>
                                <td style="width: 60%" align="left"><asp:Textbox ID="txtCaptchaRegis" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 40%">&nbsp;</td>
                                <td style="width: 60%"><asp:HiddenField ID="hdSessiongRegister" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 40%">&nbsp;</td>
                                <td style="width: 60%" align="left"><asp:ImageButton ID="b_add" runat="server" 
                                    ImageUrl="~/images/bt-register.jpg" /></td>
                            </tr>
                                <tr>
                                    <td style="width: 40%; height: 20px;">
                                    </td>
                                    <td align="left" style="width: 60%; height: 20px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 40%">
                                        &nbsp;</td>
                                    <td style="width: 60%">
                                        &nbsp;</td>
                                </tr>
                            </table>
                         </ContentTemplate>
                         </asp:UpdatePanel></td>
                    <td valign="top" style="width: 10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                </tr>
                <tr>
                    <td valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                    <td valign="top" style="height:10px; background-image:url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                    <td valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                </tr>
               </table></asp:Panel></td>
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
<tr>
    <td style="width: 100%">&nbsp;</td>
</tr>
<tr>
    <td style="width: 100%">&nbsp;</td>
</tr>
</table>
<br />
</asp:Content>
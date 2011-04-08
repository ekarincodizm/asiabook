<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Help.aspx.vb" Inherits="Help" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 100%">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Template/contact_us.jpg" /></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%; height: 10px">
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 100%; height: 10px">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image16" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
                        <td valign="top" style="height: 7px; background-image: url('images/Template/cart_head_bg.jpg')"></td>
                        <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image17" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
                    </tr>
                    <tr>
                        <td valign="top" style="background-image: url('images/Template/cart_left_bg.jpg'); width: 9px"></td>
                        <td align="center" valign="top">
                        <table cellpadding="0" cellspacing="0" style="width: 90%">
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 17px;">
                                </td>
                                <td align="left" style="height: 17px">
                                </td>
                                <td align="left" style="height: 17px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="header_other" style="height: 17px;" colspan="3">
                                    Customer Information</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 17px;">
                                    &nbsp;</td>
                                <td align="left" style="height: 17px">
                                    <asp:Label ID="lblMeassge" runat="server" Visible="False"></asp:Label>
                                                                  </td>
                                <td align="left" style="height: 17px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 27px;">
                                    Name <span style="color: #FF0000">** </span>:&nbsp;&nbsp;
                                </td>
                                <td align="left" style="height: 27px">
                                    <asp:TextBox ID="txtCus_Name" runat="server" Width="230px"></asp:TextBox>
                                </td>
                                <td align="left" style="height: 27px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px" valign="top">
                                    Email <span style="color: #FF0000">**</span> :&nbsp;&nbsp;
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCus_Email" runat="server" TextMode="MultiLine" 
                                        Width="230px"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    &nbsp;</td>
                                <td align="left">
                                    (More than 1 email use ;&nbsp; )</td>
                                <td align="left" style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    &nbsp;</td>
                                <td align="left">
                                    ex <a href="mailto:a@asiabooks.com">a@asiabooks.com</a> ;
                                    <a href="mailto:b@asiabooks.com">b@asiabooks.com</a></td>
                                <td align="left" style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 27px;">
                                    Mobile / Telephone<span style="color: #FF0000"> **</span> :&nbsp;&nbsp;
                                </td>
                                <td align="left" style="height: 27px">
                                    <asp:TextBox ID="txtCus_Tel" runat="server" Width="230px"></asp:TextBox>
                                </td>
                                <td align="left" style="height: 27px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    Issue :&nbsp;&nbsp;&nbsp; </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlIssue" runat="server" Width="228px">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 100px">
                                    &nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left" style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 27px;">
                                    Subject <span style="color: #FF0000">**</span> :&nbsp;&nbsp;
                                </td>
                                <td align="left" style="height: 27px">
                                    <asp:TextBox ID="txtCus_Subject" runat="server" Width="230px"></asp:TextBox>
                                </td>
                                <td align="left" style="height: 27px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px" valign="top">
                                    Detail <span style="color: #FF0000">** </span>: &nbsp;
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDetail" runat="server" Height="103px" TextMode="MultiLine" 
                                        Width="230px"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 17px;" 
                                    valign="top">
                                </td>
                                <td align="left" style="height: 17px">
                                </td>
                                <td align="left" style="height: 17px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 17px;" 
                                    valign="top">
                                    &nbsp;</td>
                                <td align="left" style="height: 17px">
                                    <asp:Button ID="btnSave" runat="server" Text="Submit" Width="64px" />
                                </td>
                                <td align="left" style="height: 17px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                        </table></td>
                        <td valign="top" style="background-image: url('images/Template/cart_right_bg.jpg'); width: 10px;"></td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image18" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" Border="0" /></td>
                        <td valign="top" style="height: 10px; background-image: url('images/Template/cart_footer_bg.jpg')"></td>
                        <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image19" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" Border="0" /></td>
                    </tr>
               </table></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%; height: 10px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%; height: 19px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td align="center" style="width: 20px" valign="top">
                         <a href="mailto:ecommerce@asiabooks.com">   
                         <asp:Image ID="Image29" runat="server" 
                                ImageUrl="~/images/e-commerce.gif" /></a></td>
                        <td align="left" class="font_other" valign="top">
                            &nbsp;&nbsp;
                        </td>
                        <td class="font_other" align="left" valign="top">
                            <strong><span style="font-size: 10pt">
                            <span style="color: #0066FF">e-Commerce Customer Service 
                                </span> 
                                <br />
                            </span></strong>
ASIA BOOKS CO., LTD 65/66, 65/70 7th Floor, 
  Chamnan Phenjati Business Center, Rama 9 Road, 
Huaykwang  Bangkok 10320 Thailand
(Monday-Friday 8.30 am.- 5.30 pm.)
                            <br />
                            <b>E-Mail:</b> <a href="mailto:ecommerce@asiabooks.com"> ecommerce@asiabooks.com</a>
                            <br />
                            <b>Tel: </b>(662) 715-9000 ext. 8102, 8103 Fax: (662) 715-9197

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 26px">
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 10px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td align="center" style="width: 20px" valign="top">
                            <a href="mailto:information@asiabooks.com">   
                         <asp:Image ID="Image2" runat="server" ImageUrl="~/images/information.gif" /></a></td>
                        <td align="left" class="font_other" valign="top">
                            &nbsp;&nbsp;
                        </td>
                        <td class="font_other" align="left" valign="top">
                            <strong><span style="font-size: 10pt">
                            <span style="color: #0066FF">Asia Books Customer Service 
                                </span> 
                                <br />
                            </span></strong>
221 Sukhumvit Road (between soi 15-17) Klongtoey Nua, Wattana, Bangkok 10110 Thailand (Monday-Friday 9.00 am.- 6.00 pm.) 
<br /><b>E-Mail:</b> <a href="mailto:information@asiabooks.com">information@asiabooks.com</a>
                            <br />
                            <b>Tel :</b>( 662) 651-0429-30 Fax: (662) 2251-6042
                            <br /><br /><span style="color: #FF0000">***</span>&nbsp;&nbsp; -&nbsp; Searching Books
                            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;General Information                             
                            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; -&nbsp; Others Comment<br /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 10px">
                &nbsp;</td>
        </tr>
        <tr style="color: #000000">
           <td class="font_other" align="left" valign="top">
               &nbsp;</td>
        </tr>
        <tr style="color: #000000">
            <td align="left" class="font_other" valign="top" style="height: 10px">
            </td>
        </tr>
   </table>
         <asp:Panel ID="panCheckMeassge" runat="server" HorizontalAlign="Center" style="display:none">
      <table border="0" cellpadding="0" cellspacing="0" style="width: 450px; background-color:White;">
           <tr>
               <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image25" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 7px; background-image: url('images/Template/cart_head_bg.jpg')"></td>
               <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image26" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
           </tr>
           <tr>
               <td valign="top" style="background-image: url('images/Template/cart_left_bg.jpg'); width: 9px"></td>
               <td align="center" valign="top" >
               <table cellpadding="0" cellspacing="0" style="width: 90%">
                        <tr>
                            <td align="right" style="height: 25px"></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="font_about_us" align="center">
                                Thank you for you message.</td>
                        </tr>
                        <tr>
                            <td class="font_other" style="height: 19px"></td>
                        </tr>
                        <tr>
                            <td class="font_other" align="center">
                                <asp:ImageButton ID="img_Msg_OK" runat="server" 
                                    ImageUrl="~/images/b_ok.jpg" />
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="font_other"></td>
                        </tr>
                        <tr>
                            <td class="font_other" style="height: 25px"></td>
                        </tr>
                    </table>
               </td>
               <td valign="top" style="background-image: url('images/Template/cart_right_bg.jpg'); width: 10px;"></td>
           </tr>
           <tr>
               <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image27" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 10px; background-image: url('images/Template/cart_footer_bg.jpg')"></td>
               <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image28" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" Border="0" /></td>
           </tr>
      </table>
 </asp:Panel>
 <asp:ModalPopupExtender ID="mdlPopUp_Meassge" 
        TargetControlID="linkSave" PopupControlID="panCheckMeassge"
  runat="server" BackgroundCssClass="ModelBackground" >
</asp:ModalPopupExtender>
<asp:LinkButton ID="linkSave" runat="server" style="display:none">LinkButton</asp:LinkButton>
</asp:Content>


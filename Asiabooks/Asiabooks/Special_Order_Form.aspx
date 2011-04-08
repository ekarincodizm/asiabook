<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Special_Order_Form.aspx.vb" Inherits="Special_Order_Form" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="PanelFocus" runat="server" DefaultButton="btnSave">
    <table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" style="width: 100%">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image1" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
                        <td valign="top" style="height: 7px; background-image: url('images/Template/cart_head_bg.jpg')"></td>
                        <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image2" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
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
                                    Mobile / Telephone :&nbsp;&nbsp;
                                </td>
                                <td align="left" style="height: 27px">
                                    <asp:TextBox ID="txtCus_Tel" runat="server" Width="230px"></asp:TextBox>
                                </td>
                                <td align="left" style="height: 27px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
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
                        </table></td>
                        <td valign="top" style="background-image: url('images/Template/cart_right_bg.jpg'); width: 10px;"></td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image3" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" Border="0" /></td>
                        <td valign="top" style="height: 10px; background-image: url('images/Template/cart_footer_bg.jpg')"></td>
                        <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image4" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" Border="0" /></td>
                    </tr>
               </table>
                
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%" align="center">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image5" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
                        <td valign="top" style="height: 7px; background-image: url('images/Template/cart_head_bg.jpg')"></td>
                        <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image6" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
                    </tr>
                    <tr>
                        <td valign="top" style="background-image: url('images/Template/cart_left_bg.jpg'); width: 9px"></td>
                        <td align="center" valign="top" >
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
                                    Inquiry Information</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 17px;">
                                    &nbsp;</td>
                                <td align="left" style="height: 17px">
                                    &nbsp;</td>
                                <td align="left" style="height: 17px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 27px;">
                                    ISBN :&nbsp;&nbsp;
                                </td>
                                <td align="left" style="height: 27px">
                                    <asp:TextBox ID="txtIsbn" runat="server" Width="230px"></asp:TextBox>
                                </td>
                                <td align="center" style="height: 27px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 27px;">
                                    Title :&nbsp;&nbsp;
                                </td>
                                <td align="left" style="height: 27px">
                                    <asp:TextBox ID="txtTitle" runat="server" Width="230px"></asp:TextBox>
                                </td>
                                <td align="left" style="height: 27px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 27px;">
                                    Author :&nbsp;&nbsp;
                                </td>
                                <td align="left" style="height: 27px">
                                    <asp:TextBox ID="txtAuther" runat="server" Width="230px"></asp:TextBox>
                                </td>
                                <td align="left" style="height: 27px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 27px;">
                                    Keyword :&nbsp;&nbsp;
                                </td>
                                <td align="left" style="height: 27px">
                                    <asp:TextBox ID="txtKeyword" runat="server" Width="230px"></asp:TextBox>
                                </td>
                                <td align="left" style="height: 27px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 27px;">
                                    Publisher Name :&nbsp;&nbsp;
                                </td>
                                <td align="left" style="height: 27px">
                                    <asp:TextBox ID="txtPublisher" runat="server" Width="230px"></asp:TextBox>
                                </td>
                                <td align="left" style="height: 27px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 27px;" 
                                    valign="top">
                                    &nbsp;</td>
                                <td align="left" style="height: 27px">
                                    &nbsp;</td>
                                <td align="left" style="height: 27px; width: 100px;">
                                    &nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 27px;">
                                    <span style="color: #FF3300; font-weight: bold; font-size: small">Quantity of your order</span>&nbsp;&nbsp;&nbsp;
                                </td>
                                <td align="left" style="height: 27px">
                                    <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
                                </td>
                                <td align="left" style="height: 27px; width: 100px;">
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
                        </table></td>
                        <td valign="top" style="background-image: url('images/Template/cart_right_bg.jpg'); width: 10px;"></td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image8" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" Border="0" /></td>
                        <td valign="top" style="height: 10px; background-image: url('images/Template/cart_footer_bg.jpg')"></td>
                        <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image10" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" Border="0" /></td>
                    </tr>
               </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Submit Inquiry" Width="100px" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
    </table></asp:Panel>
    
     <asp:Panel ID="panCheckMeassge" runat="server" HorizontalAlign="Center" style="display:none">
      <table border="0" cellpadding="0" cellspacing="0" style="width: 450px; background-color:White;">
           <tr>
               <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image25" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 7px; background-image: url('<% getUrl("/images/Template/cart_head_bg.jpg")%>')"></td>
               <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image26" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
           </tr>
           <tr>
               <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_left_bg.jpg")%>'); width: 9px"></td>
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
               <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_right_bg.jpg")%>'); width: 10px;"></td>
           </tr>
           <tr>
               <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image27" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 10px; background-image: url('<% getUrl("/images/Template/cart_footer_bg.jpg")%>')"></td>
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


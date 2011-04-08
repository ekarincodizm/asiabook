<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Customer_Profile.aspx.vb" Inherits="Customer_Profile" title="Untitled Page" %>
<%@ Register Assembly="MycustomDG" Namespace="MycustomDG" TagPrefix="Saifi" %>  
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="uc/ucBooks.ascx" tagname="ucBooks" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
       <table cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="label_thailand_title" 
                    style="HEIGHT: 33px; TEXT-ALIGN: left; background-image: url(images/Template/other_by_author_bg.jpg);">
                    &nbsp;&nbsp; Customer Information</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="font_other" style="width: 100%">
                                <b>Hello,
                                <asp:Label ID="lblCustomer_Name" runat="server" CssClass="font_other"></asp:Label>
                                </b>,</td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px;">
                            </td>
                        </tr>
                        <tr>
                            <td class="font_other" style="width: 100%">
                                This is just a note to let you know that your account with www.asiabooks.com has 
                                been activated!</td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px;">
                                <asp:Label ID="Label1" runat="server" CssClass="labelmyaccount_head" 
                                    Text="User Name : "></asp:Label>
                                &nbsp;<asp:Label ID="lblName_Last" runat="server" CssClass="font_other"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px;">
                                <asp:Label ID="lbltype_member" runat="server" CssClass="labelmyaccount_head">Member 
                                ID or Account No :</asp:Label>
                                &nbsp;
                                <asp:Label ID="lblmember_code" runat="server" CssClass="font_other"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px;">
                                <asp:Label ID="Label2" runat="server" CssClass="labelmyaccount_head" 
                                    Text="Your email address :"></asp:Label>
                                &nbsp;<asp:Label ID="lblemail" runat="server" CssClass="font_other"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px;">
                                <asp:Label ID="Label3" runat="server" CssClass="labelmyaccount_head" 
                                    Text="Your Shipping Address :"></asp:Label>
                                &nbsp;<asp:Label ID="lbladdress" runat="server" CssClass="labelmyaccount_detail"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 100%">
                                <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/b_edit.jpg" />
                                &nbsp;
                                <asp:ImageButton ID="btnView_Detail" runat="server" 
                                    ImageUrl="~/images/sale_history.jpg" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                <asp:Panel ID="Panel_Keios" runat="server">
                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                <td class="label_thailand_title" 
                    style="HEIGHT: 33px; TEXT-ALIGN: left; background-image: url(images/Template/other_by_author_bg.jpg);">
                    &nbsp;&nbsp; Customer Order Wait for Payment</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <Saifi:MyDg ID="Datagrid_Keios" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" BorderColor="Transparent" CellPadding="5" 
                        CssClass="Grid_inq" GridLines="None" HeaderStyle-BackColor="#aaaadd" 
                        HeaderStyle-CssClass="tableHeader" HorizontalAlign="Center" 
                        ImageFirst="images/b_firstpage.gif" ImageLast="images/b_lastpage.gif" 
                        ImageNext="images/b_nextpage.gif" ImagePrevious="images/b_prevpage.gif" 
                        ItemStyle-CssClass="tableItem" 
                        SelectedItemStyle-BackColor="#99ccff" ShowFirstAndLastImage="True" 
                        ShowPreviousAndNextImage="True" 
                        style="BORDER-RIGHT: #047700 2px solid; BORDER-TOP: #047700 2px solid; BORDER-LEFT: #047700 2px solid; BORDER-BOTTOM: #047700 2px solid" 
                        UseAccessibleHeader="True" Width="98%">
                        <SelectedItemStyle BackColor="#99CCFF" />
                        <AlternatingItemStyle CssClass="Grid_inqAltItem" />
                        <ItemStyle CssClass="Grid_inqItem" />
                        <PagerStyle CssClass="Grid_inqPager" Mode="NumericPages" PageButtonCount="5" />
                        <Columns>
                            <asp:TemplateColumn HeaderText="Order No ">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <FooterTemplate>
                                    &nbsp;<asp:Label ID="lbltxt0" runat="server" __designer:wfdid="w52" Font-Bold="True" 
                                        Font-Names="Verdana" Font-Size="Smaller" ForeColor="#FF6600" 
                                        Text="Data not found in your search"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_OrderNo_Keiod" runat="server" __designer:wfdid="w51" 
                                        Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" 
                                        style="TEXT-ALIGN: left" 
                                        Text='<%# DataBinder.Eval(Container.DataItem,"Order_No") %>' Width="120px"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;
                                </ItemTemplate>
                                <HeaderStyle Width="15%" />
                                <ItemStyle Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Book Title">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Customer_Name_Keios" runat="server" __designer:wfdid="w44" 
                                        Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" 
                                        style="TEXT-ALIGN: left" 
                                        Text='<%# DataBinder.Eval(Container.DataItem,"Customer_Name") %>' 
                                        Width="170px"></asp:Label>
                                    &nbsp;
                                </ItemTemplate>
                                <HeaderStyle Width="30%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Order Date">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Order_Data_Keios" runat="server" __designer:wfdid="w46" 
                                        Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" 
                                        style="TEXT-ALIGN: center" 
                                        Text='<%# DataBinder.Eval(Container.DataItem,"Order_Date") %>' Width="100px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="15%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Amount">
                                <ItemTemplate>
                                    &nbsp;<asp:Label ID="lbl_Amount" runat="server" Font-Bold="False" 
                                        Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" 
                                        style="TEXT-ALIGN: left" 
                                        Text='<%# DataBinder.Eval(Container.DataItem,"Grand_Total") %>' Width="114px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Payment Code">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Transport_Type" runat="server" __designer:wfdid="w45" 
                                        Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" 
                                        style="TEXT-ALIGN: left" 
                                        Text='<%# DataBinder.Eval(Container.DataItem,"Keios_Post") %>' Width="60px"></asp:Label>
                                    &nbsp;
                                </ItemTemplate>
                                <HeaderStyle Width="15%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Select">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgupdate_keios" runat="server" __designer:wfdid="w40" 
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Order_No") %>' 
                                        CommandName="Edit" ImageUrl="~/images/confirm_pos.jpg" />
                                </ItemTemplate>
                                <HeaderStyle Width="10%" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                        </Columns>
                        <HeaderStyle BackColor="#49A514" BorderStyle="None" CssClass="Grid_inqHeader" 
                            Font-Bold="True" Font-Italic="False" Font-Names="Verdana" Font-Overline="False" 
                            Font-Size="11px" Font-Strikeout="False" Font-Underline="False" 
                            ForeColor="White" HorizontalAlign="Center" />
                    </Saifi:MyDg>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                 <asp:Panel ID="panPopUp_Keios" runat="server" HorizontalAlign="Center" style="display:none">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 500px; background-color: White;">
                <tr>
                    <td align="left" valign="top" style="width:9px; height:7px; background-image: url('images/Template/cart_head_start.jpg');"></td>
                    <td align="left" valign="top" style="background-image: url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                    <td align="left" valign="top" style="width:10px; height:7px; background-image: url('images/Template/cart_head_end.jpg');"></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                    <td align="center" valign="top">
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td align="right" style="width: 35%">
                                    &nbsp;</td>
                                <td align="left" style="width: 70%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" 
                                    style="font-family: arial, Helvetica, sans-serif; font-size: 10pt; color: #696969; font-weight: bold;" 
                                    colspan="2">
                                    Please enter the code (4 digits) to confirm your payment from POS @Shop</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 35%">
                                    &nbsp;</td>
                                <td align="left" style="width: 70%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" 
                                    style="width: 35%; height: 30px; font-size: 13pt; font-weight: bold;">
                                    Order No&nbsp; :&nbsp;&nbsp;
                                </td>
                                <td align="left" style="width: 70%; height: 30px;">
                                    <asp:Label ID="lblOrdert_No" runat="server" Font-Bold="True" Font-Size="13pt" 
                                        ForeColor="#006600"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" 
                                    style="width: 35%; height: 30px; font-size: 13pt; font-weight: bold;">
                                    Code&nbsp; :&nbsp;&nbsp;
                                </td>
                                <td align="left" style="width: 70%; height: 30px;">
                                    <asp:TextBox ID="txtKeios" runat="server" MaxLength="4"></asp:TextBox>
                                    &nbsp; <span style="color: #FF0000">ex. Code: 1234</span></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 35%">
                                    &nbsp;</td>
                                <td align="left" style="width: 70%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 35%">
                                    &nbsp;</td>
                                <td align="left" style="width: 70%">
                                    <asp:ImageButton ID="btnSave" runat="server" 
                                        ImageUrl="~/images/confirm_pos.jpg" />
                                    &nbsp;
                                    <asp:ImageButton ID="btnCancel" runat="server" 
                                        ImageUrl="~/images/b_cancel.jpg" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 35%">
                                    &nbsp;</td>
                                <td align="left" style="width: 70%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 35%">
                                    &nbsp;</td>
                                <td align="left" style="width: 70%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top" style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                </tr>
                <tr>
                   <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                    <td align="left" valign="top" style="height:10px; background-image:url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                    <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                </tr>
                </table>
                </asp:Panel>
                 <asp:ModalPopupExtender ID="mdlPopUp_Keios" TargetControlID="lnkKeios" 
                    PopupControlID="panPopUp_Keios" CancelControlID="btnCancel"
                    runat="server" BackgroundCssClass="ModelBackground" >
                 </asp:ModalPopupExtender>
                 <asp:LinkButton ID="lnkKeios" runat="server" style="display:none">LinkButton</asp:LinkButton>  
                 
                 
                 <asp:Panel ID="panPopUp_Msg" runat="server" HorizontalAlign="Center" style="display:none">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 500px; background-color: White;">
                <tr>
                    <td align="left" valign="top" style="width:9px; height:7px; background-image: url('images/Template/cart_head_start.jpg');"></td>
                    <td align="left" valign="top" style="background-image: url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                    <td align="left" valign="top" style="width:10px; height:7px; background-image: url('images/Template/cart_head_end.jpg');"></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                    <td align="center" valign="top" style="width: 100%">
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="width: 5%">
                                    &nbsp;</td>
                                <td style="width: 90%">
                                    &nbsp;</td>
                                <td style="width: 5%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">
                                    &nbsp;</td>
                                <td style="width: 90%">
                                    &nbsp;</td>
                                <td style="width: 5%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">
                                    &nbsp;</td>
                                <td style="width: 90%" align="left">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Your payment has been received and your order no.&nbsp;
                                    <asp:Label ID="lblMsgOrder_No" runat="server"></asp:Label>
                                    &nbsp; is already on process.</td>
                                <td style="width: 5%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">
                                    &nbsp;</td>
                                <td style="width: 90%">
                                    &nbsp;</td>
                                <td style="width: 5%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%; height: 25px;">
                                </td>
                                <td style="width: 90%; height: 25px;">
                                    <asp:ImageButton ID="btnCancel1" runat="server" ImageUrl="~/images/b_ok.jpg" />
                                </td>
                                <td style="width: 5%; height: 25px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 5%">
                                    &nbsp;</td>
                                <td style="width: 90%">
                                    &nbsp;</td>
                                <td style="width: 5%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top" style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                </tr>
                <tr>
                   <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                    <td align="left" valign="top" style="height:10px; background-image:url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                    <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                </tr>
                </table>
                </asp:Panel>
                 <asp:ModalPopupExtender ID="mdlPopUp_Msg" TargetControlID="lnkMsg" PopupControlID="panPopUp_Msg" 
                    runat="server" BackgroundCssClass="ModelBackground" >
                 </asp:ModalPopupExtender>
                 <asp:LinkButton ID="lnkMsg" runat="server" style="display:none">LinkButton</asp:LinkButton>     
                 
                 <asp:Panel ID="panPopUp_MsgError" runat="server" HorizontalAlign="Center" style="display:none">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 500px; background-color: White;">
                <tr>
                    <td align="left" valign="top" style="width:9px; height:7px; background-image: url('images/Template/cart_head_start.jpg');"></td>
                    <td align="left" valign="top" style="background-image: url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                    <td align="left" valign="top" style="width:10px; height:7px; background-image: url('images/Template/cart_head_end.jpg');"></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                    <td align="center" valign="top" style="width: 100%">
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="width: 5%">
                                    &nbsp;</td>
                                <td style="width: 90%">
                                    &nbsp;</td>
                                <td style="width: 5%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">
                                    &nbsp;</td>
                                <td style="width: 90%">
                                    &nbsp;</td>
                                <td style="width: 5%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">
                                    &nbsp;</td>
                                <td style="width: 90%" align="left">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Error. The code is not recognized. Please check that you have entered the correct code and try again.</td>
                                <td style="width: 5%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%">
                                    &nbsp;</td>
                                <td style="width: 90%">
                                    &nbsp;</td>
                                <td style="width: 5%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 5%; height: 25px;">
                                </td>
                                <td style="width: 90%; height: 25px;">
                                    <asp:ImageButton ID="btnCancel2" runat="server" ImageUrl="~/images/b_ok.jpg" />
                                </td>
                                <td style="width: 5%; height: 25px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 5%">
                                    &nbsp;</td>
                                <td style="width: 90%">
                                    &nbsp;</td>
                                <td style="width: 5%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top" style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                </tr>
                <tr>
                   <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                    <td align="left" valign="top" style="height:10px; background-image:url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                    <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                </tr>
                </table>
                </asp:Panel>
                 <asp:ModalPopupExtender ID="mdlPopUp_MsgError" TargetControlID="lnkMsgError" PopupControlID="panPopUp_MsgError" 
                    runat="server" BackgroundCssClass="ModelBackground" >
                 </asp:ModalPopupExtender>
                 <asp:LinkButton ID="lnkMsgError" runat="server" style="display:none">LinkButton</asp:LinkButton>                                                                         
                </td>
            </tr>
                    </table>
                
                </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="label_thailand_title" 
                    style="HEIGHT: 33px; TEXT-ALIGN: left; background-image: url(images/Template/other_by_author_bg.jpg);">
                    &nbsp;&nbsp; Your Order
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblChkeBook" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td align="left" class="labelsort_by" style="width: 20%; height: 30px;">
                                Order No. :
                            </td>
                            <td align="left" style="width: 30%; height: 30px;">
                                <asp:TextBox ID="txtOrder_No" runat="server" Height="18px" Width="200px"></asp:TextBox>
                            </td>
                            <td style="width: 5%; height: 30px;">
                            </td>
                            <td style="width: 45%; height: 30px;">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="labelsort_by" style="width: 20%; height: 30px;">
                                Original Order Date :
                            </td>
                            <td align="left" style="width: 30%; height: 30px;">
                               
                                <asp:TextBox ID="txtStartDate" runat="server" Height="18px" Width="200px"></asp:TextBox>
                               
                                <asp:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                 Enabled="True" TargetControlID="txtStartDate">
                                </asp:CalendarExtender>
                               
                            </td>
                            <td align="center" class="labelsort_by" style="width: 5%; height: 30px;">
                                To</td>
                            <td align="left" style="width: 45%; height: 30px;">
                               
                                <asp:TextBox ID="txtEndDate" runat="server" Height="18px" Width="200px"></asp:TextBox>
                               
                                <asp:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                  Enabled="True" TargetControlID="txtEndDate">
                                </asp:CalendarExtender>
                               
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="labelsort_by" style="width: 20%; height: 30px;">
                                Date Range:
                            </td>
                            <td class="font_other" colspan="3" style="height: 30px;">
                                <asp:RadioButton ID="rdio30day" runat="server" GroupName="a" 
                                    Text="past 30 days" />
                                <asp:RadioButton ID="rdio60day" runat="server" GroupName="a" 
                                    Text="past 60 days" />
                                <asp:RadioButton ID="rdio90day" runat="server" GroupName="a" 
                                    Text="past 90 days" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="labelsort_by" style="width: 20%">
                                &nbsp;</td>
                            <td style="width: 30%">
                                &nbsp;</td>
                            <td style="width: 5%">
                                &nbsp;</td>
                            <td style="width: 45%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" class="labelsort_by" style="width: 20%">
                                &nbsp;</td>
                            <td style="width: 30%">
                                <asp:ImageButton ID="b_search" runat="server" 
                                    ImageUrl="~/images/b_search.jpg" />
                            </td>
                            <td style="width: 5%">
                                &nbsp;</td>
                            <td style="width: 45%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" class="labelsort_by" style="width: 20%">
                                &nbsp;</td>
                            <td style="width: 30%">
                                &nbsp;</td>
                            <td style="width: 5%">
                                &nbsp;</td>
                            <td style="width: 45%">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label_Result" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <Saifi:MyDg ID="Datagrid" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" BorderColor="Transparent" CellPadding="5" 
                        CssClass="Grid_inq" GridLines="None" HeaderStyle-BackColor="#aaaadd" 
                        HeaderStyle-CssClass="tableHeader" HorizontalAlign="Center" 
                        ImageFirst="images/b_firstpage.gif" ImageLast="images/b_lastpage.gif" 
                        ImageNext="images/b_nextpage.gif" ImagePrevious="images/b_prevpage.gif" 
                        ItemStyle-CssClass="tableItem" OnEditCommand="Datagrid_EditCommand" 
                        OnPageIndexChanged="Datagrid_PageIndexChanged" 
                        SelectedItemStyle-BackColor="#99ccff" ShowFirstAndLastImage="True" 
                        ShowPreviousAndNextImage="True" 
                        style="BORDER-RIGHT: #047700 2px solid; BORDER-TOP: #047700 2px solid; BORDER-LEFT: #047700 2px solid; BORDER-BOTTOM: #047700 2px solid" 
                        UseAccessibleHeader="True" Width="98%">
                        <SelectedItemStyle BackColor="#99CCFF" />
                        <AlternatingItemStyle CssClass="Grid_inqAltItem" />
                        <ItemStyle CssClass="Grid_inqItem" />
                        <PagerStyle CssClass="Grid_inqPager" Mode="NumericPages" PageButtonCount="5" />
                        <Columns>
                            <asp:TemplateColumn HeaderText="Order No ">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <FooterTemplate>
                                    &nbsp;<asp:Label ID="lbltxt" runat="server" __designer:wfdid="w52" Font-Bold="True" 
                                        Font-Names="Verdana" Font-Size="Smaller" ForeColor="#FF6600" 
                                        Text="Data not found in your search"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Order_no" runat="server" __designer:wfdid="w51" 
                                        Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" 
                                        style="TEXT-ALIGN: left" 
                                        Text='<%# DataBinder.Eval(Container.DataItem,"Order_No") %>' Width="120px"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;
                                </ItemTemplate>
                                <HeaderStyle Width="15%" />
                                <ItemStyle Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Customer Name">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_CustomerName" runat="server" __designer:wfdid="w44" 
                                        Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" 
                                        style="TEXT-ALIGN: left" 
                                        Text='<%# DataBinder.Eval(Container.DataItem,"Customer_Name") %>' Width="170px"></asp:Label>
                                    &nbsp;
                                </ItemTemplate>
                                <HeaderStyle Width="30%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Member ID">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Member_Id" runat="server" __designer:wfdid="w45" 
                                        Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" 
                                        style="TEXT-ALIGN: left" 
                                        Text='<%# DataBinder.Eval(Container.DataItem,"Member_Id") %>' Width="60px"></asp:Label>
                                    &nbsp;
                                </ItemTemplate>
                                <HeaderStyle Width="15%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Order Date">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Order_Data" runat="server" __designer:wfdid="w46" 
                                        Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" 
                                        style="TEXT-ALIGN: center" 
                                        Text='<%# DataBinder.Eval(Container.DataItem,"Order_Date") %>' Width="100px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="15%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Branch Name">
                                <ItemTemplate>
                                    &nbsp;<asp:Label ID="lbl_Branch" runat="server" Font-Bold="False" 
                                        Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" 
                                        style="TEXT-ALIGN: left" 
                                        Text='<%# DataBinder.Eval(Container.DataItem,"Org_AB_Name") %>' Width="114px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Sale Channel" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Sales_Channel_Code" runat="server" Font-Names="Verdana" 
                                        Font-Size="11px" ForeColor="#4E4E4E" style="TEXT-ALIGN: left" 
                                        Text='<%# DataBinder.Eval(Container.DataItem,"Sales_Channel_Code") %>' 
                                        Width="70px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Select">
                                <ItemTemplate>
                                    <asp:ImageButton ID="b_Select" runat="server" __designer:wfdid="w40" 
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Order_No") %>' 
                                        CommandName="Edit" ImageUrl="~/images/b_view.jpg" />
                                </ItemTemplate>
                                <HeaderStyle Width="10%" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="sale_channel_code" Visible="False">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Sales_Channel_Name" runat="server" Font-Names="Verdana" 
                                        Font-Size="11px" ForeColor="#4E4E4E" style="TEXT-ALIGN: left" 
                                        Text='<%# DataBinder.Eval(Container.DataItem,"Sales_Channel_Name") %>' 
                                        Width="70px"></asp:Label>
                                    &nbsp;
                                </ItemTemplate>
                                <HeaderStyle Width="15%" />
                            </asp:TemplateColumn>
                        </Columns>
                        <HeaderStyle BackColor="#49A514" BorderStyle="None" CssClass="Grid_inqHeader" 
                            Font-Bold="True" Font-Italic="False" Font-Names="Verdana" Font-Overline="False" 
                            Font-Size="11px" Font-Strikeout="False" Font-Underline="False" 
                            ForeColor="White" HorizontalAlign="Center" />
                    </Saifi:MyDg>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <uc1:ucBooks ID="ucBooks1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>

        </table>
    
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


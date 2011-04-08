<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Magazine_Detail_Internet.aspx.vb" Inherits="Magazine_Detail_Internet" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="uc/ucBooks.ascx" tagname="ucBooks" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <table cellpadding="0" cellspacing="0" style="width: 98%" align="center">
<tr>
    <td style="width: 100%" align="left">
        <asp:Image ID="Imageshopping_step_01" runat="server" ImageUrl="~/images/Shopping_Step/shopping_step_01.gif" /></td>
</tr>
        <tr>
            <td style="width: 100%">
                <asp:Panel ID="Panel5" runat="server" CssClass="label_thailand_title" 
                    Visible="False">
                    Data not found
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                <asp:Panel ID="Panel4" runat="server">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr style="width:100%;">
                            <td colspan="5" 
                style="background-image: url(images/Template/CustomerReview_head_bg.jpg); height: 47px" 
                align="left">
                                &nbsp;&nbsp;
                                <asp:Label ID="lbltitle" runat="server" Font-Bold="True" Font-Names="Arial" 
                                    Font-Size="14pt" ForeColor="#FF3300"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 140px" valign="top" align="center">
                                <asp:Label ID="lblBook_Image" runat="server" Text="" Visible="false"></asp:Label>
                                
                                <table cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 100%">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image29" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
                                                <td valign="top" style="height: 7px; background-image: url('<% getUrl("/images/Template/cart_head_bg.jpg")%>')"></td>
                                                <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image30" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
                                            </tr>
                                            <tr>
                                                <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_left_bg.jpg")%>'); width: 9px"></td>
                                                <td align="center" valign="top" ><asp:Image ID="Imag_Book" runat="server" Width="136px" /></td>
                                                <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_right_bg.jpg")%>'); width: 10px;"></td>
                                            </tr>
                                            <tr>
                                                <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image31" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" Border="0" /></td>
                                                <td valign="top" style="height: 10px; background-image: url('<% getUrl("/images/Template/cart_footer_bg.jpg")%>')"></td>
                                                <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image32" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" Border="0" /></td>
                                            </tr>
                                       </table>
                                        
                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="width: 100%; height: 20px;" class="font_other">
                                            View :
                                            <asp:Label ID="lblview" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 100%; height: 20px;" class="font_other">
                                            <asp:Label ID="lblAverage" runat="server" Text="Average&nbsp;: " 
                                                Visible="False"></asp:Label>
                                            &nbsp;<asp:Image ID="imgCustomer_Average" runat="server" Visible="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:ImageButton ID="img_facebook" runat="server" 
                                                ImageUrl="~/images/facebook-logo.jpg" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:ImageButton ID="imgtweet" runat="server" 
                                                ImageUrl="~/images/twitter-logo.jpg" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 5%" valign="top" align="center">
                                &nbsp;&nbsp;&nbsp;</td>
                            <td valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="height:10px;" class="detailbook_head" colspan="2">
                                                <asp:Image ID="Image67" runat="server" 
                                                    ImageUrl="~/images/Template/icon_product_detail.jpg" />
                                                </td>
                                        </tr>
                                        <tr>
                                            <td class="detailbook_head" style="width: 25%; height:10px;">
                                                &nbsp;</td>
                                            <td style="width: 75%; height:10px;">
                                                <asp:Label ID="lblisbn" runat="server" CssClass="detailbook_detail" 
                                                    Visible="False"></asp:Label>
                                                <asp:Label ID="lblweight" runat="server" CssClass="detailbook_detail" 
                                                    Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%; height: 17px;" class="detailbook_head">
                                                Edition :</td>
                                            <td style="width: 75%; height: 17px;">
                                                <asp:Label ID="lblauthor" runat="server" CssClass="detailbook_detail"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%; height: 17px;" class="detailbook_head">
                                                Issue :</td>
                                            <td style="width: 75%; height: 17px;">
                                                <asp:Label ID="lblpublisher" runat="server" CssClass="detailbook_detail"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%; height: 17px;" class="detailbook_head">
                                                Language :</td>
                                            <td style="width: 75%; height: 17px;">
                                                <asp:Label ID="lbllanguage" runat="server" CssClass="detailbook_detail"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%; height: 17px;">
                                            </td>
                                            <td style="width: 75%; height: 17px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="detailbook_head" style="width: 25%; height: 17px;">
                                                Available Status :</td>
                                            <td style="width: 75%; height: 17px;">
                                                <asp:Label ID="lblavailable_status" runat="server" CssClass="detailbook_detail"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="detailbook_head" style="width: 25%" valign="top">
                                                Synopsis :</td>
                                            <td style="width: 75%">
                                                <asp:Label ID="lblsynopsis" runat="server" CssClass="detailbook_detail"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%">
                                            </td>
                                            <td style="width: 75%">
                                                <asp:Label ID="lblsource" runat="server" CssClass="detailbook_detail" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%">
                                            </td>
                                            <td style="width: 75%">
                                            </td>
                                        </tr>
                                    </table>

                               </td>
                            <td style="width: 10px" valign="top" align="center">
                                &nbsp;&nbsp;&nbsp;</td>
                            <td style="width: 138px" align="right" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image17" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
                                        <td valign="top" style="height: 7px; background-image: url('<% getUrl("/images/Template/cart_head_bg.jpg")%>')"></td>
                                        <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image18" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_left_bg.jpg")%>'); width: 9px"></td>
                                        <td align="center" valign="top" >
                                        <table border="0" cellpadding="0" cellspacing="0" 
                                    style="width: 138px; height: 119px">
                                                    <tr>
                                                        <td align="right" style="width: 138px; height: 69px" valign="top">
                                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                                                ForeColor="DarkGray" Text="List Price : Bt."></asp:Label>
                                                            <asp:Label ID="lbllist_price" runat="server" Font-Bold="True" 
                                                                Font-Names="Arial" Font-Size="9pt"
                                                ForeColor="DarkGray"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                                Font-Size="9pt" ForeColor="#006600" Text="Your Price : "></asp:Label>
                                                            <asp:Label ID="lblyour_price" runat="server" Font-Bold="True" 
                                                                Font-Names="Arial" Font-Size="9pt" ForeColor="#006600" 
                                                                Text='<%# Eval("your_price","{0:#,##0}") %>' />
                                                            <br />
                                                            <asp:Label ID="lblsave_price" runat="server" Font-Bold="True" 
                                                                Font-Names="Arial" Font-Size="9pt" ForeColor="#404040" 
                                                                Text='<%# Eval("price_save") %>' />
                                                            <br />
                                                            <asp:Label ID="lbl_price_usd" runat="server" Font-Names="Arial" Font-Size="9pt" 
                                                                ForeColor="#FF8000" Style="text-align: right" Width="90px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 138px; height: 30px" valign="middle">
                                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                                                ForeColor="DarkGray" Text="Quantity"></asp:Label>
                                                            <asp:TextBox ID="txt_qty" runat="server" Width="74px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="width: 138px; height: 25px" valign="bottom">
                                                            <asp:ImageButton ID="btnadd_to_cart" runat="server" 
                                                    ImageUrl="~/images/Template/add_to_cart.jpg" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="width: 138px; height: 25px" valign="bottom">
                                                            <asp:ImageButton ID="imgwish_list" runat="server" 
                                                ImageUrl="~/images/Template/wish_list_.jpg" />
                                                        </td>
                                                    </tr>
                                                </table></td>
                                        <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_right_bg.jpg")%>'); width: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image19" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" Border="0" /></td>
                                        <td valign="top" style="height: 10px; background-image: url('<% getUrl("/images/Template/cart_footer_bg.jpg")%>')"></td>
                                        <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image20" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" Border="0" /></td>
                                    </tr>
                               </table>
                              
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 140px" valign="top">
                            </td>
                            <td align="center" style="width: 10px" valign="top">
                            </td>
                            <td>
                            </td>
                            <td align="center" style="width: 10px" valign="top">
                            </td>
                            <td align="right" style="width: 138px" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="5" style="width: 98%" valign="top">
                                <asp:Panel ID="Panel6" runat="server">
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 100%; height: 27px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:Image ID="Image68" runat="server" 
                                                    ImageUrl="~/images/Template/icon_customer_reviews.jpg" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="left">
                                            <asp:Panel ID="panelStar" runat="server" Visible="false">
                                                <table style="width:40%">
                                                    <tr>
                                                        <td style="width:10%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt;" 
                                                            align="right">
                                                            &nbsp;</td>
                                                        <td align="right" 
                                                            style="width:2%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt;">
                                                            &nbsp;</td>
                                                        <td style="width:23%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; ">
                                                            Total :
                                                            <asp:Label ID="lblcustomer_review" runat="server"></asp:Label>
                                                            &nbsp;Review</td>
                                                        <td style="width:4%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; ">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" 
                                                            style="width:10%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt;">
                                                            <asp:Image ID="Image69" runat="server" ImageUrl="~/images/Template/star.jpg" />
                                                        </td>
                                                        <td align="right" 
                                                            style="width:2%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt;">
                                                            &nbsp;</td>
                                                        <td style="width:23%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; ">
                                                            <span ID="spanPost1" runat="server"></span>
                                                        </td>
                                                        <td style="width:4%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; ">
                                                            <asp:Label ID="lblcus_review1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:10%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt;" 
                                                            align="right">
                                                            <asp:Image ID="Image70" runat="server" ImageUrl="~/images/Template/star.jpg" />
                                                            <asp:Image ID="Image10" runat="server" ImageUrl="~/images/Template/star.jpg" />
                                                        </td>
                                                        <td align="right" 
                                                            style="width:2%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt;">
                                                            &nbsp;</td>
                                                        <td style="width:23%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; ">
                                                            <span ID="spanPost2" runat="server"></span>
                                                        </td>
                                                        <td style="width:4%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; ">
                                                            <asp:Label ID="lblcus_review2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:10%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt;" 
                                                            align="right">
                                                            <asp:Image ID="Image11" runat="server" ImageUrl="~/images/Template/star.jpg" />
                                                            <asp:Image ID="Image13" runat="server" ImageUrl="~/images/Template/star.jpg" />
                                                            <asp:Image ID="Image12" runat="server" ImageUrl="~/images/Template/star.jpg" />
                                                        </td>
                                                        <td align="right" 
                                                            style="width:2%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt;">
                                                            &nbsp;</td>
                                                        <td style="width:23%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; ">
                                                            <span ID="spanPost3" runat="server"></span>
                                                        </td>
                                                        <td style="width:4%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; ">
                                                            <asp:Label ID="lblcus_review3" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:10%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt;" 
                                                            align="right">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Template/star.jpg" />
                                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Template/star.jpg" />
                                                            <asp:Image ID="Image14" runat="server" ImageUrl="~/images/Template/star.jpg" />
                                                            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/Template/star.jpg" />
                                                        </td>
                                                        <td align="right" 
                                                            style="width:2%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt;">
                                                            &nbsp;</td>
                                                        <td style="width:23%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; ">
                                                            <span ID="spanPost4" runat="server"></span>
                                                        </td>
                                                        <td style="width:4%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; ">
                                                            <asp:Label ID="lblcus_review4" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:10%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt;" 
                                                            align="right">
                                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/images/Template/star.jpg" />
                                                            <asp:Image ID="Image71" runat="server" ImageUrl="~/images/Template/star.jpg" />
                                                            <asp:Image ID="Image72" runat="server" ImageUrl="~/images/Template/star.jpg" />
                                                            <asp:Image ID="Image15" runat="server" ImageUrl="~/images/Template/star.jpg" />
                                                            <asp:Image ID="Image16" runat="server" ImageUrl="~/images/Template/star.jpg" />
                                                        </td>
                                                        <td align="right" 
                                                            style="width:2%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt;">
                                                            &nbsp;</td>
                                                        <td style="width:23%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; ">
                                                            <span ID="spanPost5" runat="server"></span>
                                                        </td>
                                                        <td style="width:4%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; ">
                                                            <asp:Label ID="lblcus_review5" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table></asp:Panel>
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
                                            <td style="width: 100%">
                                                <asp:GridView ID="gvCustomer_Reviews" runat="server" AutoGenerateColumns="False" 
                                                    ShowHeader="False" Width="100%" GridLines="None">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                                    <tr>
                                                                        <td class="font_other" style="width: 2%; height: 10px;">
                                                                            &nbsp;</td>
                                                                        <td class="font_other" style="width: 98%; height: 10px;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="font_other" style="width: 2%">&nbsp;</td>
                                                                        <td class="font_other" style="width: 98%" align="left">
                                                                            <asp:Image ID="img_start" runat="server" />
                                                                            &nbsp;, <b>Create</b>
                                                                            <asp:Label ID="Label9" runat="server" Text='<%# bind("Created") %>'></asp:Label>
                                                                            <asp:Label ID="lblReView_Rate" runat="server" Text='<%# bind("ReView_Rate") %>' 
                                                                                Visible="False"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="font_other" style="width: 2%; height: 21px;">
                                                                            &nbsp;</td>
                                                                        <td class="font_other" style="width: 98%; height: 21px;" align="left">
                                                                            <b>By</b>
                                                                            <asp:Label ID="Label10" runat="server" Text='<%# bind("CreateBy") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="font_other" style="width: 2%">
                                                                            &nbsp;</td>
                                                                        <td class="font_other" style="width: 98%" align="left">
                                                                            <asp:Label ID="Label11" runat="server" Text='<%# bind("CusDiscussion") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 2%">
                                                                            &nbsp;</td>
                                                                        <td style="width: 98%">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnAdd_Review" runat="server" Text="Start a new discussion" 
                                                    Width="165px" />
                                                
                                                <br />
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="left">
                                                <asp:Panel ID="Panel_Discussion" runat="server" Visible="False">
                                                    <table cellpadding="0" cellspacing="0" style="width: 70%">
                                                        <tr>
                                                            <td align="left" class="labelmyaccount_head" style="width: 70%; height: 20px;">
                                                                Write a review</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 70%">
                                                                <asp:TextBox ID="txtDetail" runat="server" Height="179px" TextMode="MultiLine" 
                                                                    Width="472px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 70%; height: 14px;">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="labelmyaccount_head" style="width: 70%; height: 21px;">
                                                                Product Ratings</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 70%">
                                                                <table cellpadding="0" cellspacing="0" style="width: 40%">
                                                                    <tr>
                                                                        <td align="left" style="width: 20%">
                                                                            <asp:RadioButton ID="radio1" runat="server" GroupName="a" />
                                                                            <asp:Image ID="Image73" runat="server" 
                                                                                ImageUrl="~/images/Template/stars1.gif" />
                                                                        </td>
                                                                        <td align="left" style="width: 20%">
                                                                            <asp:RadioButton ID="radio4" runat="server" GroupName="a" />
                                                                            <asp:Image ID="Image76" runat="server" 
                                                                                ImageUrl="~/images/Template/stars4.gif" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" style="width: 20%">
                                                                            <asp:RadioButton ID="radio2" runat="server" GroupName="a" />
                                                                            <asp:Image ID="Image74" runat="server" 
                                                                                ImageUrl="~/images/Template/stars2.gif" />
                                                                        </td>
                                                                        <td align="left" style="width: 20%">
                                                                            <asp:RadioButton ID="radio5" runat="server" GroupName="a" />
                                                                            <asp:Image ID="Image77" runat="server" 
                                                                                ImageUrl="~/images/Template/stars5.gif" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" style="width: 20%">
                                                                            <asp:RadioButton ID="radio3" runat="server" GroupName="a" />
                                                                            <asp:Image ID="Image75" runat="server" 
                                                                                ImageUrl="~/images/Template/stars3.gif" />
                                                                        </td>
                                                                        <td align="left" style="width: 20%">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 70%">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 70%">
                                                                <asp:Button ID="btnNew_Dis" runat="server" Text="Submit" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 70%">
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
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
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 140px" valign="top">
                                &nbsp;</td>
                            <td align="center" style="width: 10px" valign="top">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td align="center" style="width: 10px" valign="top">
                                &nbsp;</td>
                            <td align="right" style="width: 138px" valign="top">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="5" style="width: 100%" valign="top">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 100%; height: 20px;" valign="top" colspan="5">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="5" style="width: 100%" valign="top">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 140px" valign="top">
                            </td>
                            <td align="center" style="width: 10px" valign="top">
                            </td>
                            <td>
                            </td>
                            <td align="center" style="width: 10px" valign="top">
                            </td>
                            <td align="right" style="width: 138px" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="5" style="width: 100%" valign="top">
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 140px" valign="top">
                                &nbsp;</td>
                            <td align="center" style="width: 10px" valign="top">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td align="center" style="width: 10px" valign="top">
                                &nbsp;</td>
                            <td align="right" style="width: 138px" valign="top">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
    </table>
<asp:ModalPopupExtender ID="ModalPopupAlert" TargetControlID="linkBtFadeMaster" 
    PopupControlID="panAlert" runat="server" BackgroundCssClass="ModelBackground" >
</asp:ModalPopupExtender>
    <asp:Panel ID="panAlert" runat="server" style="display:none">
        <div>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="background-color:White">
              <tr>
                <td><img src="images/ebook/corner_left_top_03.gif" width="15" height="15" /></td>
                <td width="270" background="images/ebook/top_04.gif"></td>
                <td><img src="images/ebook/corner_right_top_05.gif" width="15" height="15" /></td>
              </tr>
              <tr>
                <td width="15" height="120" background="images/ebook/left_07.gif"></td>
                <td align="center" style="font-weight:bold">You already have item(s) in wish list !!</td>
                <td background="images/ebook/right_09.gif"></td>
              </tr>
              <tr>
                <td width="15" height="40" background="images/ebook/left_07.gif"></td>
                <td align="center"><asp:ImageButton ID="btn_alertClose" runat="server" ImageUrl="~/images/ebook/Button/b_ok.jpg" /></td>
                <td background="images/ebook/right_09.gif"></td>
              </tr>
              <tr>
                <td><img src="images/ebook/corner_left_bottom_10.gif" width="15" height="15" /></td>
                <td background="images/ebook/bottom_11.gif"></td>
                <td><img src="images/ebook/corner_right_bottom_12.gif" width="15" height="15" /></td>
              </tr>
            </table> 
        </div>
    </asp:Panel>
<asp:LinkButton ID="linkBtFadeMaster" runat="server" style="display:none">LinkButton</asp:LinkButton>
</asp:Content>


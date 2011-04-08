<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="book_detail_internet.aspx.vb" Inherits="book_detail_internet" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="uc/ucCaptcha.ascx" tagname="captcha" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManagerProxy runat="server" ID="ScriptManagerProxy1" />
<table cellpadding="0" cellspacing="0" style="width: 98%" align="center">
<tr>
    <td style="width: 100%" align="left">
        <asp:Image ID="Imageshopping_step_01" runat="server" ImageUrl="~/images/Shopping_Step/shopping_step_01.gif" /></td>
</tr>
<tr>
    <td style="width: 100%">
        <asp:Panel ID="Panel5" runat="server" CssClass="label_thailand_title" Visible="False">
            Data not found
        </asp:Panel></td>
</tr>
<tr>
    <td style="width: 100%">
        <asp:Panel ID="Panel4" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="5" style="width:100%; height: 47px; ">
                <h1 style="font-family:Arial; font-size:20x; font-weight:bold; color:#FF6600;"><asp:Label ID="lbltitle" runat="server"/></h1></td>
        </tr>
        <tr>
            <td align="left" colspan="5" 
                
                style="width:100%; height: 20px; font-family: arial, Helvetica, sans-serif; font-size: 10pt; color: #333333;">
                by
                <asp:LinkButton ID="lnkAuthor_Head" runat="server"></asp:LinkButton>
            </td>
        </tr>
            <tr>
                <td align="left" colspan="5" style="width:100%; height: 20px;">
                    &nbsp;</td>
            </tr>
        <tr>
            <td style="width: 140px" valign="top" align="center">
                <asp:Label ID="lblBook_Image" runat="server" Text="" Visible="false" />
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 100%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <table border="0" cellpadding="0" cellspacing="0" style="width:156px;">
                        <tr>
                            <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                            <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                            <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                            <td align="center" valign="top"><asp:Image ID="Imag_Book" runat="server" Width="136px" /></td>
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
                    <td align="center" valign="top" style="width:100%; height:20px;" 
                        class="font_other">View&nbsp;:&nbsp;<asp:Label ID="lblview" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="height:20px;" class="font_other">
                        <asp:Label ID="lblAverage" runat="server" Text="Average&nbsp;: " 
                            Visible="False"></asp:Label>
                        <asp:Image ID="imgCustomer_Average" runat="server" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top">
                        <asp:HiddenField ID="hidden_ebook_id" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top"><asp:ImageButton ID="img_facebook" runat="server" ImageUrl="~/images/facebook-logo.jpg" /></td>
                </tr>
                <tr>
                    <td align="center" valign="top"><asp:ImageButton ID="imgtweet" runat="server" ImageUrl="~/images/twitter-logo.jpg" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top">&nbsp;</td>
                </tr>
                </table></td>
            <td style="width: 5%" valign="top" align="center">&nbsp;&nbsp;&nbsp;</td>
            <td align="left" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td colspan="2" align="left" valign="top" style="width:100%; height:25px; background-image:url('images/Template/icon_product_detail.jpg'); background-repeat:no-repeat; background-position:left;"></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="width: 25%; height:10px;" class="detailbook_head">&nbsp;</td>
                    <td align="left" valign="top" style="width: 75%;"><asp:Label ID="lblItem_Dis_Group" runat="server" Visible="False" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="height:17px;" class="detailbook_head">Author&nbsp;:&nbsp;</td>
                    <td align="left" valign="top"> <asp:LinkButton ID="lnkAuthor_Detail" runat="server" 
                            CssClass="detailbook_detail"></asp:LinkButton></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="height: 17px;" class="detailbook_head">ISBN&nbsp;:&nbsp;</td>
                    <td align="left" valign="top">
                       <asp:Label ID="lblisbn" runat="server" CssClass="detailbook_detail" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="height:17px;" class="detailbook_head">Publisher&nbsp;:&nbsp;</td>
                    <td align="left" valign="top"><asp:Label ID="lblpublisher" runat="server" CssClass="detailbook_detail" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="height:17px;" class="detailbook_head">Category&nbsp;:&nbsp;</td>
                    <td align="left" valign="top"><asp:Label ID="lblcategory" runat="server" CssClass="detailbook_detail" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="height:17px;" class="detailbook_head">Language&nbsp;:&nbsp;</td>
                    <td align="left" valign="top"><asp:Label ID="lbllanguage" runat="server" CssClass="detailbook_detail" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="height:17px;" class="detailbook_head">Size (W x H)&nbsp;:&nbsp;</td>
                    <td align="left" valign="top"><asp:Label ID="lblsize" runat="server" CssClass="detailbook_detail" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="height:17px;" class="detailbook_head">Weight&nbsp;:&nbsp;</td>
                    <td align="left" valign="top"><asp:Label ID="lblweight" runat="server" CssClass="detailbook_detail" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="height:17px;" class="detailbook_head">Binding&nbsp;:&nbsp;</td>
                    <td align="left" valign="top"><asp:Label ID="lblbinding" runat="server" CssClass="detailbook_detail" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="height:17px;" class="detailbook_head">Number of page&nbsp;:&nbsp;</td>
                    <td align="left" valign="top"><asp:Label ID="lblnumber_of_page" runat="server" CssClass="detailbook_detail" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="height:17px;" class="detailbook_head">Publication Date&nbsp;:&nbsp;</td>
                    <td align="left" valign="top"><asp:Label ID="lblpublication_date" runat="server" CssClass="detailbook_detail" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="height:17px;" class="detailbook_head">Copyrights Year&nbsp;:&nbsp;</td>
                    <td align="left" valign="top"><asp:Label ID="lblcopright" runat="server" CssClass="detailbook_detail" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="height:17px;">&nbsp;</td>
                    <td align="left" valign="top">&nbsp;</td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="height:17px;" class="detailbook_head">Available Status&nbsp;:&nbsp;</td>
                    <td align="left" valign="top" class="detailbook_detail"><asp:Label ID="lblavailable_status" runat="server" CssClass="detailbook_detail" />
                        <asp:Panel ID="Panel_Available" runat="server">
                            <asp:Label ID="lblavailable1" runat="server" Text="Available in "></asp:Label>
                            <asp:LinkButton ID="lnkStock_Ab" runat="server" Font-Strikeout="False" 
                                ForeColor="Blue">Asia Books</asp:LinkButton>
                            <asp:Label ID="lblAsiabooks" runat="server" Text="Asia Books" Visible="False"></asp:Label>
                            <asp:Label ID="lblavailable2" runat="server" Text="/"></asp:Label>
                            <asp:LinkButton ID="lnkStock_BZ" runat="server" ForeColor="Blue">Bookazine</asp:LinkButton>
                            <asp:Label ID="lblBookazine" runat="server" Text="Bookazine" Visible="False"></asp:Label>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" class="detailbook_head" >&nbsp;</td>
                    <td align="left" valign="top">&nbsp;</td>        
                </tr>
                <tr>
                    <td align="left" valign="top" class="detailbook_head" >Synopsis&nbsp;:&nbsp;</td>
                    <td align="left" valign="top"><asp:Label ID="lblsynopsis" runat="server" CssClass="detailbook_detail" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top">&nbsp;</td>
                    <td align="left" valign="top"><asp:Label ID="lblsource" runat="server" CssClass="detailbook_detail" Visible="False" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top">&nbsp;</td>
                    <td align="left" valign="top">&nbsp;</td>
                </tr>
                </table></td>
            <td align="center" valign="top" style="width:10px;">&nbsp;&nbsp;&nbsp;</td>
            <td align="right" valign="top" style="width:158px;">
                <table border="0" cellpadding="0" cellspacing="0" style="width:158px;">
                <tr>
                    <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                    <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                    <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                    <td align="center" valign="top" >
                        <table border="0" cellpadding="0" cellspacing="0" style="width:138px; height:119px;">
                        <tr>
                            <td align="right" valign="top" style="width:138px; height:69px;"><asp:Label ID="Label4" runat="server" 
                                Font-Bold="True" Font-Names="Arial" Font-Size="9pt" ForeColor="DarkGray" Text="List Price : Bt." />
                                <asp:Label ID="lbllist_price" runat="server" Font-Bold="True" Font-Names="Arial" 
                                    Font-Size="9pt" ForeColor="DarkGray" />
                                <br />
                                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" 
                                    ForeColor="#006600" Text="Your Price : " />
                                <asp:Label ID="lblyour_price" runat="server" Font-Bold="True" Font-Names="Arial" 
                                    Font-Size="9pt" ForeColor="#006600" Text='<%# Eval("your_price","{0:#,###}") %>' />
                                <br />
                                <asp:Label ID="lblsave_price" runat="server" Font-Bold="True" Font-Names="Arial" 
                                    Font-Size="9pt" ForeColor="#404040" Text='<%# Eval("price_save","{0:#,###}") %>' />
                                <br />
                                <asp:Label ID="lbl_price_usd" runat="server" Font-Names="Arial" Font-Size="9pt" 
                                    ForeColor="#FF8000" Style="text-align: right" Width="90px" /></td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle" style="height:30px"><asp:Label ID="Label1" runat="server" 
                                Font-Bold="True" Font-Names="Arial" Font-Size="9pt" ForeColor="DarkGray" Text="Quantity" />
                                <asp:TextBox ID="txt_qty" runat="server" Width="74px" /></td>
                        </tr>
                        <tr>
                            <td align="right" valign="bottom" style="height:25px">
                                <table cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td align="right" style="width: 35%" valign="middle">
                                            <asp:Image ID="Image78" runat="server" 
                                                ImageUrl="~/images/icon_add_to_cart.gif" />
                                        </td>
                                        <td align="right" style="width: 65%">
                                            <asp:ImageButton ID="btnadd_to_cart" runat="server" 
                                                ImageUrl="~/images/Template/add_to_cart.jpg" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 35%">
                                            &nbsp;</td>
                                        <td align="right" style="width: 65%">
                                            <asp:ImageButton ID="imgwish_list" runat="server" 
                                                ImageUrl="~/images/Template/wish_list_.jpg" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        </table></td>
                    <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                    <td align="left" valign="top" style="height:10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                    <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                </tr>
                </table>
               <%-- prompt now--%>
                <br/>
                <asp:Panel ID="pan_linkeBook" runat="server" Visible="false" >
                    <div style="cursor:pointer"><asp:ImageButton ID="btn_ebook" runat="server" ImageUrl="~/images/ebook/ebook_link.jpg" /></div>
                </asp:Panel>
                </td>
        </tr>
        <tr>
                            <td align="center" style="width: 140px" valign="top">
                            </td>
                            <td align="center" style="width: 5%" valign="top">
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
                    <td align="left" valign="top" style="width: 100%; height: 27px;"></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="height: 25px; background-image:url('images/Template/icon_customer_reviews.jpg'); background-repeat:no-repeat; background-position:left;"></td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="width: 100%">&nbsp;</td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="width: 100%">
                        <%--<asp:Panel ID="panelStar" runat="server" Visible="false">
                        <table style="width:40%">
                        <tr>
                            <td style="width:10%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt;" align="right">&nbsp;</td>
                            <td align="right" style="width:2%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt;">&nbsp;</td>
                            <td style="width:23%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; ">Total&nbsp;:&nbsp;<asp:Label ID="lblcustomer_review" runat="server" />&nbsp;Review</td>
                            <td style="width:4%; height:21px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; ">&nbsp;</td>
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
                        </table>
                        </asp:Panel>--%></td>
                </tr>
                <tr>
                    <td style="width: 100%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100%">&nbsp;</td>
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
                                    <td class="font_other" style="width: 2%; height: 10px;">&nbsp;</td>
                                    <td class="font_other" style="width: 98%; height: 10px;"></td>
                                </tr>
                                <tr>
                                    <td class="font_other" style="width: 2%">&nbsp;</td>
                                    <td class="font_other" style="width: 98%" align="left"><asp:Image ID="img_start" runat="server" />
                                        &nbsp;,<b>Create</b>&nbsp;<asp:Label ID="Label9" runat="server" Text='<%# bind("Created") %>' />
                                        <asp:Label ID="lblReView_Rate" runat="server" Text='<%# bind("ReView_Rate") %>' Visible="False" /></td>
                                </tr>
                                <tr>
                                    <td class="font_other" style="width: 2%; height: 21px;">&nbsp;</td>
                                    <td class="font_other" style="width: 98%; height: 21px;" align="left"><b>By&nbsp;</b><asp:Label ID="Label10" runat="server" Text='<%# bind("CreateBy") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="font_other" style="width: 2%">&nbsp;</td>
                                    <td class="font_other" style="width: 98%" align="left"><asp:Label ID="Label11" runat="server" Text='<%# bind("CusDiscussion") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 2%">&nbsp;</td>
                                    <td style="width: 98%">&nbsp;</td>
                                </tr>
                                </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView></td>
                </tr>
                <tr>
                    <td style="width: 100%">&nbsp;</td>
                </tr>
                <tr>
                    <td align="left" valign="top" style="width: 100%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnAdd_Review" runat="server" Text="Start a new discussion" Width="165px" />
                        <br /></td>
                </tr>
                <tr>
                    <td style="width: 100%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100%" align="left">
                        <asp:Panel ID="Panel_Discussion" runat="server" Visible="False">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 70%">
                            <tr>
                                <td align="left" class="labelmyaccount_head" style="width: 70%; height: 20px;">Write a review</td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 70%"><asp:TextBox ID="txtDetail" runat="server" Height="179px" TextMode="MultiLine" Width="472px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 70%; height: 14px;"></td>
                            </tr>
                            <tr>
                                <td align="left" class="labelmyaccount_head" style="width: 70%; height: 21px;">Product Ratings</td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 70%">
                                    <table cellpadding="0" cellspacing="0" style="width: 40%">
                                    <tr>
                                        <td align="left" style="width: 20%"><asp:RadioButton ID="radio1" runat="server" GroupName="a" />
                                            <asp:Image ID="Image73" runat="server" ImageUrl="~/images/Template/stars1.gif" />
                                        </td>
                                        <td align="left" style="width: 20%"><asp:RadioButton ID="radio4" runat="server" GroupName="a" />
                                            <asp:Image ID="Image76" runat="server" ImageUrl="~/images/Template/stars4.gif" /></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 20%"><asp:RadioButton ID="radio2" runat="server" GroupName="a" />
                                            <asp:Image ID="Image74" runat="server" ImageUrl="~/images/Template/stars2.gif" /></td>
                                        <td align="left" style="width: 20%"><asp:RadioButton ID="radio5" runat="server" GroupName="a" />
                                            <asp:Image ID="Image77" runat="server" ImageUrl="~/images/Template/stars5.gif" /></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 20%"><asp:RadioButton ID="radio3" runat="server" GroupName="a" />
                                            <asp:Image ID="Image75" runat="server" ImageUrl="~/images/Template/stars3.gif" /></td>
                                        <td align="left" style="width: 20%">&nbsp;</td>
                                    </tr>
                                    </table></td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 70%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 70%"><asp:Button ID="btnNew_Dis" runat="server" Text="Submit" /></td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 70%">&nbsp;</td>
                            </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100%">&nbsp;</td>
                </tr>
                </table>
                </asp:Panel></td>
        </tr>
        <tr>
            <td align="center" style="width: 140px" valign="top">&nbsp;</td>
            <td align="center" style="width: 10px" valign="top">&nbsp;</td>
            <td>&nbsp;</td>
            <td align="center" style="width: 10px" valign="top">&nbsp;</td>
            <td align="right" style="width: 138px" valign="top">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="top" colspan="5" style="width: 100%">
                <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                <tr>
                    <td align="center" style="width: 100%; height: 20px">
                        <asp:Panel ID="Panel2" runat="server">
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr style="width: 100%; height:31px; background-image:url('images/Template/other_by_author_bg.jpg'); background-repeat:repeat-x;">
                            <td align="left" style="width: 100%; height:31px; background-image:url('images/Template/other_by_author.jpg'); background-repeat:no-repeat; background-position:left;"></td>
                        </tr>
                        </table>
                        </asp:Panel></td>
                </tr>
                <tr>
                    <td align="center" style="width: 100%; height: 20px">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100%" align="left">
                        <asp:ListView runat="server" ID="lvBooks_Author">
                        <LayoutTemplate>
                            <div>
                                <ol class="bookab_detail table-style_detail">
                                    <li ID="itemPlaceholder" runat="server"></li>
                                </ol>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                        <li>
                            <span class="width-fixer">
                            <div class="PZ3zoom" style="width:92px; height:120px;">
                            <table border="0" cellpadding="0" cellspacing="0" style="width:92px;">
                            <tr>
                                <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                                <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                                <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top"><a href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>' ><asp:Image id="imag_book_cat" runat="server" /></a>
                                    <asp:Label id="lblimage_book" runat="server" Visible="false" Text='<%# Eval("image")%>'></asp:Label></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                <td align="left" valign="top" style="height:10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                                <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                            </tr>
                            </table></div>
                            <div style="height:5px;"></div>
                            <div class="book-title">
                                <a style="text-decoration:none;" class="book-title" href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>' rel="add-to-cart">
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("book_title")%>' ToolTip='<%#Eval("book_title_full")%>'></asp:Label></a></div>
                            <div class="book-author">
                                <a style="text-decoration:none;" class="book-author" href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>'>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("author")%>' ToolTip='<%#Eval("author_full")%>'></asp:Label></a></div>
                            <div class="book-space"></div>
                            <div class="book-priceBaht">
                                <asp:Label ID="lblList_Price_H" runat="server" Text="List Price : Bt."></asp:Label>
                                <asp:Label ID="lblList_Price_D" runat="server" Text='<%#Eval("selling_price","{0:#,###}")%>'></asp:Label>
                            </div>
                            <div class="book-yourprice">Your Price : 
                                <asp:Label ID="lblYour_Price" runat="server" Text='<%#Eval("Selling_price_eComN","{0:#,###}")%>'></asp:Label></div>
                            <div class='book-priceUSD'>US$ <asp:Label ID="lblprice_us" runat="server" Text=''></asp:Label></div>
                            <div class='book-save'>
                                <asp:Label ID="lblsave_price_L" runat="server" Text="(Save "></asp:Label>
                                <asp:Label ID="lblsave_price_C" runat="server" Text='<%#Eval("save_price","{0:#,###}")%>'></asp:Label>
                                <asp:Label ID="lblsave_price_R" runat="server" Text="%)"></asp:Label></div>
                            <div class='book-imagestar'>
                                <asp:Image ID="imgCustomer_Average_Author" runat="server" />
                                <asp:Label ID="Label3" runat="server"  ForeColor="#FF8000" Font-Size="8pt" Text="( "></asp:Label>
                                <asp:Label ID="lblCustomerView_Author" runat="server" ForeColor="#FF8000" Font-Size="8pt"></asp:Label>
                                <asp:Label ID="Label4" runat="server"  ForeColor="#FF8000" Font-Size="8pt" Text=" )"></asp:Label></div>
                            <a href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>' rel="add-to-cart"><asp:Image runat="server" ID="imgAddToCart" ImageUrl="~/images/Template/add_to_cart.jpg" style="border:0;" class="add-to-cart-button" /></a>
                            <asp:Label ID="lblisbn_author" runat="server" Text='<%#Eval("isbn_13")%>' Visible="false"></asp:Label>
                            </span>
                        </li>
                        </ItemTemplate>
                        </asp:ListView></td>
                </tr>
                </table></td>
        </tr>
        <tr>
            <td align="center" valign="top" colspan="5" style="width: 100%; height: 20px;">&nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="5" style="width: 100%" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; ">
                <tr>
                   <td align="left" valign="top">
                        <asp:Panel ID="Panel3" runat="server">
                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr style="height:30px; background-image: url(images/Template/if_you_love_bg.jpg); background-repeat:repeat-x;">
                                <td align="left" style="width: 100%; height: 30px; background-image:url('images/Template/if_you_love.jpg'); background-position:left; background-repeat:no-repeat;"></td>
                            </tr>
                            </table>
                        </asp:Panel></td>
                </tr>
                <tr>
                    <td style="width:100%; height:20px;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <asp:ListView runat="server" ID="lvBooks_Cat">
                        <LayoutTemplate>
                            <div>
                            <ol class="bookab_detail table-style_detail">
                                <li ID="itemPlaceholder" runat="server"></li>
                            </ol>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li>
                                <span class="width-fixer">
                                    <div class="PZ3zoom" style="width:92px; height:120px;">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width:92px;">
                                    <tr>
                                        <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                                        <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                                        <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                        <td align="center" valign="top" ><a href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>' ><asp:Image id="imag_book_cat" runat="server"/></a>
                                            <asp:Label id="lblimage_book" runat="server" Visible="false" Text='<%# Eval("image")%>'></asp:Label></td>
                                        <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                        <td align="left" valign="top" style="height:10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                                        <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                                    </tr>
                                    </table>
                                    </div>
                                    <div style="height:5px;"></div>
                                    <div class="book-title">
                                        <a style="text-decoration:none;" class="book-title" href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>' rel="add-to-cart">
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("book_title")%>' ToolTip='<%#Eval("book_title_full")%>'></asp:Label></a></div>
                                    <div class="book-author">
                                        <a style="text-decoration:none;" class="book-author" href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>'>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("author")%>' ToolTip='<%#Eval("author_full")%>'></asp:Label></a></div>
                                    <div class="book-space"></div>
                                    <div class="book-priceBaht">
                                        <asp:Label ID="lblList_Price_H" runat="server" Text="List Price : Bt."></asp:Label>
                                        <asp:Label ID="lblList_Price_D" runat="server" Text='<%#Eval("selling_price","{0:#,###}")%>'></asp:Label></div>
                                    <div class="book-yourprice">Your Price : 
                                        <asp:Label ID="lblYour_Price" runat="server" Text='<%#Eval("your_price","{0:#,###}")%>'></asp:Label></div>
                                    <div class='book-priceUSD'>US$ <asp:Label ID="lblprice_us" runat="server" Text=''></asp:Label></div>
                                    <div class='book-save'>
                                        <asp:Label ID="lblsave_price_L" runat="server" Text="(Save "></asp:Label>
                                        <asp:Label ID="lblsave_price_C" runat="server" Text='<%#Eval("save_price","{0:#,###}")%>'></asp:Label>
                                        <asp:Label ID="lblsave_price_R" runat="server" Text="%)"></asp:Label></div>
                                    <div class='book-imagestar'>
                                        <asp:Image ID="imgCustomer_Average_Cat" runat="server" />
                                        <asp:Label ID="Label3" runat="server" ForeColor="#FF8000" Font-Size="8pt" Text="( "></asp:Label>
                                        <asp:Label ID="lblCustomerView_Cat" runat="server"  ForeColor="#FF8000" Font-Size="8pt"></asp:Label>
                                        <asp:Label ID="Label4" runat="server"  ForeColor="#FF8000" Font-Size="8pt" Text=" )"></asp:Label></div>
                                    <a href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>' rel="add-to-cart"><asp:Image runat="server" ID="imgAddToCart" ImageUrl="~/images/Template/add_to_cart.jpg" style="border:0;" class="add-to-cart-button" /></a>
                                    <asp:Label ID="lblisbn_cat" runat="server" Text='<%#Eval("isbn_13")%>' Visible="false"></asp:Label>
                                </span>
                            </li>
                        </ItemTemplate>
                        </asp:ListView></td>
                </tr>
                <tr>
                    <td align="center" style="width: 100%; height: 20px">&nbsp;</td>
                </tr>
                </table></td>
        </tr>
        <tr>
            <td align="center" style="width: 140px" valign="top">&nbsp;</td>
            <td align="center" style="width: 10px" valign="top">&nbsp;</td>
            <td>&nbsp;</td>
            <td align="center" style="width: 10px" valign="top">&nbsp;</td>
            <td align="right" style="width: 138px" valign="top">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="5" style="width: 100%" valign="top"></td>
        </tr>
            <tr>
                <td align="center" colspan="5" style="width: 100%" valign="top"></td>
            </tr>
        <tr>
            <td align="center" style="width: 140px" valign="top">&nbsp;</td>
            <td align="center" style="width: 10px" valign="top">&nbsp;</td>
            <td>&nbsp;</td>
            <td align="center" style="width: 10px" valign="top">&nbsp;</td>
            <td align="right" style="width: 138px" valign="top">&nbsp;</td>
        </tr>
        </table>
        </asp:Panel></td>
</tr>
<tr>
    <td style="width: 100%">&nbsp;</td>
</tr>
</table>
<asp:Panel ID="panCheck_Promotion" runat="server" HorizontalAlign="Center" style="display:none">
<table border="0" cellpadding="0" cellspacing="0" style="width:450px; background-color:White;">
<tr>
    <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
    <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
    <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
    <td align="center" valign="top">
        <table cellpadding="0" cellspacing="0" style="width: 90%">
        <tr>
            <td align="right" style="height: 25px"></td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td class="font_about_us" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblPopUp" runat="server" /></td>
        </tr>
        <tr>
            <td class="font_about_us" align="left"><asp:Label ID="lblPopUp2" runat="server" /></td>
        </tr>
        <tr>
            <td class="font_other" style="height: 19px"></td>
        </tr>
        <tr>
            <td class="font_other" align="center"><asp:ImageButton ID="img_add_to_cart" runat="server" ImageUrl="~/images/b_ok.jpg" />
                &nbsp;<asp:ImageButton ID="btnCancelPro" runat="server" ImageUrl="~/images/b_cancel.jpg" />&nbsp;</td>
        </tr>
        <tr>
            <td class="font_other"></td>
        </tr>
        <tr>
            <td class="font_other" style="height: 25px"></td>
        </tr>
        </table></td>
    <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
    <td align="left" valign="top" style="height:10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
    <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
</tr>
</table>
</asp:Panel>
<asp:ModalPopupExtender ID="mdlPopupCheck_Promotion" TargetControlID="linkBtFadeMaster" 
    PopupControlID="panCheck_Promotion" CancelControlID="btnCancelPro" runat="server" BackgroundCssClass="ModelBackground" >
</asp:ModalPopupExtender>
<asp:Panel ID="panCheckMeassge" runat="server" HorizontalAlign="Center"  style="display:none">
<table border="0" cellpadding="0" cellspacing="0" style="width: 450px; background-color:White;">
<tr>
    <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
	<td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
	<td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
    <td align="center" valign="top" >
        <table cellpadding="0" cellspacing="0" style="width: 90%">
        <tr>
            <td align="right" style="height: 25px"></td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td class="font_about_us" align="left"><asp:Label ID="lblCheck_Meassge" runat="server" /></td>
        </tr>
        <tr>
            <td class="font_other" style="height: 19px"></td>
        </tr>
        <tr>
            <td class="font_other" align="center"><asp:ImageButton ID="img_Msg_OK" runat="server" ImageUrl="~/images/b_ok.jpg" />
                &nbsp;<asp:ImageButton ID="img_Msg_Cancel" runat="server" ImageUrl="~/images/b_cancel.jpg" /></td>
        </tr>
        <tr>
            <td class="font_other"></td>
        </tr>
        <tr>
            <td class="font_other" style="height: 25px"></td>
        </tr>
        </table></td>
    <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
	<td align="left" valign="top" style="height:10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
	<td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
</tr>
</table>
</asp:Panel>
<asp:ModalPopupExtender ID="mdlPopUp_CheckMeassge" TargetControlID="linkBtFadeMaster" 
    PopupControlID="panCheckMeassge" runat="server" BackgroundCssClass="ModelBackground" >
</asp:ModalPopupExtender>

<asp:Panel ID="panel_stock" runat="server" HorizontalAlign="Center" style="display:none">
<table border="0" cellpadding="0" cellspacing="0" style="width:550px; background-color:White;">
<tr>
    <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
    <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
    <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;">
        &nbsp;</td>
    <td align="left" valign="top" >
        <asp:Label ID="lblAvailable_Stock" runat="server" 
            Text="Available at Asia Books’ shops:" Font-Bold="True" Font-Names="Arial" 
            Font-Size="14pt" ForeColor="#0066FF"></asp:Label>
    </td>
    <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;">
        &nbsp;</td>
</tr>
    <caption>
        <br />
        <tr>
            <td align="left" 
                style="width: 9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat: repeat-y;" 
                valign="top">
            </td>
            <td align="center" valign="top" class="font_other">
                <br />
                <asp:UpdatePanel ID="UpdatePanel_Stock" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvStock" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="500px">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#D9EBBD" />
                            <Columns>
                                <asp:TemplateField HeaderText="Branch">
                                    <ItemTemplate>
                                        <a href='Store_Event_Detail.aspx?Branch_Code=<%# Eval("Org_AB_Code")%> &Branch_Group=<%# Eval("Group_Code") %>'>
                                        <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("Org_AB_Name") %>'>
                                        </asp:Label>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Tel" HeaderText="Telephone">
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="qty" HeaderText="Quantity">
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle BackColor="#009933" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#EAFFEA" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#009933" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="left" 
                style="width: 10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat: repeat-y;" 
                valign="top">
            </td>
        </tr>
    </caption>
    </tr>
    <tr>
        <td align="left" 
            style="width: 9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat: repeat-y; height: 11px;" 
            valign="top">
            </td>
        <td align="left" class="font_other" valign="top" style="height: 11px">
        </td>
        <td align="left" 
            style="width: 10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat: repeat-y; height: 11px;" 
            valign="top">
            </td>
    </tr>
    <tr>
        <td align="left" 
            style="width: 9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat: repeat-y; height: 23px;" 
            valign="top">
        </td>
        <td align="left" class="font_other" style="height: 23px; font-weight:bold;" valign="top">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color: #FF0000">** </span>The stock is subject to change 
            without notice.
            <asp:Label ID="lblGroup_Code" runat="server" Visible="False"></asp:Label>
            <br />
        </td>
        <td align="left" 
            style="width: 10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat: repeat-y; height: 23px;" 
            valign="top">
        </td>
    </tr>
    <tr>
        <td align="left" 
            style="width: 9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat: repeat-y;" 
            valign="top">
            &nbsp;</td>
        <td align="center" class="font_other" valign="top">
            <asp:ImageButton ID="btnCancel_Stock" runat="server" 
                ImageUrl="~/images/close_button.gif" />
        </td>
        <td align="left" 
            style="width: 10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat: repeat-y;" 
            valign="top">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" 
            style="width: 9px; height: 10px; background-image: url('images/Template/cart_footer_start.jpg');" 
            valign="top">
        </td>
        <td align="left" 
            style="height: 10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat: repeat-x;" 
            valign="top">
        </td>
        <td align="left" 
            style="width: 10px; height: 10px; background-image: url('images/Template/cart_footer_end.jpg');" 
            valign="top">
        </td>
    </tr>
</table></asp:Panel>
<asp:ModalPopupExtender ID="mdlStock" TargetControlID="linkBtFadeMaster" 
    PopupControlID="panel_stock" CancelControlID="btnCancel_Stock" runat="server" BackgroundCssClass="ModelBackground" >
</asp:ModalPopupExtender>
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
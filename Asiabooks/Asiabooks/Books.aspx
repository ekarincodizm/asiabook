<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Books.aspx.vb" Inherits="Books" title="Untitled Page" %>
<%@ Register Src="uc/ucBooks.ascx" TagName="ucBooks" TagPrefix="uc3" %>
<%@ Register Src="uc/ucPromotion.ascx" TagName="ucPromotion" TagPrefix="uc2" %>
<%@ Register Assembly="MycustomDG" Namespace="MycustomDG" TagPrefix="Saifi" %>
<%@ Register Src="uc/ucfeatured.ascx" TagName="ucfeatured" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
<tr>
    <td colspan="2" style="width:100%; height:32px; background-image:url('images/Template/new_releases.jpg'); background-position:left; background-repeat:no-repeat;"></td>
</tr>
<tr>
    <td colspan="2" style="width: 100%; height: 7px">&nbsp;</td>
</tr>
<tr>
    <td colspan="2" style="width: 100%">
    
    </td>
</tr>
<tr>
    <td style="width: 100%">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                <cc1:tabcontainer id="tbMain" runat="server" CssClass="ajax__tab_yuitabview-theme" ActiveTabIndex="0" >
                <cc1:TabPanel runat="server" ID="TabPanel1">
                <HeaderTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Template/book_this_week.jpg" />
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:UpdatePanel runat="server" ID="upMaster1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel runat="server" ID="pnlDetail1">
                        <table style="width:100%;" cellpadding="0" cellspacing="0">
                        <tr style="width:100%; height:237px; background-image:url('<% getUrl("/images/Template/tab_detail_bg.jpg")%>');">
                            <td style="width:3px; height:237px;" align="left"><asp:Image ID="Image33" runat="server" 
                                ImageUrl="~/images/Template/tab_left.jpg" Width="3px" Height="237px" /></td>
                            <td valign="top">
                                <table style="width:100%;" cellpadding="0" cellspacing="0">
                                <tr style="width:100%;" align="center">
                                    <td><asp:DataList ID="dtlThis_Week" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" Width="100%">
                                        <ItemTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td align="center" style="width: 100%; height: 20px;" valign="middle"></td>
                                        </tr>
                                            <tr>
                                                <td align="center" style="width: 100%;" valign="middle">
                                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                        <tr>
                                                            <td style="width: 20%">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 80%">
                                                                
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image17" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
                                                                        <td valign="top" style="height: 7px; background-image: url('<% getUrl("/images/Template/cart_head_bg.jpg")%>')"></td>
                                                                        <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image18" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_left_bg.jpg")%>'); width: 9px"></td>
                                                                        <td align="center" valign="top" >
                                                                            <a href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13") %>' style="text-decoration:none;">
                                                                            <asp:Image ID="Book_Image_week" runat="server" Height="140px" ImageUrl='<%# Eval("image") %>' Width="100px" /></a></td>
                                                                        <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_right_bg.jpg")%>'); width: 10px;"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image19" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" /></td>
                                                                        <td valign="top" style="height: 10px; background-image: url('<% getUrl("/images/Template/cart_footer_bg.jpg")%>')"></td>
                                                                        <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image20" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" /></td>
                                                                    </tr>
                                                               </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 80%">
                                                                <asp:Label ID="Label1" runat="server" CssClass="labelBest_Title" 
                                                                    Text='<%# bind("book_title") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 80%">
                                                                <asp:Label ID="Label2" runat="server" CssClass="font_book_title" 
                                                                    Text='<%# bind("author") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 100%" valign="middle">
                                                    <asp:Label ID="lblisbn_week" runat="server" Text='<%# Eval("isbn_13") %>' 
                                                        Visible="False" />
                                                </td>
                                            </tr>
                                        </table>
                                        </ItemTemplate>
                                        </asp:DataList></td>
                               </tr>
                            <tr style="width:100%;" align="right">
                                <td><a href="#" runat="server" id="lnkMore_ThisWeek" style="text-decoration:none;" class="see_more2">See more..</a></td>
                            </tr>
                            </table></td>
                            <td style="width:3px; height:237px;" align="right"><asp:Image ID="Image44" runat="server" 
                                ImageUrl="~/images/Template/tab_right.jpg" Width="3px" Height="237px" /></td>
                        </tr>
                        </table>
                        </asp:Panel>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel runat="server" ID="TabPanel2">
                <HeaderTemplate>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Template/book_this_month.jpg" />
                </HeaderTemplate>
                <ContentTemplate>
                <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Panel runat="server" ID="Panel1">
                    <table style="width:100%;" cellpadding="0" cellspacing="0">
                    <tr style="width:100%; height:237px; background-image:url('<% getUrl("/images/Template/tab_detail_bg.jpg")%>');">
                        <td style="width:3px; height:237px;" align="left"><asp:Image ID="Image3" runat="server" 
                            ImageUrl="~/images/Template/tab_left.jpg" Width="3px" Height="237px" /></td>
                        <td valign="top">
                            <table style="width:100%;" cellpadding="0" cellspacing="0">
                            <tr style="width:100%;" align="center">
                                <td><asp:DataList ID="dtlThis_Month" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" Width="100%">
                                    <ItemTemplate>
                                     <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td align="center" style="width: 100%; height: 20px;" valign="middle"></td>
                                        </tr>
                                            <tr>
                                                <td align="center" style="width: 100%;" valign="middle">
                                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                        <tr>
                                                            <td style="width: 20%">
                                                                </td>
                                                            <td align="left" style="width: 80%">
                                                                
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image17" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
                                                                        <td valign="top" style="height: 7px; background-image: url('<% getUrl("/images/Template/cart_head_bg.jpg")%>')"></td>
                                                                        <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image18" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_left_bg.jpg")%>'); width: 9px"></td>
                                                                        <td align="center" valign="top" >
                                                                            <a href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13") %>' style="text-decoration:none;">
                                                                            <asp:Image ID="Book_Image_month" runat="server" Height="140px" ImageUrl='<%# Eval("image") %>' Width="100px" /></a></td>
                                                                        <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_right_bg.jpg")%>'); width: 10px;"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image19" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" /></td>
                                                                        <td valign="top" style="height: 10px; background-image: url('<% getUrl("/images/Template/cart_footer_bg.jpg")%>')"></td>
                                                                        <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image20" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" /></td>
                                                                    </tr>
                                                               </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 80%">
                                                                <asp:Label ID="Label1" runat="server" CssClass="labelBest_Title" 
                                                                    Text='<%# bind("book_title") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 80%">
                                                                <asp:Label ID="Label2" runat="server" CssClass="font_book_title" 
                                                                    Text='<%# bind("author") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 100%" valign="middle">
                                                    <asp:Label ID="lblisbn_month" runat="server" Text='<%# Eval("isbn_13") %>' 
                                                        Visible="False" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList></td>
                            </tr>
                            <tr style="width:100%;" align="right">
                                <td><a href="#" runat="server" id="lnkMore_ThisMonth" style="text-decoration:none;" class="see_more2">See more..</a></td>
                            </tr>
                            </table></td>
                            <td style="width:3px; height:237px;" align="right"><asp:Image ID="Image4" runat="server" 
                                ImageUrl="~/images/Template/tab_right.jpg" Width="3px" Height="237px" /></td>
                        </tr>
                        </table>
                        </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel runat="server" ID="TabPanel3">
                <HeaderTemplate>
                    <asp:Image ID="Image23" runat="server" ImageUrl="~/images/Template/book_featured_item.jpg" />
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel22" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="Panel12">
                            <table style="width:100%;" cellpadding="0" cellspacing="0">
                            <tr style="width:100%; height:237px; background-image:url('<% getUrl("/images/Template/tab_detail_bg.jpg")%>');">
                                <td style="width:3px; height:237px;" align="left"><asp:Image ID="Image31" runat="server" 
                                    ImageUrl="~/images/Template/tab_left.jpg" Width="3px" Height="237px" /></td>
                                <td valign="top">
                                    <table style="width:100%;" cellpadding="0" cellspacing="0">
                                    <tr style="width:100%;" align="center">
                                        <td><asp:DataList ID="dtlFeatured_Items" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" Width="100%">
                                            <ItemTemplate>
                                             <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td align="center" style="width: 100%; height: 20px;" valign="middle"></td>
                                        </tr>
                                            <tr>
                                                <td align="center" style="width: 100%;" valign="middle">
                                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                        <tr>
                                                            <td style="width: 20%">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 80%">
                                                                
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image17" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
                                                                        <td valign="top" style="height: 7px; background-image: url('<% getUrl("/images/Template/cart_head_bg.jpg")%>')"></td>
                                                                        <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image18" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_left_bg.jpg")%>'); width: 9px"></td>
                                                                        <td align="center" valign="top" >
                                                                             <a style="text-decoration:none;" href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13") %>'>
                                                                            <asp:Image ID="Book_Image_releases" runat="server" Height="140px" Width="100px" ImageUrl='<%# Eval("image") %>' /></a></td>
                                                                        <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_right_bg.jpg")%>'); width: 10px;"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image19" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" /></td>
                                                                        <td valign="top" style="height: 10px; background-image: url('<% getUrl("/images/Template/cart_footer_bg.jpg")%>')"></td>
                                                                        <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image20" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" /></td>
                                                                    </tr>
                                                               </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 80%">
                                                                <asp:Label ID="Label1" runat="server" CssClass="labelBest_Title" 
                                                                    Text='<%# bind("book_title") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 80%">
                                                                <asp:Label ID="Label2" runat="server" CssClass="font_book_title" 
                                                                    Text='<%# bind("author") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 100%" valign="middle">
                                                    <asp:Label ID="lblisbn_releases" runat="server" Text='<%# Eval("isbn_13") %>' 
                                                        Visible="False" />
                                                </td>
                                            </tr>
                                        </table>                                                
                                            </ItemTemplate>
                                            </asp:DataList></td>
                                    </tr>
                                    <tr style="width:100%;" align="right">
                                        <td><a href="#" runat="server" id="lnkMore_Featured_Items" style="text-decoration:none;" class="see_more2">See more..</a></td>
                                    </tr>
                                    </table></td>
                                    <td style="width:3px; height:237px;" align="right"><asp:Image ID="Image41" runat="server" 
                                        ImageUrl="~/images/Template/tab_right.jpg" Width="3px" Height="237px" /></td>
                            </tr>
                            </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </cc1:TabPanel>
            </cc1:tabcontainer>
        </ContentTemplate>
    </asp:UpdatePanel>
    </td>
    <td style="width: 201px" rowspan="3" valign="top">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="right" style="width: 100%" valign="top"><uc2:ucPromotion ID="UcPromotion1" runat="server" /></td>
        </tr>
        </table></td>
</tr>
<tr>
    <td>&nbsp;</td>
</tr>
<tr>
    <td align="left" valign="top">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 100%">
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td class="font_other" style="width: 250px">See more books in each popular category&nbsp;&nbsp;:&nbsp;</td>
                    <td><asp:DropDownList ID="ddlCat" runat="server" AutoPostBack="True" Height="22px" Width="230px" /></td>
                </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 100%; height: 20px;"></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%"><uc3:ucBooks ID="UcBooks1" runat="server" /></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%"></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%"><uc3:ucBooks ID="UcBooks2" runat="server" /></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%"></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%"><uc3:ucBooks ID="UcBooks3" runat="server" /></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%"></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%"><uc3:ucBooks ID="ucBooks4" runat="server" /></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%">&nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="width: 100%">&nbsp;</td>
        </tr>
        </table></td>
</tr>
<tr>
    <td></td>
    <td style="width: 201px"></td>
</tr>
<tr>
    <td></td>
    <td style="width: 201px"></td>
</tr>
</table>
</asp:Content>
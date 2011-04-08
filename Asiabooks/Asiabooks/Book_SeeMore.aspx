<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Book_SeeMore.aspx.vb" Inherits="Book_SeeMore" title="Untitled Page" %>
<%@ Register Src="uc/ucPromotion.ascx" TagName="ucPromotion" TagPrefix="uc1" %>
<%@ Register Assembly="MycustomDG" Namespace="MycustomDG" TagPrefix="Saifi" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
<tr>
    <td style="width: 100%">&nbsp;</td>
</tr>
<tr>
    <td style="width: 100%"><asp:Label ID="Label_Result" runat="server" CssClass="grdBestseller_detail"></asp:Label><asp:Label
        ID="lblPage_Name" runat="server" Visible="False"></asp:Label></td>
</tr>
<tr>
    <td style="width: 90%" align="center">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 3%"></td>
            <td valign="top">
                <Saifi:MyDg ID="Datagrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    BorderColor="White" CssClass="Grid_book" GridLines="None" HeaderStyle-BackColor="#aaaadd"
                    HeaderStyle-CssClass="tableHeader" ImageFirst="images/b_firstpage.gif" ImageLast="images/b_lastpage.gif"
                    ImageNext="images/b_nextpage.gif" ImagePrevious="images/b_prevpage.gif" ItemStyle-CssClass="tableItem" SelectedItemStyle-BackColor="#99ccff" ShowFirstAndLastImage="True"
                    ShowPreviousAndNextImage="True" UseAccessibleHeader="True" Width="100%">
                    <Columns>
                        <asp:TemplateColumn>
                            <itemtemplate>
                                <br />
                                <table border="0" cellpadding="0" cellspacing="0" style="width:105px;">
                                <tr>
                                     <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                                     <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                                     <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                    <td align="center" valign="top" ><a href='book_detail_Internet.aspx?Title_1=<%# Eval("ISBN_13") %>'>
                                    <asp:Image id="Book_Image" runat="server" ImageUrl='<%# Eval("image") %>' Width="85px"  Height="126px" __designer:wfdid="w362"></asp:Image></a></td>
                                    <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                     <td align="left" valign="top" style="height:10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                                     <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                                </tr>
                               </table>
                               &nbsp;<br /><br />
                            </itemtemplate>
                            <headerstyle width="10%" />
                            <itemstyle font-bold="False" font-italic="False" font-overline="False" font-strikeout="False"
                                font-underline="False" horizontalalign="left" verticalalign="Top" width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <itemtemplate>
                            </itemtemplate>
                            <headerstyle width="5%" />
                            <itemstyle font-bold="False" font-italic="False" font-overline="False" font-strikeout="False"
                                font-underline="False" horizontalalign="left" verticalalign="Top" width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <itemtemplate>
                                <BR /><a style="text-decoration:none;" href='book_detail_internet.aspx?Title_1=<%# Eval("ISBN_13") %>'>
                                <asp:Label id="lblBook_Title" runat="server" CssClass="grdBestseller_title" Font-Bold="True" 
                                    __designer:dtid="2814749767106603" __designer:wfdid="w364" Text='<%# Eval("book_title") %>'></asp:Label></a>
                                <BR /><BR /><asp:Label id="Label2" runat="server" CssClass="grdBestseller_head" Font-Bold="True" 
                                    __designer:dtid="2814749767106606" __designer:wfdid="w365" Text="ISBN : "></asp:Label><asp:Label id="Label12" 
                                    runat="server" CssClass="grdBestseller_detail" __designer:dtid="2814749767106607" __designer:wfdid="w366" 
                                    Text='<%# Eval("ISBN_13") %>'></asp:Label><BR /><asp:Label id="Label1" 
                                    runat="server" CssClass="grdBestseller_head" Font-Bold="True" __designer:dtid="2814749767106609" 
                                    __designer:wfdid="w367" Text="Author : "></asp:Label><asp:Label id="lblauthor" runat="server" 
                                    CssClass="grdBestseller_detail" __designer:dtid="2814749767106610" __designer:wfdid="w368" 
                                    Text='<%# Eval("author") %>'></asp:Label><BR /><asp:Label id="Label3" runat="server" 
                                    CssClass="grdBestseller_head" Font-Bold="True" __designer:dtid="2814749767106612" __designer:wfdid="w369" 
                                    Text="Publisher : "></asp:Label><asp:Label id="Label13" runat="server" CssClass="grdBestseller_detail" 
                                    __designer:dtid="2814749767106613" __designer:wfdid="w370" 
                                    Text='<%# Eval("publisher_Name") %>'></asp:Label><BR /><asp:Label id="lblisbn" 
                                    runat="server" __designer:dtid="2814749767106618" __designer:wfdid="w371" Visible="False" 
                                    Text='<%# Eval("isbn_13") %>'></asp:Label><BR />&nbsp;&nbsp;
                            </itemtemplate>
                            <headerstyle width="55%" />
                            <itemstyle font-bold="False" font-italic="False" font-overline="False" font-strikeout="False"
                                font-underline="False" horizontalalign="Left" verticalalign="Top" width="55%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <itemtemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 138px; height: 136px">
                                <tbody>
                                <tr>
                                    <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                                     <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                                     <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                    <td style="width: 100px" align="left" valign="top">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:119px; height:119px;">
                                        <tr>
                                            <td style="width: 119px; height:69px" valign="top" align="right">
                                                <asp:Label ID="lblList_Price_H" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                                                    ForeColor="DarkGray" Text="List Price : Bt. " />
                                                <asp:Label ID="lblList_Price_D" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                                                    ForeColor="DarkGray" Text='<%# Eval("list_price","{0:#,##0}") %>' /><br />
                                                <asp:Label ID="lblYour_Price_H" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                                                    ForeColor="#006600" Text='Your Price : '></asp:Label>
                                                <asp:Label ID="lblYour_Price_D" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                                                    ForeColor="#006600" Text='<%# Eval("your_price","{0:#,##0}") %>' /><br />
                                                <asp:Label ID="lblSave_Price" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                                                    ForeColor="#404040" Text='<%# Eval("price_save","{0:#,##0}") %>' /><br />
                                                <asp:Label ID="lbl_price_usd" runat="server" Font-Names="Arial" Font-Size="9pt" ForeColor="#FF8000"
                                                    Style="text-align: right" Width="90px" Text='<%# Eval("price_usd") %>' /></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 119px; height:25px" valign="bottom"><a style="text-decoration:none;" 
                                                href='book_detail_internet.aspx?Title_1=<%# Eval("ISBN_13") %>'><asp:Image ID="ImageButton1" 
                                                runat="server" ImageUrl="~/images/Template/add_to_cart.jpg" /></a></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 119px; height:25px" align="right" valign="bottom">
                                                <asp:ImageButton 
                                                ID="ImageButton2" runat="server" ImageUrl="~/images/Template/wish_list_.jpg" 
                                                CommandArgument='<%# Eval("ISBN_13") %>' CommandName="delete" /></td>
                                        </tr>
                                        </table></td>
                                    <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                    <td align="left" valign="top" style="height:10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                                    <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                                </tr>
                                </tbody>
                                </table>
                            </itemtemplate>
                            <headerstyle width="15%" />
                            <itemstyle font-bold="False" font-italic="False" font-overline="False" font-strikeout="False"
                                font-underline="False" horizontalalign="right" verticalalign="Top" width="15%" />
                        </asp:TemplateColumn>
                    </Columns>
                    <ItemStyle CssClass="Grid_bookItem" />
                    <HeaderStyle BackColor="White" CssClass="Grid_bookHeader" Wrap="True" />
                    <SelectedItemStyle BackColor="#99CCFF" />
                    <PagerStyle CssClass="Grid_bookPager" HorizontalAlign="Right" Mode="NumericPages"
                        PageButtonCount="5" Position="TopAndBottom" />
                </Saifi:MyDg></td>
            <td  style="width: 3%"></td>
            <td style="width: 201px" align="right" valign="top"><uc1:ucPromotion ID="UcPromotion1" runat="server" /></td>
        </tr>
        </table></td>
</tr>
<tr>
    <td style="width: 100%"></td>
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
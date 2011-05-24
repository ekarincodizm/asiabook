<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Advanced_Search.aspx.vb" 
    Inherits="Advanced_Search" title="Untitled Page" %>
<%@ Register Assembly="MycustomDG" Namespace="MycustomDG" TagPrefix="Saifi" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="PanelFocus" runat="server" DefaultButton="btnSearch">
<table cellpadding="0" cellspacing="0" style="width: 100%">
<tr>
    <td style="width: 15%; height: 13px;"></td>
    <td style="width: 65%;"></td>
    <td style="width: 15%;"></td>
</tr>
<tr>
    <td colspan="3" align="left" valign="top" style="height: 25px;"><asp:Image ID="Image43" runat="server" ImageUrl="~/images/Template/advanced_search.jpg" /></td>
</tr>
<tr>
    <td style="height: 10px;">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
</tr>
<tr>
    <td colspan="3" align="left" valign="top" class="font_other"><b>&nbsp;&nbsp;Fill in one or more of the fields below:</b></td>
</tr>
<tr>
    <td style="height: 10px;">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
</tr>
<tr>
    <td style="width: 15%">&nbsp;</td>
    <td align="center" valign="top" style="width: 65%;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 95%">
        <tr>
            <td align="left" valign="middle" style="width: 20%; height: 30px;" class="font_other">
                ISBN : </td>
            <td align="left" valign="top" style="width: 75%;">
                <asp:TextBox ID="txtIsbn" runat="server" Width="217px" />
            </td>
        </tr>
            <tr>
                <td align="left" class="font_other" style="width: 20%; height: 30px;" 
                    valign="middle">
                    Title&nbsp;:&nbsp;</td>
                <td align="left" style="width: 75%;" valign="top">
                    <asp:TextBox ID="txttitle" runat="server" Width="217px" />
                </td>
            </tr>
        <tr>
            <td align="left" valign="middle" style="width: 20%; height: 30px;" class="font_other">Author&nbsp;:&nbsp;</td>
            <td align="left" valign="top"><asp:TextBox ID="txtauthor" runat="server" Width="217px" /></td>
        </tr>
        <tr>
            <td align="left" valign="middle" style="height: 30px; " class="font_other">Keyword&nbsp;:&nbsp;</td>
            <td align="left" valign="top"><asp:TextBox ID="txtkeyword" runat="server" Width="217px" /></td>
        </tr>
        <%--<tr>
            <td align="left" valign="middle" style="height: 30px; width: 20%" class="font_other">Publisher&nbsp;:&nbsp;</td>
            <td align="left" valign="top"><asp:TextBox ID="txtpub" runat="server" Width="217px" /></td>
        </tr>--%>
        <tr>
            <td align="left" valign="middle" style="height: 30px; width: 20%" class="font_other">
                Book type&nbsp;:&nbsp;</td>
            <td style="width: 75%; height: 30px" align="left">
                <asp:DropDownList ID="txttype" runat="server" Width="217px">
                    <asp:ListItem Value="all">books & ebooks</asp:ListItem>
                    <asp:ListItem Value="book">books only</asp:ListItem>
                    <asp:ListItem Value="ebook">ebooks only</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 20px;">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px;">&nbsp;</td>
            <td align="left" valign="top"><asp:Button ID="btnSearch" runat="server" Text="Search" OnClientClick="ads_wait()"/></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <div id="div_adsWait" style="display:none;">
                    <img src="images/loading.gif" /><br/>loading...
                </div>
            </td>
        </tr>
        </table></td>
    <td style="width: 15%">&nbsp;</td>
</tr>
<tr>
    <td style="height: 20px;">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
</tr>
<tr>
    <td colspan="3" style="width:100%; height:7px; background-image: url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
</tr>
<tr>
    <td colspan="3">
        <asp:Label ID="lblWording" runat="server" CssClass="font_other" 
            Font-Size="11pt" 
            Text="There are not available in our online database, please contact Customer Service at 02-7159000 EXT: 8103, 8102" 
            Visible="False"></asp:Label>
    </td>
</tr>
<tr>
    <td style="width: 100%" colspan="3" align="center">
        <table cellpadding="0" cellspacing="0" style="width: 85%">
        <tr>
            <td align="left" valign="top" style="width: 85%"><asp:Label ID="Label_Result" runat="server" CssClass="grdBestseller_detail" /></td>
        </tr>
            <tr>
                <td style="width: 90%" align="center">
                <Saifi:MyDg ID="Datagrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    BorderColor="White" CssClass="Grid_book" GridLines="None" HeaderStyle-BackColor="#aaaadd"
                    HeaderStyle-CssClass="tableHeader" ImageFirst="images/b_firstpage.gif" ImageLast="images/b_lastpage.gif"
                    ImageNext="images/b_nextpage.gif" ImagePrevious="images/b_prevpage.gif" 
                    ItemStyle-CssClass="tableItem" ShowFirstAndLastImage="True"
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
                                <td align="left" 
                                    style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;" 
                                    valign="top"></td>
                                <td align="center" valign="top"><a class="Grid_bookItem_A" href='book_detail_Internet.aspx?Title_1=<%# Eval("ISBN_13") %>&Book_Type=<%# Eval("Book_Type") %>'>
                                    <asp:Image style="VERTICAL-ALIGN: top" id="Book_Image" runat="server" ImageUrl='<%# Eval("image") %>' 
                                    Width="85px" CssClass="Grid_bookItem_image" Height="126px" 
                                        __designer:wfdid="w362"></asp:Image></a></td>
                                <td align="left" 
                                    style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;" 
                                    valign="top"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                <td align="left" valign="top" 
                                    style="background-image:url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x; height: 10px;"></td>
                                <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                            </tr>
                            </table>
                                <asp:Label ID="lblBook_Image" runat="server" Text='<%# Eval("image") %>' 
                                    Visible="False"></asp:Label>
                            <br /><br />
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
                            <br /><a style="text-decoration:none;" href='book_detail_internet.aspx?Title_1=<%# Eval("ISBN_13") %>&Book_Type=<%# Eval("Book_Type") %>'>
                            <asp:Label id="lblBook_Title" runat="server" CssClass="grdBestseller_title" Font-Bold="True" 
                                __designer:dtid="2814749767106603" __designer:wfdid="w364" 
                                    Text='<%# Eval("book_title") %>'></asp:Label></a>
                            <br /><br />
                                <asp:Label id="Label15" runat="server" CssClass="grdBestseller_head" Font-Bold="True" 
                                __designer:dtid="2814749767106606" __designer:wfdid="w365" Text="ISBN : "></asp:Label><asp:Label id="Label16" 
                                runat="server" CssClass="grdBestseller_detail" 
                                    __designer:dtid="2814749767106607" __designer:wfdid="w366" 
                                Text='<%# Eval("ISBN_13") %>'></asp:Label><br />
                                <asp:Label id="Label17" 
                                runat="server" CssClass="grdBestseller_head" Font-Bold="True" __designer:dtid="2814749767106609" 
                                __designer:wfdid="w367" Text="Author : "></asp:Label>
                                <asp:Label id="lblauthor" runat="server" 
                                CssClass="grdBestseller_detail" __designer:dtid="2814749767106610" __designer:wfdid="w368" 
                                Text='<%# Eval("author") %>'></asp:Label><br /><asp:Label id="Label18" runat="server" 
                                CssClass="grdBestseller_head" Font-Bold="True" 
                                    __designer:dtid="2814749767106612" __designer:wfdid="w369" 
                                Text="Publisher : "></asp:Label>
                                <asp:Label id="Label19" runat="server" CssClass="grdBestseller_detail" 
                                __designer:dtid="2814749767106613" __designer:wfdid="w370" 
                                Text='<%# Eval("publisher_Name") %>'></asp:Label><br />
                            <asp:Label id="lblsource" 
                                runat="server" __designer:dtid="2814749767106618" __designer:wfdid="w371" Visible="False" 
                                Text='<%# Eval("source") %>'></asp:Label>
                                <br />
                                <%--//////////////////promptnow////////////////////--%>
                                <asp:Label ID="Label20" runat="server" CssClass="grdBestseller_head" Font-Bold="True" 
                                    Text="Book Type : "></asp:Label>
                                <asp:Label ID="lbltype" runat="server"  CssClass="grdBestseller_detail" 
                                    Text='<%# Eval("Book_Type") %>'></asp:Label>
                                <br />
                                <asp:Label ID="lbltxt_format" runat="server" CssClass="grdBestseller_head" Font-Bold="True" 
                                    Text="eBook Format : "></asp:Label>       
                                  
                                &nbsp;<asp:ImageButton ID="btn1" runat="server" Visible="false" />
                                &nbsp;<asp:ImageButton ID="btn2" runat="server" Visible="false" />
                                &nbsp;<asp:ImageButton ID="btn3" runat="server" Visible="false" />
                                &nbsp;<asp:ImageButton ID="btn4" runat="server" Visible="false" />
                                &nbsp;<asp:ImageButton ID="btn5" runat="server" Visible="false" />
                                &nbsp;<asp:ImageButton ID="btn6" runat="server" Visible="false" />
                                &nbsp;<asp:ImageButton ID="btn7" runat="server" Visible="false" />
                                &nbsp;<asp:ImageButton ID="btn8" runat="server" Visible="false" />
                                &nbsp;<asp:ImageButton ID="btn9" runat="server" Visible="false" />
                                
                                <asp:HiddenField ID="hdd_type" runat="server" 
                                    Value='<%# Eval("Book_Type") %>' />
                                <asp:HiddenField ID="hdd_other" runat="server" 
                                    Value='<%# Eval("Other_format") %>' />
                                <asp:HiddenField ID="hdd_ebook_format" runat="server" 
                                    Value='<%# Eval("eBook_Format") %>' />
                                <br />
                                    <asp:LinkButton ID="lnkavailable" runat="server" CssClass="grdBestseller_head" 
                                        ForeColor="Red">Available On Other Format</asp:LinkButton>&nbsp;
                                    <asp:Image ID="image_icon" runat="server" Height="25px" 
                                        ImageUrl="~/images/ebook/ebook_icon.jpg" Width="25px" />&nbsp;
                            <%--////////////////promptnow end//////////////////--%>
                            </itemtemplate>
                            <headerstyle width="55%" />
                            <itemstyle font-bold="False" font-italic="False" font-overline="False" font-strikeout="False"
                                font-underline="False" horizontalalign="Left" verticalalign="Top" width="55%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <itemtemplate>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 138px; height: 136px;">
                            <tbody>
                                <tr>
                                    <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                                    <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                                    <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                                </tr>
                                <tr>
                                    <td align="left" 
                                        style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;" 
                                        valign="top"></td>
                                    <td align="left" valign="top" style="width:100px;">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 119px; height: 119px">
                                        <tr>
                                            <td style="width: 119px; height:69px" valign="top" align="right">
                                                <asp:Label ID="lblList_Price_H" runat="server" Font-Bold="True" 
                                                    Font-Names="Arial" Font-Size="9pt"
                                                    ForeColor="DarkGray" Text="List Price : Bt." />
                                                <asp:Label ID="lblList_Price_D" runat="server" Font-Bold="True" 
                                                    Font-Names="Arial" Font-Size="9pt"
                                                    ForeColor="DarkGray" Text='<%# Eval("Selling_price","{0:#,###}") %>' /><br />
                                                <asp:Label ID="lblYour_Price_H" runat="server" Font-Bold="True" 
                                                    Font-Names="Arial" Font-Size="9pt"
                                                    ForeColor="#006600" Text='Your Price : '></asp:Label>
                                                <asp:Label ID="lblYour_Price_D" runat="server" Font-Bold="True" 
                                                    Font-Names="Arial" Font-Size="9pt"
                                                    ForeColor="#006600" 
                                                    Text='<%# Eval("selling_price_eComN","{0:#,###}") %>' /><br />
                                                <asp:Label ID="lblSave_Price_L" runat="server" Font-Bold="True" 
                                                    Font-Names="Arial" Font-Size="9pt"
                                                    ForeColor="#404040" Text='(Save ' />
                                                <asp:Label ID="lblSave_Price_C" runat="server" Font-Bold="True" 
                                                    Font-Names="Arial" Font-Size="9pt"
                                                    ForeColor="#404040" Text='<%# Eval("eCom_discount","{0:#,###}") %>' />
                                                 <asp:Label ID="lblSave_Price_R" runat="server" Font-Bold="True" 
                                                    Font-Names="Arial" Font-Size="9pt"
                                                    ForeColor="#404040" Text='%)' /><br />
                                                <asp:Label ID="lbl_price_usd" runat="server" Font-Names="Arial" 
                                                    Font-Size="9pt" ForeColor="#FF8000"
                                                    Style="text-align: right" Width="90px"  /></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 119px; height:25px" valign="bottom"><a style="text-decoration:none;" 
                                                href='book_detail_internet.aspx?Title_1=<%# Eval("ISBN_13") %>&Book_Type=<%# Eval("Book_Type") %>'>
                                                <asp:Image ID="btn_view_detail" runat="server" ImageUrl="~/images/Template/add_to_cart.jpg" /></a></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 119px; height:25px" align="right" valign="bottom">
                                                <asp:ImageButton ID="btn_wish_list" runat="server" CommandArgument='<%# Eval("ISBN_13") %>' CommandName="delete"
                                                    ImageUrl="~/images/Template/wish_list_.jpg"/>
                                            </td>
                                        </tr>
                                        </table>
                                    </td>
                                    <td align="left" 
                                        style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;" 
                                        valign="top"></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                    <td align="left" valign="top" 
                                        style="background-image:url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x; height: 10px;"></td>
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
                    <HeaderStyle BackColor="White" CssClass="Grid_bookHeader" />
                    <PagerStyle CssClass="Grid_bookPager" HorizontalAlign="Right" Mode="NumericPages"
                        PageButtonCount="5" Position="TopAndBottom" Visible="true" />
                </Saifi:MyDg></td>
            </tr>
            <tr>
                <td style="width: 85%">&nbsp;</td>
            </tr>
        </table></td>
</tr>
<tr>
    <td style="width: 15%">&nbsp;</td>
    <td style="width: 65%">&nbsp;</td>
    <td style="width: 15%">&nbsp;</td>
</tr>
</table></asp:Panel>
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
<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="eBook_SeeMore.aspx.vb" Inherits="eBook_SeeMore" title="Untitled Page" %>
<%@ Register Src="uc/ucPromotion.ascx" TagName="ucPromotion" TagPrefix="uc1" %>
<%@ Register Assembly="MycustomDG" Namespace="MycustomDG" TagPrefix="Saifi" %>
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
            <td  style="width: 3%"></td>
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
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image1" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
                                        <td valign="top" style="height: 7px; background-image: url('<% getUrl("/images/Template/cart_head_bg.jpg")%>')"></td>
                                        <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image2" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_left_bg.jpg")%>'); width: 9px"></td>
                                        <td align="center" valign="top" ><a href='ebook_detail.aspx?code=<%# Eval("ISBN_13") %>&format=<%# Eval("Format_Type") %>'>
                                        <asp:Image id="Book_Image" runat="server" Width="85px"  ImageUrl='<%# Eval("Image") %>'  Height="126px" __designer:wfdid="w362"></asp:Image></a></td>
                                        <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_right_bg.jpg")%>'); width: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image3" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" Border="0" /></td>
                                        <td valign="top" style="height: 10px; background-image: url('<% getUrl("/images/Template/cart_footer_bg.jpg")%>')"></td>
                                        <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image4" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" Border="0" /></td>
                                    </tr>
                               </table>
                                
                                &nbsp;<BR /><BR />
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
                                 <BR /><a style="text-decoration:none;" href='ebook_detail.aspx?code=<%# Eval("ISBN_13") %>&format=<%# Eval("Format_Type") %>'>
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
                                    Text='<%# Eval("isbn_13") %>'></asp:Label><BR />&nbsp;&nbsp;<br />
                                    <asp:Label ID="Label14" runat="server" CssClass="grdBestseller_head" Font-Bold="True" 
                                    Text="Book Type : "></asp:Label>
                                <asp:Label ID="lbltype" runat="server"  CssClass="grdBestseller_detail" 
                                    Text='<%# Eval("Book_Type") %>'></asp:Label>
                                <br />
                                <asp:Label ID="lbltxt_format" runat="server" CssClass="grdBestseller_head" Font-Bold="True" 
                                    Text="eBook Format : "></asp:Label><asp:Label ID="hdd_ebook_format" runat="server" CssClass="grdBestseller_detail"  Text='<%# Eval("eBook_Format") %>' ></asp:Label>
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
                                        <td style="width: 9px; height: 7px"><asp:Image ID="Image5" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" /></td>
                                        <td style="background-image: url('<% getUrl("/images/Template/cart_head_bg.jpg")%>')"></td>
                                        <td style="width: 10px; height: 7px"><asp:Image ID="Image6" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" /></td>
                                    </tr>
                                    <tr>
                                        <td style="background-image: url('<% getUrl("/images/Template/cart_left_bg.jpg")%>');
                                            width: 9px"></td>
                                        <td style="width: 100px" align="left" valign="top">
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 119px; height: 119px">
                                            <tr>
                                                <td style="width: 119px; height:69px" valign="top" align="right">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                <td valign="top" align="right">
                                                    <asp:Label ID="lblList_Price_H" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                                                        ForeColor="DarkGray" Text="List Price : Bt." />&nbsp;</td><td valign="bottom">
                                                    <asp:Label ID="lblList_Price_D" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                                                        ForeColor="DarkGray" Text='<%# Eval("list_price","{0:#,##0}") %>' /></td></tr></table><br />
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                <td valign="top" align="right">
                                                    <asp:Label ID="lblYour_Price_H" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                                                        ForeColor="#006600" Text="Your Price : Bt."></asp:Label>&nbsp;</td><td valign="bottom">
                                                    <asp:Label ID="lblYour_Price_D" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                                                        ForeColor="#006600" Text='<%# Eval("your_price","{0:#,##0}") %>' /></td></tr></table><br />
                                                    <asp:Label ID="lblSave_Price" runat="server" Font-Bold="True" 
                                                        Font-Names="Arial" Font-Size="9pt"
                                                        ForeColor="#404040" Text='<%# Eval("save_price","{0:#,##0}") %>' /><br />
                                                    <asp:Label ID="lbl_price_usd" runat="server" Font-Names="Arial" Font-Size="9pt" ForeColor="#FF8000"
                                                        Style="text-align: right" Width="90px" Text='<%# Eval("your_price_usd") %>' /></td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 119px; height:25px" valign="bottom"><a style="text-decoration:none;" 
                                                    href='ebook_detail.aspx?code=<%# Eval("ISBN_13") %>&format=<%# Eval("Format_Type") %>'><asp:Image ID="ImageButton1" 
                                                    runat="server" ImageUrl="~/images/Template/add_to_cart.jpg" /></a></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 119px; height:25px" align="right" valign="bottom"><a style="text-decoration:none;" 
                                                    href='ebook_detail.aspx?code=<%# Eval("ISBN_13") %>&format=<%# Eval("Format_Type") %>'><asp:ImageButton 
                                                    ID="ImageButton2" runat="server" ImageUrl="~/images/Template/wish_list_.jpg" 
                                                    CommandName="select" /></a></td>
                                            </tr>
                                            </table>
                                        </td>
                                        <td style="background-image: url('<% getUrl("/images/Template/cart_right_bg.jpg")%>'); width: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 9px; height: 10px"><asp:Image ID="Image7" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" /></td>
                                        <td style="background-image: url('<% getUrl("/images/Template/cart_footer_bg.jpg")%>')"></td>
                                        <td style="width: 10px; height: 10px"><asp:Image ID="Image8" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" /></td>
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
                    <SelectedItemStyle BackColor="#99CCFF" />
                    <PagerStyle CssClass="Grid_bookPager" HorizontalAlign="Right" Mode="NumericPages"
                        PageButtonCount="5" Position="TopAndBottom" />
                </Saifi:MyDg>
                </td>
            <td  style="width: 3%"></td>
            <td style="width: 201px" align="right" valign="top">
                <uc1:ucpromotion ID="UcPromotion1" runat="server" /></td>
        </tr>
        </table></td>
</tr>
<tr>
    <td style="width: 100%">
        <asp:SqlDataSource ID="SqlDataSource_Main" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ASBKEOConnectionString %>" 
            SelectCommand="SELECT TOP(10) * FROM ebook_store"></asp:SqlDataSource>
    </td>
</tr>
</table>
</asp:Content>
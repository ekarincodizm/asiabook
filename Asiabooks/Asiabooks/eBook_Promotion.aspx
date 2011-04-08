<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="eBook_Promotion.aspx.vb" Inherits="eBook_Promotion" %>
<%@ Register Assembly="MycustomDG" Namespace="MycustomDG" TagPrefix="Saifi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0" style="width: 85%">
        <tr>
            <td align="left" valign="top" style="width: 85%"><asp:Label ID="lblhead" 
                    runat="server" CssClass="grdBestseller_detail" Font-Bold="True" 
                    Font-Size="Small" >PROMOTION : YOU HAVE </asp:Label>
            &nbsp;<asp:Label ID="lblcredits" runat="server" CssClass="grdBestseller_detail" 
                    Font-Bold="True" Font-Size="Small" ForeColor="Maroon" Text="CREDITS"></asp:Label>
&nbsp;<asp:Label ID="Label16" runat="server" CssClass="grdBestseller_head" Font-Bold="True" 
                    Font-Size="Small" Text="CREDIT(S)"></asp:Label>
            </td>
        </tr>
            <tr>
                <td style="width: 90%" align="center">
                <Saifi:MyDg ID="Datagrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    BorderColor="White" CssClass="Grid_book" GridLines="None" HeaderStyle-BackColor="#aaaadd"
                    HeaderStyle-CssClass="tableHeader" ImageFirst="images/b_firstpage.gif" ImageLast="images/b_lastpage.gif"
                    ImageNext="images/b_nextpage.gif" ImagePrevious="images/b_prevpage.gif" 
                    ItemStyle-CssClass="tableItem" SelectedItemStyle-BackColor="#99ccff" ShowFirstAndLastImage="True"
                    ShowPreviousAndNextImage="True" UseAccessibleHeader="True" Width="90%" 
                        style="margin-right: 0px">
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
                                <td align="left" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="middle">
                                    <asp:Image  id="Book_Image" runat="server" ImageUrl='<%# Eval("image") %>' 
                                    Width="85px"  Height="126px" title='<%# Eval("synopsis_full") %>' AlternateText='<%# Eval("synopsis_full") %>'></asp:Image></td>
                                <td align="left" style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                <td align="left" valign="top" style="background-image:url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                                <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                            </tr>
                            </table>
                            &nbsp;<asp:Label ID="lblBook_Image" runat="server" Text='<%# Eval("image") %>' Visible="False"></asp:Label>
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
                            <br />
                            <asp:Label id="lblBook_Title" runat="server" CssClass="grdBestseller_title" Font-Bold="True" 
                                __designer:dtid="2814749767106603" __designer:wfdid="w364" Text='<%# Eval("title") %>'></asp:Label>
                            <br /><br /><asp:Label id="Label2" runat="server" CssClass="grdBestseller_head" Font-Bold="True" 
                                __designer:dtid="2814749767106606" __designer:wfdid="w365" Text="ISBN : "></asp:Label><asp:Label id="Label12" 
                                runat="server" CssClass="grdBestseller_detail" __designer:dtid="2814749767106607" __designer:wfdid="w366" 
                                Text='<%# Eval("ISBN_13") %>'></asp:Label><br /><asp:Label id="Label1" 
                                runat="server" CssClass="grdBestseller_head" Font-Bold="True" __designer:dtid="2814749767106609" 
                                __designer:wfdid="w367" Text="Author : "></asp:Label><asp:Label id="lblauthor" runat="server" 
                                CssClass="grdBestseller_detail" __designer:dtid="2814749767106610" __designer:wfdid="w368" 
                                Text='<%# Eval("author") %>'></asp:Label><br /><asp:Label id="Label3" runat="server" 
                                CssClass="grdBestseller_head" Font-Bold="True" __designer:dtid="2814749767106612" __designer:wfdid="w369" 
                                Text="Publisher : "></asp:Label><asp:Label id="Label13" runat="server" CssClass="grdBestseller_detail" 
                                __designer:dtid="2814749767106613" __designer:wfdid="w370" 
                                Text='<%# Eval("publisher") %>'></asp:Label><br />
                                <asp:Label ID="Label14" runat="server" __designer:dtid="2814749767106612" 
                                    __designer:wfdid="w369" CssClass="grdBestseller_head" Font-Bold="True" 
                                    Text="Format : "></asp:Label>
                                <asp:Label ID="Label15" runat="server" __designer:dtid="2814749767106613" 
                                    __designer:wfdid="w370" CssClass="grdBestseller_detail"  ForeColor="Red"
                                    Text='<%# Eval("format") %>'></asp:Label><br />
                                <asp:Label ID="Label4" runat="server" __designer:dtid="2814749767106612" 
                                    __designer:wfdid="w369" CssClass="grdBestseller_head" Font-Bold="True" 
                                    Text="Synopsis : "></asp:Label>
                                <asp:Label ID="Label6" runat="server" __designer:dtid="2814749767106613" 
                                    __designer:wfdid="w370" CssClass="grdBestseller_detail" 
                                    Text='<%# Eval("synopsis") %>'></asp:Label>
                                <br />
                            </itemtemplate>
                            <headerstyle width="55%" />
                            <itemstyle font-bold="False" font-italic="False" font-overline="False" font-strikeout="False"
                                font-underline="False" horizontalalign="Left" verticalalign="Top" width="55%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <itemtemplate>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 138px; height: 100px;">
                            <tbody>
                                <tr>
                                    <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                                    <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                                    <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                                </tr>
                                <tr>
                                    <td align="left" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                    <td align="left" valign="top" style="width:100px;">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 119px; height: 119px">
                                        <tr>
                                            <td align="center" style="width: 119px; height:25px" valign="middle">
                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                    Font-Size="9pt" ForeColor="#006600" Text="Quantity" />
                                                <br />
                                                <asp:TextBox ID="txt_qty" runat="server" Width="70px" Text="1" style="TEXT-ALIGN: right"></asp:TextBox>
                                                <br />
                                                <br />
                                                <asp:Button ID="btn_add" runat="server" Text="Get Free" 
                                                    onclick="btn_add_Click" />
                                            </td>
                                        </tr>
                                        </table>
                                    </td>
                                    <td align="left" style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                    <td align="left" valign="top" style="background-image:url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
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
                    <SelectedItemStyle BackColor="#99CCFF" />
                    <PagerStyle CssClass="Grid_bookPager" HorizontalAlign="Right" Mode="NumericPages"
                        PageButtonCount="5" Position="TopAndBottom" />
                </Saifi:MyDg>
                </td>
            </tr>
            <tr>
                <td style="width: 85%">&nbsp;</td>
            </tr>
        </table>
</asp:Content>


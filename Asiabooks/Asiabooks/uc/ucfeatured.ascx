<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucfeatured.ascx.vb" Inherits="uc_ucfeatured" %>
<table style="width:100%; height:268px;" cellpadding="0" cellspacing="0" border="0">
<tr style="width:100%; height:31px; background-image:url('images/Template/featured_head_bg.jpg'); background-repeat:repeat-x;">
    <td align="left" valign="top" style="width:10px; height:31px; background-image:url('images/Template/featured_head_start.jpg');"></td>
    <td align="left" valign="middle" class="label_recommended_title">&nbsp;<asp:Label ID="lblHead" runat="server" Text="" /></td>
    <td align="left" valign="top" style="width:12px; height:31px; background-image:url('images/Template/featured_head_end.jpg');"></td>
</tr>
<tr valign="top" style="height:237px;">
    <td align="left" valign="top" style="width:10px; height:237px; background-image:url('images/Template/featured_left.jpg'); background-repeat:no-repeat;"></td>
    <td align="left" valign="top" style="height:237px; background-image:url('images/Template/featured_detail_bg.jpg'); background-repeat:repeat-x;">
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" Width="100%">
            <ItemTemplate>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td align="right" colspan="3" style="width: 100%; height: 5px" valign="top"></td>
                </tr>
                <tr>
                    <td align="right" rowspan="2" style="width: 50%" valign="top">
                        <asp:Image ID="Book_Image" runat="server" Height="187px" ImageUrl='<%# Eval("image") %>' Width="121px" /></td>
                    <td align="center" style="width: 5%" valign="top"></td>
                    <td align="left" style="width: 50%" valign="top">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="width: 100%">
                                    <a style="text-decoration:none;" href='book_detail_internet.aspx?Title_1=<%# Eval("ISBN_13") %>'><asp:Label ID="lblBook_Title" runat="server" CssClass="grdBestseller_title" Text='<%# bind("book_title") %>' ></asp:Label></a><br />
                                    <asp:Label ID="Label2" runat="server" CssClass="grdBestseller_head" Font-Bold="True" Text="ISBN : "></asp:Label>
                                    <asp:Label ID="Label12" runat="server" CssClass="grdBestseller_detail" Text='<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>'></asp:Label><br />
                                    <asp:Label ID="Label1" runat="server" CssClass="grdBestseller_head" Font-Bold="True" Text="Author : " />
                                    <asp:Label ID="lblauthor" runat="server" CssClass="grdBestseller_detail" Text='<%# bind("author") %>'></asp:Label><br />
                                    <asp:Label ID="Label13" runat="server" CssClass="grdBestseller_head" Font-Bold="True" Text="Publisher Name : "></asp:Label>
                                    <asp:Label ID="lblpub_name" runat="server" CssClass="grdBestseller_detail" Text='<%# bind("publisher_name") %>'></asp:Label><br />
                                    <asp:Label ID="lblisbn" runat="server" Text='<%# bind("isbn_13") %>' Visible="False"></asp:Label><br />
                                    <asp:Label ID="lblList_Price_L" runat="server" Font-Bold="True" Text="List Price : Bt." CssClass="labelprice" />
                                    <asp:Label ID="lblList_Price_D" runat="server" Font-Bold="True" Text='<%# bind("list_price") %>' CssClass="labelprice" /><br />
                                    <asp:Label ID="lblYout_Price_L" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" ForeColor="#006600" Text="Your Price : " />
                                    <asp:Label ID="lblYout_Price_D" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" ForeColor="#006600" Text='<%# Eval("your_price") %>' /><br />
                                    <asp:Label ID="lbl_price_usd" runat="server" Style="text-align: left" Width="90px" CssClass="labelpriceusd" Text='<%# Eval("price_usd") %>' /><br />
                                    <asp:Label ID="lblSave_Price" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" ForeColor="#404040" Text='<%# Eval("save_price") %>' /></td>
                            </tr>
                        </table></td>
                </tr>
                <tr>
                    <td align="center" style="width: 5%" valign="top"></td>
                    <td align="left" style="width: 50%" valign="top"><a style="text-decoration:none;" 
                        href='book_detail_internet.aspx?Title_1=<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>'><asp:Image ID="imagadd" 
                        runat="server" ImageUrl="~/images/Template/add_to_cart.jpg" /></a></td>
                </tr>
                </table>
                <asp:Label ID="lblBook_Image" runat="server" Text='<%# bind("image") %>' Visible="False"></asp:Label>
            </ItemTemplate>
        </asp:DataList></td>
    <td align="left" valign="top" style="width:12px; height:237px; background-image:url('images/Template/featured_right.jpg'); background-repeat:no-repeat;"></td>
</tr>
<tr>
    <td colspan="3" align="right" valign="bottom" style="height:11px;"><asp:Image ID="Image17" runat="server" 
        ImageUrl="~/images/Template/icon_arrow.gif" />&nbsp;<a href="#" runat="server" id="lnkMore" style="text-decoration:none;" 
        class="see_more2">See more...</a></td>
</tr>
</table>
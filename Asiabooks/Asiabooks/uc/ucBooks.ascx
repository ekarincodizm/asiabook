<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucBooks.ascx.vb" Inherits="uc_ucBooks" %>


<table border="0" cellpadding="0" cellspacing="0" style="width: 98%; background-image: url('images/bg.gif');">
<tr>
    <td style="width:100%; height:33px; background-image:url('images/Template/fantastic_saving_bg.jpg'); background-repeat:repeat-x;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 70%">&nbsp;<asp:Label ID="lblhead" runat="server" CssClass="label_head" Font-Bold="True" />
                <asp:Label ID="lblcat_name" runat="server" CssClass="label_thailand_title" Font-Bold="True"></asp:Label></td>
            <td align="right" style="width: 30%; height: 19px;" class="see_more2"><asp:Image ID="imgSeemore" runat="server" 
                ImageUrl="~/images/Template/icon_arrow.gif" />&nbsp;<a href="#" runat="server" id="lnkMore" style="text-decoration:none;">See more..</a></td>
        </tr>
        </table></td>
</tr>
<tr>
    <td style="width: 100%">
    <asp:ListView runat="server" ID="lvBooks">
    <LayoutTemplate>
        <div>
        <ol class="bookab table-style">
            <li ID="itemPlaceholder" runat="server"></li>
        </ol>
        </div>
    </LayoutTemplate>
    <ItemTemplate>
        <li>
            <span class="width-fixer"><div class="PZ3zoom" style="width:92px; height:120px;">
            <table border="0" cellpadding="0" cellspacing="0" style="width:92px;">
            <tr>
                <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
            </tr>
            <tr>
                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                <td align="center" valign="top" ><a href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>' ><img src='<%# Eval("image")%>' alt=""/></a></td>
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
                <asp:Label ID="lblList_Price_D" runat="server" Text='<%#Eval("selling_price")%>'></asp:Label>
                </div>
            <div class="book-yourprice">Your Price : 
                <asp:Label ID="lblYour_Price" runat="server" Text='<%#Eval("your_price")%>'></asp:Label></div>
            <div class='book-priceUSD'>US$ <%#Eval("price_usd")%></div>
            <div class='book-save'>
                <asp:Label ID="lblsave_price_L" runat="server" Text="(Save "></asp:Label>
                <asp:Label ID="lblsave_price_C" runat="server" Text='<%#Eval("save_price")%>'></asp:Label>
                <asp:Label ID="lblsave_price_R" runat="server" Text="%)"></asp:Label></div>
            <div class='book-imagestar'>
                <asp:Image ID="imgCustomer_Average" runat="server" />
                <asp:Label ID="Label3" runat="server" Text="( "></asp:Label>
                <asp:Label ID="lblCustomerView" runat="server"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text=" )"></asp:Label></div>
            <a href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>' rel="add-to-cart"><asp:Image runat="server" ID="imgAddToCart" ImageUrl="~/images/Template/add_to_cart.jpg" style="border:0;" class="add-to-cart-button" /></a>
            <asp:Label ID="lblisbn" runat="server" Text='<%#Eval("isbn_13")%>' Visible="false"></asp:Label>
            </span>
        </li>
    </ItemTemplate>
    </asp:ListView>
    </td>
</tr>
</table>    

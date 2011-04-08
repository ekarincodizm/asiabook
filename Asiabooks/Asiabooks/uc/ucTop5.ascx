<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucTop5.ascx.vb" Inherits="uc_ucTop5" %>
<table cellpadding="0" cellspacing="0" style="width:201px; height:269px;">
<tr>
    <td style="width: 201px" valign="top"><asp:Image ID="imgHead" runat="server" ImageUrl="~/images/Template/head_top.gif" /></td>
</tr>
<tr>
    <td align="center" valign="top" style="width:201px; height:228px; background-image:url('images/Template/bg.gif'); background-repeat:no-repeat;">
        <asp:GridView ID="GridBestSellers" runat="server" AutoGenerateColumns="False" Width="183px" ShowHeader="False" GridLines="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr valign="top">
                        <td align="center" width="20%"><asp:Label ID="lblSeq" runat="server" CssClass="labelBest_Number" 
                            Font-Italic="True"></asp:Label></td>
                        <td align="left" width="60%">
                            <a style="text-decoration:none;" href='book_detail_internet.aspx?Title_1=<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>'>
                            <asp:Label ID="lblTitle" runat="server" CssClass="labelBest_Title" Font-Bold="True" 
                                Text='<%# DataBinder.Eval(Container.DataItem, "Book_Title") %>' ToolTip='<%# bind("book_title_full") %>'></asp:Label></a>
                            <br />
                            <asp:Label ID="Label2" runat="server" CssClass="labelBest_Author" Text="by"></asp:Label>
                            &nbsp;<a style="text-decoration:none;" href='book_detail_internet.aspx?Title_1=<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>'>
                            <asp:Label ID="Label1" runat="server" CssClass="labelBest_Author" 
                                Text='<%# DataBinder.Eval(Container.DataItem, "Author") %>' ToolTip='<%# bind("author_full") %>'></asp:Label></a>
                            <asp:Label ID="lblisbn" runat="server" Text='<%# bind("isbn_13") %>' Visible="False"></asp:Label>
                            <asp:Label ID="lblBook_Image" runat="server" Text='<%# bind("image") %>' Visible="False"></asp:Label></td>
                        <td align="left" valign="middle" width="20%"><a style="text-decoration:none;" 
                            href='book_detail_internet.aspx?Title_1=<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>'>
                            <asp:Image ID="Book_Image" runat="server" BorderWidth="0" Height="36px" 
                                ImageUrl="~/images_book/noImage.jpg" Width="26px" /></a></td>
                    </tr>
                    <tr valign="middle">
                        <td align="center" colspan="3" style="width: 100%; height:3px"></td>
                    </tr>
                    <tr valign="middle" align="center">
                        <td align="left" colspan="3" style="width: 201px; height:1px; background-image:url('images/Template/top5best_line.jpg'); background-repeat:repeat-x;"></td>
                    </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView></td>
</tr>
<tr>
    <td style="width:201px; height:11px; background-image:url('images/Template/bottom.gif');"></td>
</tr>
<tr>
    <td style="width: 201px" align="right" valign="top"><asp:Label ID="lblSource_Nielsen" runat="server" 
        CssClass="label_store_event_detail" Text="Source: Nielsen" Visible="False"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image17" runat="server" 
        ImageUrl="~/images/Template/icon_arrow.gif" />&nbsp;<a href="#" runat="server" id="lnkMore" 
        style="text-decoration:none;" class="see_more2">See more..</a></td>
</tr>
</table>

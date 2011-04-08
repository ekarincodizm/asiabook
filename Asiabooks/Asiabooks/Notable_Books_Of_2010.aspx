<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Notable_Books_Of_2010.aspx.vb" Inherits="Notable_Books_Of_2010" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%; height: 20px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                <asp:Image ID="Image53" runat="server" 
                    ImageUrl="~/images/100_Notable_Books_Of_2010/100_banner_content.jpg" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 21px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                <asp:Image ID="Image54" runat="server" 
                    ImageUrl="~/images/100_Notable_Books_Of_2010/bar_fiction.gif" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 21px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 21px;">
                <asp:DataList ID="DL_Fiction" runat="server" RepeatColumns="2" 
                    RepeatDirection="Horizontal" Width="100%">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="width: 5%"></td>
                                <td style="width: 60%" valign="top">
                                    <a href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>' ><asp:Label ID="lblTitle_Fiction" runat="server" Font-Bold="False" 
                                        Font-Names="Arial" ForeColor="#77B900" Text='<%# bind("book_title") %>'></asp:Label></a>
                                </td>
                                <td style="width: 5%"></td>
                                <td align="center" rowspan="4" style="width: 30%">
                                    <a href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>' ><asp:Image ID="Book_Image_Fiction" runat="server" Height="88px" 
                                        ImageUrl="~/images_book/no_book.jpg" Width="59px" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 5%"></td>
                                <td style="width: 60%" valign="top">
                                    <asp:Label ID="lblAuthor_Fiction" runat="server" Font-Names="Arial" 
                                        ForeColor="Gray" Text='<%# bind("author") %>'></asp:Label>
                                </td>
                                <td style="width: 5%"></td>
                            </tr>
                            <tr>
                                <td style="width: 5%"></td>
                                <td style="width: 60%" valign="top">
                                    <asp:Label ID="lblSynopsis_Fiction" runat="server" Font-Names="Arial" 
                                        ForeColor="#4E4E4E" Text='<%# bind("synopsis") %>'></asp:Label>
                                </td>
                                <td style="width: 5%"></td>
                            </tr>
                            <tr>
                                <td style="width: 5%"></td>
                                <td style="width: 60%">
                                    <asp:Label ID="lblIsbn_Fiction" runat="server" Text='<%# bind("isbn_13") %>' 
                                        Visible="False"></asp:Label>
                                </td>
                                <td style="width: 5%"></td>
                            </tr>
                            <tr>
                                <td style="width: 5%; height: 18px;"></td>
                                <td style="width: 60%; height: 18px;">
                                    <asp:Label ID="lblImage_Fiction" runat="server" Text='<%# bind("image") %>' 
                                        Visible="False"></asp:Label>
                                </td>
                                <td style="width: 5%; height: 18px;"></td>
                                <td style="width: 30%; height: 18px;"></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td style="width: 100%"></td>
        </tr>
        <tr>
            <td style="width: 100%; height: 21px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                <asp:Image ID="Image55" runat="server" 
                    ImageUrl="~/images/100_Notable_Books_Of_2010/bar_non_fiction.gif" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 21px;"></td>
        </tr>
        <tr>
            <td style="width: 100%">
                <asp:DataList ID="DL_NonFiction" runat="server" RepeatColumns="2" 
                    RepeatDirection="Horizontal" Width="100%">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="width: 5%"></td>
                                <td style="width: 60%" valign="top">
                                    <a href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>' ><asp:Label ID="lblTitle_NonFiction" runat="server" Font-Bold="False" 
                                        Font-Names="Arial" ForeColor="#77B900" Text='<%# bind("book_title") %>'></asp:Label></a>
                                </td>
                                <td style="width: 5%"></td>
                                <td align="center" rowspan="4" style="width: 30%">
                                    <a href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>' ><asp:Image ID="Book_Image_NonFiction" runat="server" Height="88px" 
                                        ImageUrl="~/images_book/no_book.jpg" Width="59px" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 5%"></td>
                                <td style="width: 60%" valign="top">
                                    <asp:Label ID="lblAuthor_NonFiction" runat="server" Font-Names="Arial" 
                                        ForeColor="Gray" Text='<%# bind("author") %>'></asp:Label>
                                </td>
                                <td style="width: 5%"></td>
                            </tr>
                            <tr>
                                <td style="width: 5%"></td>
                                <td style="width: 60%" valign="top">
                                    <asp:Label ID="lblSynopsis_NonFiction" runat="server" Font-Names="Arial" 
                                        ForeColor="#4E4E4E" Text='<%# bind("synopsis") %>'></asp:Label>
                                </td>
                                <td style="width: 5%"></td>
                            </tr>
                            <tr>
                                <td style="width: 5%"></td>
                                <td style="width: 60%">
                                    <asp:Label ID="lblIsbn_NonFiction" runat="server" Text='<%# bind("isbn_13") %>' 
                                        Visible="False"></asp:Label>
                                </td>
                                <td style="width: 5%"></td>
                            </tr>
                            <tr>
                                <td style="width: 5%; height: 18px;">
                                </td>
                                <td style="width: 60%; height: 18px;">
                                    <asp:Label ID="lblImage_NonFiction" runat="server" Text='<%# bind("image") %>' 
                                        Visible="False"></asp:Label>
                                </td>
                                <td style="width: 5%; height: 18px;">
                                </td>
                                <td style="width: 30%; height: 18px;">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
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
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


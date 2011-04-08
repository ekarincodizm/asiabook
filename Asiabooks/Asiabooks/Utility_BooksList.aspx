<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Utility_BooksList.aspx.vb" Inherits="Utility_BooksList" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Asiabooks.Com - Books List</title>
<style runat="server" type="text/css">
.body {
	margin-left: 0;
	margin-top: 0;
	margin-right: 0;
	margin-bottom: 0;

}
.page 
{  
	font-family: "arial","MS Sans Serif", "Microsoft Sans Serif"; 
	font-size: 12px; 
	color: #333333;
}

a.GreenBold:link { font-weight:bold; color: #086b28; text-decoration: none}
a.GreenBold:visited { font-weight:bold; color: #086b28; text-decoration: none}
a.GreenBold:active { font-weight:bold; color: #10a401; text-decoration: none}
a.GreenBold:hover { font-weight:bold; color: #10a401; text-decoration: none}

a.Green:link {font-size: 9px; font-weight:bold; color: #086b28; text-decoration: none}
a.Green:visited {font-size: 9px; font-weight:bold; color: #086b28; text-decoration: none}
a.Green:active {font-size: 9px; font-weight:bold; color: #10a401; text-decoration: none}
a.Green:hover {font-size: 9px; font-weight:bold; color: #10a401; text-decoration: none}

a.MoreDetail:link { font-weight:bold; color: #555555; text-decoration: none;}
a.MoreDetail:visited { font-weight:bold; color: #555555; text-decoration: none;}
a.MoreDetail:active { font-weight:bold; color: #ee8100; text-decoration: none;}
a.MoreDetail:hover { font-weight:bold; color: #ee8100; text-decoration: none;}

</style>
    <meta runat="server" http-equiv="Content-Type" content="text/html; charset=windows-874" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="615" border="0" align="center" cellpadding="0" cellspacing="0" class="page">
            <tr>
                <td colspan="3" align="center">
                <img src="https://www.asiabooks.com/images_books/Reading_Time/Outter_Header.jpg" width="600"/></td>
            </tr>
            <tr>
                <td width="22" background="https://www.asiabooks.com/images/Asiabooks/ReadingTime/Outter_Left.jpg"></td>
                <td>
                    <table width="570" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center" valign="top">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="100%" ><br />
<div align="left">
<table border="0" cellpadding="0" cellspacing="0" class="f12">
  <tr>
    <td width="378"><img src="http://www.asiabooks.com/images/Reading_Time/bar_reading_time.gif" width="360" height="25" /></td>
  </tr>
</table>
<table width="379" border="0" cellpadding="0" cellspacing="0" class="f12">
  <tr>
    <td colspan="2"><div align="left" style="margin-top:20px; margin-bottom:20px; margin-left:10px; margin-right:10px"><strong><font color="#3a366c"><a href="https://www.asiabooks.com/Reading_Time.aspx?Number=5" target="_blank" class="link_purple_12">Read All Year Round (Jan - Feb 11)</a></font></strong><img src="http://www.asiabooks.com/images/Reading_Time/icon_new.gif" width="22" height="9" hspace="5" /></div></td>
  </tr>
  <tr>
    <td align="left" valign="top" style="padding-bottom:20px; padding-left:10px; padding-right:10px"><a href="https://www.asiabooks.com/Reading_Time.aspx?Number=5" target="_blank"><img src="https://www.asiabooks.com/images/Reading_Time/pic_reading_time.jpg" width="180" height="257" border="0" /></a><br /></td>
    <td valign="top"><div align="left" style="margin-top:5px; margin-bottom:5px">Get 
        updated information on new books, books’ review, Author of the month, and 
        current Asia Books promotions &amp; activities. </div>
    <div align="left"><a href="https://www.asiabooks.com/Reading_Time.aspx?Number=5" target="_blank"><img src="http://www.asiabooks.com/images/Reading_Time/button_read_now.gif" width="86" height="22" border="0" /></a></div></td>
  </tr>
</table>
</div>
                                            <asp:GridView ID="GridView_Left" runat="server" PageSize="7" PagerSettings-Visible="false" AutoGenerateColumns="false" Width="100%" GridLines="None" AllowPaging="True">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td ><img src="https://www.asiabooks.com/images/Asiabooks/ReadingTime/Inner_HeaderLeft.jpg" /></td>
                                                                    <td background="https://www.asiabooks.com/images/Asiabooks/ReadingTime/Inner_Header.jpg"></td>
                                                                    <td ><img src="https://www.asiabooks.com/images/Asiabooks/ReadingTime/Inner_HeaderRight.jpg" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="23" background="https://www.asiabooks.com/images/Asiabooks/ReadingTime/Inner_Left.jpg"></td>
                                                                    <td width="345">
                                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td colspan="2" align="left" height="24" width="100%">
                                                                                <a class="GreenBold"  href='https://www.asiabooks.com/book_detail_internet.aspx?Title_1=<%# DataBinder.Eval(Container.DataItem, "ISBN")%>'>
                                                                                <asp:Label ID="lblBook_Title" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Book_Title")%>' ></asp:Label></a></td>
                                                                            </tr>
                                                                            <tr valign="top" align="left">
                                                                                <td width="100">
                                                                                <a href='https://www.asiabooks.com/book_detail_internet.aspx?Title_1=<%# DataBinder.Eval(Container.DataItem, "ISBN")%>'>
                                                                                <img src='https://www.asiabooks.com/images_books/<%# DataBinder.Eval(Container.DataItem, "Book_Image")%>' width="90" height="120" /></a></td>
                                                                                <td width="245"><%# DataBinder.Eval(Container.DataItem, "Synopsis")%></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" align="Right" height="24" width="100%">
                                                                                <a href='https://www.asiabooks.com/book_detail_internet.aspx?Title_1=<%# DataBinder.Eval(Container.DataItem, "ISBN")%>' class="MoreDetail">
                                                                                    More Detail</a></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td width="27" background="https://www.asiabooks.com/images/Asiabooks/ReadingTime/Inner_Right.jpg"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td ><img src="https://www.asiabooks.com/images/Asiabooks/ReadingTime/Inner_FooterLeft.jpg" /></td>
                                                                    <td background="https://www.asiabooks.com/images/Asiabooks/ReadingTime/Inner_Footer.jpg"></td>
                                                                    <td ><img src="https://www.asiabooks.com/images/Asiabooks/ReadingTime/Inner_FooterRight.jpg" /></td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerSettings Visible="False" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="center" width="175" valign="top">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr >
                                        <td>
<img src="https://www.asiabooks.com/images/Asiabooks/ReadingTime/JustOut.jpg" width="175" height="66"/>
                                            <asp:GridView ID="GridView_Right" runat="server" AllowPaging="True" AutoGenerateColumns="false" Width="100%" GridLines="None" PageSize="14">
                                            <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                    <a class="Green" href='https://www.asiabooks.com/book_detail_internet.aspx?Title_1=<%# DataBinder.Eval(Container.DataItem, "ISBN")%>'>
                                                                    <img src='https://www.asiabooks.com/images_books/<%# DataBinder.Eval(Container.DataItem, "Book_Image")%>' width="50" height="67"/></a></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="center" height="20">
                                                                    <a class="Green" href='https://www.asiabooks.com/book_detail_internet.aspx?Title_1=<%# DataBinder.Eval(Container.DataItem, "ISBN")%>'>
                                                                    <asp:Label ID="lblBook_Title" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Book_Title")%>' ></asp:Label></a></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="center" height="15"></td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerSettings Visible="False" />
                                            </asp:GridView>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td >
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="570" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left">
                            <asp:Image runat="server" ID="ImagePromotion" ImageUrl="https://www.asiabooks.com/images_books/Reading_Time/Promotion_ReadingTime.jpg" width="280" height="200"/></td>
                            <td align="right">
                            <asp:Image runat="server" ID="ImageWin" ImageUrl="https://www.asiabooks.com/images_books/Reading_Time/Win_ReadingTime.jpg" width="280" height="200"/></td>
                        </tr>
                    </table></td>
                <td width="23" background="https://www.asiabooks.com/images/Asiabooks/ReadingTime/Outter_Right.jpg"></td>
            </tr>
            <tr>
                <td colspan="3"><img src="https://www.asiabooks.com/images/Asiabooks/ReadingTime/Outter_Footer.jpg" width="615"/></td>
            </tr>
        </table>
    </form>
</body>
</html>

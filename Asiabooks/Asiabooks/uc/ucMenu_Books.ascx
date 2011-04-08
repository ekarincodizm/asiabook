<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMenu_Books.ascx.vb" Inherits="uc_ucMenu_Books" %>

    <style type="text/css">
        .style1
        {
            font-family:Arial;
            color:#666666;
            font-size:9pt;
        }
 
    </style>
    
<table class="style1" cellpadding="0" cellspacing="0" border="0" 
    style="width:210px; background-image: url('<% getUrl("/images/Template/bgmenu_cat.jpg")%>'); ">
    <tr>
        <td colspan="3">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Template/menu_cat_books.jpg" style="width: 210px; height: 35px"/></td>
    </tr>
    <tr>
        <td colspan="3">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Template/line_menu_cat.jpg" style="width: 210px; height: 9px"/></td>
    </tr>
    <tr>
        <td style="width:20px"></td>
        <td style="width:190px"><a href="#" data-flexmenu="flexmenu2" data-dir="h" data-offsets="8,0" class="menu">
Art and Photography</a></td>
        <td style="width:10px"></td>
    </tr>


     <tr>
        <td colspan="3">
            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/Template/line_menu_cat.jpg" style="width: 210px; height: 9px"/></td>
    </tr>
    <tr>
        <td style="width:10px"></td>
        <td style="width:190px"><a href="#" data-flexmenu="flexmenu2" data-dir="h" data-offsets="8,0" class="menu">Audiobooks</a></td>
        <td style="width:10px"></td>
    </tr>
     <tr>
        <td colspan="3">
            <asp:Image ID="Image4" runat="server" ImageUrl="~/images/Template/line_menu_cat.jpg" style="width: 210px; height: 9px"/></td>
    </tr>
    <tr>
        <td style="width:10px"></td>
        <td style="width:190px">Biography</td>
        <td style="width:10px"></td>
    </tr>
     <tr>
        <td colspan="3">
            <asp:Image ID="Image5" runat="server" ImageUrl="~/images/Template/line_menu_cat.jpg" style="width: 210px; height: 9px"/></td>
    </tr>
    <tr>
        <td style="width:10px"></td>
        <td style="width:190px">Business,Finance and Law</td>
        <td style="width:10px"></td>
    </tr>
     <tr>
        <td colspan="3">
            <asp:Image ID="Image6" runat="server" ImageUrl="~/images/Template/line_menu_cat.jpg" style="width: 210px; height: 9px"/></td>
    </tr>
    <tr>
        <td style="width:10px"></td>
        <td style="width:190px">Children's</td>
        <td style="width:10px"></td>
    </tr>
     <tr>
        <td colspan="3">
            <asp:Image ID="Image7" runat="server" ImageUrl="~/images/Template/line_menu_cat.jpg" style="width: 210px; height: 9px"/></td>
    </tr>
    <tr>
        <td style="width:10px"></td>
        <td style="width:190px">Comics and Graphic Novels</td>
        <td style="width:10px"></td>
    </tr>
     <tr>
        <td colspan="3">
            <asp:Image ID="Image8" runat="server" ImageUrl="~/images/Template/line_menu_cat.jpg" style="width: 210px; height: 9px"/></td>
    </tr>
    <tr>
        <td style="width:10px"></td>
        <td style="width:190px">Computing</td>
        <td style="width:10px"></td>
    </tr>
     <tr>
        <td colspan="3">
            <asp:Image ID="Image9" runat="server" ImageUrl="~/images/Template/line_menu_cat.jpg" style="width: 210px; height: 9px"/></td>
    </tr>
    <tr>
        <td style="width:10px"></td>
        <td style="width:190px">Crime</td>
        <td style="width:10px"></td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Image ID="Image10" runat="server" ImageUrl="~/images/Template/footer_menu_cat.jpg" style="width: 210px; height: 37px"/></td>
    </tr>
        <ul id="flexmenu2" class="flexdropdownmenu" >
<li style="height:5px"></li>
<li><a href="http://www.dynamicdrive.com/">Dynamic Drive</a></li>
<li><a href="http://www.cssdrive.com">CSS Drive</a></li>
<li><a href="http://www.javascriptkit.com">JavaScript Kit</a></li>
<li><a href="http://www.codingforums.com">Coding Forums</a></li>
<li><a href="http://www.javascriptkit.com/domref/">DOM Reference</a></li>
<li style="height:5px"></li>
</ul>
<ul id="flexmenu3" class="flexdropdownmenu">
<li style="height:5px"></li>
<li><a href="http://www.dynamicdrive.com/">Dynamic Drive</a></li>
<li><a href="http://www.cssdrive.com">CSS Drive</a></li>
<li><a href="http://www.javascriptkit.com">JavaScript Kit</a></li>
<li><a href="http://www.codingforums.com">Coding Forums</a></li>
<li><a href="http://www.javascriptkit.com/domref/">DOM Reference</a></li>
<li style="height:5px"></li>
</ul>
</table>
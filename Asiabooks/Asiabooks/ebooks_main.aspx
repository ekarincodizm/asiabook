<%@ Page Language="VB" MasterPageFile="~/MasterPage_eBooks.master" AutoEventWireup="false" CodeFile="ebooks_main.aspx.vb" Inherits="ebooks_main" %>
<%@ Register Src="uc/ucPromotion_eBooks.ascx" TagName="ucPromotion_eBooks" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function MM_openBrWindow(theURL, winName, features) { //v2.0
        window.open(theURL, winName, features);
    }
</script>
    <script type="text/javascript" src="Javascript/jquery.min.js"></script>
<script type="text/javascript" src="Javascript/stepcarousel.js"></script>
<% if lv_ebook1.Items.Count > 0 Then %>
<style type="text/css">
.shadow {
filter:progid:DXImageTransform.Microsoft.dropshadow(OffX=3, OffY=3, Color='gray', Positive='true');
background-color:#FFFFFF;
border:solid 1px #000000;
}
.stepcarousel{
position: relative; /*leave this value alone*/
border: 0px solid black;
overflow: scroll; /*leave this value alone*/
width: 565px; /*Width of Carousel Viewer itself*/
height: 350px; /*Height should enough to fit largest content's height*/
}

.stepcarousel .belt{
position: absolute; /*leave this value alone*/
left: 0;
top: 0;
}

.stepcarousel .panel{
float: right; /*leave this value alone*/
overflow: hidden; /*clip content that go outside dimensions of holding panel DIV*/
margin: 0px; /*margin around each panel*/
width: 565px; /*Width of each panel holding each content. If removed, widths should be individually defined on each content DIV then. */
}
.stepcarousel_award{
position: relative; /*leave this value alone*/
border: 0px solid black;
overflow: scroll; /*leave this value alone*/
width: 565px; /*Width of Carousel Viewer itself*/
height: 100px; /*Height should enough to fit largest content's height*/
}

.stepcarousel_award .belt{
position: absolute; /*leave this value alone*/
left: 0;
top: 0;
}

.stepcarousel_award .panel{
float: right; /*leave this value alone*/
overflow: hidden; /*clip content that go outside dimensions of holding panel DIV*/
margin: 0px; /*margin around each panel*/
width: 565px; /*Width of each panel holding each content. If removed, widths should be individually defined on each content DIV then. */
}
</style>

<script type="text/javascript">
<%  If lv_ebook1.Items.Count > 0 And lv_ebook1.Visible Then%>
    stepcarousel.setup({
        galleryid: 'booklist', //id of carousel DIV
        beltclass: 'belt', //class of inner "belt" DIV containing all the panel DIVs
        panelclass: 'panel', //class of panel DIVs each holding content
        autostep: { enable: false, moveby: 1, pause: 3000 },
        panelbehavior: { speed: 500, wraparound: false, wrapbehavior: 'slide', persist: true },        
        statusvars: ['statusA', 'statusB', 'statusC'], //register 3 variables that contain current panel (start), current panel (last), and total panels
        contenttype: ['inline'], //content setting ['inline'] or ['ajax', 'path_to_external_file']
        defaultbuttons: { enable: true, moveby: 1, leftnav: ['images/ebook/leftnav.gif', -10, 80], rightnav: ['images/ebook/rightnav.gif', -50, 80] }
    })
<%End If%><% if lv_ebook2.Items.Count > 0 and lv_ebook2.Visible Then %>
    stepcarousel.setup({
        galleryid: 'booklist2', //id of carousel DIV
        beltclass: 'belt', //class of inner "belt" DIV containing all the panel DIVs
        panelclass: 'panel', //class of panel DIVs each holding content
        autostep: { enable: false, moveby: 1, pause: 3000 },
        panelbehavior: { speed: 500, wraparound: false, wrapbehavior: 'slide', persist: true },
        statusvars: ['statusA', 'statusB', 'statusC'], //register 3 variables that contain current panel (start), current panel (last), and total panels
        contenttype: ['inline'], //content setting ['inline'] or ['ajax', 'path_to_external_file']
        defaultbuttons: { enable: true, moveby: 1, leftnav: ['images/ebook/leftnav.gif', -10, 80], rightnav: ['images/ebook/rightnav.gif', -50, 80] }
    })
     
<%End If%><% if lv_ebook3.Items.Count > 0 and lv_ebook3.Visible Then %>
    stepcarousel.setup({
        galleryid: 'booklist3', //id of carousel DIV
        beltclass: 'belt', //class of inner "belt" DIV containing all the panel DIVs
        panelclass: 'panel', //class of panel DIVs each holding content
        autostep: { enable: false, moveby: 1, pause: 3000 },
        panelbehavior: { speed: 500, wraparound: false, wrapbehavior: 'slide', persist: true },
        statusvars: ['statusA', 'statusB', 'statusC'], //register 3 variables that contain current panel (start), current panel (last), and total panels
        contenttype: ['inline'], //content setting ['inline'] or ['ajax', 'path_to_external_file']
        defaultbuttons: { enable: true, moveby: 1, leftnav: ['images/ebook/leftnav.gif', -10, 80], rightnav: ['images/ebook/rightnav.gif', -50, 80] }
    })
<%End If%><% if lv_ebook4.Items.Count > 0 and lv_ebook4.Visible Then %>
    stepcarousel.setup({
        galleryid: 'booklist4', //id of carousel DIV
        beltclass: 'belt', //class of inner "belt" DIV containing all the panel DIVs
        panelclass: 'panel', //class of panel DIVs each holding content
        autostep: { enable: false, moveby: 1, pause: 3000 },
        panelbehavior: { speed: 500, wraparound: false, wrapbehavior: 'slide', persist: true },
        statusvars: ['statusA', 'statusB', 'statusC'], //register 3 variables that contain current panel (start), current panel (last), and total panels
        contenttype: ['inline'], //content setting ['inline'] or ['ajax', 'path_to_external_file']
        defaultbuttons: { enable: true, moveby: 1, leftnav: ['images/ebook/leftnav.gif', -10, 80], rightnav: ['images/ebook/rightnav.gif', -50, 80] }
    })
<%End If%><% if lv_ebook5.Items.Count > 0 and lv_ebook5.Visible Then %>
    stepcarousel.setup({
        galleryid: 'booklist5', //id of carousel DIV
        beltclass: 'belt', //class of inner "belt" DIV containing all the panel DIVs
        panelclass: 'panel', //class of panel DIVs each holding content
        autostep: { enable: false, moveby: 1, pause: 3000 },
        panelbehavior: { speed: 500, wraparound: false, wrapbehavior: 'slide', persist: true },
        statusvars: ['statusA', 'statusB', 'statusC'], //register 3 variables that contain current panel (start), current panel (last), and total panels
        contenttype: ['inline'], //content setting ['inline'] or ['ajax', 'path_to_external_file']
        defaultbuttons: { enable: true, moveby: 1, leftnav: ['images/ebook/leftnav.gif', -10, 80], rightnav: ['images/ebook/rightnav.gif', -50, 80] }
    })   
<%End If%><% if lv_ebook6.Items.Count > 0 and lv_ebook6.Visible Then %>
    stepcarousel.setup({
        galleryid: 'booklist6', //id of carousel DIV
        beltclass: 'belt', //class of inner "belt" DIV containing all the panel DIVs
        panelclass: 'panel', //class of panel DIVs each holding content
        autostep: { enable: false, moveby: 1, pause: 3000 },
        panelbehavior: { speed: 500, wraparound: false, wrapbehavior: 'slide', persist: true },
        statusvars: ['statusA', 'statusB', 'statusC'], //register 3 variables that contain current panel (start), current panel (last), and total panels
        contenttype: ['inline'], //content setting ['inline'] or ['ajax', 'path_to_external_file']
        defaultbuttons: { enable: true, moveby: 1, leftnav: ['images/ebook/leftnav.gif', -10, 80], rightnav: ['images/ebook/rightnav.gif', -50, 80] }
    })   
<%End If%>
    stepcarousel.setup({
        galleryid: 'booklist_awards', //id of carousel DIV
        beltclass: 'belt', //class of inner "belt" DIV containing all the panel DIVs
        panelclass: 'panel', //class of panel DIVs each holding content
        autostep: { enable: false, moveby: 1, pause: 3000 },
        panelbehavior: { speed: 500, wraparound: false, wrapbehavior: 'slide', persist: true },
        statusvars: ['statusA', 'statusB', 'statusC'], //register 3 variables that contain current panel (start), current panel (last), and total panels
        contenttype: ['inline'], //content setting ['inline'] or ['ajax', 'path_to_external_file']
        defaultbuttons: { enable: true, moveby: 1, leftnav: ['images/ebook/leftnav.gif', -10, 80], rightnav: ['images/ebook/rightnav.gif', -50, 80] }
    })
</script>
<%End If%>
<script type="text/javascript" src="Javascript/reelslideshow.js"></script>
<script type=""text/javascript""><%=javascript1%></script>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
<tr>
    <td colspan="2" style="width:100%; height:80px; background-image:url('images/ebook/AB_eBooks_head.gif'); background-position:center; background-repeat:no-repeat;"></td>
</tr>
<tr>
<td class="font_other" style="width: 100%"><br />&nbsp;All books sold on asiabooks.com are in ePub or PDF format secured with Adobe Digital rights Management.<br />
Are you new to eBooks? Find out more details here <br /><br />
    <a href="#"><img src="images/ebook/ebooks_video.gif" width="140" height="60" border="0" onclick="MM_openBrWindow('video_presentation.aspx','','width=368,height=208')" /></a>
    <asp:ImageButton ID="ebookfaq" runat="server" ImageUrl="images/ebook/faqs.gif" PostBackUrl="~/FAQs_eBook.aspx" />
    &nbsp;&nbsp;
    <asp:ImageButton ID="ebooksupport" runat="server" ImageUrl="images/ebook/ebooksupport.gif" PostBackUrl="~/Support.aspx" />
    <br />
</td>
</tr>
<tr>
    <td style="width:100%; height:10px; background-image:url('images/Template/fantastic_saving_bg.jpg'); background-repeat:repeat-x;"  colspan=2>&nbsp;</td>
</tr>
<tr>
    <td colspan="2" style="width:100%; height:32px; background-image:url('images/Template/new_releases.jpg'); background-position:left; background-repeat:no-repeat;"></td>
</tr>
<tr>
    <td style="width: 100%; height: 7px">
        <asp:SqlDataSource ID="SqlDataSource_feature" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ASBKEOConnectionString %>" 
            SelectCommand="">
        </asp:SqlDataSource>
    </td>
</tr>
<tr>
    <td style="width: 100%" colspan=2>  
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                <cc1:tabcontainer id="tbMain" runat="server" CssClass="ajax__tab_yuitabview-theme" ActiveTabIndex="0" >
                <cc1:TabPanel runat="server" ID="TabPanel1">
                <HeaderTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ebook/ebook_this_week.gif" />
                
                
</HeaderTemplate>
                
<ContentTemplate>
                    <asp:UpdatePanel runat="server" ID="upMaster1" UpdateMode="Conditional"><ContentTemplate>
                        <asp:Panel runat="server" ID="pnlDetail1">
                        <table style="width:100%;" cellpadding="0" cellspacing="0">
                        <tr style="width:100%; height:257px; background-image:url('<% getUrl("/images/ebook/tab_detail_bg.jpg")%>');">
                            <td style="width:3px; height:257px;" align="left" valign="top">
                                <asp:Image ID="Image33" runat="server" 
                                ImageUrl="~/images/ebook/tab_left.jpg" Width="3px" Height="257px" /></td>
                            <td valign="top">
                                <table style="width:100%;" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width:100%;" align="center"><asp:DataList ID="DataList_feature" runat="server" RepeatColumns="2" 
            RepeatDirection="Horizontal" Width="100%">
            <ItemTemplate>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td align="right" colspan="3" style="width: 100%; height: 5px" valign="top"></td>
                </tr>
                <tr>
                    <td align="right" rowspan="2" style="width: 50%" valign="top">
          <table width=164 border=0 cellpadding=0 cellspacing=0>
	<tr>
		<td colspan=3>
			<img src="images/untitled-3_01.gif" width=164 height=19 alt=""></td>
	</tr>
	<tr>
		<td>
			<img src="images/untitled-3_02.gif" width=19 height=168 alt=""></td>
		<td>
		<div Width="126px" Height="168px" id="display_bookDataList_feature<%# Eval("ISBN_13") %>"><a style="text-decoration:none;" href='ebook_detail.aspx?code=<%# Eval("ISBN_13") %>&format=<%# Eval("Format_Type") %>'><asp:Image ID="Book_Image" runat="server" Height="168px" ImageUrl='<%# Eval("image") %>' Width="126px" /></a></div></td>
		<td>
			<img src="images/untitled-3_04.gif" width=19 height=168 alt=""></td>
	</tr>
	<tr>
		<td colspan=3>
			<img src="images/untitled-3_05.gif" width=164 height=33 alt=""></td>
	</tr>
</table></td>
                    <td align="center" style="width: 5%" valign="top"></td>
                    <td align="left" style="width: 50%" valign="top">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 200px">
                            <tr>
                                <td style="width: 200px">
                                    <a style="text-decoration:none;" 
                                        href='ebook_detail.aspx?code=<%# Eval("ISBN_13") %>&format=<%# Eval("Format_Type") %>'><asp:Label ID="lblBook_Title" runat="server" CssClass="grdBestseller_title" Text='<%# bind("book_title") %>' ></asp:Label></a><br />
                                    <asp:Label ID="Label2" runat="server" CssClass="grdBestseller_head" Font-Bold="True" Text="ISBN : "></asp:Label>
                                    <asp:Label ID="Label12" runat="server" CssClass="grdBestseller_detail" Text='<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>'></asp:Label><br />
                                    <asp:Label ID="Label1" runat="server" CssClass="grdBestseller_head" Font-Bold="True" Text="Author : " />
                                    <asp:Label ID="lblauthor" runat="server" CssClass="grdBestseller_detail" Text='<%# bind("author") %>'></asp:Label><br />
                                    <asp:Label ID="Label13" runat="server" CssClass="grdBestseller_head" Font-Bold="True" Text="Publisher Name : "></asp:Label>
                                    <asp:Label ID="lblpub_name" runat="server" CssClass="grdBestseller_detail" Text='<%# bind("publisher_name") %>'></asp:Label><br />
                                    <asp:Label ID="lblisbn" runat="server" Text='<%# bind("isbn_13") %>' Visible="False"></asp:Label><br />
                                    <asp:Label ID="lblList_Price_L" runat="server" Font-Bold="True" Text="List Price : Bt." CssClass="labelprice" />
                                    <asp:Label ID="lblList_Price_D" runat="server" Font-Bold="True" Text='<%# bind("list_price") %>' CssClass="labelprice" /><br />
                                    <asp:Label ID="lblYout_Price_L" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" ForeColor="#006600" Text="Your Price : Bt. " />
                                    <asp:Label ID="lblYout_Price_D" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" ForeColor="#006600" Text='<%# Eval("your_price") %>' /><br />
                                    <asp:Label ID="lbl_price_usd" runat="server" Style="text-align: left" Width="90px" CssClass="labelpriceusd" Text='<%# Eval("your_price_usd") %>' /><br />
                                    <asp:Label ID="lbl_synopsis" runat="server" Style="text-align: left" Width="90px" Text='<%# Eval("Synopsis") %>' Visible="false" />
                                    <asp:Label ID="lblSave_Price" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" ForeColor="#404040" Text='<%# Eval("save_price") %>' /><br /></td>
                            </tr>
                            <tr><td>
                            <asp:Label ID="lbltxt_format" runat="server" CssClass="grdBestseller_head" Font-Bold="True" Text="Available eBook format(s) "></asp:Label> 
                            </td></tr><tr><td>
                            <asp:Label ID="hdd_ebook_format" runat="server" Text='<%# Eval("eBook_Format") %>' Visible=false></asp:Label> 
                                &nbsp;<asp:ImageButton ID="lnkformat1" runat="server" ImageUrl="images/ebook/epdf.gif" title="CLICK HERE TO VIEW DETAIL OF DRM-PDF"/>
                                &nbsp;<asp:ImageButton ID="lnkformat2" runat="server" ImageUrl="images/ebook/pdf.gif" title="CLICK HERE TO VIEW DETAIL OF PDF"/>
                                &nbsp;<asp:ImageButton ID="lnkformat3" runat="server" ImageUrl="images/ebook/eepub.gif" title="CLICK HERE TO VIEW DETAIL OF DRM-EPUB"/>
                                &nbsp;<asp:ImageButton ID="lnkformat4" runat="server" ImageUrl="images/ebook/epub.gif" title="CLICK HERE TO VIEW DETAIL OF EPUB"/>
                                &nbsp;<asp:ImageButton ID="lnkformat5" runat="server" ImageUrl="images/ebook/lit.gif" title="CLICK HERE TO VIEW DETAIL OF LIT"/>
                                &nbsp;<asp:ImageButton ID="lnkformat6" runat="server" ImageUrl="images/ebook/mp3.gif" title="CLICK HERE TO VIEW DETAIL OF MP3"/>
                                &nbsp;<asp:ImageButton ID="lnkformat7" runat="server" ImageUrl="images/ebook/pdb.gif" title="CLICK HERE TO VIEW DETAIL OF PDB"/>
                                &nbsp;<asp:ImageButton ID="lnkformat8" runat="server" ImageUrl="images/ebook/mobi.gif" title="CLICK HERE TO VIEW DETAIL OF MOBI"/>
                           </td></tr>
                            <!--<tr><td><img src="images/icons/pdf.gif" alt="PDF" />&nbsp;<img src="images/icons/epub.gif" alt="ePUB" />&nbsp;<img src="images/icons/lit.gif" alt="MS Reader" /></td></tr>!-->
                        </table></td>
                </tr>
                <!--<tr>
                    <td align="center" style="width: 5%" valign="top"></td>
                    <td align="left" style="width: 50%" valign="top"><a style="text-decoration:none;" 
                        
                            href='book_detail_internet.aspx?Title_1=<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>&Book_Type=1'><asp:Image ID="imagadd" 
                        runat="server" ImageUrl="~/images/Template/add_to_cart.jpg" /></a></td>
                </tr>!-->
                </table>
                <asp:Label ID="lblBook_Image" runat="server" Text='<%# bind("image") %>' Visible="False"></asp:Label>
            </ItemTemplate>
        </asp:DataList></td>
                               </tr><tr><td><table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 70%">&nbsp;</td>
            <td align="right" style="width: 30%; height: 5px;" class="see_more2"><a href="eBook_SeeMore.aspx?catcode=l1" runat="server" 
                    id="L1" style="text-decoration:none;" visible="True">See more..</a></td>
        </tr>
        </table></td></tr>
                            </table></td>
                            <td style="width:3px; height:257px;" align="right" valign="top">
                                <asp:Image ID="Image44" runat="server" 
                                ImageUrl="~/images/ebook/tab_right.jpg" Width="3px" Height="257px" /></td>
                        </tr>
                        </table>
                        </asp:Panel>
                    
</ContentTemplate>
</asp:UpdatePanel>
                

                
</ContentTemplate>
                
</cc1:TabPanel>
                <cc1:TabPanel runat="server" ID="TabPanel2">
                <HeaderTemplate>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/ebook/ebook_last_week.gif" />
                
                
</HeaderTemplate>
                
<ContentTemplate>
                <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Panel runat="server" ID="Panel1">
                    <table style="width:100%;" cellpadding="0" cellspacing="0">
                    <tr style="width:100%; height:257px; background-image:url('<% getUrl("/images/ebook/tab_detail_bg.jpg")%>');">
                        <td style="width:3px; height:257px;" align="left"><asp:Image ID="Image3" runat="server" 
                            ImageUrl="~/images/ebook/tab_left.jpg" Width="3px" Height="257px" /></td>
                        <td valign="top">
                            <table style="width:100%;" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width:100%;" align="center"><asp:DataList ID="DataList_thismonth" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" Width="100%">
            <ItemTemplate>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td align="right" colspan="3" style="width: 100%; height: 5px" valign="top"></td>
                </tr>
                <tr>
                    <td align="right" rowspan="2" style="width: 50%" valign="top">
                    <table width=164 border=0 cellpadding=0 cellspacing=0>
	<tr>
		<td colspan=3>
			<img src="images/untitled-3_01.gif" width=164 height=19 alt=""></td>
	</tr>
	<tr>
		<td>
			<img src="images/untitled-3_02.gif" width=19 height=168 alt=""></td>
		<td>
		<div Width="126px" Height="168px" id="display_bookDataList_thismonth<%# Eval("ISBN_13") %>"><a style="text-decoration:none;" href='ebook_detail.aspx?code=<%# Eval("ISBN_13") %>&format=<%# Eval("Format_Type") %>'><asp:Image ID="Book_Image" runat="server" Height="168px" ImageUrl='<%# Eval("image") %>' Width="126px" /></a></div></td>
		<td>
			<img src="images/untitled-3_04.gif" width=19 height=168 alt=""></td>
	</tr>
	<tr>
		<td colspan=3>
			<img src="images/untitled-3_05.gif" width=164 height=33 alt=""></td>
	</tr>
</table>
                        </td>
                    <td align="center" style="width: 5%" valign="top"></td>
                    <td align="left" style="width: 50%" valign="top">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 200px">
                            <tr>
                                <td style="width: 200px">
                                    <a style="text-decoration:none;" 
                                        href='ebook_detail.aspx?code=<%# Eval("ISBN_13") %>&format=<%# Eval("Format_Type") %>'><asp:Label ID="lblBook_Title" runat="server" CssClass="grdBestseller_title" Text='<%# bind("book_title") %>' ></asp:Label></a><br />
                                    <asp:Label ID="Label2" runat="server" CssClass="grdBestseller_head" Font-Bold="True" Text="ISBN : "></asp:Label>
                                    <asp:Label ID="Label12" runat="server" CssClass="grdBestseller_detail" Text='<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>'></asp:Label><br />
                                    <asp:Label ID="Label1" runat="server" CssClass="grdBestseller_head" Font-Bold="True" Text="Author : " />
                                    <asp:Label ID="lblauthor" runat="server" CssClass="grdBestseller_detail" Text='<%# bind("author") %>'></asp:Label><br />
                                    <asp:Label ID="Label13" runat="server" CssClass="grdBestseller_head" Font-Bold="True" Text="Publisher Name : "></asp:Label>
                                    <asp:Label ID="lblpub_name" runat="server" CssClass="grdBestseller_detail" Text='<%# bind("publisher_name") %>'></asp:Label><br />
                                    <asp:Label ID="lblisbn" runat="server" Text='<%# bind("isbn_13") %>' Visible="False"></asp:Label><br />
                                    <asp:Label ID="lblList_Price_L" runat="server" Font-Bold="True" Text="List Price : Bt." CssClass="labelprice" />
                                    <asp:Label ID="lblList_Price_D" runat="server" Font-Bold="True" Text='<%# bind("list_price") %>' CssClass="labelprice" /><br />
                                    <asp:Label ID="lblYout_Price_L" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" ForeColor="#006600" Text="Your Price : Bt. " />
                                    <asp:Label ID="lblYout_Price_D" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" ForeColor="#006600" Text='<%# Eval("your_price") %>' /><br />
                                    <asp:Label ID="lbl_price_usd" runat="server" Style="text-align: left" Width="90px" CssClass="labelpriceusd" Text='<%# Eval("your_price_usd") %>' /><br />
                                    <asp:Label ID="lbl_synopsis" runat="server" Style="text-align: left" Width="90px" Text='<%# Eval("Synopsis") %>' Visible="false" />
                                    <asp:Label ID="lblSave_Price" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" ForeColor="#404040" Text='<%# Eval("save_price") %>' /><br /></td>
                            </tr>
                            <tr><td>
                            <asp:Label ID="lbltxt_format" runat="server" CssClass="grdBestseller_head" Font-Bold="True" Text="Available eBook format(s) "></asp:Label> 
                            </td></tr><tr><td>
                            <asp:Label ID="hdd_ebook_format" runat="server" CssClass="grdBestseller_detail" Text='<%# Eval("eBook_Format") %>' Visible=false></asp:Label> 
                                &nbsp;<asp:ImageButton ID="lnkformat1" runat="server" ImageUrl="images/ebook/epdf.gif" title="CLICK HERE TO VIEW DETAIL OF DRM-PDF"/>
                                &nbsp;<asp:ImageButton ID="lnkformat2" runat="server" ImageUrl="images/ebook/pdf.gif" title="CLICK HERE TO VIEW DETAIL OF PDF"/>
                                &nbsp;<asp:ImageButton ID="lnkformat3" runat="server" ImageUrl="images/ebook/eepub.gif" title="CLICK HERE TO VIEW DETAIL OF DRM-EPUB"/>
                                &nbsp;<asp:ImageButton ID="lnkformat4" runat="server" ImageUrl="images/ebook/epub.gif" title="CLICK HERE TO VIEW DETAIL OF EPUB"/>
                                &nbsp;<asp:ImageButton ID="lnkformat5" runat="server" ImageUrl="images/ebook/lit.gif" title="CLICK HERE TO VIEW DETAIL OF LIT"/>
                                &nbsp;<asp:ImageButton ID="lnkformat6" runat="server" ImageUrl="images/ebook/mp3.gif" title="CLICK HERE TO VIEW DETAIL OF MP3"/>
                                &nbsp;<asp:ImageButton ID="lnkformat7" runat="server" ImageUrl="images/ebook/pdb.gif" title="CLICK HERE TO VIEW DETAIL OF PDB"/>
                                &nbsp;<asp:ImageButton ID="lnkformat8" runat="server" ImageUrl="images/ebook/mobi.gif" title="CLICK HERE TO VIEW DETAIL OF MOBI"/>
                           </td></tr>
                            <!--<tr><td><img src="images/icons/pdf.gif" alt="PDF" />&nbsp;<img src="images/icons/epub.gif" alt="ePUB" />&nbsp;<img src="images/icons/lit.gif" alt="MS Reader" /></td></tr>!-->
                        </table></td>
                </tr>
                <!--<tr>
                    <td align="center" style="width: 5%" valign="top"></td>
                    <td align="left" style="width: 50%" valign="top"><a style="text-decoration:none;" 
                        
                            href='book_detail_internet.aspx?Title_1=<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>&Book_Type=1'><asp:Image ID="imagadd" 
                        runat="server" ImageUrl="~/images/Template/add_to_cart.jpg" /></a></td>
                </tr>!-->
                </table>
                <asp:Label ID="lblBook_Image" runat="server" Text='<%# bind("image") %>' Visible="False"></asp:Label>
            </ItemTemplate>
        </asp:DataList></td>
                            </tr><tr><td><table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 70%">&nbsp;</td>
            <td align="right" style="width: 30%; height: 5px;" class="see_more2"><a href="eBook_SeeMore.aspx?catcode=l2" runat="server" 
                    id="L2" style="text-decoration:none;" visible="True">See more..</a></td>
        </tr>
        </table></td></tr>
                            </table></td>
                            <td style="width:3px; height:257px;" align="right"><asp:Image ID="Image4" runat="server" 
                                ImageUrl="~/images/ebook/tab_right.jpg" Width="3px" Height="257px" /></td>
                        </tr>
                        </table>
                        </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                
                
</ContentTemplate>
            
</cc1:TabPanel>
            <cc1:TabPanel runat="server" ID="TabPanel3">
                <HeaderTemplate>
                    <asp:Image ID="Image23" runat="server" ImageUrl="~/images/ebook/ebook_last_month.gif" />
                
                
</HeaderTemplate>
                
<ContentTemplate>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel22" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="Panel12">
                            <table style="width:100%;" cellpadding="0" cellspacing="0">
                            <tr style="width:100%; height:257px; background-image:url('<% getUrl("/images/ebook/tab_detail_bg.jpg")%>');">
                                <td style="width:3px; height:257px;" align="left"><asp:Image ID="Image31" runat="server" 
                                    ImageUrl="~/images/ebook/tab_left.jpg" Width="3px" Height="257px" /></td>
                                <td valign="top">
                                    <table style="width:100%;" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width:100%;" align="center"><asp:DataList ID="DataList_all" runat="server" RepeatColumns="2" 
            RepeatDirection="Horizontal" Width="100%">
            <ItemTemplate>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td align="right" colspan="3" style="width: 100%; height: 5px" valign="top"></td>
                </tr>
                <tr>
                    <td align="right" rowspan="2" style="width: 50%" valign="top">
                    <table width=164 border=0 cellpadding=0 cellspacing=0>
	<tr>
		<td colspan=3>
			<img src="images/untitled-3_01.gif" width=164 height=19 alt=""></td>
	</tr>
	<tr>
		<td>
			<img src="images/untitled-3_02.gif" width=19 height=168 alt=""></td>
		<td>
		<div Width="126px" Height="168px" id="display_bookDataList_all<%# Eval("ISBN_13") %>"><a style="text-decoration:none;" href='ebook_detail.aspx?code=<%# Eval("ISBN_13") %>&format=<%# Eval("Format_Type") %>'><asp:Image ID="Book_Image" runat="server" Height="168px" ImageUrl='<%# Eval("image") %>' Width="126px" /></a></div></td>
		<td>
			<img src="images/untitled-3_04.gif" width=19 height=168 alt=""></td>
	</tr>
	<tr>
		<td colspan=3>
			<img src="images/untitled-3_05.gif" width=164 height=33 alt=""></td>
	</tr>
</table></td>
                    <td align="center" style="width: 5%" valign="top"></td>
                    <td align="left" style="width: 50%" valign="top">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 200px">
                            <tr>
                                <td style="width: 200px">
                                    <a style="text-decoration:none;" 
                                        href='ebook_detail.aspx?code=<%# Eval("ISBN_13") %>&format=<%# Eval("Format_Type") %>'><asp:Label ID="lblBook_Title" runat="server" CssClass="grdBestseller_title" Text='<%# bind("book_title") %>' ></asp:Label></a><br />
                                    <asp:Label ID="Label2" runat="server" CssClass="grdBestseller_head" Font-Bold="True" Text="ISBN : "></asp:Label>
                                    <asp:Label ID="Label12" runat="server" CssClass="grdBestseller_detail" Text='<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>'></asp:Label><br />
                                    <asp:Label ID="Label1" runat="server" CssClass="grdBestseller_head" Font-Bold="True" Text="Author : " />
                                    <asp:Label ID="lblauthor" runat="server" CssClass="grdBestseller_detail" Text='<%# bind("author") %>'></asp:Label><br />
                                    <asp:Label ID="Label13" runat="server" CssClass="grdBestseller_head" Font-Bold="True" Text="Publisher Name : "></asp:Label>
                                    <asp:Label ID="lblpub_name" runat="server" CssClass="grdBestseller_detail" Text='<%# bind("publisher_name") %>'></asp:Label><br />
                                    <asp:Label ID="lblisbn" runat="server" Text='<%# bind("isbn_13") %>' Visible="False"></asp:Label><br />
                                    <asp:Label ID="lblList_Price_L" runat="server" Font-Bold="True" Text="List Price : Bt." CssClass="labelprice" />
                                    <asp:Label ID="lblList_Price_D" runat="server" Font-Bold="True" Text='<%# bind("list_price") %>' CssClass="labelprice" /><br />
                                    <asp:Label ID="lblYout_Price_L" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" ForeColor="#006600" Text="Your Price : Bt. " />
                                    <asp:Label ID="lblYout_Price_D" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" ForeColor="#006600" Text='<%# Eval("your_price") %>' /><br />
                                    <asp:Label ID="lbl_price_usd" runat="server" Style="text-align: left" Width="90px" CssClass="labelpriceusd" Text='<%# Eval("your_price_usd") %>' /><br />
                                    <asp:Label ID="lbl_synopsis" runat="server" Style="text-align: left" Width="90px" Text='<%# Eval("Synopsis") %>' Visible="false" />
                                    <asp:Label ID="lblSave_Price" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" ForeColor="#404040" Text='<%# Eval("save_price") %>' /><br /></td>
                            </tr>
                            <tr><td>
                            <asp:Label ID="lbltxt_format" runat="server" CssClass="grdBestseller_head" Font-Bold="True" Text="Available eBook format(s) "></asp:Label> 
                            </td></tr><tr><td>
                            <asp:Label ID="hdd_ebook_format" runat="server" Text='<%# Eval("eBook_Format") %>' Visible=false></asp:Label> 
                                &nbsp;<asp:ImageButton ID="lnkformat1" runat="server" ImageUrl="images/ebook/epdf.gif" title="CLICK HERE TO VIEW DETAIL OF DRM-PDF"/>
                                &nbsp;<asp:ImageButton ID="lnkformat2" runat="server" ImageUrl="images/ebook/pdf.gif" title="CLICK HERE TO VIEW DETAIL OF PDF"/>
                                &nbsp;<asp:ImageButton ID="lnkformat3" runat="server" ImageUrl="images/ebook/eepub.gif" title="CLICK HERE TO VIEW DETAIL OF DRM-EPUB"/>
                                &nbsp;<asp:ImageButton ID="lnkformat4" runat="server" ImageUrl="images/ebook/epub.gif" title="CLICK HERE TO VIEW DETAIL OF EPUB"/>
                                &nbsp;<asp:ImageButton ID="lnkformat5" runat="server" ImageUrl="images/ebook/lit.gif" title="CLICK HERE TO VIEW DETAIL OF LIT"/>
                                &nbsp;<asp:ImageButton ID="lnkformat6" runat="server" ImageUrl="images/ebook/mp3.gif" title="CLICK HERE TO VIEW DETAIL OF MP3"/>
                                &nbsp;<asp:ImageButton ID="lnkformat7" runat="server" ImageUrl="images/ebook/pdb.gif" title="CLICK HERE TO VIEW DETAIL OF PDB"/>
                                &nbsp;<asp:ImageButton ID="lnkformat8" runat="server" ImageUrl="images/ebook/mobi.gif" title="CLICK HERE TO VIEW DETAIL OF MOBI"/>
                           </td></tr>                            
                        </table></td>
                </tr>
                </table>
                <asp:Label ID="lblBook_Image" runat="server" Text='<%# bind("image") %>' Visible="False"></asp:Label>
            </ItemTemplate>
        </asp:DataList></td>
                                    </tr> <tr><td><table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 70%">&nbsp;</td>
            <td align="right" style="width: 30%; height: 5px;" class="see_more2"><a href="eBook_SeeMore.aspx?catcode=l3" runat="server" 
                    id="L3" style="text-decoration:none;" visible="True">See more..</a></td>
        </tr>
        </table></td></tr>                                   
                                    </table></td>
                                    <td style="width:3px; height:257px;" align="right"><asp:Image ID="Image41" runat="server" 
                                        ImageUrl="~/images/ebook/tab_right.jpg" Width="3px" Height="257px" /></td>
                            </tr>
                            </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                
                
</ContentTemplate>
            
</cc1:TabPanel>
            </cc1:tabcontainer>
        </ContentTemplate>
    </asp:UpdatePanel></td>
</tr>
<tr>
    <td>&nbsp;</td>
    <td style="width: 201px" rowspan="4" valign="top">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="right" style="width: 100%" valign="top"><uc2:ucPromotion_eBooks ID="ucPromotion_eBooks1" runat="server" /></td>
        </tr>
        </table></td>
</tr>
<tr>
    <td align="left" valign="top">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 100%">
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td class="font_other" style="width: 250px">See more books in each popular category&nbsp;&nbsp;:&nbsp;</td>
                    <td><asp:DropDownList ID="ddlCat" runat="server" AutoPostBack="True" Height="22px" Width="230px" /></td>
                </tr>
                </table> 
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 100%; height: 20px;"></td>
        </tr>
  <% If lv_ebook6.Items.Count > 0 And lv_ebook6.Visible Then%>
<!--TAB6!-->
<tr>
    <td style="width:100%; height:33px; background-image:url('images/Template/fantastic_saving_bg.jpg'); background-repeat:repeat-x;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 70%">&nbsp;<asp:Label ID="lblhead6" runat="server" CssClass="label_head" Font-Bold="True" />
                <asp:Label ID="Label5" runat="server" CssClass="label_thailand_title" Font-Bold="True"></asp:Label></td>
            <td align="right" style="width: 30%; height: 19px;" class="see_more2"><asp:Image ID="imgSeemore6" runat="server" 
                ImageUrl="~/images/Template/icon_arrow.gif" visible="False" />&nbsp;<a href="#" runat="server" 
                    id="lnkMore6" style="text-decoration:none;" visible="False">See more..</a></td>
        </tr>
        </table></td>
</tr>
<tr>
<td align="center" style="width: 100%">
<table><tr><td><div id="booklist6-leftnav"></div></td><td style="width:50px;">&nbsp;</td>
<td align="left"><div id="booklist6" class="stepcarousel">
<div class="belt">
            <asp:ListView runat="server" ID="lv_ebook6" GroupItemCount="3">
    <LayoutTemplate>
        <div class="panel">
            <li id="groupPlaceholder" runat="server"></li>        
        </div>
    </LayoutTemplate>
    <GroupTemplate>
        <ol class="bookab table-style">
            <li ID="itemPlaceholder" runat="server"></li>
        </ol>
    </GroupTemplate>
    <GroupSeparatorTemplate>
          </div><div class="panel">
        </GroupSeparatorTemplate>
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
                <td align="center" valign="top" ><a href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' ><asp:Image ID="Book_Image" runat="server" ImageUrl='<%# Eval("image") %>' /></a></td>
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
                <a style="text-decoration:none;" class="book-title" href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' rel="add-to-cart">
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("book_title")%>' ToolTip='<%#Eval("book_title")%>'></asp:Label></a></div>
            <div class="book-author">
                <a style="text-decoration:none;" class="book-author" href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>'>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("author")%>' ToolTip='<%#Eval("author")%>'></asp:Label></a></div>
            <div class="book-space"></div>
            <div class="book-priceBaht">
                <asp:Label ID="lblList_Price_H" runat="server" Text="List Price : Bt. "></asp:Label>
                <asp:Label ID="lblList_Price_D" runat="server" Text='<%#Eval("list_price")%>'></asp:Label>
                </div>
            <div class="book-yourprice">Your Price : Bt. 
                <asp:Label ID="lblYour_Price" runat="server" Text='<%#Eval("your_price")%>'></asp:Label></div>
            <div class='book-priceUSD'><%# Eval("your_price_usd") %></div>
            <div class='book-save'>
                <asp:Label ID="lblsave_price_L" runat="server" Text="(Save "></asp:Label>
                <asp:Label ID="lblsave_price_C" runat="server" Text='<%#Eval("save_price")%>'></asp:Label>
                <asp:Label ID="lblsave_price_R" runat="server" Text="%)"></asp:Label></div>
            <div class="book-author">
            <asp:Label ID="hdd_ebook_format" runat="server" Text='<%# Eval("eBook_Format") %>' ></asp:Label> 
            </div><br />
            <div class='book-imagestar'>
                <asp:Image ID="imgCustomer_Average" runat="server" />
                <asp:Label ID="Label3" runat="server" Text="( "></asp:Label>
                <asp:Label ID="lblCustomerView" runat="server" Text="0"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text=" )"></asp:Label></div>
            <a href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' rel="add-to-cart"><asp:Image runat="server" ID="imgAddToCart" ImageUrl="~/images/Template/add_to_cart.jpg" style="border:0;" class="add-to-cart-button" /></a>
            <asp:Label ID="lblisbn" runat="server" Text='<%#Eval("isbn_13")%>' Visible="false"></asp:Label>
            </span>
        </li>
    </ItemTemplate>
    </asp:ListView>
    </div>
</div><br />
<p id="booklist6-paginate" style="text-align:center"> 
<img src="images/ebook/opencircle.png" data-over="images/ebook/graycircle.png" data-select="images/ebook/closedcircle.png" data-moveby="1" /> 
</p>
</td>
<td><div id="booklist6-rightnav"></div></td></tr></table>
</td>
</tr>
 <%End If%> 
 
<%  If lv_ebook1.Items.Count > 0 And lv_ebook1.Visible Then%>
<!--TAB1!-->
<tr>
    <td style="width:100%; height:33px; background-image:url('images/Template/fantastic_saving_bg.jpg'); background-repeat:repeat-x;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 70%">&nbsp;<asp:Label ID="lblhead1" runat="server" CssClass="label_head" Font-Bold="True" />
                <asp:Label ID="lblcat_name" runat="server" CssClass="label_thailand_title" Font-Bold="True"></asp:Label></td>
            <td align="right" style="width: 30%; height: 19px;" class="see_more2"><asp:Image ID="imgSeemore" runat="server" 
                ImageUrl="~/images/Template/icon_arrow.gif" Visible=false />&nbsp;<a href="#" runat="server" 
                    id="lnkMore" style="text-decoration:none;" visible="False">See more..</a></td>
        </tr>
        </table></td>
</tr>
<tr>
<td align="center" style="width: 100%">
<table><tr><td><div id="booklist-leftnav"></div></td><td style="width:50px;">&nbsp;</td>
<td align="left"><div id="booklist" class="stepcarousel">
<div class="belt">
            <asp:ListView runat="server" ID="lv_ebook1" GroupItemCount="3">
    <LayoutTemplate>
        <div class="panel">
            <li id="groupPlaceholder" runat="server"></li>        
        </div>
    </LayoutTemplate>
    <GroupTemplate>
        <ol class="bookab table-style">
            <li ID="itemPlaceholder" runat="server"></li>
        </ol>
    </GroupTemplate>
    <GroupSeparatorTemplate>
          </div><div class="panel">
        </GroupSeparatorTemplate>
    <ItemTemplate>
       <li>
            <span class="width-fixer"><div class="PZ3zoom" style="height:120px;">
            <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
            </tr>
            <tr>
                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                <td align="center" valign="top" ><a href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' ><asp:Image ID="Book_Image" runat="server" ImageUrl='<%# Eval("image") %>' /></a></td>
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
                <a style="text-decoration:none;" class="book-title" href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' rel="add-to-cart">
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("book_title")%>' ToolTip='<%#Eval("book_title")%>'></asp:Label></a></div>
            <div class="book-author">
                <a style="text-decoration:none;" class="book-author" href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>'>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("author")%>' ToolTip='<%#Eval("author")%>'></asp:Label></a></div>
            <div class="book-space"></div>
            <div class="book-priceBaht">
                <asp:Label ID="lblList_Price_H" runat="server" Text="List Price : Bt."></asp:Label>
                <asp:Label ID="lblList_Price_D" runat="server" Text='<%#Eval("list_price")%>'></asp:Label>
                </div>
            <div class="book-yourprice">Your Price : Bt. 
                <asp:Label ID="lblYour_Price" runat="server" Text='<%#Eval("your_price")%>'></asp:Label></div>
            <div class='book-priceUSD'><%# Eval("your_price_usd") %></div>
            <div class='book-save'>
                <asp:Label ID="lblsave_price_L" runat="server" Text="(Save "></asp:Label>
                <asp:Label ID="lblsave_price_C" runat="server" Text='<%#Eval("save_price")%>'></asp:Label>
                <asp:Label ID="lblsave_price_R" runat="server" Text="%)"></asp:Label></div>
            <div class='book-imagestar'>
            <asp:Label ID="hdd_ebook_format" runat="server" Text='<%# Eval("eBook_Format") %>' ></asp:Label> 
            </div><br />
            <div class='book-imagestar'>
                <asp:Image ID="imgCustomer_Average" runat="server" />
                <asp:Label ID="Label3" runat="server" Text="( "></asp:Label>
                <asp:Label ID="lblCustomerView" runat="server" Text="0"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text=" )"></asp:Label></div>
            <a href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' rel="add-to-cart"><asp:Image runat="server" ID="imgAddToCart" ImageUrl="~/images/Template/add_to_cart.jpg" style="border:0;" class="add-to-cart-button" /></a>
            <asp:Label ID="lblisbn" runat="server" Text='<%#Eval("isbn_13")%>' Visible="false"></asp:Label>
            </span>
        </li>
    </ItemTemplate>
    </asp:ListView>
    </div>
</div><br />
<p id="booklist-paginate" style="text-align:center"> 
<img src="images/ebook/opencircle.png" data-over="images/ebook/graycircle.png" data-select="images/ebook/closedcircle.png" data-moveby="1" /> 
</p></td>
<td><div id="booklist-rightnav"></div></td></tr></table>
</td>
</tr>
<% End If %>
<%  If lv_ebook2.Items.Count > 0 And lv_ebook2.Visible Then%>
<!--TAB2!-->
<tr>
    <td style="width:100%; height:33px; background-image:url('images/Template/fantastic_saving_bg.jpg'); background-repeat:repeat-x;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 70%">&nbsp;<asp:Label ID="lblhead2" runat="server" CssClass="label_head" Font-Bold="True" />
                <asp:Label ID="Label6" runat="server" CssClass="label_thailand_title" Font-Bold="True"></asp:Label></td>
            <td align="right" style="width: 30%; height: 19px;" class="see_more2"><asp:Image ID="imgSeemore2" runat="server" 
                ImageUrl="~/images/Template/icon_arrow.gif" visible="False" />&nbsp;<a href="#" runat="server" 
                    id="lnkMore2" style="text-decoration:none;" visible="False">See more..</a></td>
        </tr>
        </table></td>
</tr>
<tr>
<td align="center" style="width: 100%">
<table><tr><td><div id="booklist2-leftnav"></div></td><td style="width:50px;">&nbsp;</td>
<td align="left"><div id="booklist2" class="stepcarousel">
<div class="belt">
            <asp:ListView runat="server" ID="lv_ebook2" GroupItemCount="3">
    <LayoutTemplate>
        <div class="panel">
            <li id="groupPlaceholder" runat="server"></li>        
        </div>
    </LayoutTemplate>
    <GroupTemplate>
        <ol class="bookab table-style">
            <li ID="itemPlaceholder" runat="server"></li>
        </ol>
    </GroupTemplate>
    <GroupSeparatorTemplate>
          </div><div class="panel">
        </GroupSeparatorTemplate>
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
                <td align="center" valign="top" ><a href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' ><asp:Image ID="Book_Image" runat="server" ImageUrl='<%# Eval("image") %>' /></a></td>
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
                <a style="text-decoration:none;" class="book-title" href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' rel="add-to-cart">
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("book_title")%>' ToolTip='<%#Eval("book_title")%>'></asp:Label></a></div>
            <div class="book-author">
                <a style="text-decoration:none;" class="book-author" href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>'>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("author")%>' ToolTip='<%#Eval("author")%>'></asp:Label></a></div>
            <div class="book-space"></div>
            <div class="book-priceBaht">
                <asp:Label ID="lblList_Price_H" runat="server" Text="List Price : Bt."></asp:Label>
                <asp:Label ID="lblList_Price_D" runat="server" Text='<%#Eval("list_price")%>'></asp:Label>
                </div>
            <div class="book-yourprice">Your Price : Bt. 
                <asp:Label ID="lblYour_Price" runat="server" Text='<%#Eval("your_price")%>'></asp:Label></div>
            <div class='book-priceUSD'><%# Eval("your_price_usd") %></div>
            <div class='book-save'>
                <asp:Label ID="lblsave_price_L" runat="server" Text="(Save "></asp:Label>
                <asp:Label ID="lblsave_price_C" runat="server" Text='<%#Eval("save_price")%>'></asp:Label>
                <asp:Label ID="lblsave_price_R" runat="server" Text="%)"></asp:Label></div>
            <div class="book-author">
            <asp:Label ID="hdd_ebook_format" runat="server" Text='<%# Eval("eBook_Format") %>' ></asp:Label> 
            </div><br />
            <div class='book-imagestar'>
                <asp:Image ID="imgCustomer_Average" runat="server" />
                <asp:Label ID="Label3" runat="server" Text="( "></asp:Label>
                <asp:Label ID="lblCustomerView" runat="server" Text="0"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text=" )"></asp:Label></div>
            <a href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' rel="add-to-cart"><asp:Image runat="server" ID="imgAddToCart" ImageUrl="~/images/Template/add_to_cart.jpg" style="border:0;" class="add-to-cart-button" /></a>
            <asp:Label ID="lblisbn" runat="server" Text='<%#Eval("isbn_13")%>' Visible="false"></asp:Label>
            </span>
        </li>
    </ItemTemplate>
    </asp:ListView>
    </div>
</div><br />
<p id="booklist2-paginate" style="text-align:center"> 
<img src="images/ebook/opencircle.png" data-over="images/ebook/graycircle.png" data-select="images/ebook/closedcircle.png" data-moveby="1" /> 
</p></td>
<td><div id="booklist2-rightnav"></div></td></tr></table>
</td>
</tr>
<%End IF %>
<!--TAB AWARDS!-->
<tr>
    <td style="width:100%; height:33px; background-image:url('images/Template/fantastic_saving_bg.jpg'); background-repeat:repeat-x;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 70%">&nbsp;<asp:Label ID="Label_head" runat="server" CssClass="label_head" Font-Bold="True" Text="Awards Winning titles - Now available in eBooks" />
                <asp:Label ID="Label9" runat="server" CssClass="label_thailand_title" Font-Bold="True"></asp:Label></td>
            <td align="right" style="width: 30%; height: 19px;" class="see_more2"><asp:Image ID="Image5" runat="server" 
                ImageUrl="~/images/Template/icon_arrow.gif" visible="False" />&nbsp;<a href="#" runat="server" 
                    id="A1" style="text-decoration:none;" visible="False">See more..</a></td>
        </tr>
        </table></td>
</tr>
<tr>
<td align="center" style="width: 100%">
<table><tr><td><div id="booklist_awards-leftnav"></div></td>
<td align="center" width=80%><div id="booklist_awards" class="stepcarousel_award">
<div class="belt">            
        <div class="panel">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="f12_arial">
  <tr>
    <td width="100" align="center"><a href="eBook_SeeMore.aspx?catcode=a1"><img src="images/ebook/newbery.jpg" width="32" height="57" border="0" /></a></td>
    <td align="left" valign="top"><strong><a href="eBook_SeeMore.aspx?catcode=a1" class="menu">Newbery Medal Winners</a></strong><br />
      <br />
    The John Newbery Medal is a literary award given by the Association for Library Service to Children, a division of the American Library Association (ALA).</td>
  </tr>
</table>
</div>
</div>
<!--
<div class="belt">            
        <div class="panel">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="f12_arial">
  <tr>
    <td width="100" align="center"><a href="eBook_SeeMore.aspx?catcode=a2"><img src="images/ebook/caldecott.jpg" width="31" height="55" border="0" /></a></td>
    <td align="left" valign="top"><strong><a href="eBook_SeeMore.aspx?catcode=a2" class="menu">Caldecott Medal Winners</a></strong><br />
      <br />
      The Caldecott Medal is awarded annually by the Association for Library Service to Children (ALSC), a division of the American Library Association</td>
  </tr>
</table>
</div>
</div>!-->
<div class="belt">            
        <div class="panel">
           <table width="100%" border="0" cellpadding="0" cellspacing="0" class="f12_arial">
  <tr>
    <td width="100" align="center"><a href="eBook_SeeMore.aspx?catcode=a3"><img src="images/ebook/man_booker_prizes.jpg" width="43" height="51" border="0" /></a></td>
    <td align="left" valign="top"><strong><a href="eBook_SeeMore.aspx?catcode=a3" class="menu">Man Booker Prize</a></strong><br />
      <br />
      The Man Booker Prize for Fiction, first awarded in 1969, promotes the finest in fiction by rewarding the very best book of the year.</td>
  </tr>
</table>
</div>
</div>
<div class="belt">            
        <div class="panel">
           <table width="100%" border="0" cellpadding="0" cellspacing="0" class="f12_arial">
  <tr>
    <td width="100" align="center"><a href="eBook_SeeMore.aspx?catcode=a4"><img src="images/ebook/orange.jpg" width="45" height="45" border="0" /></a></td>
    <td align="left" valign="top"><strong><a href="eBook_SeeMore.aspx?catcode=a4" class="menu">Orange Prize Winners</a></strong><br />
      <br />
      The Orange Prize for Fiction (known as the Orange Broadband Prize for Fiction from 2007 to 2008) is one of the United Kingdom's most prestigious literary prizes.</td>
  </tr>
</table>
</div>
</div>
<div class="belt">            
        <div class="panel">
           <table width="100%" border="0" cellpadding="0" cellspacing="0" class="f12_arial">
  <tr>
    <td width="100" align="center"><a href="eBook_SeeMore.aspx?catcode=a5"><img src="images/ebook/nobel.jpg" width="59" height="41" border="0" /></a></td>
    <td align="left" valign="top"><strong><a href="eBook_SeeMore.aspx?catcode=a5" class="menu">Nobel Prize Winners: Literature</a></strong><br />
      <br />
      Every year since 1901 the Nobel Prize has been awarded for achievements in physics, chemistry, physiology or medicine, literature and for peace.</td>
  </tr>
</table>
</div>
</div>
<div class="belt">            
        <div class="panel">
           <table width="100%" border="0" cellpadding="0" cellspacing="0" class="f12_arial">
  <tr>
    <td width="100" align="center"><a href="eBook_SeeMore.aspx?catcode=a6"><img src="images/ebook/pulitzer.jpg" width="45" height="59" border="0" /></a></td>
    <td align="left" valign="top"><strong><a href="eBook_SeeMore.aspx?catcode=a6" class="menu">Pulitzer Winners: Fiction</a></strong><br />
      <br />
      In the latter years of the 19th century, Joseph Pulitzer stood out as the very embodiment of American journalism. Hungarian-born, an intense indomitable figure, Pulitzer was the most skillful of newspaper publishers.</td>
  </tr>
</table>
</div>
</div>
<div class="belt">            
        <div class="panel">
           <table width="100%" border="0" cellpadding="0" cellspacing="0" class="f12_arial">
  <tr>
    <td width="100" align="center"><a href="eBook_SeeMore.aspx?catcode=a7"><img src="images/ebook/goldmansach.jpg" width="65" height="35" border="0" /></a></td>
    <td align="left" valign="top"><strong><a href="eBook_SeeMore.aspx?catcode=a7" class="menu">GoldmanSach (Business Book of the Year)</a></strong><br />
      <br />
      Business Book Award 2010: Get in depth coverage of this year's Financial Times and Goldman Sachs 
      Business Book of the Year prize.<br /></td>
  </tr>
</table>
</div>
</div>
</div><br />
<p id="booklist_awards-paginate" style="text-align:center"> 
<img src="images/ebook/opencircle.png" data-over="images/ebook/graycircle.png" data-select="images/ebook/closedcircle.png" data-moveby="1" /> 
</p>
</td>
<td><div id="booklist_awards-rightnav"></div></td></tr></table>
</td>
</tr>     
<%  If lv_ebook3.Items.Count > 0 And lv_ebook3.Visible Then%>
<!--TAB3!-->
<tr>
    <td style="width:100%; height:33px; background-image:url('images/Template/fantastic_saving_bg.jpg'); background-repeat:repeat-x;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 70%">&nbsp;<asp:Label ID="lblhead3" runat="server" CssClass="label_head" Font-Bold="True" />
                <asp:Label ID="Label7" runat="server" CssClass="label_thailand_title" Font-Bold="True"></asp:Label></td>
            <td align="right" style="width: 30%; height: 19px;" class="see_more2"><asp:Image ID="imgSeemore3" runat="server" 
                ImageUrl="~/images/Template/icon_arrow.gif" visible="False" />&nbsp;<a href="#" runat="server" 
                    id="lnkMore3" style="text-decoration:none;" visible="False">See more..</a></td>
        </tr>
        </table></td>
</tr>
<tr>
<td align="center" style="width: 100%">
<table><tr><td><div id="booklist3-leftnav"></div></td><td style="width:50px;">&nbsp;</td>
<td align="left"><div id="booklist3" class="stepcarousel">
<div class="belt">
            <asp:ListView runat="server" ID="lv_ebook3" GroupItemCount="3">
    <LayoutTemplate>
        <div class="panel">
            <li id="groupPlaceholder" runat="server"></li>        
        </div>
    </LayoutTemplate>
    <GroupTemplate>
        <ol class="bookab table-style">
            <li ID="itemPlaceholder" runat="server"></li>
        </ol>
    </GroupTemplate>
    <GroupSeparatorTemplate>
          </div><div class="panel">
        </GroupSeparatorTemplate>
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
                <td align="center" valign="top" ><a href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' ><asp:Image ID="Book_Image" runat="server" ImageUrl='<%# Eval("image") %>' /></a></td>
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
                <a style="text-decoration:none;" class="book-title" href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' rel="add-to-cart">
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("book_title")%>' ToolTip='<%#Eval("book_title")%>'></asp:Label></a></div>
            <div class="book-author">
                <a style="text-decoration:none;" class="book-author" href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>'>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("author")%>' ToolTip='<%#Eval("author")%>'></asp:Label></a></div>
            <div class="book-space"></div>
            <div class="book-priceBaht">
                <asp:Label ID="lblList_Price_H" runat="server" Text="List Price : Bt."></asp:Label>
                <asp:Label ID="lblList_Price_D" runat="server" Text='<%#Eval("list_price")%>'></asp:Label>
                </div>
            <div class="book-yourprice">Your Price : Bt. 
                <asp:Label ID="lblYour_Price" runat="server" Text='<%#Eval("your_price")%>'></asp:Label></div>
            <div class='book-priceUSD'><%# Eval("your_price_usd") %></div>
            <div class='book-save'>
                <asp:Label ID="lblsave_price_L" runat="server" Text="(Save "></asp:Label>
                <asp:Label ID="lblsave_price_C" runat="server" Text='<%#Eval("save_price")%>'></asp:Label>
                <asp:Label ID="lblsave_price_R" runat="server" Text="%)"></asp:Label></div>
            <div class="book-author">
            <asp:Label ID="hdd_ebook_format" runat="server" Text='<%# Eval("eBook_Format") %>' ></asp:Label> 
            </div><br />
            <div class='book-imagestar'>
                <asp:Image ID="imgCustomer_Average" runat="server" />
                <asp:Label ID="Label3" runat="server" Text="( "></asp:Label>
                <asp:Label ID="lblCustomerView" runat="server" Text="0"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text=" )"></asp:Label></div>
            <a href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' rel="add-to-cart"><asp:Image runat="server" ID="imgAddToCart" ImageUrl="~/images/Template/add_to_cart.jpg" style="border:0;" class="add-to-cart-button" /></a>
            <asp:Label ID="lblisbn" runat="server" Text='<%#Eval("isbn_13")%>' Visible="false"></asp:Label>
            </span>
        </li>
    </ItemTemplate>
    </asp:ListView>
    </div>
</div><br />
<p id="booklist3-paginate" style="text-align:center"> 
<img src="images/ebook/opencircle.png" data-over="images/ebook/graycircle.png" data-select="images/ebook/closedcircle.png" data-moveby="1" /> 
</p>
</td>
<td><div id="booklist3-rightnav"></div></td></tr></table>
</td>
</tr>
 <%End If%>  
 <% If lv_ebook4.Items.Count > 0 And lv_ebook4.Visible Then%>
<!--TAB4!-->
<tr>
    <td style="width:100%; height:33px; background-image:url('images/Template/fantastic_saving_bg.jpg'); background-repeat:repeat-x;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 70%">&nbsp;<asp:Label ID="lblhead4" runat="server" CssClass="label_head" Font-Bold="True" />
                <asp:Label ID="Label8" runat="server" CssClass="label_thailand_title" Font-Bold="True"></asp:Label></td>
            <td align="right" style="width: 30%; height: 19px;" class="see_more2"><asp:Image ID="imgSeemore4" runat="server" 
                ImageUrl="~/images/Template/icon_arrow.gif" visible="False" />&nbsp;<a href="#" runat="server" 
                    id="lnkMore4" style="text-decoration:none;" visible="False">See more..</a></td>
        </tr>
        </table></td>
</tr>
<tr>
<td align="center" style="width: 100%">
<table><tr><td><div id="booklist4-leftnav"></div></td><td style="width:50px;">&nbsp;</td>
<td align="left"><div id="booklist4" class="stepcarousel">
<div class="belt">
            <asp:ListView runat="server" ID="lv_ebook4" GroupItemCount="3">
    <LayoutTemplate>
        <div class="panel">
            <li id="groupPlaceholder" runat="server"></li>        
        </div>
    </LayoutTemplate>
    <GroupTemplate>
        <ol class="bookab table-style">
            <li ID="itemPlaceholder" runat="server"></li>
        </ol>
    </GroupTemplate>
    <GroupSeparatorTemplate>
          </div><div class="panel">
        </GroupSeparatorTemplate>
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
                <td align="center" valign="top" ><a href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' ><asp:Image ID="Book_Image" runat="server" ImageUrl='<%# Eval("image") %>' /></a></td>
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
                <a style="text-decoration:none;" class="book-title" href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' rel="add-to-cart">
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("book_title")%>' ToolTip='<%#Eval("book_title")%>'></asp:Label></a></div>
            <div class="book-author">
                <a style="text-decoration:none;" class="book-author" href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>'>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("author")%>' ToolTip='<%#Eval("author")%>'></asp:Label></a></div>
            <div class="book-space"></div>
            <div class="book-priceBaht">
                <asp:Label ID="lblList_Price_H" runat="server" Text="List Price : Bt. "></asp:Label>
                <asp:Label ID="lblList_Price_D" runat="server" Text='<%#Eval("list_price")%>'></asp:Label>
                </div>
            <div class="book-yourprice">Your Price : Bt. 
                <asp:Label ID="lblYour_Price" runat="server" Text='<%#Eval("your_price")%>'></asp:Label></div>
            <div class='book-priceUSD'><%# Eval("your_price_usd") %></div>
            <div class='book-save'>
                <asp:Label ID="lblsave_price_L" runat="server" Text="(Save "></asp:Label>
                <asp:Label ID="lblsave_price_C" runat="server" Text='<%#Eval("save_price")%>'></asp:Label>
                <asp:Label ID="lblsave_price_R" runat="server" Text="%)"></asp:Label></div>
            <div class="book-author">
            <asp:Label ID="hdd_ebook_format" runat="server" Text='<%# Eval("eBook_Format") %>' ></asp:Label> 
            </div><br />
            <div class='book-imagestar'>
                <asp:Image ID="imgCustomer_Average" runat="server" />
                <asp:Label ID="Label3" runat="server" Text="( "></asp:Label>
                <asp:Label ID="lblCustomerView" runat="server" Text="0"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text=" )"></asp:Label></div>
            <a href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' rel="add-to-cart"><asp:Image runat="server" ID="imgAddToCart" ImageUrl="~/images/Template/add_to_cart.jpg" style="border:0;" class="add-to-cart-button" /></a>
            <asp:Label ID="lblisbn" runat="server" Text='<%#Eval("isbn_13")%>' Visible="false"></asp:Label>
            </span>
        </li>
    </ItemTemplate>
    </asp:ListView>
    </div>
</div><br />
<p id="booklist4-paginate" style="text-align:center"> 
<img src="images/ebook/opencircle.png" data-over="images/ebook/graycircle.png" data-select="images/ebook/closedcircle.png" data-moveby="1" /> 
</p>
</td>
<td><div id="booklist4-rightnav"></div></td></tr></table>
</td>
</tr>
 <%End If%>   

 <% If lv_ebook5.Items.Count > 0 And lv_ebook5.Visible Then%>
<!--TAB5!-->
<tr>
    <td style="width:100%; height:33px; background-image:url('images/Template/fantastic_saving_bg.jpg'); background-repeat:repeat-x;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 70%">&nbsp;<asp:Label ID="lblhead5" runat="server" CssClass="label_head" Font-Bold="True" />
                <asp:Label ID="Label10" runat="server" CssClass="label_thailand_title" Font-Bold="True"></asp:Label></td>
            <td align="right" style="width: 30%; height: 19px;" class="see_more2"><asp:Image ID="imgSeemore5" runat="server" 
                ImageUrl="~/images/Template/icon_arrow.gif" visible="False" />&nbsp;<a href="#" runat="server" 
                    id="lnkMore5" style="text-decoration:none;" visible="False">See more..</a></td>
        </tr>
        </table></td>
</tr>
<tr>
<td align="center" style="width: 100%">
<table><tr><td><div id="booklist5-leftnav"></div></td><td style="width:50px;">&nbsp;</td>
<td align="left"><div id="booklist5" class="stepcarousel">
<div class="belt">
            <asp:ListView runat="server" ID="lv_ebook5" GroupItemCount="3">
    <LayoutTemplate>
        <div class="panel">
            <li id="groupPlaceholder" runat="server"></li>        
        </div>
    </LayoutTemplate>
    <GroupTemplate>
        <ol class="bookab table-style">
            <li ID="itemPlaceholder" runat="server"></li>
        </ol>
    </GroupTemplate>
    <GroupSeparatorTemplate>
          </div><div class="panel">
        </GroupSeparatorTemplate>
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
                <td align="center" valign="top" ><a href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' ><asp:Image ID="Book_Image" runat="server" ImageUrl='<%# Eval("image") %>' /></a></td>
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
                <a style="text-decoration:none;" class="book-title" href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' rel="add-to-cart">
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("book_title")%>' ToolTip='<%#Eval("book_title")%>'></asp:Label></a></div>
            <div class="book-author">
                <a style="text-decoration:none;" class="book-author" href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>'>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("author")%>' ToolTip='<%#Eval("author")%>'></asp:Label></a></div>
            <div class="book-space"></div>
            <div class="book-priceBaht">
                <asp:Label ID="lblList_Price_H" runat="server" Text="List Price : Bt. "></asp:Label>
                <asp:Label ID="lblList_Price_D" runat="server" Text='<%#Eval("list_price")%>'></asp:Label>
                </div>
            <div class="book-yourprice">Your Price : Bt. 
                <asp:Label ID="lblYour_Price" runat="server" Text='<%#Eval("your_price")%>'></asp:Label></div>
            <div class='book-priceUSD'><%# Eval("your_price_usd") %></div>
            <div class='book-save'>
                <asp:Label ID="lblsave_price_L" runat="server" Text="(Save "></asp:Label>
                <asp:Label ID="lblsave_price_C" runat="server" Text='<%#Eval("save_price")%>'></asp:Label>
                <asp:Label ID="lblsave_price_R" runat="server" Text="%)"></asp:Label></div>
            <div class="book-author">
            <asp:Label ID="hdd_ebook_format" runat="server" Text='<%# Eval("eBook_Format") %>' ></asp:Label> 
            </div><br />
            <div class='book-imagestar'>
                <asp:Image ID="imgCustomer_Average" runat="server" />
                <asp:Label ID="Label3" runat="server" Text="( "></asp:Label>
                <asp:Label ID="lblCustomerView" runat="server" Text="0"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text=" )"></asp:Label></div>
            <a href='ebook_detail.aspx?code=<%# Eval("isbn_13")%>&format=<%# Eval("Format_Type") %>' rel="add-to-cart"><asp:Image runat="server" ID="imgAddToCart" ImageUrl="~/images/Template/add_to_cart.jpg" style="border:0;" class="add-to-cart-button" /></a>
            <asp:Label ID="lblisbn" runat="server" Text='<%#Eval("isbn_13")%>' Visible="false"></asp:Label>
            </span>
        </li>
    </ItemTemplate>
    </asp:ListView>
    </div>
</div><br />
<p id="booklist5-paginate" style="text-align:center"> 
<img src="images/ebook/opencircle.png" data-over="images/ebook/graycircle.png" data-select="images/ebook/closedcircle.png" data-moveby="1" /> 
</p>
</td>
<td><div id="booklist5-rightnav"></div></td></tr></table>
</td>
</tr>
 <%End If%>   

 
        <tr>
            <td align="left" style="width: 100%">&nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="width: 100%">&nbsp;</td>
        </tr>
        </table></td>
    <td align="right" style="width: 201px" valign="top">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="right" style="width: 100%" valign="top"></td>
        </tr>
        </table></td>
</tr>
<tr>
    <td></td>
    <td style="width: 201px"></td>
</tr>
<tr>
    <td></td>
    <td style="width: 201px"></td>
</tr>
</table>
</asp:Content>

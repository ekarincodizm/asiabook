<%@ Page Language="VB" MasterPageFile="~/MasterPagePopup.master" AutoEventWireup="false"  MaintainScrollPositionOnPostback="true"
    CodeFile="HomepagePopup.aspx.vb" Inherits="HomepagePopup" EnableViewState="true" %>
<%@ Register Src="uc/ucBooks.ascx" TagName="ucBooks" TagPrefix="uc4" %>
<%@ Register Src="uc/ucPromotion.ascx" TagName="ucPromotion" TagPrefix="uc3" %>
<%@ Register Src="uc/ucHotnew_Tilte.ascx" TagName="ucHotnew_Tilte" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="uc/ucTop5.ascx" tagname="ucTop5" tagprefix="uc2" %>
<%@ Register src="uc/ucShopping_Cart.ascx" tagname="ucShopping_Cart" tagprefix="uc5" %>
<%--<%@ OutputCache Duration="60" VaryByParam="none" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">

var mygallery=new fadeSlideShow({
	wrapperid: "fadeshow1", //ID of blank DIV on page to house Slideshow
	dimensions: [455, 269], //width/height of gallery in pixels. Should reflect dimensions of largest image
	imagearray: [
["images/Template/ebooks_available_now.jpg", "ebooks_main.aspx", "", ""],
["images/Template/9780789210784.jpg", "book_detail_Internet.aspx?Title_1=9780789210784", "", ""],
["images/Template/goldsmith.jpg", "Goldsmith.aspx", "", ""],
["images/Template/9786167277035.jpg", "book_detail_Internet.aspx?Title_1=9786167277035", "", ""],
["images/Template/9780062086648.jpg", "book_detail_Internet.aspx?Title_1=9780062086648", "", ""]
	],
	displaymode: {type:'auto', pause:3300, cycles:0, wraparound:false},
	persist: false, //remember last viewed slide and recall within same session?
	fadeduration: 1100, //transition duration (milliseconds)
	descreveal: "ondemand",
	togglerid: ""
})

</script>
<table cellpadding="0" style="width: 100%">
<tr>
    <td style="width:100%; height:269px;" valign="top">
        <table cellpadding="0" cellspacing="0" style="width:100%; height:269px;" >
            <tr style="background-image:url('<% getUrl("/images/Template/Magazine_banner_bg.jpg")%>'); height:269px" valign="top">
                <td style="width:455px; height:269px; background-image:url('<% getUrl("/images/Template/Magazine_banner_bg.jpg")%>');" align="right" valign="top">
                <div id="fadeshow1" style="z-index:500;"></div>
                    <%--<a href="book_detail_Internet.aspx?Title_1=9780141331980"><asp:Image ID="Image6" runat="server" ImageUrl="~/images/Template/Wimpy.jpg" /></a>--%>
                    <%--<object id="FlashID" width="455" height="269">                
                    <param name="movie" value="coming_soon.swf" />
                    <param name="WMODE" value="Transparent" />
                    <embed src="images/Template/coming_soon.swf" wmode="transparent" width="455" height="269" valign="top"></embed>
                    </object>
                    <DIV valign="top" ID="oTransContainer1" STYLE="FILTER:progid:DXImageTransform.Microsoft.Fade(duration=1.0,overlap=1.0);WIDTH:455px;POSITION:absolute;HEIGHT:269px">
					    <DIV ID="oDIV11" STYLE=" WIDTH:455px; POSITION:absolute; HEIGHT:269px"><img id="Img1" style="MARGIN: 0px; CURSOR: hand" width="455" height="269" src="images/Template/HeroesOfOlypus.jpg"
							    align="left" onClick=" window.open('https://www.asiabooks.com/book_detail_Internet.aspx?Title_1=9780141334011','_self');">
					    </DIV>
					    <DIV ID="oDIV21" STYLE=" VISIBILITY:hidden; WIDTH:455px; POSITION:absolute; HEIGHT:269px"><img id="Img2" style="MARGIN: 0px; CURSOR: hand" width="455" height="269" src="images/Template/Wimpy.jpg"
							    align="left" onClick=" window.open('https://www.asiabooks.com/book_detail_Internet.aspx?Title_1=9780141331980','_self');">
					    </DIV>
				    </DIV>--%>
                    </td>    
                <td style="height:269px" valign="top"></td>
                <td style="height:269px" align="right" valign="top"><asp:Image ID="Image1" runat="server" 
                        ImageUrl="~/images/Template/Magazine_banner_right.jpg" Border="0" /></td>
            </tr>
        </table>
    </td>
    <td style="width:201px" align="right" valign="top"><uc2:ucTop5 ID="ucTop51" runat="server" /></td>
</tr>
<tr>
    <td colspan="2"><table cellpadding="0" cellspacing="0" style="width: 100%; height:145px">
          <tr>
                <td style="width: 144px; height:145px" align="right" valign="top" class="see_more2">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="width: 100%">
                                <asp:Image ID="Image5" runat="server" ImageUrl="~/images/Template/hotnew_title.jpg" /></td>
                        </tr>
                    </table>
                    <asp:Image ID="Image17" runat="server" 
                        ImageUrl="~/images/Template/icon_arrow.gif" />
&nbsp;<a href="#" runat="server" id="lnkMore" style="text-decoration:none;" class="see_more2">See more..</a></td>
                <td style="width: 29px;" valign="middle">
                    <asp:Image ID="Image42" runat="server" 
                        ImageUrl="~/images/Template/hotnew_title_left.jpg" />
                </td>
                <td style="width: 11px; height:145px" align="right" valign="top">
                    <asp:Image ID="Image2" runat="server" 
                        ImageUrl="~/images/Template/hotnew_title_start.jpg" />
                   </td>
                <td valign="top" align="left" style="background-image:url('<% getUrl("/images/Template/hotnew_title_bg.jpg")%>'); height:145px ">
                   <uc1:ucHotnew_Tilte ID="UcHotnew_Tilte1" runat="server" />
                   <%-- <object id="Object1" height="145" width="600">                
                    <param name="movie" value="slider_as2.swf" />
                    <param name="WMODE" value="Transparent" />
                    <embed src="flash/slider_as2.swf" wmode="transparent" height="145" width="600"></embed>
                    </object>--%>
                    <%--<div style="width:500px; height:145px">
                    <OBJECT classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" 
                        codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" 
                        height="100%" width="100%" id="Yourfilename" ALIGN="">
                    <PARAM NAME=movie VALUE="flash/slider_as2.swf">
                    <PARAM NAME=quality VALUE=high>
                    <param name="WMODE" value="Transparent" />
                    <EMBED src="/flash/slider_as2.swf" quality=high wmode="transparent" height="100%" width="100%" 
                        NAME="Yourfilename" ALIGN="" TYPE="application/x-shockwave-flash" 
                        PLUGINSPAGE="http://www.macromedia.com/go/getflashplayer"></EMBED></OBJECT></div>--%>
                  <%--<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/
                shockwave/cabs/flash/swflash.cab#version=7,0,0,0" width="600" height="145" id="myfile" align="middle"> 
                <param name="allowScriptAccess" value="sameDomain" /> 
                <param name="movie" value="flash/slider_as2_1.swf" /> 
                <param name="quality" value="high" /> 
                <param name="scale" value="noscale" /> 
                <param name="WMODE" value="Transparent" /> 
                <embed src="flash/slider_as2_1.swf" quality="high" scale="noscale" wmode="transparent" width="600" height="145" name="myfile" align="middle" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go
                /getflashplayer" /> 
                </object> --%>
                </td>
                <td style="width: 10px; height:145px" valign="top">
                <asp:Image ID="Image4" runat="server" 
                        ImageUrl="~/images/Template/hotnew_title_end.jpg"/>
                   </td>
                <td style="width: 29px;" valign="middle">
                    <asp:Image ID="Image3" runat="server" 
                        ImageUrl="~/images/Template/hotnew_title_right.jpg" /></td>
            </tr>
        </table></td>
</tr>
<tr>
    <td valign="top" style="height: 13px">
                    </td>
    <td align="center" rowspan="4" style="width: 201px" valign="top">
        <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 100%">
        <uc3:ucPromotion ID="UcPromotion1" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%">
                    <table cellpadding="0" cellspacing="0" style="width: 201px">
                        <tr>
                            <td style="width: 201px" valign="top">
                                <asp:Image ID="Image50" runat="server" 
                                    ImageUrl="~/images/About/bar_about.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 201px; height: 277px; background-image: url('images/About/bg_about.gif');" 
                                valign="top" align="center">
                                <table cellpadding="0" style="width: 180px">
                                    <tr>
                                        <td style="width: 180px">
                                            <asp:Image ID="Image51" runat="server" 
                                                ImageUrl="~/images/About/about_pic.jpg" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" 
                                            style="width: 180px; font-family: arial, Helvetica, sans-serif; font-size: 8pt; color: #808080;">
        <span style="color: #006600"><strong>Asia Books</strong></span> has been serving the literary public in Bangkok since its opening in September 1969.
        <br />
        <br />
                                            Today, it is the first and the largest English language bookstore chain and 
                                            distributor in Thailand, offering varieties of books and magazines.<br />
                                            <br />
                                            Our Retail chain of more than 70 shops under Asia Books and Bookazine brand’s 
                                            target customers include English-speaking Thais, expatriates and tourists.
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table></td>
                                                </tr>
                                            <tr>
                <td style="width: 100%; font-size: 8pt;" align="right" class="font_other">
                    <asp:Image ID="Image52" runat="server" 
                        ImageUrl="~/images/Template/icon_arrow.gif" />
&nbsp;<a href="About_Us.aspx" style="text-decoration:none">See more...</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
</tr>
<tr>
    <td valign="top" style="height: 25px">
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td class="font_other" style="width: 250px">
                                    See more books in each popular category&nbsp; :</td>
                                <td>
                                    <asp:DropDownList ID="ddlCat" runat="server" Width="230px" AutoPostBack="True" Height="22px" />
                                </td>
                            </tr>
                        </table>
                    </td>
</tr>
<tr>
    <td valign="top" style="height: 15px">
                        &nbsp;</td>
</tr>
<tr>
    <td valign="top">
        <table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr style="width:100%">
            <td colspan="3" style="width: 100%"><uc4:ucBooks ID="UcBooks1" runat="server" /></td>
        </tr>
        <tr style="width: 100%">
            <td colspan="3" style="width: 100%;"></td>
        </tr>
        <tr style="width: 100%">
            <td colspan="3" style="width: 100%"><uc4:ucBooks ID="UcBooks2" runat="server" /></td>
        </tr>
        <tr style="width: 100%">
            <td colspan="3" style="width: 100%;"></td>
        </tr>
        <tr style="width: 100%">
            <td colspan="3" style="width: 100%"><uc4:ucBooks ID="UcBooks3" runat="server" /></td>
        </tr>
        <tr style="width: 100%">
            <td colspan="3" style="width: 100%"></td>
        </tr>
        <tr style="width: 100%">
            <td colspan="3" style="width: 100%"><uc4:ucBooks ID="UcBooks4" runat="server" Visible="false" /></td>
        </tr>
        <tr style="width: 100%">
            <td colspan="3" style="width: 100%"></td>
        </tr>
        </table></td>
    <td>&nbsp;</td>
</tr>
<tr>
<td style="width: 9px">&nbsp;</td>
<td>&nbsp;</td>
</tr>
</table>
</asp:Content>
<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Reading_Time.aspx.vb" Inherits="Reading_Time" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 100%; height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 100%">
                <asp:Image ID="Image43" runat="server" 
                    ImageUrl="~/images/Template/reading_time_head.jpg" />
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 100%">
                <asp:Label ID="lblNumber" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 100%">
            <span id="spanRTOnline" runat="server"></span>
              <%-- <div><object style="width:650px;height:464px" ><param name="movie" 
               value="http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=100901082713-43f3de64999643d9b21c287e1fa90c27&amp;docName=readingtime_living_with_art_10&amp;username=Asiabooks&amp;loadingInfoText=Reading%20Time%3A%20Living%20with%20Art%20(Sep%20-%20Oct%202010)&amp;et=1283739374872&amp;er=91" />
               <param name="allowfullscreen" value="true"/><param name="menu" value="false"/>
               <embed src="http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf" 
               type="application/x-shockwave-flash" allowfullscreen="true" 
               menu="false" style="width:650px;height:464px" 
               flashvars="mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=100901082713-43f3de64999643d9b21c287e1fa90c27&amp;docName=readingtime_living_with_art_10&amp;username=Asiabooks&amp;loadingInfoText=Reading%20Time%3A%20Living%20with%20Art%20(Sep%20-%20Oct%202010)&amp;et=1283739374872&amp;er=91" /></object></div> --%>
                </td>
        </tr>
        <tr>
            <td align="center" style="width: 100%">
                <a href="#" id="lnkDownload" runat="server" target="_blank">
                <asp:Label ID="lblDownload" runat="server" Text="Download File Reading Time" Visible="False"></asp:Label></a>
                </td>
        </tr>
        <tr>
            <td align="center" style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" style="width: 100%">
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td style="width: 120px" align="center">
                            <asp:ImageButton ID="img1" runat="server" 
                                ImageUrl="~/images/Template/Reading_Time/ART2_cover.jpg" />
                        </td>
                        <td style="width: 120px" align="center">
                            <asp:ImageButton ID="img2" runat="server" 
                                ImageUrl="~/images/Template/Reading_Time/CH2_Cover.jpg" />
                        </td>
                        <td style="width: 120px" align="center">
                            <asp:ImageButton ID="img3" runat="server" 
                                ImageUrl="~/images/Template/Reading_Time/vg10.jpg" />
                        </td>
                        <td style="width: 120px" align="center">
                            <asp:ImageButton ID="img4" runat="server" 
                                ImageUrl="~/images/Template/Reading_Time/FictionCover.jpg" />
                        </td>
                        <td style="width: 120px" align="center">
                            <asp:ImageButton ID="img5" runat="server" 
                                ImageUrl="~/images/Template/Reading_Time/CH_Cover.jpg" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px">
                            &nbsp;</td>
                        <td style="width: 120px">
                            &nbsp;</td>
                        <td style="width: 120px">
                            &nbsp;</td>
                        <td align="left" style="width: 120px">
                            &nbsp;</td>
                        <td style="width: 120px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 120px" align="center">
                            <asp:ImageButton ID="img6" runat="server" 
                                ImageUrl="~/images/Template/Reading_Time/ART_cover.jpg" />
                        </td>
                        <td style="width: 120px" align="center">
                            &nbsp;</td>
                        <td style="width: 120px" align="center">
                            &nbsp;</td>
                        <td style="width: 120px" align="center">
                            &nbsp;</td>
                        <td style="width: 120px" align="center">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 100%">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


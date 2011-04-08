<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="My_Ebook.aspx.vb" Inherits="My_Ebook" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="MycustomDG" Namespace="MycustomDG" TagPrefix="Saifi" %>  

<%@ Register src="uc/ucBooks.ascx" tagname="ucBooks" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         
    <table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="WIDTH: 100%" class="header_other">
                My eBook</td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%">
                <%--Instruction: Users need to install and activate the following programs to read eBooks.
                <br /> &bull; Flash Player (for download link file), 
                <a href='http://www.adobe.com/products/digitaleditions/'>Adobe Digital Edition</a> (DRM-PDF, DRM-EPUB), <a href='http://www.microsoft.com/reader/update'>Microsoft Reader</a> (LIT). --%>
                Instruction: Following programs should be installed to read the eBooks: <br />
                Flash Player (for download link file), <a href='http://www.adobe.com/products/digitaleditions/'>Adobe Digital Edition (DRM-PDF, DRM-EPUB)</a>, and <a href='http://das.microsoft.com/activate/en-us/default.asp'>Microsoft Reader (LIT)</a>.
                <div style="cursor:pointer"><a onclick="javascript:window.open('Reader.html','_blank')"><img src="images/ebook/which.jpg" /></a></div>
                </td>
        </tr>
        <%--
        <tr>
            <td class="label_thailand_title" style="HEIGHT: 33px; TEXT-ALIGN: left;background-image: url(images/Template/other_by_author_bg.jpg);">
                &nbsp;&nbsp; Your Order</td>
        </tr>
        <tr>
            <td style="width: 100%" class="labelBest_Title">
                &nbsp;</td>
        </tr>
        --%>
        <tr>
            <td style="width: 100%">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<%--
<tr>
    <td align="left" style="width: 100%; ">
                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="width: 20%; height: 30px;" align="left" class="labelsort_by">
                                Order No. : </td>
                            <td style="width: 30%; height: 30px;" align="left">
                                <asp:TextBox ID="txtOrder_No" runat="server" Width="200px" Height="18px"></asp:TextBox>
                            </td>
                            <td style="width: 5%; height: 30px;">
                                </td>
                            <td style="width: 45%; height: 30px;">
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; height: 30px;" align="left" class="labelsort_by">
                                Original Order Date : </td>
                            <td style="width: 30%; height: 30px;" align="left">
                                <asp:TextBox ID="txtStartDate" runat="server" Width="200px" Height="20px" />
                    <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtStartDate" /></td>
                            <td style="width: 5%; height: 30px;" align="center" class="labelsort_by">
                                To</td>
                            <td style="width: 45%; height: 30px;" align="left">
                                <asp:TextBox runat="server" 
                ID="txtEndDate" Width="200px" Height="18px" /><cc1:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtEndDate" Format="dd/MM/yyyy" /></td>
                        </tr>
                        <tr>
                            <td style="width: 20%; height: 30px;" align="left" class="labelsort_by">
                                Date Range:	</td>
                            <td style="height: 30px;" class="font_other" colspan="3">
                                <asp:RadioButton ID="rdio30day" runat="server" GroupName="a" 
                                    Text="past 30 days" />
                                <asp:RadioButton ID="rdio60day" runat="server" GroupName="a" 
                                    Text="past 60 days" />
                                <asp:RadioButton ID="rdio90day" runat="server" GroupName="a" 
                                    Text="past 90 days" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" align="left" class="labelsort_by">
                                &nbsp;</td>
                            <td style="width: 30%">
                                &nbsp;</td>
                            <td style="width: 5%">
                                &nbsp;</td>
                            <td style="width: 45%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 20%" align="left" class="labelsort_by">
                                &nbsp;</td>
                            <td style="width: 30%">
                                <asp:ImageButton ID="b_search" runat="server" 
                                    ImageUrl="~/images/b_search.jpg" />
                            </td>
                            <td style="width: 5%">
                                &nbsp;</td>
                            <td style="width: 45%">
                                &nbsp;</td>
                        </tr>
                    </table>
    </td>
</tr>
--%>
<tr align="right">
    <td>&nbsp;</td>
</tr>
<tr align="left">
    <td align="left" style="width: 100%;">
        <asp:Label ID="Label_Result" runat="server"></asp:Label>
    </td>
</tr>
<tr align="center">
    <td align="center" style="width: 100%; height: 35px; text-align: left">
      
            <ContentTemplate>
                <Saifi:MyDg style="BORDER-RIGHT: #047700 2px solid; BORDER-TOP: #047700 2px solid; BORDER-LEFT: #047700 2px solid; BORDER-BOTTOM: #047700 2px solid" 
                    id="Datagrid" runat="server" Width="98%" CssClass="Grid_inq" 
                    HorizontalAlign="Center" AllowPaging="True" AutoGenerateColumns="False" 
                    BorderColor="Transparent" CellPadding="5" HeaderStyle-BackColor="#aaaadd" 
                    HeaderStyle-CssClass="tableHeader" ImageFirst="images/b_firstpage.gif" 
                    ImageLast="images/b_lastpage.gif" ImageNext="images/b_nextpage.gif" 
                    ImagePrevious="images/b_prevpage.gif" ItemStyle-CssClass="tableItem" 
                    SelectedItemStyle-BackColor="#99ccff" ShowFirstAndLastImage="True" 
                    ShowPreviousAndNextImage="True" OnPageIndexChanged="Datagrid_PageIndexChanged" 
                    GridLines="None" DataKeyField="MyEBookID"
                    UseAccessibleHeader="True">
<SelectedItemStyle BackColor="#99CCFF"></SelectedItemStyle>

<AlternatingItemStyle CssClass="Grid_inqAltItem"></AlternatingItemStyle>

<ItemStyle CssClass="Grid_inqItem"></ItemStyle>

<PagerStyle Mode="NumericPages" PageButtonCount="5" CssClass="Grid_inqPager"></PagerStyle>
<Columns>
<asp:TemplateColumn HeaderText="ISBN"><EditItemTemplate>
&nbsp; 
</EditItemTemplate>
<FooterTemplate>
&nbsp;<asp:Label id="lbltxt" runat="server" ForeColor="#FF6600" Font-Size="Smaller" Font-Names="Verdana" Font-Bold="True" Text="No eBook" __designer:wfdid="w52"></asp:Label>
</FooterTemplate>
<ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_ISBN" runat="server"  
        ForeColor="#4E4E4E" Font-Size="11px" Font-Names="Verdana" 
        Text='<%# DataBinder.Eval(Container.DataItem,"isbn_13") %>' 
        __designer:wfdid="w51"></asp:Label>&nbsp;&nbsp;&nbsp; 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Title"><EditItemTemplate>
&nbsp; 
</EditItemTemplate>
<ItemTemplate>

<a class="Grid_bookItem_A" href="Ebook_Download_History.aspx?MyEBookID=<%# DataBinder.Eval(Container, "DataItem.MyEBookID") %>">
<asp:Label style="TEXT-ALIGN: left" id="lbl_Title" runat="server"  
        Font-Size="11px" Font-Names="Verdana" 
        Text='<%# DataBinder.Eval(Container.DataItem,"book_title") %>' 
        __designer:wfdid="w44"></asp:Label>&nbsp; 
</a>
    <asp:Label ID="lbl_Note" runat="server" CssClass="textRed" Visible="false"></asp:Label>
    
</ItemTemplate>

</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="eBook Format">
    <ItemTemplate>
        <asp:Label ID="lbl_Format" runat="server" __designer:wfdid="w51" 
            Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" 
            style="TEXT-ALIGN: left" 
            Text='<%# DataBinder.Eval(Container.DataItem,"Type") %>'></asp:Label>
    </ItemTemplate>
    
    <HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Max Download" ItemStyle-HorizontalAlign="Center"><EditItemTemplate>
&nbsp; 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lbl_Max_Download" runat="server" 
        Width="60px" ForeColor="#4E4E4E" Font-Size="11px" Font-Names="Verdana" 
        Text='<%# DataBinder.Eval(Container.DataItem,"max_download") %>' 
        __designer:wfdid="w45"></asp:Label>&nbsp; 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Downloaded Times" ItemStyle-HorizontalAlign="Center">
<ItemTemplate>
    <asp:Label id="lbl_Downloaded_Times" runat="server" 
        Width="114px" ForeColor="#4E4E4E" Font-Size="11px" Font-Names="Verdana" 
        Text='<%# DataBinder.Eval(Container.DataItem,"Downloaded_Times") %>' 
        Font-Bold="False"></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateColumn>
    <asp:TemplateColumn HeaderText="Order No">
        <ItemTemplate>
        <a href="Customer_Order_Tracking_Internet.aspx?action=Edit&Order_NO=<%# DataBinder.Eval(Container.DataItem,"Order_No") %>">
            <asp:Label style="TEXT-ALIGN: left" id="lbl_Order" runat="server"  
                    Font-Size="11px" Font-Names="Verdana" 
                    Text='<%# DataBinder.Eval(Container.DataItem,"Order_No") %>' 
                    __designer:wfdid="w44"></asp:Label>&nbsp; 
            </a>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox runat="server" 
                Text='<%# DataBinder.Eval(Container, "DataItem.Order_No") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Download"><ItemTemplate>
    <asp:ImageButton ID="b_Select" runat="server" __designer:wfdid="w40" 
        ImageUrl="~/images/b_download.jpg" onclick="b_Select_Click" OnClientClick="this.style.visibility = 'hidden'" />

</ItemTemplate>
    <HeaderStyle Width="10%" />
    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
</asp:TemplateColumn>
<asp:BoundColumn HeaderText="MyEBookID" Visible="False"></asp:BoundColumn>
    <asp:TemplateColumn HeaderText="Download_URL" Visible="false">
        <EditItemTemplate>
            <asp:TextBox runat="server" 
                Text='<%# DataBinder.Eval(Container, "DataItem.Download_URL") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Label runat="server" 
                Text='<%# DataBinder.Eval(Container, "DataItem.Download_URL") %>' ID="lbl_Download_URL"></asp:Label>
        </ItemTemplate>
    </asp:TemplateColumn>
    <asp:TemplateColumn HeaderText="Is_Void" Visible="false">
        <ItemTemplate>
            <asp:Label runat="server" 
                Text='<%# DataBinder.Eval(Container, "DataItem.Is_Void") %>' ID="lbl_Is_Void"></asp:Label>
        </ItemTemplate>
    </asp:TemplateColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" BackColor="#49A514" BorderStyle="None" CssClass="Grid_inqHeader" Font-Bold="True" Font-Italic="False" Font-Names="Verdana" Font-Overline="False" Font-Size="11px" Font-Strikeout="False" Font-Underline="False" ForeColor="White"></HeaderStyle>
</Saifi:MyDg> 
</ContentTemplate>
           <%-- <triggers>
<asp:AsyncPostBackTrigger ControlID="b_search" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>--%>
       &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
</tr>
<tr>
    <td style="width: 100%; text-align: center">
    </td>
</tr>
<tr>
    <td style="width: 100%" class="font_other">
    <b>
    <asp:Label ID="lbl_UnAuthEBook" runat="server" CssClass="font_other" ForeColor="#FF6600"></asp:Label>
    </b></td>
</tr>
<tr align="left">
    <td align="left" style="width: 100%;">
        <asp:Label ID="Label_Result2" runat="server"></asp:Label>
    </td>
</tr>
<tr align="center">
    <td align="center" style="width: 100%; height: 35px; text-align: left">
      
            <ContentTemplate>
                <Saifi:MyDg style="BORDER-RIGHT: #047700 2px solid; BORDER-TOP: #047700 2px solid; BORDER-LEFT: #047700 2px solid; BORDER-BOTTOM: #047700 2px solid" 
                    id="Datagrid2" runat="server" Width="98%" CssClass="Grid_inq" 
                    HorizontalAlign="Center" AllowPaging="True" AutoGenerateColumns="False" 
                    BorderColor="Transparent" CellPadding="5" HeaderStyle-BackColor="#aaaadd" 
                    HeaderStyle-CssClass="tableHeader" ImageFirst="images/b_firstpage.gif" 
                    ImageLast="images/b_lastpage.gif" ImageNext="images/b_nextpage.gif" 
                    ImagePrevious="images/b_prevpage.gif" ItemStyle-CssClass="tableItem" 
                    SelectedItemStyle-BackColor="#99ccff" ShowFirstAndLastImage="True" 
                    ShowPreviousAndNextImage="True" OnPageIndexChanged="Datagrid2_PageIndexChanged" 
                    GridLines="None" DataKeyField="MyEBookID"
                    UseAccessibleHeader="True">
<SelectedItemStyle BackColor="#99CCFF"></SelectedItemStyle>

<AlternatingItemStyle CssClass="Grid_inqAltItem"></AlternatingItemStyle>

<ItemStyle CssClass="Grid_inqItem"></ItemStyle>

<PagerStyle Mode="NumericPages" PageButtonCount="5" CssClass="Grid_inqPager"></PagerStyle>
<Columns>
<asp:TemplateColumn HeaderText="ISBN"><EditItemTemplate>
&nbsp; 
</EditItemTemplate>
<FooterTemplate>
&nbsp;<asp:Label id="lbltxt" runat="server" ForeColor="#FF6600" Font-Size="Smaller" Font-Names="Verdana" Font-Bold="True" Text="No eBook" __designer:wfdid="w52"></asp:Label>
</FooterTemplate>
<ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_ISBN" runat="server"  
        ForeColor="#4E4E4E" Font-Size="11px" Font-Names="Verdana" 
        Text='<%# DataBinder.Eval(Container.DataItem,"isbn_13") %>' 
        __designer:wfdid="w51"></asp:Label>&nbsp;&nbsp;&nbsp; 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Title"><EditItemTemplate>
&nbsp; 
</EditItemTemplate>
<ItemTemplate>

<asp:Label style="TEXT-ALIGN: left" id="lbl_Title" runat="server"  
        ForeColor="#4E4E4E" Font-Size="11px" Font-Names="Verdana"
        Text='<%# DataBinder.Eval(Container.DataItem,"book_title") %>' 
        __designer:wfdid="w44"></asp:Label>&nbsp; 

</ItemTemplate>

</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="eBook Format">
    <ItemTemplate>
        <asp:Label ID="lbl_Format" runat="server" __designer:wfdid="w51" 
            Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" 
            style="TEXT-ALIGN: left" 
            Text='<%# DataBinder.Eval(Container.DataItem,"Type") %>'></asp:Label>
    </ItemTemplate>
    
    <HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Max Download" ItemStyle-HorizontalAlign="Center" Visible="false"><EditItemTemplate>
&nbsp; 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lbl_Max_Download" runat="server" 
        Width="60px" ForeColor="#4E4E4E" Font-Size="11px" Font-Names="Verdana" 
        Text='<%# DataBinder.Eval(Container.DataItem,"max_download") %>' 
        __designer:wfdid="w45"></asp:Label>&nbsp; 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Downloaded Times" ItemStyle-HorizontalAlign="Center" Visible="false">
<ItemTemplate>
    <asp:Label id="lbl_Downloaded_Times" runat="server" 
        Width="114px" ForeColor="#4E4E4E" Font-Size="11px" Font-Names="Verdana" 
        Text='<%# DataBinder.Eval(Container.DataItem,"Downloaded_Times") %>' 
        Font-Bold="False"></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Download" Visible="false"><ItemTemplate>
    <asp:ImageButton ID="b_Select" runat="server" __designer:wfdid="w40" 
        ImageUrl="~/images/b_download.jpg" onclick="b_Select_Click" OnClientClick="this.style.visibility = 'hidden'" />
    
</ItemTemplate>
    <HeaderStyle Width="10%" />
    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
</asp:TemplateColumn>
    <asp:BoundColumn DataField="Order_No" HeaderText="Order No" Visible="True" ItemStyle-Width="15%"></asp:BoundColumn>
    <asp:BoundColumn HeaderText="MyEBookID" Visible="false"></asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" BackColor="#49A514" BorderStyle="None" CssClass="Grid_inqHeader" Font-Bold="True" Font-Italic="False" Font-Names="Verdana" Font-Overline="False" Font-Size="11px" Font-Strikeout="False" Font-Underline="False" ForeColor="White"></HeaderStyle>
</Saifi:MyDg> 
</ContentTemplate>
           <%-- <triggers>
<asp:AsyncPostBackTrigger ControlID="b_search" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>--%>
       &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
</tr>
<tr>
    <td style="width: 100%; text-align: center">
    </td>
</tr>
</table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
    </table> 
</asp:Content>


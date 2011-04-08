<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="Ebook_Download_History.aspx.vb" Inherits="Ebook_Download_History" title="Untitled Page" %>
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
                My eBook Download History</td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
        <%-- <triggers>
<asp:AsyncPostBackTrigger ControlID="b_search" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>--%>
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
    <td align="right" style="width: 80%; padding-right: 20px"></td>
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
                    GridLines="None" UseAccessibleHeader="True">
<SelectedItemStyle BackColor="#99CCFF"></SelectedItemStyle>

<AlternatingItemStyle CssClass="Grid_inqAltItem"></AlternatingItemStyle>

<ItemStyle CssClass="Grid_inqItem"></ItemStyle>

<PagerStyle Mode="NumericPages" PageButtonCount="5" CssClass="Grid_inqPager"></PagerStyle>
<Columns>

<asp:TemplateColumn HeaderText="Timestamp">
    <ItemTemplate>
        <asp:Label ID="lbl_Timestamp" runat="server" __designer:wfdid="w51" 
            Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" 
            style="TEXT-ALIGN: left" 
            Text='<%# DataBinder.Eval(Container.DataItem,"Timestamp") %>'></asp:Label>
    </ItemTemplate>
    <HeaderStyle Width="15%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="ISBN"><EditItemTemplate>
&nbsp; 
</EditItemTemplate>
<FooterTemplate>
&nbsp;<asp:Label id="lbltxt" runat="server" ForeColor="#FF6600" Font-Size="Smaller" Font-Names="Verdana" Font-Bold="True" Text="No Data" __designer:wfdid="w52"></asp:Label>
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

<HeaderStyle Width="30%"></HeaderStyle>
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

<asp:TemplateColumn HeaderText="Status" Visible="True">
    <ItemTemplate>
        <asp:Label ID="lbl_Status" runat="server" __designer:wfdid="w51" 
            Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E" 
            style="TEXT-ALIGN: left" 
            Text='<%# DataBinder.Eval(Container.DataItem,"Status") %>'></asp:Label>
    </ItemTemplate>
    
    <HeaderStyle Width="20%"></HeaderStyle>
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
</table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
    </table> 
</asp:Content>


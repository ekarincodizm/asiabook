<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Customer_Tracking_Internet.aspx.vb" Inherits="Customer_Tracking_Internet" title="Untitled Page" %>
<%@ Register Assembly="MycustomDG" Namespace="MycustomDG" TagPrefix="Saifi" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td align="center" style="width: 100%; height: 51px; text-align: center">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
            <tr>
                <td align="left" style="width: 100%; height: 20px; text-align: left">
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 100%; height: 26px; text-align: left" class="header_other">
                Order Status & History</td>
            </tr>
            <tr>
                <td align="left" style="width: 100%; height: 35px; text-align: left" class="font_other">
                    Check the current status of your orders by entering one or more selections, then 
                    click Search.<br /><br /><br /></td>
            </tr>
            <tr>
                <td align="left" style="width: 100%; height: 44px; text-align: left">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 90%">
                            <tr>
                                <td class="search_order" style="width: 20%; height: 33px" align="right">
                                    Customer Order N0. :&nbsp;&nbsp; </td>
                                <td class="search_order" style="width: 35%; height: 33px">
                                    <asp:TextBox ID="tbx_order_no" runat="server" Font-Names="MS Sans Serif" Font-Size="10pt"
                                        Width="214px"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 40%; ">
                                    <asp:ImageButton ID="b_search" runat="server" ImageUrl="~/images/b_search.jpg" />
                                </td>
                            </tr>
                            </table>
                        &nbsp; &nbsp;<br />
                </td>
            </tr>
        </table>
                                    <asp:UpdateProgress id="UpdateProgress1" runat="server">
                                        <progresstemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/images/loading.gif" __designer:wfdid="w38"></asp:Image><BR /><SPAN style="FONT-SIZE: 9pt">
                                                Loading.. </SPAN>
</progresstemplate>
                                    </asp:UpdateProgress>
    </td>
</tr>
<tr align="center">
    <td align="right" style="width: 100%; height: 20px; ">
        <asp:Label ID="Label_Result" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
</tr>
<tr align="center">
    <td align="center" style="width: 100%; height: 35px; text-align: left">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <Saifi:MyDg style="BORDER-RIGHT: #047700 2px solid; BORDER-TOP: #047700 2px solid; BORDER-LEFT: #047700 2px solid; BORDER-BOTTOM: #047700 2px solid" id="Datagrid" runat="server" Width="95%" CssClass="Grid_inq" HorizontalAlign="Center" AllowPaging="True" AutoGenerateColumns="False" BorderColor="Transparent" CellPadding="5" HeaderStyle-BackColor="#aaaadd" HeaderStyle-CssClass="tableHeader" ImageFirst="images/b_firstpage.gif" ImageLast="images/b_lastpage.gif" ImageNext="images/b_nextpage.gif" ImagePrevious="images/b_prevpage.gif" ItemStyle-CssClass="tableItem" SelectedItemStyle-BackColor="#99ccff" ShowFirstAndLastImage="True" ShowPreviousAndNextImage="True" OnPageIndexChanged="Datagrid_PageIndexChanged" OnEditCommand="Datagrid_EditCommand" GridLines="None">
<SelectedItemStyle BackColor="#99CCFF"></SelectedItemStyle>

<AlternatingItemStyle CssClass="Grid_inqAltItem"></AlternatingItemStyle>

<ItemStyle CssClass="Grid_inqItem"></ItemStyle>

<PagerStyle Mode="NumericPages" PageButtonCount="5" CssClass="Grid_inqPager"></PagerStyle>
<Columns>
<asp:TemplateColumn HeaderText="Order No "><EditItemTemplate>
    &nbsp; 
</EditItemTemplate>
<FooterTemplate>
    &nbsp;<asp:Label id="lbltxt" runat="server" ForeColor="#FF6600" Font-Size="Smaller" Font-Names="Verdana" Font-Bold="True" Text="Data not found in your search" __designer:wfdid="w52"></asp:Label>
</FooterTemplate>
<ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_Order_no" runat="server" Width="120px" ForeColor="#4E4E4E" Font-Size="11px" Font-Names="Verdana" Text='<%# DataBinder.Eval(Container.DataItem,"Order_No") %>' __designer:wfdid="w51"></asp:Label>
    &nbsp;&nbsp;&nbsp; 
</ItemTemplate>

<HeaderStyle Width="15%"></HeaderStyle>

<ItemStyle Font-Names="Verdana" Font-Size="11px" ForeColor="#4E4E4E"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Customer Name"><EditItemTemplate>
    &nbsp; 
</EditItemTemplate>
<ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_CustomerName" runat="server" Width="170px" ForeColor="#4E4E4E" Font-Size="11px" Font-Names="Verdana" Text='<%# DataBinder.Eval(Container.DataItem,"Customer_Name") %>' __designer:wfdid="w44"></asp:Label>
    &nbsp; 
</ItemTemplate>

<HeaderStyle Width="30%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Member ID"><EditItemTemplate>
    &nbsp; 
</EditItemTemplate>
<ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_Member_Id" runat="server" Width="60px" ForeColor="#4E4E4E" Font-Size="11px" Font-Names="Verdana" Text='<%# DataBinder.Eval(Container.DataItem,"Member_Id") %>' __designer:wfdid="w45"></asp:Label>
    &nbsp; 
</ItemTemplate>

<HeaderStyle Width="15%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Order Date"><EditItemTemplate>
    &nbsp; 
</EditItemTemplate>
<ItemTemplate>
<asp:Label style="TEXT-ALIGN: center" id="lbl_Order_Data" runat="server" Width="100px" ForeColor="#4E4E4E" Font-Size="11px" Font-Names="Verdana" Text='<%# DataBinder.Eval(Container.DataItem,"Order_Date") %>' __designer:wfdid="w46"></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="15%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Branch Name"><ItemTemplate>
    &nbsp;<asp:Label style="TEXT-ALIGN: left" id="lbl_Branch" runat="server" Width="114px" Text='<%# DataBinder.Eval(Container.DataItem,"Org_AB_Name") %>' Font-Size="11px" Font-Names="Verdana" ForeColor="#4E4E4E" Font-Bold="False"></asp:Label> 
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Sale Channel" Visible="False"><EditItemTemplate>
    &nbsp; 
</EditItemTemplate>
<ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_Sales_Channel_Name" runat="server" Width="70px" Font-Size="11px" Font-Names="Verdana" Text='<%# DataBinder.Eval(Container.DataItem,"Sales_Channel_Name") %>' ForeColor="#4E4E4E"></asp:Label>
    &nbsp; 
</ItemTemplate>

<HeaderStyle Width="15%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Select"><ItemTemplate>
<asp:ImageButton id="b_Select" runat="server" ImageUrl="~/images/b_view.jpg" __designer:wfdid="w40" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Order_No") %>'></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="sale_channel_code" Visible="False"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_Sales_Channel_Code" runat="server" Width="70px" Font-Size="11px" Font-Names="Verdana" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Sales_Channel_Code") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" BackColor="#49A514" BorderStyle="None" CssClass="Grid_inqHeader" Font-Bold="True" Font-Italic="False" Font-Names="Verdana" Font-Overline="False" Font-Size="11px" Font-Strikeout="False" Font-Underline="False" ForeColor="White"></HeaderStyle>
</Saifi:MyDg> 
</ContentTemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="b_search" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
</tr>
<tr>
    <td align="center" style="width: 100%; height: 19px; text-align: center">
        &nbsp;&nbsp;
    </td>
</tr>
<tr>
    <td style="width: 100%; text-align: center">
    </td>
</tr>
</table>
</asp:Content>
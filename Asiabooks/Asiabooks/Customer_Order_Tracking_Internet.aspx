<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Customer_Order_Tracking_Internet.aspx.vb" Inherits="Customer_Order_Tracking_Internet" title="Untitled Page" %>
<%@ Register Src="uc/Country.ascx" TagName="Country" TagPrefix="uc2" %>
<%@ Register Src="uc/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>
<%@ Register Assembly="MycustomDG" Namespace="MycustomDG" TagPrefix="Saifi" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="center" style="width: 100%; height: 51px; text-align: left">
                <span style="font-size: 16pt; color: #666666"><strong>
                  
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="width: 100%; height: 27px" colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 5%; height: 27px">
                            </td>
                            <td style="width: 15%; height: 27px" class="font_gray_11">
                                &nbsp;Order No :</td>
                            <td style="width: 30%; height: 27px">
                                <asp:Label ID="lbl_h_order_no" runat="server" Font-Names="MS Sans Serif" Font-Size="10pt" Width="97%"></asp:Label></td>
                            <td style="width: 15%; height: 27px" class="font_gray_11">
                                &nbsp;Order Date :</td>
                            <td style="width: 30%; height: 27px">
                                <asp:Label ID="lbl_h_Order_Date" runat="server" Font-Names="MS Sans Serif" Font-Size="10pt"
                                    Width="60%"></asp:Label></td>
                            <td style="width: 5%; height: 27px">
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 5%;
                                height: 27px">
                            </td>
                            <td style="width: 15%; height: 27px" class="font_gray_11">
                                &nbsp;Customer Name :</td>
                            <td style="width: 30%;
                                height: 27px">
                                <asp:Label ID="lbl_h_customer_name" runat="server" Font-Names="MS Sans Serif" Font-Size="10pt" Width="98%"></asp:Label></td>
                            <td style="width: 15%; height: 27px" class="font_gray_11">
                                &nbsp;Telephone :</td>
                            <td style="width: 30%;
                                height: 27px">
                                <asp:Label ID="lbl_h_telephone" runat="server" Font-Names="MS Sans Serif" Font-Size="10pt" Width="100%"></asp:Label></td>
                            <td style="width: 5%;
                                height: 27px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 5%; height: 27px">
                            </td>
                            <td class="font_gray_11" style="width: 15%; height: 27px">
                                &nbsp;E-Mail :</td>
                            <td style="width: 30%;
                                height: 27px">
                                <asp:Label ID="lblemail" runat="server" Font-Names="ms sans serif" Font-Size="10pt"></asp:Label></td>
                            <td class="font_gray_11" style="width: 15%; height: 27px">
                            </td>
                            <td style="width: 30%;
                                height: 27px">
                            </td>
                            <td style="width: 5%;
                                height: 27px">
                            </td>
                        </tr>
                        <tr id="trEMS0" runat="server" visible="false">
                            <td style="width: 5%; height: 27px">
                                &nbsp;</td>
                            <td class="font_gray_11" style="width: 15%; height: 27px">
                                &nbsp;</td>
                            <td style="width: 30%;
                                height: 27px">
                                &nbsp;</td>
                            <td class="font_gray_11" style="width: 15%; height: 27px">
                                &nbsp;</td>
                            <td style="width: 30%;
                                height: 27px">
                                &nbsp;</td>
                            <td style="width: 5%;
                                height: 27px">
                                &nbsp;</td>
                        </tr>
                        <tr id="trEMS" runat="server" visible="false">
                            <td style="width: 5%; height: 27px">
                                &nbsp;</td>
                            <td class="font_gray_11" style="height: 27px" colspan="2">
                                <asp:Label ID="lblEMS" runat="server" Text="EMS Tracking   : " Font-Size="11pt" Visible="false"></asp:Label>
&nbsp;
                                <asp:LinkButton ID="lnkEMS" runat="server" ForeColor="Blue" Font-Size="11pt" Visible="false"></asp:LinkButton>
                            </td>
                            <td class="font_gray_11" style="width: 15%; height: 27px">
                                &nbsp;</td>
                            <td style="width: 30%;
                                height: 27px">
                                &nbsp;</td>
                            <td style="width: 5%;
                                height: 27px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6" style="height: 27px; text-align: center">
                                <span style="font-size: 11px; font-family: arial; width: 100%;"></span></td>
                        </tr>
                    </table>
                </strong></span>
            </td>
        </tr>
        <tr runat="server" id="trBook">
            <td align="center" style="width: 100%; height: 52px; text-align: left">
                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                    <contenttemplate>
<asp:Panel id="Panel1" runat="server" Width="100%"><TABLE cellSpacing=0 cellPadding=4 width="100%" border=0><TBODY><TR>
            <TD style="BACKGROUND-IMAGE: url(images/Asiabooks/ImagesTP_ec/BS_menuBooksSearch_Bg.jpg); WIDTH: 100%; HEIGHT: 24px" class="menuHeaderGreen">Available</TD></TR></TBODY></TABLE><Saifi:MyDg style="BORDER-RIGHT: #047700 2px solid; BORDER-TOP: #047700 2px solid; BORDER-LEFT: #047700 2px solid; BORDER-BOTTOM: #047700 2px solid" id="Datagrid1" runat="server" Width="100%" CssClass="Grid_shopping" Font-Bold="False" AllowPaging="false" HorizontalAlign="Center" AutoGenerateColumns="False" CellPadding="0" HeaderStyle-BackColor="#aaaadd" HeaderStyle-CssClass="tableHeader" ImageFirst="images/b_firstpage.gif" ImageLast="images/b_lastpage.gif" ImageNext="images/b_nextpage.gif" ImagePrevious="images/b_prevpage.gif" ItemStyle-CssClass="tableItem" SelectedItemStyle-BackColor="#99ccff" ShowFirstAndLastImage="True" ShowPreviousAndNextImage="True">
<FooterStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></FooterStyle>
<EditItemStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></EditItemStyle>
<SelectedItemStyle BackColor="#99CCFF" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></SelectedItemStyle>
<AlternatingItemStyle CssClass="Grid_shoppingAltItem" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></AlternatingItemStyle>
<ItemStyle CssClass="Grid_shoppingItem" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></ItemStyle>
<PagerStyle Mode="NumericPages" PageButtonCount="5" Visible="False"></PagerStyle>
<HeaderStyle BackColor="#49A514" BorderStyle="None" ForeColor="White" CssClass="Grid_shoppingHeader" HorizontalAlign="Center" Font-Italic="False" Font-Size="11px" Font-Names="arial" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
<Columns>
<asp:TemplateColumn HeaderText="Item  No"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: center" id="lbl_datagrid1_Orderdtl_No" runat="server" Width="20px" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Orderdtl_No") %>'></asp:Label>&nbsp; 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
<EditItemTemplate>
&nbsp; 
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Title"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_datagrid1_Title" runat="server" Width="200px" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Book_Title_Report") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="20%"></HeaderStyle>
<EditItemTemplate>
&nbsp; 
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="ISBN"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: center" id="lbl_datagrid1_isbn" runat="server" Width="80px" Font-Size="11px" Font-Names="arial" Font-Bold="True" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"ISBN") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Order Status"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: center" id="lbl_datagrid1_order_status" runat="server" Width="50px" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Order_Status") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
<EditItemTemplate>
&nbsp; 
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Weight (kg)"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid1_weight" runat="server" Width="50px" Font-Size="11px" Font-Names="arial" Font-Bold="True" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Weight","{0:#,##0.00}") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Price (Baht)"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid1_price" runat="server" Width="60px" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Unitprice","{0:#,##0.00}") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
<EditItemTemplate>
&nbsp; 
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Discount"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: center" id="lbl_datagrid1_Discount" runat="server" Width="50px" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Discount","{0:0}%") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Quantity"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: center" id="lbl_datagrid1_qty" runat="server" Width="50px" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Orderqty","{0:#,##0.##}") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Amount&lt;br&gt;(Bath)"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid1_amount" runat="server" Width="100px" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Amount","{0:#,##0.00}") %>'></asp:Label><BR /><asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid1_amount_usd" runat="server" Width="100px" Font-Size="11px" Font-Names="arial" ForeColor="#FF9900" Text='<%# DataBinder.Eval(Container.DataItem,"USD","{0:US$#,##0.00}") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
<EditItemTemplate>
&nbsp; 
</EditItemTemplate>
</asp:TemplateColumn>
</Columns>
</Saifi:MyDg> <TABLE style="FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: #4e4e4e; FONT-FAMILY: arial; BACKGROUND-COLOR: #f2fdec" cellSpacing=0 cellPadding=1 width="100%" border=0><TBODY></TBODY><TBODY>
        <TR>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 50%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 38px; TEXT-ALIGN: right">Total Weight</TD>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 10%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right"><asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid1_Total_Weight" runat="server" Width="100%"></asp:Label></TD>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 30%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: center">Amount</TD>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 10%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: left"><asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid1_amount" runat="server" Width="100%"></asp:Label>
                <asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid1_amount_usd" runat="server" Width="100%" ForeColor="#FF8000"></asp:Label> </TD></TR>
        <TR>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 50%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right">Max Leadtime</TD>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 10%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right"><asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid1_max_leadtime" runat="server" Width="100%"></asp:Label></TD>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 30%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: center">Delivery Cost</TD>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 10%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right"><asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid1_delivery_cost" runat="server" Width="100%"></asp:Label><asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid1_delivery_cost_usd" runat="server" Width="100%" ForeColor="#FF8000"></asp:Label> </TD></TR></TBODY></TABLE></asp:Panel> 
</contenttemplate>
                </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td align="center" style="width: 100%; height: 35px; text-align: center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
<asp:Panel id="Panel2" runat="server" Width="100%"><TABLE cellSpacing=0 cellPadding=4 width="100%" border=0><TBODY><TR>
            <TD style="BACKGROUND-IMAGE: url(images/Asiabooks/ImagesTP_ec/BS_menuBooksSearch_Bg.jpg); HEIGHT: 24px" class="menuHeaderGreen" colSpan=3>Out of stock but available on special order</TD></TR></TBODY></TABLE><Saifi:MyDg style="BORDER-RIGHT: #047700 2px solid; BORDER-TOP: #047700 2px solid; BORDER-LEFT: #047700 2px solid; BORDER-BOTTOM: #047700 2px solid" id="Datagrid2" runat="server" Width="100%" CssClass="Grid_shopping" Font-Bold="False" AllowPaging="false" HorizontalAlign="Center" AutoGenerateColumns="False" CellPadding="0" HeaderStyle-BackColor="#aaaadd" HeaderStyle-CssClass="tableHeader" ImageFirst="images/b_firstpage.gif" ImageLast="images/b_lastpage.gif" ImageNext="images/b_nextpage.gif" ImagePrevious="images/b_prevpage.gif" ItemStyle-CssClass="tableItem" SelectedItemStyle-BackColor="#99ccff" ShowFirstAndLastImage="True" ShowPreviousAndNextImage="True">
<FooterStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></FooterStyle>

<EditItemStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></EditItemStyle>

<SelectedItemStyle BackColor="#99CCFF" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></SelectedItemStyle>

<AlternatingItemStyle CssClass="Grid_shoppingAltItem" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></AlternatingItemStyle>

<ItemStyle CssClass="Grid_shoppingItem" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></ItemStyle>

<PagerStyle Mode="NumericPages" PageButtonCount="5" Visible="False"></PagerStyle>

<HeaderStyle BackColor="#49A514" BorderStyle="None" ForeColor="White" CssClass="Grid_shoppingHeader" HorizontalAlign="Center" Font-Italic="False" Font-Size="11px" Font-Names="arial" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
<Columns>
<asp:TemplateColumn HeaderText="Item  No"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: center" id="lbl_datagrid2_Orderdtl_No" runat="server" Width="20px" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Orderdtl_No") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
<EditItemTemplate>
&nbsp; 
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Title"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_datagrid2_Title" runat="server" Width="200px" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Book_Title_Report") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="20%"></HeaderStyle>
<EditItemTemplate>
&nbsp; 
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="ISBN"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: center" id="lbl_datagrid2_isbn" runat="server" Width="80px" Font-Size="11px" Font-Names="arial" Font-Bold="True" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"ISBN") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Order Status"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: center" id="lbl_datagrid2_order_status" runat="server" Width="50px" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Order_Status") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
<EditItemTemplate>
&nbsp; 
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Weight (kg)"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid2_weight" runat="server" Width="50px" Font-Size="11px" Font-Names="arial" Font-Bold="True" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Weight","{0:#,##0.00}") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Price (Baht)"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid2_price" runat="server" Width="60px" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Unitprice","{0:#,##0.00}") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
<EditItemTemplate>
&nbsp; 
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Discount"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: center" id="lbl_datagrid2_Discount" runat="server" Width="50px" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Discount","{0:0}%") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Quantity"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: center" id="lbl_datagrid2_qty" runat="server" Width="50px" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Orderqty","{0:#,##0.##}") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Amount&lt;br&gt;(Bath)"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid2_amount" runat="server" Width="100px" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Amount","{0:#,##0.00}") %>'></asp:Label><BR /><asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid2_amount_usd" runat="server" Width="100px" Font-Size="11px" Font-Names="arial" ForeColor="#FF9900" Text='<%# DataBinder.Eval(Container.DataItem,"USD","{0:US$#,##0.00}") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
<EditItemTemplate>
&nbsp; 
</EditItemTemplate>
</asp:TemplateColumn>
</Columns>
</Saifi:MyDg> <TABLE style="FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: #4e4e4e; FONT-FAMILY: arial; BACKGROUND-COLOR: #f2fdec" cellSpacing=0 cellPadding=1 width="100%" border=0><TBODY><TR>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 50%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right">Total Weight</TD>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 10%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right"><asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid2_Total_Weight" runat="server" Width="100%"></asp:Label></TD>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 30%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right">Amount</TD>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 10%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right"><asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid2_amount" runat="server" Width="90px"></asp:Label>
                <asp:Label id="lbl_datagrid2_amount_usd" runat="server" Width="90px" ForeColor="#FF8000"></asp:Label></TD></TR>
            <TR>
                <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 50%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right">Max Leadtime</TD>
                <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 10%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right"><asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid2_max_leadtime" runat="server" Width="100%"></asp:Label></TD>
                <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 30%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right">Delivery Cost</TD>
                <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 10%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right"><asp:Label style="TEXT-ALIGN: right" id="lbl_datagrid2_delivery_cost" runat="server" Width="90px"></asp:Label>
                    <asp:Label id="lbl_datagrid2_delivery_cost_usd" runat="server" Width="90px" ForeColor="#FF8000"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> 
                
                </ContentTemplate>
                </asp:UpdatePanel>
                
                <asp:UpdatePanel ID="UpdatePanel_eb" runat="server">
                    <ContentTemplate>
<asp:Panel id="Panel3" runat="server" Width="100%"><TABLE cellSpacing=0 cellPadding=4 width="100%" border=0><TBODY><TR>
            <TD style="BACKGROUND-IMAGE: url(images/Asiabooks/ImagesTP_ec/BS_menuBooksSearch_Bg.jpg); HEIGHT: 24px" 
                class="menuHeaderGreen">eBook</TD></TR></TBODY></TABLE>
                <Saifi:MyDg id="ebook" runat="server" Width="100%" CssClass="Grid_shopping" 
        AutoGenerateColumns="False" CellPadding="0" ImageFirst="images/b_firstpage.gif" 
        ImageLast="images/b_lastpage.gif" ImageNext="images/b_nextpage.gif" 
        ImagePrevious="images/b_prevpage.gif" SelectedItemStyle-BackColor="#99ccff" 
        ShowFirstAndLastImage="True" ShowPreviousAndNextImage="True" 
        AllowPaging="True" PageSize="50">
<FooterStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></FooterStyle>

<EditItemStyle HorizontalAlign="Center" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></EditItemStyle>

<SelectedItemStyle HorizontalAlign="Center" BackColor="#99CCFF" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></SelectedItemStyle>

<AlternatingItemStyle HorizontalAlign="Center" CssClass="Grid_shoppingAltItem" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Center" CssClass="Grid_shoppingItem" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>

<PagerStyle Mode="NumericPages" PageButtonCount="5" Visible="False"></PagerStyle>
<Columns>
<asp:TemplateColumn HeaderText="Item No" SortExpression="No"><EditItemTemplate>
</EditItemTemplate>
<ItemTemplate>
<asp:Label style="TEXT-ALIGN: center" id="lbl_No_ebook" runat="server" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Orderdtl_No") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Title" SortExpression="Book_Title" ItemStyle-HorizontalAlign="Left"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_Book_Title_ebook" runat="server" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Book_Title_Report") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="30%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="ISBN" SortExpression="ISBN"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_ISBN_ebook" runat="server" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"ISBN") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Order Status"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: center" id="lbl_order_status_ebook" runat="server" Width="50px" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Order_Status") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Price (Baht)" SortExpression="Price"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Price_ebook" runat="server" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Unitprice","{0:#,##0.00}") %>'></asp:Label>
<asp:Label ID="lbl_Price_ebook_free" runat="server" style="TEXT-ALIGN: right" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='0.00'></asp:Label>
</ItemTemplate>
<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Discount" SortExpression="Discount"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_discount_ebook" runat="server" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Discount","{0:0}%") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="15%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="QTY" SortExpression="Quantity"><ItemTemplate>
&nbsp;<asp:Label style="TEXT-ALIGN: right" id="lbl_quantity_ebook" runat="server" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Orderqty") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Amount &lt;br&gt; (Baht)" SortExpression="Amount" ItemStyle-HorizontalAlign="Right"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Amount_ebook" runat="server" Font-Size="11px" Font-Names="arial" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Amount","{0:#,##0.00}") %>'></asp:Label><BR /><asp:Label style="TEXT-ALIGN: right" id="lbl_Amount_ebook_usd" runat="server" Width="100px" Font-Size="11px" Font-Names="arial" ForeColor="#FF9900" Text='<%# DataBinder.Eval(Container.DataItem,"USD","{0:US$#,##0.00}") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Ordstt" Visible="False"><ItemTemplate>
<asp:Label id="ordstt_In_Branch" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="To_Org_AB_Code" Visible="False"><ItemTemplate>
<asp:Label id="To_Org_AB_Code_In_branch" runat="server" Text='<%# "" %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>

<%--
<asp:TemplateColumn HeaderText="Status" Visible="False"><ItemTemplate>
<asp:Label id="lbl_Status" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem,"Status") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateColumn>
 --%>
 
</Columns>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#49A514" BorderStyle="None" CssClass="Grid_shoppingHeader" Font-Bold="True" Font-Italic="False" Font-Names="arial" Font-Overline="False" Font-Size="11px" Font-Strikeout="False" Font-Underline="False" ForeColor="White"></HeaderStyle>
</Saifi:MyDg>
<asp:Panel id="P_ebook_promo" runat="server" Width="100%">
<TABLE style="FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: #4e4e4e; FONT-FAMILY: arial; BACKGROUND-COLOR: #f2fdec" cellSpacing=0 cellPadding=1 width="100%" border=0><TBODY><TR>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 50%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right">
                    &nbsp;</TD>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 30%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right">
                <asp:Label ID="lblpromo_discount" runat="server" Text="Promotion Discount"></asp:Label>
            </TD>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 10%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right">
                <asp:Label ID="lbl_ebook_discount_amount" runat="server" 
                    style="TEXT-ALIGN: right" Width="90px"></asp:Label>
                <asp:Label ID="lbl_ebook_discount_amount_usd" runat="server" 
                    ForeColor="#FF8000" Width="90px"></asp:Label>
            </TD></TR>
</TBODY></TABLE>
</asp:Panel>
    <TABLE style="FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: #4e4e4e; FONT-FAMILY: arial; BACKGROUND-COLOR: #f2fdec" cellSpacing=0 cellPadding=1 width="100%" border=0><TBODY>
            <TR>
                <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 50%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right">
                    &nbsp;</TD>
                
                <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 30%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right">
                    Amount</TD>
                <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 10%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right"><asp:Label style="TEXT-ALIGN: right" id="lbl_ebook_amount" runat="server" Width="90px"></asp:Label>
                    <asp:Label id="lbl_ebook_amount_usd" runat="server" Width="90px" 
                        ForeColor="#FF8000"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> 
                
                
               <TABLE style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; BORDER-BOTTOM: #047700 1px solid; BACKGROUND-COLOR: #f2fdec" cellSpacing=0 cellPadding=0 width="100%" border=1><TBODY><TR><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 40%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left">Ship Address </TD><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 50%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left">Total Amount</TD><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 10%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right"><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: #4e4e4e; FONT-FAMILY: arial; TEXT-ALIGN: right" id="lbl_total_amount" runat="server" Width="100px" ForeColor="Gray" Font-Size="11px" Font-Names="arial" Font-Bold="True"></asp:Label><asp:Label style="TEXT-ALIGN: right" id="lbl_total_amount_usd" runat="server" Width="100px" ForeColor="#FF8000" Font-Size="11px" Font-Names="arial" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 40%; COLOR: gray; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; TEXT-ALIGN: left" rowSpan=6><TABLE style="FONT-WEIGHT: bold; FONT-SIZE: 11px; WIDTH: 100%; COLOR: #4e4e4e; FONT-FAMILY: arial" cellSpacing=0 cellPadding=2 border=0><TBODY><TR><TD style="WIDTH: 20%; HEIGHT: 23px; TEXT-ALIGN: left">&nbsp; Name :</TD><TD style="WIDTH: 80%; TEXT-ALIGN: left"><asp:Label style="TEXT-ALIGN: left" id="lbl_ship_name" runat="server" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 20%; HEIGHT: 23px; TEXT-ALIGN: left" vAlign=top>&nbsp;&nbsp;Address :</TD><TD style="WIDTH: 80%; TEXT-ALIGN: left"><asp:TextBox id="tbx_ship_address" runat="server" Width="230px" ForeColor="#4E4E4E" Font-Size="11px" Font-Names="arial" Font-Bold="True" Height="100px" Enabled="False" TextMode="MultiLine"></asp:TextBox></TD></TR></TBODY></TABLE>&nbsp;&nbsp;&nbsp; </TD><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 50%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left">Delivery Cost </TD><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 10%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right"><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: #4e4e4e; FONT-FAMILY: arial; TEXT-ALIGN: right" id="lbl_delivery_cost" runat="server" Width="100px" ForeColor="Gray" Font-Size="11px" Font-Names="arial" Font-Bold="True"></asp:Label><asp:Label style="TEXT-ALIGN: right" id="lbl_delivery_cost_usd" runat="server" Width="100px" ForeColor="#FF8000" Font-Size="11px" Font-Names="arial" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 50%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left">Grand Total </TD><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 10%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 40px; TEXT-ALIGN: right"><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: #4e4e4e; FONT-FAMILY: arial; TEXT-ALIGN: right" id="lbl_grand_total" runat="server" Width="100px" ForeColor="Gray" Font-Size="11px" Font-Names="arial" Font-Bold="True"></asp:Label><asp:Label style="TEXT-ALIGN: right" id="lbl_grand_total_usd" runat="server" Width="100px" ForeColor="#FF8000" Font-Size="11px" Font-Names="arial" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 60%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left" colSpan=2>Shipping Type</TD></TR><TR><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 60%; COLOR: gray; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 9px; TEXT-ALIGN: left" colSpan=2><TABLE style="FONT-WEIGHT: bold; FONT-SIZE: 11px; WIDTH: 62%; COLOR: #4e4e4e; FONT-FAMILY: arial" cellSpacing=0 cellPadding=2 border=0><TBODY><TR><TD style="WIDTH: 309px; HEIGHT: 9px; TEXT-ALIGN: left">&nbsp; <asp:Label id="lbl_transport_type" runat="server" Width="180px"></asp:Label>&nbsp;&nbsp;<asp:Label id="lbl_Day" runat="server" Width="179px"></asp:Label>&nbsp; <asp:Label id="lbl_country_name" runat="server" Width="177px"></asp:Label></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 60%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left" colSpan=2>Billing Address</TD></TR><TR><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 60%; COLOR: gray; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial" colSpan=2><TABLE style="FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: #4e4e4e; FONT-FAMILY: arial" cellSpacing=0 cellPadding=2 width="100%" border=0><TBODY><TR><TD style="WIDTH: 20%; HEIGHT: 23px; TEXT-ALIGN: left">&nbsp; Name :</TD><TD style="WIDTH: 80%; HEIGHT: 23px; TEXT-ALIGN: left"><asp:Label id="lbl_billing_name" runat="server"></asp:Label></TD></TR><TR><TD style="WIDTH: 20%; HEIGHT: 23px; TEXT-ALIGN: left" vAlign=top>&nbsp; Address :</TD><TD style="WIDTH: 80%; HEIGHT: 9px; TEXT-ALIGN: left"><asp:TextBox id="tbx_billing_address" runat="server" Width="230px" ForeColor="#4E4E4E" Font-Size="11px" Font-Names="arial" Font-Bold="True" Height="100px" Enabled="False" TextMode="MultiLine"></asp:TextBox></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 40%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left">Gift-Wrapping Service</TD><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 60%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left" colSpan=2>Select Payment Method </TD></TR><TR><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 40%; COLOR: gray; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial"><TABLE style="FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: #4e4e4e; FONT-FAMILY: arial" cellSpacing=0 cellPadding=2 width="100%" border=0><TBODY><TR><TD style="TEXT-ALIGN: left" colSpan=2>&nbsp; <asp:Label id="lbl_send" runat="server"></asp:Label></TD></TR><TR><TD style="HEIGHT: 17px; TEXT-ALIGN: left">&nbsp; <asp:Label id="lbl_from" runat="server"></asp:Label></TD><TD style="HEIGHT: 17px; TEXT-ALIGN: left">&nbsp;<asp:Label id="lbl_to" runat="server"></asp:Label></TD></TR><TR><TD style="TEXT-ALIGN: left" colSpan=2>&nbsp; <asp:Label id="lbl_message" runat="server"></asp:Label></TD></TR></TBODY></TABLE></TD><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; VERTICAL-ALIGN: top; BORDER-LEFT: #047700 1px solid; WIDTH: 60%; COLOR: gray; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; TEXT-ALIGN: left" colSpan=2><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: #4e4e4e; FONT-FAMILY: arial" id="lbl_payment" runat="server" Font-Size="11px" Font-Names="arial" Font-Bold="True"></asp:Label>&nbsp;&nbsp; <asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: #4e4e4e; FONT-FAMILY: arial" id="lbl_currency" runat="server"></asp:Label></TD></TR></TBODY></TABLE>&nbsp;&nbsp;&nbsp; 
                
                </ContentTemplate>
                </asp:UpdatePanel>
                
                &nbsp;&nbsp; 
                <asp:ImageButton ID="b_export" runat="server" ImageUrl="~/images/bt_export.jpg" Visible="False" />
                &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImgPrint" runat="server" ImageUrl="~/images/print12.jpg" /></td>
        </tr>
        <tr>
            <td align="center" style="width: 100%; height: 19px; text-align: center">
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 100%; text-align: center">&nbsp;
            </td>
        </tr>
    </table>
    
    <asp:Panel ID="panEMS_Tracking" HorizontalAlign="Center" runat="server">   
<table border="0" cellpadding="0" cellspacing="0" style="width: 630px; background-color:White;">
<tr>
    <td align="left" valign="top" style="width:9px; height:7px; background-image: url('images/Template/cart_head_start.jpg');"></td>
    <td align="left" valign="top" style="background-image: url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
    <td align="left" valign="top" style="width:10px; height:7px; background-image: url('images/Template/cart_head_end.jpg');"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
    <td align="right" valign="top"><asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/Template/close.jpg" /></td>
    <td style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
    <td align="left" valign="top" style="width:600px;">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="height: 10px" align="left">
            <div style="overflow:auto; width:600px">
                <asp:GridView ID="gvEMS" runat="server" AutoGenerateColumns="False" 
                    BorderColor="#009900" BorderStyle="Double" 
                    CellPadding="4" GridLines="None" Width="100%" ForeColor="#333333">
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <RowStyle BackColor="#EEF9EE" Font-Size="8pt" ForeColor="#5B5B5B" />
                    <Columns>
                        <asp:BoundField DataField="DateTime" HeaderText="DateTime" />
                        <asp:BoundField DataField="DeliveryDateTime" HeaderText="DeliveryDate" />
                        <asp:BoundField DataField="Description" HeaderText="Description" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Location" HeaderText="Location" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Signature" HeaderText="Signature" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StatusName" HeaderText="StatusName" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" 
                        Font-Size="8pt" />
                    <SelectedRowStyle BackColor="#9FE89F" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#49A514" Font-Bold="True" Font-Size="8pt" 
                        ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" ForeColor="#606060" 
                    Text="Your order is in transit to your home address and the status could be tracked by tomorrow."></asp:Label>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" ForeColor="#606060" 
                    Text="Sorry for an inconvenience may cause. "></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table></td>
    <td align="left" valign="top" style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
    <td align="left" valign="top" style="height:10px; background-image:url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
    <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
</tr>
</table> 
</asp:Panel>
<asp:ModalPopupExtender ID="mdlPopUp_EMS" TargetControlID="lnkMeassge" PopupControlID="panEMS_Tracking"
    runat="server" BackgroundCssClass="ModelBackground" >
</asp:ModalPopupExtender>
<asp:LinkButton ID="lnkMeassge" runat="server" style="display:none">LinkButton</asp:LinkButton>
     </ContentTemplate>
    </asp:UpdatePanel>
  
</asp:Content>
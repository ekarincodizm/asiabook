<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="Customer_Order_Internet.aspx.vb" Inherits="Customer_Order_Internet" title="Untitled Page" %>
<%@ Register Src="uc/Country.ascx" TagName="Country" TagPrefix="uc2" %>
<%@ Register Src="uc/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>
<%@ Register Assembly="MycustomDG" Namespace="MycustomDG" TagPrefix="Saifi" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" class="Page" style="width: 100%">
        <tr>
            <td align="center" style="width: 100%;">
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: center; width: 100%;">

<TABLE style="BACKGROUND-COLOR: #f2fdec" cellSpacing=0 cellPadding=0 width="100%"><TBODY><TR><TD style="WIDTH: 100%; HEIGHT: 150px; BACKGROUND-COLOR: white"><TABLE cellSpacing=0 cellPadding=0 width="100%" align=center border=0><TBODY><TR><TD style="WIDTH: 100%; HEIGHT: 19px" align=right colSpan=5></TD></TR><TR><TD style="WIDTH: 20%; HEIGHT: 27px; TEXT-ALIGN: left" class="font_gray_11">&nbsp;Order No :</TD><TD style="WIDTH: 40%; HEIGHT: 27px" class="font_gray_11"><asp:Label style="TEXT-ALIGN: left" id="lbl_h_order_no" runat="server" Width="100%"></asp:Label></TD><TD style="WIDTH: 15%; HEIGHT: 27px; TEXT-ALIGN: left" class="font_gray_11">&nbsp;Order Date :</TD><TD style="WIDTH: 25%; HEIGHT: 27px; TEXT-ALIGN: left" class="font_gray_11" align=left><asp:Label style="TEXT-ALIGN: left" id="lbl_h_Order_Date" runat="server" Width="100%"></asp:Label></TD><TD style="WIDTH: 10%"><asp:ImageButton id="b_change_book" runat="server" ImageUrl="images/bt_chg_bk_ord.jpg"></asp:ImageButton></TD></TR><TR><TD style="WIDTH: 20%; HEIGHT: 27px; TEXT-ALIGN: left" class="font_gray_11">&nbsp;Customer Name :</TD><TD style="WIDTH: 40%; HEIGHT: 27px" class="font_gray_11" align=left><asp:Label id="lbl_h_customer_name" runat="server"></asp:Label> <asp:Label id="lbl_h_Last_Name" runat="server"></asp:Label></TD><TD style="WIDTH: 15%; HEIGHT: 27px; TEXT-ALIGN: left" class="font_gray_11">&nbsp;Telephone :</TD><TD style="WIDTH: 25%; HEIGHT: 27px; TEXT-ALIGN: left" class="font_gray_11" align=left><asp:Label style="TEXT-ALIGN: left" id="lbl_h_telephone" runat="server" Width="100%"></asp:Label></TD><TD style="WIDTH: 10%; HEIGHT: 27px"></TD></TR><TR><TD style="WIDTH: 20%; HEIGHT: 28px; TEXT-ALIGN: left" class="font_gray_11">&nbsp;E-Mail :</TD><TD style="WIDTH: 40%; HEIGHT: 28px" class="font_gray_11" align=left><asp:Label id="lblemail" runat="server"></asp:Label></TD><TD style="WIDTH: 15%; HEIGHT: 28px; TEXT-ALIGN: left" class="font_gray_11"></TD><TD style="WIDTH: 25%; HEIGHT: 27px; TEXT-ALIGN: left" class="font_gray_11"></TD><TD style="WIDTH: 10%; HEIGHT: 28px"></TD></TR></TBODY></TABLE><asp:Panel id="P_In_Branch" runat="server" Width="100%">
<TABLE cellSpacing=0 cellPadding=0 width="100%">
    <TBODY>
<tr>
<td style="HEIGHT:24px; width: 100%;" class="menuHeaderGreen">Available</td>
</tr>
</TBODY></TABLE></asp:Panel></TD></TR><TR><TD style="WIDTH: 100%">
        <Saifi:MyDg id="In_Branch" runat="server" Width="100%" CssClass="Grid_shopping" 
            AutoGenerateColumns="False" AllowPaging="false" CellPadding="0" 
            ImageFirst="images/b_firstpage.gif" ImageLast="images/b_lastpage.gif" 
            ImageNext="images/b_nextpage.gif" ImagePrevious="images/b_prevpage.gif" 
            SelectedItemStyle-BackColor="#99ccff" ShowFirstAndLastImage="True" 
            ShowPreviousAndNextImage="True" PageSize="50">
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
<asp:Label style="TEXT-ALIGN: center" id="lbl_No_Inbranch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"No") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Title" SortExpression="Book_Title" ItemStyle-HorizontalAlign="Left"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_Book_Title_Inbranch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Book_Title") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="30%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="ISBN" SortExpression="ISBN"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_ISBN_Inbranch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ISBN_13") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Weight (Kg)" SortExpression="Weight"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Weight_Inbranch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Weight","{0:#,##0.00}") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Price (Baht)" SortExpression="Price"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Price_Inbranch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Selling_Price","{0:#,##0.00}") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Discount" SortExpression="Discount"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_discount_Inbranch" runat="server"  Text="<%# 5 %>"></asp:Label>&nbsp;% 
</ItemTemplate>
<HeaderStyle Width="15%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="QTY" SortExpression="Quantity"><ItemTemplate>
&nbsp;<asp:Label style="TEXT-ALIGN: right" id="lbl_quantity_Inbranch" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem,"Quantity") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Amount &lt;br&gt; (Baht)" SortExpression="Amount" ItemStyle-HorizontalAlign="Right"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Amount_Inbranch" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Amount","{0:#,##0.00}") %>'></asp:Label> <asp:Label style="TEXT-ALIGN: right" id="lbl_Amount_in_branch_usd" runat="server" Width="120px" CssClass="font_yellow_11_bold"></asp:Label> 
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
<asp:TemplateColumn HeaderText="leadtime" Visible="False"><ItemTemplate>
<asp:Label id="lbl_leadTime_InBranch" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem,"Lead_Time") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Status" Visible="False"><ItemTemplate>
<asp:Label id="lbl_Status" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem,"Status") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#49A514" BorderStyle="None" CssClass="Grid_shoppingHeader" Font-Bold="True" Font-Italic="False" Font-Names="arial" Font-Overline="False" Font-Size="11px" Font-Strikeout="False" Font-Underline="False" ForeColor="White"></HeaderStyle>
</Saifi:MyDg> <asp:Panel id="P_In_branch_1" runat="server" Width="100%"><TABLE style="BORDER-TOP-STYLE: none" borderColor=#047700 cellSpacing=0 cellPadding=0 width="100%" border=1><TBODY><TR>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 65%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 38px; TEXT-ALIGN: right" class="font_gray_11">Total Weight &nbsp;</TD>
            <td class="font_gray_11" style="WIDTH: 10%; TEXT-ALIGN: right"><asp:Label ID="lbl_InBranch_Total_Weight" runat="server" 
                                                                  style="TEXT-ALIGN: right"></asp:Label></td>
            <TD style="WIDTH: 10%" class="font_gray_11">Amount</TD>
            <td class="font_gray_11" style="WIDTH: 15%; TEXT-ALIGN: right"><asp:Label ID="lbl_InBranch_total" runat="server" 
                                                                  style="TEXT-ALIGN: right" Width="90px"></asp:Label>
                <br /><asp:Label ID="lbl_InBranch_total_usd" runat="server" CssClass="font_yellow_11_bold" style="TEXT-ALIGN: right" 
                                                                  Width="90px"></asp:Label></td></TR>
            <tr><td align="right" class="font_gray_11" style="WIDTH: 65%; HEIGHT: 40px">Max Leadtime&#160;</td>
                <td class="font_gray_11" style="WIDTH: 10%; TEXT-ALIGN: right"><asp:Label ID="lbl_InBranch_max_leadtime" runat="server" 
                                                                  style="TEXT-ALIGN: right"></asp:Label></td>
                <td class="font_gray_11" style="WIDTH: 10%">Delivery Cost</td>
                <td class="font_gray_11" style="WIDTH: 15%; TEXT-ALIGN: right"><asp:Label ID="lbl_InBranch_delivery_cost" runat="server" 
                                                                  style="TEXT-ALIGN: right" Width="90px"></asp:Label><br />
                    <asp:Label ID="lbl_InBranch_delivery_cost_usd" runat="server" CssClass="font_yellow_11_bold" style="TEXT-ALIGN: right" 
                                                                  Width="90px"></asp:Label></td></tr></TBODY></TABLE></asp:Panel></TD></TR><TR><TD style="WIDTH: 100%"><asp:Panel id="P_jobber" runat="server" Width="100%">
<TABLE cellSpacing=0 cellPadding=0 width="100%">
    <TBODY><TR>
<TD 
        
        style="HEIGHT: 24px; background-image: url('file:///C:/Documents%20and%20Settings/kung/Desktop/Website/EOrdering_New/Eordering/EorderingWebsite/images/Asiabooks/ImagesTP_ec/BS_menuBooksSearch_Bg.jpg'); width: 100%;" 
        class="menuHeaderGreen">
Out of stock but available on special order</TD>
</TR></TBODY></TABLE></asp:Panel> <Saifi:MyDg id="jobber" runat="server" Width="100%" 
            CssClass="Grid_shopping" AutoGenerateColumns="False" AllowPaging="false" 
            CellPadding="0" ImageFirst="images/b_firstpage.gif" 
            ImageLast="images/b_lastpage.gif" ImageNext="images/b_nextpage.gif" 
            ImagePrevious="images/b_prevpage.gif" SelectedItemStyle-BackColor="#99ccff" 
            ShowFirstAndLastImage="True" ShowPreviousAndNextImage="True" PageSize="50">
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
<asp:Label style="TEXT-ALIGN: center" id="lbl_No_jobber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"No") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Title" SortExpression="Book_Title" ItemStyle-HorizontalAlign="Left"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_Book_Title_jobber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Book_Title") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="30%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="ISBN" SortExpression="ISBN"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_ISBN_jobber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ISBN_13") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Weight (Kg)" SortExpression="Weight"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Weight_jobber" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem,"Weight","{0:#,##0.00}") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Price (Baht)" SortExpression="Price"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Price_jobber" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem,"Selling_Price","{0:#,##0.00}") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Discount" SortExpression="Discount"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_discount_jobber" runat="server"  Text="<%# 5 %>"></asp:Label>&nbsp;% 
</ItemTemplate>
<HeaderStyle Width="15%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="QTY" SortExpression="Quantity"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_quantity_jobber" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem,"Quantity") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Amount &lt;br&gt; (Baht)" SortExpression="Amount" ItemStyle-HorizontalAlign="Right"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Amount_jobber" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem,"Amount","{0:#,##0.00}") %>'></asp:Label> <asp:Label style="TEXT-ALIGN: right" id="lbl_Amount_jobber_usd" runat="server" Width="120px" CssClass="font_yellow_11_bold"></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Ordstt" Visible="False"><ItemTemplate>
<asp:Label id="ordstt_jobber" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="To_Org_AB_Code" Visible="False"><ItemTemplate>
<asp:Label id="To_Org_AB_Code_jobber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"To_Org_AB_code") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="leadtime" Visible="False"><ItemTemplate>
<asp:Label id="lbl_leadTime_Jobber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Lead_Time") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Status" Visible="False"><ItemTemplate>
<asp:Label id="lbl_Status_Jobber" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem,"Status") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#49A514" BorderStyle="None" CssClass="Grid_shoppingHeader" Font-Bold="True" Font-Italic="False" Font-Names="arial" Font-Overline="False" Font-Size="11px" Font-Strikeout="False" Font-Underline="False" ForeColor="White"></HeaderStyle>
</Saifi:MyDg> <asp:Panel id="P_jobber1" runat="server" Width="100%"><TABLE style="WIDTH: 100%" borderColor=#047700 cellSpacing=0 cellPadding=0 border=1><TBODY><TR><TD style="WIDTH: 65%; HEIGHT: 40px" class="font_gray_11" align=right>Total Weight&nbsp;</TD><TD style="WIDTH: 10%; TEXT-ALIGN: right" class="font_gray_11" vAlign=middle><asp:Label style="TEXT-ALIGN: right" id="lbl_jobber_Total_Weight" runat="server"></asp:Label> </TD><TD style="WIDTH: 10%" class="font_gray_11">Amount</TD><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="font_gray_11"><asp:Label style="TEXT-ALIGN: right" id="lbl_jobber_total" runat="server" Width="90px">
</asp:Label><BR /><asp:Label style="TEXT-ALIGN: right" id="lbl_jobber_total_usd" runat="server" Width="90px" CssClass="font_yellow_11_bold"></asp:Label> </TD></TR><TR><TD style="WIDTH: 65%; HEIGHT: 40px" class="font_gray_11" align=right>Max Leadtime&nbsp;</TD><TD style="WIDTH: 10%; TEXT-ALIGN: right" class="font_gray_11" vAlign=middle><asp:Label style="TEXT-ALIGN: right" id="lbl_jobber_max_leadtime" runat="server"></asp:Label> </TD><TD style="WIDTH: 10%" class="font_gray_11">Delivery Cost</TD><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="font_gray_11"><asp:Label style="TEXT-ALIGN: right" id="lbl_jobber_delivery_cost" runat="server" Width="90px"></asp:Label><BR /><asp:Label style="TEXT-ALIGN: right" id="lbl_jobber_delivery_cost_usd" runat="server" Width="90px" CssClass="font_yellow_11_bold"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> 

<TR><TD style="WIDTH: 100%">
<asp:Panel id="P_ebook" runat="server" Width="100%">
<TABLE cellSpacing=0 cellPadding=0 width="100%">
    <TBODY><TR>
<TD 
        
        style="HEIGHT: 24px; background-image: url('file:///C:/Documents%20and%20Settings/kung/Desktop/Website/EOrdering_New/Eordering/EorderingWebsite/images/Asiabooks/ImagesTP_ec/BS_menuBooksSearch_Bg.jpg'); width: 100%;" 
        class="menuHeaderGreen">
    eBook</TD>
</TR></TBODY></TABLE></asp:Panel>
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
<asp:Label style="TEXT-ALIGN: center" id="lbl_No_ebook" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"No") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="ID" SortExpression="Book_ID" ItemStyle-HorizontalAlign="Left" Visible="false"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_Book_ID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Book_ID") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="30%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Title" SortExpression="Book_Title" ItemStyle-HorizontalAlign="Left"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_Book_Title_ebook" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Book_Title") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="30%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="ISBN" SortExpression="ISBN"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_ISBN_ebook" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ISBN_13") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Price (Baht)" SortExpression="Price"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Price_ebook" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Selling_Price","{0:#,##0.00}") %>'></asp:Label> 
    <asp:Label ID="lbl_Price_ebook_free" runat="server" style="TEXT-ALIGN: right" 
        Text='<%# 0 %>'></asp:Label>
</ItemTemplate>
<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Discount" SortExpression="Discount"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_discount_ebook" runat="server"  Text='<%# 0 %>'></asp:Label>&nbsp;% 
</ItemTemplate>
<HeaderStyle Width="15%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="QTY" SortExpression="Quantity"><ItemTemplate>
&nbsp;<asp:Label style="TEXT-ALIGN: right" id="lbl_quantity_ebook" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem,"Quantity") %>'></asp:Label> 
</ItemTemplate>
<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Amount &lt;br&gt; (Baht)" SortExpression="Amount" ItemStyle-HorizontalAlign="Right"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Amount_ebook" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Items_Amount","{0:#,##0.00}") %>'></asp:Label><br /><asp:Label style="TEXT-ALIGN: right" id="lbl_Amount_ebook_usd" runat="server" Width="120px" CssClass="font_yellow_11_bold"></asp:Label> 
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
 --%><asp:TemplateColumn HeaderText="Exchange" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lbl_Exchange" runat="server" style="TEXT-ALIGN: left" 
                Text='<%# DataBinder.Eval(Container.DataItem,"Exchange") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateColumn>
    <asp:TemplateColumn HeaderText="Exchange_Internet" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lbl_Exchange_Internet" runat="server" style="TEXT-ALIGN: left" 
                Text='<%# DataBinder.Eval(Container.DataItem,"Exchange_Internet") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateColumn>
 
</Columns>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#49A514" BorderStyle="None" CssClass="Grid_shoppingHeader" Font-Bold="True" Font-Italic="False" Font-Names="arial" Font-Overline="False" Font-Size="11px" Font-Strikeout="False" Font-Underline="False" ForeColor="White"></HeaderStyle>
</Saifi:MyDg> 
<asp:Panel id="P_ebook_promo" runat="server" Width="100%"><TABLE style="BORDER-TOP-STYLE: none" borderColor=#047700 cellSpacing=0 cellPadding=0 width="100%" border=1><TBODY>
<TR>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 65%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 38px; TEXT-ALIGN: right" class="font_gray_11">
                &nbsp;</TD>
            <TD style="WIDTH: 10%" class="font_gray_11">
                <asp:Label ID="lblpromo_discount" runat="server" ForeColor="#CC0000" 
                    Text="Promotion Discount"></asp:Label>
            </TD>
            <td class="font_gray_11" style="WIDTH: 15%; TEXT-ALIGN: right">
                <asp:Label ID="lbldiscount" runat="server" ForeColor="#CC0000"></asp:Label>
                <br /></td></TR>
            </TBODY></TABLE></asp:Panel>
<asp:Panel id="P_ebook1" runat="server" Width="100%"><TABLE style="BORDER-TOP-STYLE: none" borderColor=#047700 cellSpacing=0 cellPadding=0 width="100%" border=1><TBODY>

<TR>
            <TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 65%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 38px; TEXT-ALIGN: right" class="font_gray_11">
                &nbsp;</TD>
            <TD style="WIDTH: 10%" class="font_gray_11">Amount</TD>
            <td class="font_gray_11" style="WIDTH: 15%; TEXT-ALIGN: right">
                <asp:Label ID="lbl_ebook_total" runat="server" style="TEXT-ALIGN: right" Width="90px"></asp:Label>
                <br /><asp:Label ID="lbl_ebook_total_usd" runat="server" 
                    CssClass="font_yellow_11_bold" style="TEXT-ALIGN: right" 
                                                                  Width="90px"></asp:Label></td></TR>
            </TBODY></TABLE></asp:Panel></TD></TR><TR><TD style="WIDTH: 100%">
<TABLE borderColor=#047700 cellSpacing=0 cellPadding=0 width="100%" border=1><TBODY><TR><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 40%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left" class="table_shoppingHeader" align=left>&nbsp;Shipping Address</TD><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 45%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left" class="table_shoppingHeader">&nbsp;Total Amount</TD><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="font_gray_11"><asp:Label style="TEXT-ALIGN: right" id="lbl_total_amount" runat="server" Width="90px"></asp:Label>&nbsp;<BR /><asp:Label style="TEXT-ALIGN: right" id="lbl_total_amount_usd" runat="server" Width="90px" CssClass="font_yellow_11_bold"></asp:Label></TD></TR><TR><TD style="WIDTH: 40%" vAlign=top rowSpan=6>&nbsp;&nbsp; <TABLE cellSpacing=0 cellPadding=0 width="100%"><TBODY><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left><asp:Label id="Label1" runat="server" Font-Bold="True" Text="Home Address"></asp:Label></TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left><asp:RadioButton id="rad_address1" runat="server" Checked="True" GroupName="Address" AutoPostBack="True"></asp:RadioButton> <asp:Label id="lbl_address1" runat="server"></asp:Label></TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 11px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 11px" align=left>
    <asp:Label ID="lblcountry1" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblzipcode1" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblprovince1" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblamphur1" runat="server" Visible="False"></asp:Label>
    </TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left><asp:Label id="Label3" runat="server" Font-Bold="True" Text="Office Address"></asp:Label></TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left><asp:RadioButton id="rad_address2" runat="server" GroupName="Address" AutoPostBack="True"></asp:RadioButton> <asp:Label id="lbl_address2" runat="server"></asp:Label> </TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 11px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 11px" align=left>
    <asp:Label ID="lblcountry2" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblzipcode2" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblprovince2" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblamphur2" runat="server" Visible="False"></asp:Label>
    </TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left><asp:Label id="Label2" runat="server" Font-Bold="True" Text="Shipping Address"></asp:Label></TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left><asp:RadioButton id="rad_address3" runat="server" GroupName="Address" AutoPostBack="True"></asp:RadioButton> <asp:Label id="lbl_address3" runat="server"></asp:Label> </TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left colSpan=1></TD>
    <TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" 
        align=left>
        <asp:Label ID="lblcountry3" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblzipcode3" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblprovince3" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblamphur3" runat="server" Visible="False"></asp:Label>
    </TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left colSpan=1></TD>
        <TD style="FONT-SIZE: 9pt; WIDTH: 257px; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" 
            align=left><asp:RadioButton id="rad_address4" runat="server" GroupName="Address" AutoPostBack="True"></asp:RadioButton> <STRONG style="WIDTH: 97%">Other</STRONG></TD></TR><TR><TD style="WIDTH: 3%; HEIGHT: 24px" class="font_gray_11" align=left colSpan=1></TD>
        <TD style="WIDTH: 97%; HEIGHT: 24px" class="font_gray_11" align=left></TD></TR><TR><TD style="WIDTH: 3%; HEIGHT: 24px" class="font_gray_11" align=left colSpan=1></TD>
    <TD style="WIDTH: 97%; " class="font_gray_11" align=left rowspan="4">
        <table cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" style="width: 20%; height: 28px;">
                    Name :
                </td>
                <td align="left" style="width: 80%; height: 28px;">
                    <asp:TextBox id="tbx_name" runat="server" Width="241px" EnableTheming="True"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 20%; height: 50px;">
                    Address :</td>
                <td align="left" style="width: 80%; height: 50px;">
                    <asp:TextBox id="tbx_Address" runat="server" Width="250px" Height="47px" 
                        TextMode="MultiLine"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td style="width: 20%; height: 28px;">
                    Amphur :</td>
                <td style="width: 80%; height: 28px;">
                    <asp:TextBox id="tbx_amphur" runat="server" Width="241px" EnableTheming="True" 
                        Enabled="False"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td style="width: 20%; height: 28px;">
                    Province :</td>
                <td style="width: 80%; height: 28px;">
                    <asp:TextBox id="tbx_province" runat="server" Width="241px" 
                        EnableTheming="True" Enabled="False"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td style="width: 20%; height: 28px;">
                    Country :</td>
                <td style="width: 80%; height: 28px;">
                    <asp:TextBox id="tbx_country" runat="server" Width="241px" EnableTheming="True" 
                        Enabled="False"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td style="width: 20%; height: 28px;">
                    ZIP Code :</td>
                <td style="width: 80%; height: 28px;">
                    <asp:TextBox id="tbx_zipcode" runat="server" Width="241px" EnableTheming="True" 
                        Enabled="False"></asp:TextBox> 
                </td>
            </tr>
        </table>
    </TD></TR><TR><TD style="WIDTH: 3%; HEIGHT: 20px" class="font_gray_11" align=left colSpan=1></TD></TR><TR><TD style="WIDTH: 3%" colSpan=1></TD></TR><TR><TD style="WIDTH: 3%" colSpan=1>
    &nbsp;</TD></TR><TR>
    <TD style="WIDTH: 3%; HEIGHT: 34px"></TD>
    <TD style="WIDTH: 97%; HEIGHT: 34px">
    <asp:ImageButton id="b_edit" onclick="b_edit_Click" runat="server" ImageUrl="images/b_edit_small.jpg" Visible="False"></asp:ImageButton> </TD></TR>
    </TBODY></TABLE></TD><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 45%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left" class="table_shoppingHeader">
                                                                                    &nbsp;
                                                                                    Delivery Cost </TD><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="font_gray_11">
                             <asp:Label style="TEXT-ALIGN: right" id="lbl_delivery_cost" runat="server" Width="90px"></asp:Label> 
                                                                                    <br />
                             <asp:Label style="TEXT-ALIGN: right" id="lbl_delivery_cost_usd" runat="server" Width="90px" CssClass="font_yellow_11_bold"></asp:Label>
                                                                                </TD></TR><TR><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 45%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left" class="table_shoppingHeader">&nbsp; Grand Total </TD><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="font_gray_11"><asp:Label style="TEXT-ALIGN: right" id="lbl_grand_total" runat="server" Width="90px"></asp:Label> 
                                                                                    <br />
                                                                                    <asp:Label style="TEXT-ALIGN: right" id="lbl_grand_total_usd" runat="server" Width="90px" CssClass="font_yellow_11_bold"></asp:Label></TD></TR><TR>
                                                                                    <TD style="border: 1px solid #047700; FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: white; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left" 
                                                                                        class="table_shoppingHeader" colspan="2">&nbsp; Shipping Type</TD></TR><TR>
                                                                                    <TD vAlign=top colSpan=2><TABLE style="WIDTH: 100%; TEXT-ALIGN: left" cellSpacing=0 cellPadding=0><TBODY><TR><TD style="WIDTH: 50%; HEIGHT: 23px" align=left>&nbsp; 
    
    <asp:DropDownList id="cbo_Transport_Type" runat="server" Width="250px" 
        AutoPostBack="True" 
        OnSelectedIndexChanged="cbo_Transport_Type_SelectedIndexChanged"></asp:DropDownList> </TD><TD style="WIDTH: 50%" rowSpan=2><asp:Label style="TEXT-ALIGN: center" id="lbl_Day" runat="server" Width="165px" CssClass="font_gray_11"></asp:Label> </TD></TR><TR><TD style="WIDTH: 50%; HEIGHT: 15px" align=left></TD></TR><TR><TD style="WIDTH: 50%; HEIGHT: 45px" align=left><uc2:Country id="uc_country" runat="server" Visible="false" AutoPostBack="true"></uc2:Country>&nbsp; <asp:DropDownList id="cbo_organizeab" runat="server" Width="208px"></asp:DropDownList> <asp:DropDownList id="cbo_county" runat="server" Width="208px" AutoPostBack="True" OnSelectedIndexChanged="cbo_county_SelectedIndexChanged"></asp:DropDownList><A href="uc/Country.ascx.vb"></A></TD><TD style="WIDTH: 50%; HEIGHT: 45px"><asp:TextBox id="tbx_Zone" runat="server" Visible="False"></asp:TextBox> </TD></TR></TBODY></TABLE></TD></TR><TR>
                                                                                <TD style="HEIGHT: 28px" class="table_shoppingHeader" align=left colSpan=2>&nbsp;Billing Address</TD></TR><TR>
    <TD vAlign=top colSpan=2><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0><TBODY><TR><TD style="HEIGHT: 20px" align=right><asp:RadioButton id="rad_bill_sameAddress" runat="server" CssClass="font_gray_11" Checked="True" GroupName="bill_address" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;</TD><TD style="HEIGHT: 20px" class="font_gray_11" align=left>Same as Shipping Address</TD></TR><TR><TD align=right><asp:RadioButton id="rad_bill_sameAddress1" runat="server" CssClass="font_gray_11" GroupName="bill_address" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;</TD><TD class="font_gray_11" align=left>Other</TD></TR><TR><TD class="font_gray_11" align=right>Name : &nbsp;</TD><TD align=left><asp:TextBox id="tbx_name_bill" runat="server"></asp:TextBox></TD></TR><TR><TD class="font_gray_11" vAlign=top align=right>Address : &nbsp;</TD><TD align=left><asp:TextBox id="tbx_Address_bill" runat="server" Width="250px" Height="61px" TextMode="MultiLine"></asp:TextBox></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 40%; HEIGHT: 28px" class="table_shoppingHeader" align=left>&nbsp;Gift-Wrapping Service</TD>
    <TD style="WIDTH: 60%; HEIGHT: 28px" class="table_shoppingHeader" align=left 
        colSpan=2>&nbsp;Select Payment Method </TD></TR><TR><TD style="WIDTH: 40%" vAlign=top>&nbsp;<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0><TBODY><TR><TD style="FONT-SIZE: 9pt; WIDTH: 100%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 29px" align=left><asp:CheckBox id="chk_gift" runat="server" AutoPostBack="True" OnCheckedChanged="chk_gift_CheckedChanged"></asp:CheckBox>&nbsp;&nbsp;Send items as a gift with our free gift-wrap.</TD></TR><TR><TD style="WIDTH: 100%; HEIGHT: 25px" class="font_gray_11" align=left>&nbsp;From&nbsp;: <asp:TextBox id="tbx_name_gift_from" runat="server"></asp:TextBox>&nbsp;&nbsp;</TD></TR><TR><TD style="WIDTH: 100%" class="font_gray_11" align=left>&nbsp;To :&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox id="tbx_name_gift_to" runat="server"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100%; HEIGHT: 15px" class="font_gray_11" align=left>&nbsp;Message: </TD></TR><TR><TD style="WIDTH: 100%" vAlign=top align=center>&nbsp;<asp:TextBox style="HEIGHT: 69px" id="tbx_message_gift" runat="server" Width="250px" Height="61px" TextMode="MultiLine"></asp:TextBox></TD></TR></TBODY></TABLE></TD>
        <TD style="WIDTH: 60%" vAlign=top colSpan=2><TABLE cellSpacing=0 cellPadding=0 width="100%"><TBODY><TR><TD style="WIDTH: 60%; HEIGHT: 21px; TEXT-ALIGN: left">
            &nbsp;</TD><TD style="WIDTH: 40%; HEIGHT: 21px; TEXT-ALIGN: left"></TD></TR><TR>
            <TD style="WIDTH: 60%; HEIGHT: 21px; TEXT-ALIGN: left; color: #0066FF; font-weight: bold;" 
                align="left">
            &nbsp;<table style="width: 100%">
                    <tr>
                        <td align="right" style="width: 40%">
                            Add Promotional Code :&nbsp;&nbsp;
                        </td>
                        <td align="left" style="width: 60%">
            <asp:ImageButton ID="btnCross_POS" runat="server" 
                ImageUrl="~/images/enter_code.jpg" />
                        </td>
                    </tr>
                </table>
            </TD><TD style="WIDTH: 40%; HEIGHT: 21px; TEXT-ALIGN: left">&nbsp;</TD></TR><TR><TD style="WIDTH: 60%; HEIGHT: 21px; TEXT-ALIGN: left">
            <asp:Label ID="lblCheck_Confirm_Code_Promotion" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblCode_Promotion" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblCheck_Digit" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblChkData_Table_Promotion" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblCheck_Pro_Use" runat="server" Visible="False"></asp:Label>
            </TD><TD style="WIDTH: 40%; HEIGHT: 21px; TEXT-ALIGN: left">&nbsp;</TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 60%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 21px; TEXT-ALIGN: left"><asp:RadioButtonList id="rdobtnPayment" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdobtnPayment_SelectedIndexChanged"></asp:RadioButtonList></TD><TD style="WIDTH: 40%; HEIGHT: 21px; TEXT-ALIGN: left"><asp:DropDownList id="cbo_payment_type" runat="server" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 60%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 21px; TEXT-ALIGN: left"></TD><TD style="WIDTH: 40%; HEIGHT: 21px; TEXT-ALIGN: left">
        &nbsp;</TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 100%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 21px; TEXT-ALIGN: left" colSpan=2><asp:Panel id="Panel2" runat="server" Width="100%" Font-Bold="True" Visible="False">
            <asp:Image ID="Image43" runat="server" 
                ImageUrl="~/images/Template/select_payment_method.jpg" />
            </asp:Panel>
                <asp:Panel ID="Panel3" runat="server" Visible="False">
                    <table cellpadding="0" cellspacing="0" 
    style="width: 100%" border="0">
                        <tr>
                            <td style="width: 100%; font-family: arial, Helvetica, sans-serif; font-size: 11pt; color: #339933; font-weight: bold; height: 26px;">
                                &nbsp;&nbsp;&nbsp; Pay only at shop</td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #333333;">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 1. Central Bangna&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #333333;">
                                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 2. Central Pinklao</td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #333333;">
                                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 3. Chamchuri Square</td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #333333;">
                                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 4. Central World</td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #333333;">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 5. &nbsp;Central Plaza Chaengwattana</td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #333333;">
                                &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; 6. Emporium</td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #333333;">
                                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 7. Fashion Island</td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #333333;">
                                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 8. Paradise Park Seri Center</td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #333333;">
                                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;9. Siam Discovery</td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #333333;">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 10. Siam Paragon</td>
                        </tr>
                    </table>
                </asp:Panel>
                </TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 100%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 25px; TEXT-ALIGN: left" colSpan=2></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>

                &nbsp;<br />
                <asp:ImageButton ID="b_confirm_order" runat="server" 
                    ImageUrl="~/images/Template/proceed_payment.gif" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="b_export" runat="server" ImageUrl="~/images/bt_export2.jpg" Visible="False" />
               
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 100%;">&nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 100%;">
            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                <tr>
                    <td align="center" style="width: 100%; height: 20px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Panel ID="Panel1" runat="server">
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr style="width: 100%; height:31px; background-image:url('images/Template/other_by_author_bg.jpg'); background-repeat:repeat-x;">
                            <td align="left" style="width: 100%; height:31px;" class="label_head">&nbsp;&nbsp; Suggested 
                                List</td>
                        </tr>
                        </table>
                        </asp:Panel></td>
                </tr>
                <tr>
                    <td align="center" style="width: 100%; height: 20px">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100%" align="left">
                        <asp:ListView runat="server" ID="lvBooks">
                        <LayoutTemplate>
                            <div>
                            <ol class="bookab table-style">
                                <li ID="itemPlaceholder" runat="server"></li>
                            </ol>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li>
                                <span class="width-fixer"><div class="PZ3zoom" style="width:92px; height:120px;">
                                <table border="0" cellpadding="0" cellspacing="0" style="width:92px;">
                                <tr>
                                    <td align="left" valign="top" 
                                        style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                                    <td align="left" valign="top" 
                                        style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                                    <td align="left" valign="top" 
                                        style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" 
                                        style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                    <td align="center" valign="top" >
                                        <a href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>' ><img src='<%# Eval("image")%>' alt=""/></a></td>
                                    <td align="left" valign="top" 
                                        style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" 
                                        style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                    <td align="left" valign="top" 
                                        style="height:10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                                    <td align="left" valign="top" 
                                        style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                                </tr>
                                </table></div>
                                <div style="height:5px;"></div>
                                <div class="book-title">
                                    <a style="text-decoration:none;" class="book-title" 
                                        href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>' 
                                        rel="add-to-cart">
                                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("book_title")%>' 
                                        ToolTip='<%#Eval("book_title_full")%>'></asp:Label></a></div>
                                <div class="book-author">
                                    <a style="text-decoration:none;" class="book-author" 
                                        href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>'>
                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("author")%>' 
                                        ToolTip='<%#Eval("author_full")%>'></asp:Label></a></div>
                                <div class="book-space"></div>
                                <div class="book-priceBaht">
                                    <asp:Label ID="lblList_Price_H" runat="server" Text="List Price : Bt."></asp:Label>
                                    <asp:Label ID="lblList_Price_D" runat="server" Text='<%#Eval("selling_price")%>'></asp:Label>
                                    </div>
                                <div class="book-yourprice">Your Price : 
                                    <asp:Label ID="lblYour_Price" runat="server" Text='<%#Eval("your_price")%>'></asp:Label></div>
                                <div class='book-priceUSD'>US$ <%#Eval("price_usd")%></div>
                                <div class='book-save'>
                                    <asp:Label ID="lblsave_price_L" runat="server" Text="(Save "></asp:Label>
                                    <asp:Label ID="lblsave_price_C" runat="server" Text='<%#Eval("save_price")%>'></asp:Label>
                                    <asp:Label ID="lblsave_price_R" runat="server" Text="%)"></asp:Label></div>
                                <div class='book-imagestar'>
                                    <asp:Image ID="imgCustomer_Average" runat="server" />
                                    <asp:Label ID="Label7" runat="server" Text="( "></asp:Label>
                                    <asp:Label ID="lblCustomerView" runat="server"></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text=" )"></asp:Label></div>
                                <a href='book_detail_internet.aspx?Title_1=<%# Eval("isbn_13")%>' 
                                    rel="add-to-cart"><asp:Image runat="server" ID="imgAddToCart" ImageUrl="~/images/Template/add_to_cart.jpg" style="border:0;" class="add-to-cart-button" /></a>
                                <asp:Label ID="lblisbn" runat="server" Text='<%#Eval("isbn_13")%>' Visible="false"></asp:Label>
                                </span>
                            </li>
                        </ItemTemplate>
                        </asp:ListView>
                    </td>
                </tr>
                </table></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 100%;">&nbsp;</td>
        </tr>
    </table>
    
 <asp:Panel ID="panPopUp_Meassge" runat="server" HorizontalAlign="Center" style="display:none">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 450px; background-color:White;">
           <tr>
               <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image21" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 7px; background-image: url('<% getUrl("/images/Template/cart_head_bg.jpg")%>')"></td>
               <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image22" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
           </tr>
           <tr>
               <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_left_bg.jpg")%>'); width: 9px"></td>
               <td align="center" valign="top" >
               <table cellpadding="0" cellspacing="0" style="width: 90%">
                        <tr>
                            <td align="center" style="height: 21px">
                            </td>
                        </tr>
                        <tr>
                            <td class="font_about_us" align="left">
                                <asp:Label ID="lblCheck_Meassge" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="font_other" style="height: 19px">
                                </td>
                        </tr>
                        <tr>
                            <td class="font_other" align="center">
                                <asp:ImageButton ID="img_comfirm_check_pro" runat="server" 
                                    ImageUrl="~/images/b_ok.jpg" OnClientClick="this.style.visibility = 'hidden'" />
                            </td>
                        </tr>
                        <tr>
                            <td class="font_other">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="font_other">
                                &nbsp;</td>
                        </tr>
                    </table>
               </td>
               <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_right_bg.jpg")%>'); width: 10px;"></td>
           </tr>
           <tr>
               <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image23" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 10px; background-image: url('<% getUrl("/images/Template/cart_footer_bg.jpg")%>')"></td>
               <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image24" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" Border="0" /></td>
           </tr>
      </table>
        
 </asp:Panel>
 <asp:ModalPopupExtender ID="mdlPopup_Meassge" 
        TargetControlID="linkConfirm_Order" PopupControlID="panPopUp_Meassge"
  runat="server" BackgroundCssClass="ModelBackground" >
</asp:ModalPopupExtender>

 <asp:Panel ID="panPopUp_Enjoy" runat="server" HorizontalAlign="Center" style="display:none">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 450px; background-color:White;">
           <tr>
               <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image1" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 7px; background-image: url('<% getUrl("/images/Template/cart_head_bg.jpg")%>')"></td>
               <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image2" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
           </tr>
           <tr>
               <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_left_bg.jpg")%>'); width: 9px"></td>
               <td align="center" valign="top" >
               <table cellpadding="0" cellspacing="0" style="width: 90%">
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="font_about_us" align="left">
                                <asp:Label ID="lblEnjoy" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="font_other">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="font_other" align="center">
                                <asp:ImageButton ID="img_Enjoy" runat="server" 
                                    ImageUrl="~/images/b_ok.jpg" OnClientClick="this.style.visibility = 'hidden'" />
                            </td>
                        </tr>
                        <tr>
                            <td class="font_other">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="font_other">
                                &nbsp;</td>
                        </tr>
                    </table>
               </td>
               <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_right_bg.jpg")%>'); width: 10px;"></td>
           </tr>
           <tr>
               <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image3" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 10px; background-image: url('<% getUrl("/images/Template/cart_footer_bg.jpg")%>')"></td>
               <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image4" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" Border="0" /></td>
           </tr>
      </table>
        
 </asp:Panel>
 <asp:ModalPopupExtender ID="mdlPopUp_Enjoy" 
        TargetControlID="lnkEnjoy" PopupControlID="panPopUp_Enjoy"
 CancelControlID="img_Enjoy" runat="server" BackgroundCssClass="ModelBackground" >
</asp:ModalPopupExtender>

<asp:LinkButton ID="linkConfirm_Order" runat="server" style="display:none">LinkButton</asp:LinkButton>
<asp:LinkButton ID="lnkEnjoy" runat="server" style="display:none">LinkButton</asp:LinkButton>

 <asp:Panel ID="panPopUp_ShowCode_Promotion" runat="server" HorizontalAlign="Center" style="display:none">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 450px; background-color:White;">
           <tr>
               <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image5" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 7px; background-image: url('<% getUrl("/images/Template/cart_head_bg.jpg")%>')"></td>
               <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image6" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
           </tr>
           <tr>
               <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_left_bg.jpg")%>'); width: 9px"></td>
               <td align="center" valign="top" >
               <table cellpadding="0" cellspacing="0" style="width: 90%">
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="font_about_us" align="left">
                                Code Promotion&nbsp; :&nbsp;
                                <asp:Label ID="lblPromotion_Cross" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="font_other">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="font_other" align="center">
                                <asp:ImageButton ID="btnCode_Promotion_Cross" runat="server" 
                                    ImageUrl="~/images/b_ok.jpg" />
                            </td>
                        </tr>
                        <tr>
                            <td class="font_other">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="font_other">
                                &nbsp;</td>
                        </tr>
                    </table>
               </td>
               <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_right_bg.jpg")%>'); width: 10px;"></td>
           </tr>
           <tr>
               <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image7" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 10px; background-image: url('<% getUrl("/images/Template/cart_footer_bg.jpg")%>')"></td>
               <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image8" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" Border="0" /></td>
           </tr>
      </table>
        
 </asp:Panel>
 <asp:ModalPopupExtender ID="mdlPopUp_ShowCode_Promotion" 
        TargetControlID="lnkShowCode_Promotion" PopupControlID="panPopUp_ShowCode_Promotion"
 runat="server" BackgroundCssClass="ModelBackground" >
</asp:ModalPopupExtender>

<asp:LinkButton ID="lnkShowCode_Promotion" runat="server" style="display:none">LinkButton</asp:LinkButton>

 <asp:Panel ID="panPopUp_ConfirmCode_Promotion" runat="server" HorizontalAlign="Center" style="display:none">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 450px; background-color:White;">
           <tr>
               <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image9" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 7px; background-image: url('<% getUrl("/images/Template/cart_head_bg.jpg")%>')"></td>
               <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image10" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
           </tr>
           <tr>
               <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_left_bg.jpg")%>'); width: 9px"></td>
               <td align="center" valign="top" >
               <table cellpadding="0" cellspacing="0" style="width: 90%">
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" class="font_about_us">
                                &nbsp;&nbsp;&nbsp;&nbsp; Please enter ther Promotional Code (16 digits) provided &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" class="font_about_us">
                                to get 10% discount on top for shopping online.</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="font_about_us" align="left" valign="top">
                                Code Promotion&nbsp; :&nbsp;
                                <asp:TextBox ID="txtConfirm_Promotion" runat="server" Height="22px" 
                                    Width="232px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="font_other">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="font_other" align="center">
                                <asp:ImageButton ID="btnCheckCode_Promotion_Cross" runat="server" 
                                    ImageUrl="~/images/b_ok.jpg" style="height: 23px" />
                                &nbsp;
                                <asp:ImageButton ID="btncancel_promotion" runat="server" 
                                    ImageUrl="~/images/cancel.jpg" />
                            </td>
                        </tr>
                        <tr>
                            <td class="font_other">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="font_other">
                                &nbsp;</td>
                        </tr>
                    </table>
               </td>
               <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_right_bg.jpg")%>'); width: 10px;"></td>
           </tr>
           <tr>
               <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image11" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 10px; background-image: url('<% getUrl("/images/Template/cart_footer_bg.jpg")%>')"></td>
               <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image12" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" Border="0" /></td>
           </tr>
      </table>
        
 </asp:Panel>
 <asp:ModalPopupExtender ID="mdlPopUp_ConfirmCode_Promotion" CancelControlID="btncancel_promotion" 
        TargetControlID="lnkConfirmCode_Promotion" PopupControlID="panPopUp_ConfirmCode_Promotion"
  runat="server" BackgroundCssClass="ModelBackground" >
</asp:ModalPopupExtender>

<asp:LinkButton ID="lnkConfirmCode_Promotion" runat="server" style="display:none">LinkButton</asp:LinkButton>

 <asp:Panel ID="panPopUp_Msg_Promotion" runat="server" HorizontalAlign="Center" style="display:none">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 450px; background-color:White;">
           <tr>
               <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image13" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 7px; background-image: url('<% getUrl("/images/Template/cart_head_bg.jpg")%>')"></td>
               <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image14" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
           </tr>
           <tr>
               <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_left_bg.jpg")%>'); width: 9px"></td>
               <td align="center" valign="top" >
               <table cellpadding="0" cellspacing="0" style="width: 90%">
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="font_about_us" align="left">
                                <asp:Label ID="lblMsg_Promotion" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="font_other">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="font_other" align="center">
                                <asp:ImageButton ID="imagok" runat="server" 
                                    ImageUrl="~/images/b_ok.jpg" style="height: 23px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="font_other">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="font_other">
                                &nbsp;</td>
                        </tr>
                    </table>
               </td>
               <td valign="top" style="background-image: url('<% getUrl("/images/Template/cart_right_bg.jpg")%>'); width: 10px;"></td>
           </tr>
           <tr>
               <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image15" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 10px; background-image: url('<% getUrl("/images/Template/cart_footer_bg.jpg")%>')"></td>
               <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image16" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" Border="0" /></td>
           </tr>
      </table>
        
 </asp:Panel>
 <asp:ModalPopupExtender ID="mdlPopUp_Msg_Promotion" 
        TargetControlID="lnkMsg_Promotion" PopupControlID="panPopUp_Msg_Promotion"
 CancelControlID="imagok" runat="server" BackgroundCssClass="ModelBackground" >
</asp:ModalPopupExtender>

<asp:LinkButton ID="lnkMsg_Promotion" runat="server" style="display:none">LinkButton</asp:LinkButton>
</asp:Content>
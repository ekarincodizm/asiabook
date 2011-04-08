<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Customer_Order_Internet_20101005.aspx.vb" Inherits="Customer_Order_Internet" title="Untitled Page" %>
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
                <asp:Panel ID="Panel1" runat="server">
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<TABLE style="BACKGROUND-COLOR: #f2fdec" cellSpacing=0 cellPadding=0 width="100%"><TBODY><TR><TD style="WIDTH: 100%; HEIGHT: 150px; BACKGROUND-COLOR: white"><TABLE cellSpacing=0 cellPadding=0 width="100%" align=center border=0><TBODY><TR><TD style="WIDTH: 100%; HEIGHT: 19px" align=right colSpan=5></TD></TR><TR><TD style="WIDTH: 20%; HEIGHT: 27px; TEXT-ALIGN: left" class="font_gray_11">&nbsp;Order No :</TD><TD style="WIDTH: 40%; HEIGHT: 27px" class="font_gray_11"><asp:Label style="TEXT-ALIGN: left" id="lbl_h_order_no" runat="server" Width="100%"></asp:Label></TD><TD style="WIDTH: 15%; HEIGHT: 27px; TEXT-ALIGN: left" class="font_gray_11">&nbsp;Order Date :</TD><TD style="WIDTH: 25%; HEIGHT: 27px; TEXT-ALIGN: left" class="font_gray_11" align=left><asp:Label style="TEXT-ALIGN: left" id="lbl_h_Order_Date" runat="server" Width="100%"></asp:Label></TD><TD style="WIDTH: 10%"><asp:ImageButton id="b_change_book" runat="server" ImageUrl="images/bt_chg_bk_ord.jpg"></asp:ImageButton></TD></TR><TR><TD style="WIDTH: 20%; HEIGHT: 27px; TEXT-ALIGN: left" class="font_gray_11">&nbsp;Customer Name :</TD><TD style="WIDTH: 40%; HEIGHT: 27px" class="font_gray_11" align=left><asp:Label id="lbl_h_customer_name" runat="server"></asp:Label> <asp:Label id="lbl_h_Last_Name" runat="server"></asp:Label></TD><TD style="WIDTH: 15%; HEIGHT: 27px; TEXT-ALIGN: left" class="font_gray_11">&nbsp;Telephone :</TD><TD style="WIDTH: 25%; HEIGHT: 27px; TEXT-ALIGN: left" class="font_gray_11" align=left><asp:Label style="TEXT-ALIGN: left" id="lbl_h_telephone" runat="server" Width="100%"></asp:Label></TD><TD style="WIDTH: 10%; HEIGHT: 27px"></TD></TR><TR><TD style="WIDTH: 20%; HEIGHT: 28px; TEXT-ALIGN: left" class="font_gray_11">&nbsp;E-Mail :</TD><TD style="WIDTH: 40%; HEIGHT: 28px" class="font_gray_11" align=left><asp:Label id="lblemail" runat="server"></asp:Label></TD><TD style="WIDTH: 15%; HEIGHT: 28px; TEXT-ALIGN: left" class="font_gray_11"></TD><TD style="WIDTH: 25%; HEIGHT: 27px; TEXT-ALIGN: left" class="font_gray_11"></TD><TD style="WIDTH: 10%; HEIGHT: 28px"></TD></TR></TBODY></TABLE><asp:Panel id="P_In_Branch" runat="server" Width="100%">
<TABLE cellSpacing=0 cellPadding=0 width="100%">
    <TBODY>
<TR>
<TD 
        style="HEIGHT: 24px; background-image: url('file:///C:/Documents%20and%20Settings/kung/Desktop/Website/EOrdering_New/Eordering/EorderingWebsite/images/Asiabooks/ImagesTP_ec/BS_menuBooksSearch_Bg.jpg'); width: 100%;" 
        class="menuHeaderGreen">Available</TD>
</TR>
</TBODY></TABLE></asp:Panel></TD></TR><TR><TD style="WIDTH: 100%"><Saifi:MyDg id="In_Branch" runat="server" Width="100%" CssClass="Grid_shopping" AutoGenerateColumns="False" AllowPaging="false" CellPadding="0" ImageFirst="images/b_firstpage.gif" ImageLast="images/b_lastpage.gif" ImageNext="images/b_nextpage.gif" ImagePrevious="images/b_prevpage.gif" SelectedItemStyle-BackColor="#99ccff" ShowFirstAndLastImage="True" ShowPreviousAndNextImage="True">
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
<asp:Label style="TEXT-ALIGN: center" id="lbl_No_Inbranch" runat="server" Width="50px" Text='<%# DataBinder.Eval(Container.DataItem,"No") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Title" SortExpression="Book_Title"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_Book_Title_Inbranch" runat="server" Width="165px" Text='<%# DataBinder.Eval(Container.DataItem,"Book_Title") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="30%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="ISBN" SortExpression="ISBN"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_ISBN_Inbranch" runat="server" Width="100px" Text='<%# DataBinder.Eval(Container.DataItem,"ISBN_13") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Weight (Kg)" SortExpression="Weight"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Weight_Inbranch" runat="server" Width="60px" Text='<%# DataBinder.Eval(Container.DataItem,"Weight","{0:#,##0.00}") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Price (Baht)" SortExpression="Price"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Price_Inbranch" runat="server" Width="64px" Text='<%# DataBinder.Eval(Container.DataItem,"Selling_Price","{0:#,##0.00}") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Discount" SortExpression="Discount"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_discount_Inbranch" runat="server" Width="50%" Text="<%# 5 %>"></asp:Label>&nbsp;% 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Quantity" SortExpression="Quantity"><ItemTemplate>
&nbsp;<asp:Label style="TEXT-ALIGN: right" id="lbl_quantity_Inbranch" runat="server" Width="63px" Text='<%# DataBinder.Eval(Container.DataItem,"Quantity") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Amount &lt;br&gt; (Baht)" SortExpression="Amount"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Amount_Inbranch" runat="server" Width="120px" Text='<%# DataBinder.Eval(Container.DataItem,"Amount","{0:#,##0.00}") %>'></asp:Label> <asp:Label style="TEXT-ALIGN: right" id="lbl_Amount_in_branch_usd" runat="server" Width="120px" CssClass="font_yellow_11_bold"></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="15%"></HeaderStyle>
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
</Saifi:MyDg> <asp:Panel id="P_In_branch_1" runat="server" Width="100%"><TABLE style="BORDER-TOP-STYLE: none" borderColor=#047700 cellSpacing=0 cellPadding=0 width="100%" border=1><TBODY><TR><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; BORDER-LEFT: #047700 1px solid; WIDTH: 65%; BORDER-BOTTOM: #047700 1px solid; HEIGHT: 38px; TEXT-ALIGN: right" class="font_gray_11">Total Weight &nbsp;</TD><TD style="WIDTH: 10%; TEXT-ALIGN: right" class="font_gray_11"><asp:Label style="TEXT-ALIGN: right" id="lbl_InBranch_Total_Weight" runat="server" Width="100%"></asp:Label></TD><TD style="WIDTH: 10%" class="font_gray_11">Amount</TD><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="font_gray_11"><asp:Label style="TEXT-ALIGN: right" id="lbl_InBranch_total" runat="server" Width="90px"></asp:Label><BR /><asp:Label style="TEXT-ALIGN: right" id="lbl_InBranch_total_usd" runat="server" Width="90px" CssClass="font_yellow_11_bold"></asp:Label></TD></TR><TR><TD style="WIDTH: 65%; HEIGHT: 40px" class="font_gray_11" align=right>Max Leadtime&nbsp;</TD><TD style="WIDTH: 10%; TEXT-ALIGN: right" class="font_gray_11"><asp:Label style="TEXT-ALIGN: right" id="lbl_InBranch_max_leadtime" runat="server" Width="100%"></asp:Label></TD><TD style="WIDTH: 10%" class="font_gray_11">Delivery Cost</TD><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="font_gray_11"><asp:Label style="TEXT-ALIGN: right" id="lbl_InBranch_delivery_cost" runat="server" Width="90px"></asp:Label><BR /><asp:Label style="TEXT-ALIGN: right" id="lbl_InBranch_delivery_cost_usd" runat="server" Width="90px" CssClass="font_yellow_11_bold"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel></TD></TR><TR><TD style="WIDTH: 100%"><asp:Panel id="P_jobber" runat="server" Width="100%">
<TABLE cellSpacing=0 cellPadding=0 width="100%">
    <TBODY><TR>
<TD 
        
        style="HEIGHT: 24px; background-image: url('file:///C:/Documents%20and%20Settings/kung/Desktop/Website/EOrdering_New/Eordering/EorderingWebsite/images/Asiabooks/ImagesTP_ec/BS_menuBooksSearch_Bg.jpg'); width: 100%;" 
        class="menuHeaderGreen">
Out of stock but available on special order</TD>
</TR></TBODY></TABLE></asp:Panel> <Saifi:MyDg id="jobber" runat="server" Width="100%" CssClass="Grid_shopping" AutoGenerateColumns="False" AllowPaging="false" CellPadding="0" ImageFirst="images/b_firstpage.gif" ImageLast="images/b_lastpage.gif" ImageNext="images/b_nextpage.gif" ImagePrevious="images/b_prevpage.gif" SelectedItemStyle-BackColor="#99ccff" ShowFirstAndLastImage="True" ShowPreviousAndNextImage="True">
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
<asp:Label style="TEXT-ALIGN: center" id="lbl_No_jobber" runat="server" Width="50px" Text='<%# DataBinder.Eval(Container.DataItem,"No") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Title" SortExpression="Book_Title"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_Book_Title_jobber" runat="server" Width="165px" Text='<%# DataBinder.Eval(Container.DataItem,"Book_Title") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="30%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="ISBN" SortExpression="ISBN"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: left" id="lbl_ISBN_jobber" runat="server" Width="100px" Text='<%# DataBinder.Eval(Container.DataItem,"ISBN_13") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Weight (Kg)" SortExpression="Weight"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Weight_jobber" runat="server" Width="60px" Text='<%# DataBinder.Eval(Container.DataItem,"Weight","{0:#,##0.00}") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Price (Baht)" SortExpression="Price"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Price_jobber" runat="server" Width="64px" Text='<%# DataBinder.Eval(Container.DataItem,"Selling_Price","{0:#,##0.00}") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Discount" SortExpression="Discount"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_discount_jobber" runat="server" Width="50%" Text="<%# 5 %>"></asp:Label>&nbsp;% 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Quantity" SortExpression="Quantity"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_quantity_jobber" runat="server" Width="63px" Text='<%# DataBinder.Eval(Container.DataItem,"Quantity") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Amount &lt;br&gt; (Baht)" SortExpression="Amount"><ItemTemplate>
<asp:Label style="TEXT-ALIGN: right" id="lbl_Amount_jobber" runat="server" Width="120px" Text='<%# DataBinder.Eval(Container.DataItem,"Amount","{0:#,##0.00}") %>'></asp:Label> <asp:Label style="TEXT-ALIGN: right" id="lbl_Amount_jobber_usd" runat="server" Width="120px" CssClass="font_yellow_11_bold"></asp:Label> 
</ItemTemplate>

<HeaderStyle Width="15%"></HeaderStyle>
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
</asp:Label><BR /><asp:Label style="TEXT-ALIGN: right" id="lbl_jobber_total_usd" runat="server" Width="90px" CssClass="font_yellow_11_bold"></asp:Label> </TD></TR><TR><TD style="WIDTH: 65%; HEIGHT: 40px" class="font_gray_11" align=right>Max Leadtime&nbsp;</TD><TD style="WIDTH: 10%; TEXT-ALIGN: right" class="font_gray_11" vAlign=middle><asp:Label style="TEXT-ALIGN: right" id="lbl_jobber_max_leadtime" runat="server"></asp:Label> </TD><TD style="WIDTH: 10%" class="font_gray_11">Delivery Cost</TD><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="font_gray_11"><asp:Label style="TEXT-ALIGN: right" id="lbl_jobber_delivery_cost" runat="server" Width="90px"></asp:Label><BR /><asp:Label style="TEXT-ALIGN: right" id="lbl_jobber_delivery_cost_usd" runat="server" Width="90px" CssClass="font_yellow_11_bold"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> <TABLE borderColor=#047700 cellSpacing=0 cellPadding=0 width="100%" border=1><TBODY><TR><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 40%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left" class="table_shoppingHeader" align=left>&nbsp;Shipping Address</TD><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 45%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left" class="table_shoppingHeader">&nbsp;Total Amount</TD><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="font_gray_11"><asp:Label style="TEXT-ALIGN: right" id="lbl_total_amount" runat="server" Width="90px"></asp:Label>&nbsp;<BR /><asp:Label style="TEXT-ALIGN: right" id="lbl_total_amount_usd" runat="server" Width="90px" CssClass="font_yellow_11_bold"></asp:Label></TD></TR><TR><TD style="WIDTH: 40%" vAlign=top rowSpan=6>&nbsp;&nbsp; <TABLE cellSpacing=0 cellPadding=0 width="100%"><TBODY><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left><asp:Label id="Label1" runat="server" Font-Bold="True" Text="Home Address"></asp:Label></TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left><asp:RadioButton id="rad_address1" runat="server" Checked="True" GroupName="Address" AutoPostBack="True"></asp:RadioButton> <asp:Label id="lbl_address1" runat="server"></asp:Label></TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 11px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 11px" align=left></TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left><asp:Label id="Label3" runat="server" Font-Bold="True" Text="Office Address"></asp:Label></TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left><asp:RadioButton id="rad_address2" runat="server" GroupName="Address" AutoPostBack="True"></asp:RadioButton> <asp:Label id="lbl_address2" runat="server"></asp:Label> </TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 11px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 11px" align=left></TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left><asp:Label id="Label2" runat="server" Font-Bold="True" Text="Shipping Address"></asp:Label></TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left><asp:RadioButton id="rad_address3" runat="server" GroupName="Address" AutoPostBack="True"></asp:RadioButton> <asp:Label id="lbl_address3" runat="server"></asp:Label> </TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left colSpan=1></TD><TD style="FONT-SIZE: 9pt; WIDTH: 97%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left colSpan=2></TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 3%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left colSpan=1></TD><TD style="FONT-SIZE: 9pt; WIDTH: 257px; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 20px" align=left colSpan=2><asp:RadioButton id="rad_address4" runat="server" GroupName="Address" AutoPostBack="True"></asp:RadioButton> <STRONG style="WIDTH: 97%">Other</STRONG></TD></TR><TR><TD style="WIDTH: 3%; HEIGHT: 24px" class="font_gray_11" align=left colSpan=1></TD><TD style="WIDTH: 97%; HEIGHT: 24px" class="font_gray_11" align=left colSpan=2></TD></TR><TR><TD style="WIDTH: 3%; HEIGHT: 24px" class="font_gray_11" align=left colSpan=1></TD><TD style="WIDTH: 97%; HEIGHT: 24px" class="font_gray_11" align=left colSpan=2>&nbsp;Name : &nbsp; <asp:TextBox id="tbx_name" runat="server" Width="241px" EnableTheming="True"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 3%; HEIGHT: 20px" class="font_gray_11" align=left colSpan=1></TD><TD style="WIDTH: 97%; HEIGHT: 20px" class="font_gray_11" align=left colSpan=2>&nbsp;Address :</TD></TR><TR><TD style="WIDTH: 3%" colSpan=1></TD><TD style="WIDTH: 97%" colSpan=2><asp:TextBox id="tbx_Address" runat="server" Width="250px" Height="61px" TextMode="MultiLine"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 3%; HEIGHT: 34px"></TD><TD style="WIDTH: 97%; HEIGHT: 34px"><asp:ImageButton id="b_edit" onclick="b_edit_Click" runat="server" ImageUrl="images/b_edit_small.jpg" Visible="False"></asp:ImageButton> </TD></TR></TBODY></TABLE></TD><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 45%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left" class="table_shoppingHeader">&nbsp;Delivery Cost </TD><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="font_gray_11"><asp:Label style="TEXT-ALIGN: right" id="lbl_delivery_cost" runat="server" Width="90px"></asp:Label> &nbsp; <BR /><asp:Label style="TEXT-ALIGN: right" id="lbl_delivery_cost_usd" runat="server" Width="90px" CssClass="font_yellow_11_bold"></asp:Label></TD></TR><TR><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 45%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left" class="table_shoppingHeader">Grand Total </TD><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="font_gray_11"><asp:Label style="TEXT-ALIGN: right" id="lbl_grand_total" runat="server" Width="90px"></asp:Label> &nbsp; <BR /><asp:Label style="TEXT-ALIGN: right" id="lbl_grand_total_usd" runat="server" Width="90px" CssClass="font_yellow_11_bold"></asp:Label></TD></TR><TR><TD style="BORDER-RIGHT: #047700 1px solid; BORDER-TOP: #047700 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 11px; BORDER-LEFT: #047700 1px solid; WIDTH: 60%; COLOR: white; BORDER-BOTTOM: #047700 1px solid; FONT-FAMILY: arial; HEIGHT: 40px; BACKGROUND-COLOR: #49a514; TEXT-ALIGN: left" class="table_shoppingHeader" align=left colSpan=4>&nbsp;Shipping Type</TD></TR><TR><TD vAlign=top colSpan=4><TABLE style="WIDTH: 100%; TEXT-ALIGN: left" cellSpacing=0 cellPadding=0><TBODY><TR><TD style="WIDTH: 50%; HEIGHT: 23px" align=left><asp:DropDownList id="cbo_Transport_Type" runat="server" Width="147px" AutoPostBack="True" OnSelectedIndexChanged="cbo_Transport_Type_SelectedIndexChanged"></asp:DropDownList> </TD><TD style="WIDTH: 50%" rowSpan=2><asp:Label style="TEXT-ALIGN: center" id="lbl_Day" runat="server" Width="165px" CssClass="font_gray_11"></asp:Label> </TD></TR><TR><TD style="WIDTH: 50%; HEIGHT: 15px" align=left></TD></TR><TR><TD style="WIDTH: 50%; HEIGHT: 45px" align=left><uc2:Country id="uc_country" runat="server" Visible="false" AutoPostBack="true"></uc2:Country>&nbsp; <asp:DropDownList id="cbo_organizeab" runat="server" Width="208px"></asp:DropDownList> <asp:DropDownList id="cbo_county" runat="server" Width="208px" AutoPostBack="True" OnSelectedIndexChanged="cbo_county_SelectedIndexChanged"></asp:DropDownList><A href="uc/Country.ascx.vb"></A></TD><TD style="WIDTH: 50%; HEIGHT: 45px"><asp:TextBox id="tbx_Zone" runat="server" Visible="False"></asp:TextBox> </TD></TR></TBODY></TABLE></TD></TR><TR><TD style="HEIGHT: 28px" class="table_shoppingHeader" align=left colSpan=4>&nbsp;Billing Address</TD></TR><TR><TD vAlign=top colSpan=4><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0><TBODY><TR><TD style="HEIGHT: 20px" align=right><asp:RadioButton id="rad_bill_sameAddress" runat="server" CssClass="font_gray_11" Checked="True" GroupName="bill_address" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;</TD><TD style="HEIGHT: 20px" class="font_gray_11" align=left>Same as Shipping Address</TD></TR><TR><TD align=right><asp:RadioButton id="rad_bill_sameAddress1" runat="server" CssClass="font_gray_11" GroupName="bill_address" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;</TD><TD class="font_gray_11" align=left>Other</TD></TR><TR><TD class="font_gray_11" align=right>Name : &nbsp;</TD><TD align=left><asp:TextBox id="tbx_name_bill" runat="server"></asp:TextBox></TD></TR><TR><TD class="font_gray_11" vAlign=top align=right>Address : &nbsp;</TD><TD align=left><asp:TextBox id="tbx_Address_bill" runat="server" Width="250px" Height="61px" TextMode="MultiLine"></asp:TextBox></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 40%; HEIGHT: 28px" class="table_shoppingHeader" align=left>&nbsp;Gift-Wrapping Service</TD><TD style="WIDTH: 60%; HEIGHT: 28px" class="table_shoppingHeader" align=left colSpan=4>&nbsp;Select Payment Method </TD></TR><TR><TD style="WIDTH: 40%" vAlign=top>&nbsp;<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0><TBODY><TR><TD style="FONT-SIZE: 9pt; WIDTH: 100%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 29px" align=left><asp:CheckBox id="chk_gift" runat="server" AutoPostBack="True" OnCheckedChanged="chk_gift_CheckedChanged"></asp:CheckBox>&nbsp;&nbsp;Send items as a gift with our free gift-wrap.</TD></TR><TR><TD style="WIDTH: 100%; HEIGHT: 25px" class="font_gray_11" align=left>&nbsp;From&nbsp;: <asp:TextBox id="tbx_name_gift_from" runat="server"></asp:TextBox>&nbsp;&nbsp;</TD></TR><TR><TD style="WIDTH: 100%" class="font_gray_11" align=left>&nbsp;To :&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox id="tbx_name_gift_to" runat="server"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100%; HEIGHT: 15px" class="font_gray_11" align=left>&nbsp;Message: </TD></TR><TR><TD style="WIDTH: 100%" vAlign=top align=center>&nbsp;<asp:TextBox style="HEIGHT: 69px" id="tbx_message_gift" runat="server" Width="250px" Height="61px" TextMode="MultiLine"></asp:TextBox></TD></TR></TBODY></TABLE></TD><TD style="WIDTH: 60%" vAlign=top colSpan=4><TABLE cellSpacing=0 cellPadding=0 width="100%"><TBODY><TR><TD style="WIDTH: 60%; HEIGHT: 21px; TEXT-ALIGN: left">&nbsp;</TD><TD style="WIDTH: 40%; HEIGHT: 21px; TEXT-ALIGN: left"></TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 60%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 21px; TEXT-ALIGN: left"><asp:RadioButtonList id="rdobtnPayment" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdobtnPayment_SelectedIndexChanged"></asp:RadioButtonList></TD><TD style="WIDTH: 40%; HEIGHT: 21px; TEXT-ALIGN: left"><asp:DropDownList id="cbo_payment_type" runat="server" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 60%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 21px; TEXT-ALIGN: left"></TD><TD style="WIDTH: 40%; HEIGHT: 21px; TEXT-ALIGN: left">
        &nbsp;</TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 100%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 21px; TEXT-ALIGN: left" colSpan=2><asp:Panel id="Panel2" runat="server" Width="100%" Font-Bold="True" Visible="False">Counter Service&nbsp; in 7/11 shops <asp:Image id="imgseven" runat="server" ImageUrl="~/images/Asiabooks/7-11.jpg"></asp:Image>, shopping malls <BR />or other shops with a sign "Counter Service"&nbsp; <asp:Image id="imgcounter" runat="server" ImageUrl="~/images/Asiabooks/Counter.jpg"></asp:Image></asp:Panel></TD></TR><TR><TD style="FONT-SIZE: 9pt; WIDTH: 100%; COLOR: #4e4e4e; FONT-FAMILY: Arial; HEIGHT: 25px; TEXT-ALIGN: left" colSpan=2></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
                </asp:UpdatePanel>
                </asp:Panel>
                &nbsp;<br />
                <asp:ImageButton ID="b_save" runat="server" ImageUrl="images/b_crf_ord.jpg" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="b_export" runat="server" ImageUrl="~/images/bt_export2.jpg" Visible="False" /></td>
        </tr>
        <tr>
            <td style="text-align: center">&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>


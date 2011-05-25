<%@ Page Language = "VB" MasterPageFile = "~/MasterPage.master" AutoEventWireup = "False" EnableEventValidation="false" CodeFile = "shoppingCart_Internet.aspx.vb" Inherits = "shoppingCart_Internet" title = "ShoppingCart Page" %>
<%@ Register Assembly = "MycustomDG" Namespace = "MycustomDG" TagPrefix = "Saifi" %>
<%@ Register Assembly = "AjaxControlToolkit" Namespace = "AjaxControlToolkit" TagPrefix = "asp" %>
<asp:Content ID = "Content1" ContentPlaceHolderID = "ContentPlaceHolder1" Runat = "Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
    <asp:UpdatePanel id = "UpdatePanel1" runat = "server">
        <contenttemplate>
            <table cellspacing = "0" cellpadding = "0" width = "100%" border = "0">
                <tbody>
		<tr>
    <td style="width: 100%" align="left">
        <asp:Image ID="Imageshopping_step_02" runat="server" ImageUrl="~/images/Shopping_Step/shopping_step_02.gif" /></td>
</tr>
                    <tr>
                        <td style = "width:100%" align = "right"></td>
                    </tr>
                    <tr>
                        <td align = "left" style = "width:100%" class = "header_other">Shopping Cart</td>
                    </tr>
                    <tr>
                        <td align = "left" style = "width:100%" class = "font_other">
                            <asp:Label ID = "lblStatus_Head" runat = "server"></asp:Label>
                        <br /><br /></td>
                    </tr>
                    <tr>
                        <td align = "right" style = "width:100%">
                            <asp:ImageButton ID = "b_continue_shopping" runat = "server" 
                                ImageUrl = "~/images/Template/Button/continue_shopping.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td style = "width:100%" align = "center"></td>
                    </tr>
                    <tr>
                        <td style = "width:100%; text-align:center" valign = "top">
                            <table cellspacing = "0" cellpadding = "0" width = "100%" align = "center" border = "0">
                                <!-- Data Available in Branch (1)-->
                                    <tbody>
                                        <tr>
                                            <td style = "background-image:url(images/Asiabooks/ImagesTP_ec/BS_menuBooksSearch_Bg.jpg); width:100%; height:24px" class = "menuHeaderGreen">Available</td>
                                        </tr>
                                        <tr>
                                            <td style = "width:100%" align = "center">
                                                <!-- Datagrid Available in Branch (1)-->
                                                <Saifi:MyDg style = "border-right:#047700 2px solid; border-top:#047700 2px solid; border-left:#047700 2px solid; border-bottom:#047700 2px solid" 
                                                    id = "In_Branch" runat = "server" width = "100%" CssClass = "Grid_shopping" 
                                                    cellpadding = "0" ImageFirst = "images/b_firstpage.gif" 
                                                    ImageLast = "images/b_lastpage.gif" ImageNext = "images/b_nextpage.gif" 
                                                    ImagePrevious = "images/b_prevpage.gif" SelectedItemStyle-BackColor = "#99ccff" 
                                                    ShowFirstAndLastImage = "True" ShowPreviousAndNextImage = "True" 
                                                    AutoGenerateColumns = "False" PageSize="100">
                                                <FooterStyle Horizontalalign = "Center" Font-Bold = "False" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></FooterStyle>
                                                <EditItemStyle Horizontalalign = "Center" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></EditItemStyle>
                                                <SelectedItemStyle Horizontalalign = "Center" BackColor = "#99CCFF" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></SelectedItemStyle>
                                                <AlternatingItemStyle Horizontalalign = "Center" CssClass = "Grid_shoppingAltItem" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></AlternatingItemStyle>
                                                <ItemStyle Horizontalalign = "Center" CssClass = "Grid_shoppingItem" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></ItemStyle>
                                                <PagerStyle Mode = "NumericPages" PageButtonCount = "5" Visible = "False"></PagerStyle>
                                                    <Columns>
                                                        <asp:TemplateColumn HeaderText = "Item No" SortExpression = "No">
                                                            <ItemTemplate>
                                                                <asp:Label style = "text-align:center" id = "No" runat = "server" 
                                                                    Text='<%# DataBinder.Eval(Container.DataItem,"No") %>'>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                </asp:Label> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "7%"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Title" SortExpression = "Book_Title">
                                                            <ItemTemplate>
                                                                <a class = "Grid_bookItem_A" href='book_detail_internet.aspx?Title_1=<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>'>
                                                                <asp:Label style = "text-align:left"  width = "100%"  id = "Book_Title" runat = "server" 
                                                                    Text='<%# DataBinder.Eval(Container.DataItem,"Book_Title") %>'></asp:Label> 
                                                                </a>
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "20%" />
                                                        </asp:TemplateColumn>

                                                        <asp:TemplateColumn HeaderText = "ISBN" SortExpression = "ISBN">
                                                            <ItemTemplate>
                                                                <asp:Label style = "text-align:center" id = "ISBN" runat = "server" 
                                                                    width = "100%" Text='<%# DataBinder.Eval(Container.DataItem,"ISBN_13") %>'></asp:Label> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "15%"></HeaderStyle>
                                                        </asp:TemplateColumn>

                                                        <asp:TemplateColumn HeaderText = "Price (Baht)" SortExpression = "Price">
                                                            <ItemTemplate>
                                                                <asp:Label style = "text-align:right" id = "Price" runat = "server" 
                                                                    width = "100%" Text='<%# DataBinder.Eval(Container.DataItem,"Selling_Price","{0:##,###.00}") %>'></asp:Label> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "10%"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Lead Time (Day)" SortExpression = "Lead_Time">
                                                            <ItemTemplate>
                                                                <asp:Label id = "Lead_Time_show" runat = "server"></asp:Label>
                                                                <asp:Label id = "Lead_Time" runat = "server" Text='<%# DataBinder.Eval(Container.DataItem,"Lead_Time") %>' Visible = "False"></asp:Label> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "10%"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Weight (Kg)" SortExpression = "Weight">
                                                            <ItemTemplate>
                                                            <asp:Label style = "text-align:right" id = "Weight" runat = "server" width = "100%" 
                                                                Text='<%# DataBinder.Eval(Container.DataItem,"Weight","{0:##,###.00}") %>'></asp:Label> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "10%"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Quantity" SortExpression = "Quantity"><ItemTemplate>
                                                            <asp:TextBox onblur = "ValidInt();" style = "text-align:center" id = "Quantity" runat = "server" 
                                                                width = "30px" Text='<%# DataBinder.Eval(Container.DataItem,"Quantity") %>' 
                                                                OnTextChanged = "Quantity_TextChanged" AutoPostBack = "True" MaxLength="3">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            </asp:TextBox> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "8%"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Amount &lt;br&gt;(Baht)" SortExpression = "Amount">
                                                            <ItemTemplate>
                                                                <asp:Label style = "text-align:right" id = "Amount" runat = "server" width = "100%" 
                                                                    Text='<%# DataBinder.Eval(Container.DataItem,"Amount","{0:##,###.00}") %>'></asp:Label>
                                                                <br />
                                                                <asp:Label style = "text-align:right" id = "lbl_Amount_in_branch_usd" runat = "server" 
                                                                    width = "100%" CssClass = "font_yellow_11_bold"></asp:Label> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "15%"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton style = "text-align:center" id = "b_del_In_Branch" runat = "server" 
                                                                    ImageUrl = "~/images/bin.jpg" __designer:wfdid = "w22" CommandName = "Delete" 
                                                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ISBN_13") %>'>
                                                                </asp:ImageButton> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "5%"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Stock" Visible = "False">
                                                            <ItemTemplate>
                                                                <asp:ImageButton id = "b_stock" runat = "server" ImageUrl = "~/images/star.jpg" 
                                                                    CommandName = "Stock" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"No") %>'>
                                                                </asp:ImageButton> 
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Ordstt" Visible = "False">
                                                            <ItemTemplate>
                                                                <asp:Label id = "ordstt_In_Branch" runat = "server" Text = "0" ></asp:Label> 
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "To_Org_AB_Code" Visible = "False">
                                                            <ItemTemplate>
                                                                <asp:Label id = "To_Org_AB_Code_In_branch" runat = "server" Text='<%# "" %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Status" Visible = "False">
                                                            <ItemTemplate>
                                                                <asp:Label id = "Status_In_branch" runat = "server" 
                                                                    Text='<%# DataBinder.Eval(Container.DataItem,"Status") %>'></asp:Label> 
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                <HeaderStyle Horizontalalign = "Center" Verticalalign = "Middle" BackColor = "#49A514" BorderStyle = "None" CssClass = "Grid_shoppingHeader" Font-Bold = "True" Font-Italic = "False" Font-Names = "arial" Font-Overline = "False" Font-Size = "11px" Font-Strikeout = "False" Font-Underline = "False" ForeColor = "White"></HeaderStyle>
                                                </Saifi:MyDg>
                                                <!-- Data  footer Available in Branch (1)-->
                                                <table style = "border-top-width:1px; border-right:1px solid; border-left:1px solid; width:100%; border-bottom:1px solid; border-style: solid; border-color: #008000;" 
                                                cellspacing = "0" cellpadding = "0" border = "1">
                                                    <tbody>
                                                        <tr>
                                                            <td align = "right" height = "30px">
                                                                <asp:Label style = "font-weight:bold; font-size:9pt; color:#ff6600; font-family:arial; text-align:left" 
                                                                id = "lbl_item_in_shopping1" runat = "server" width = "100%"></asp:Label> 
                                                                <asp:Label style = "text-align:right" id = "lbl_total_Inbranch" runat = "server" 
                                                                CssClass = "font_green_11" Text = "Label" width = "95%"></asp:Label>
                                                            </td>
                                                            <td class = "font_gray_11" align = "right" height = "30px" width = "15%">
                                                                <asp:Label style = "font-size:11px; color:#4e4e4e; font-family:arial; text-align:right" 
                                                                    id = "lbl_Amount_InBranch" runat = "server" height = "16px"></asp:Label>
                                                                <br />
                                                                <asp:Label style = "text-align:right" id = "lbl_Amount_InBranch_usd" runat = "server" 
                                                                    CssClass = "font_yellow_11_bold"></asp:Label>
                                                            </td>
                                                            <td width = "5%" height="30px"></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style = "background-image:url(images/Asiabooks/ImagesTP_ec/BS_menuBooksSearch_Bg.jpg); width:100%; height:24px; text-align:left" class = "menuHeaderGreen">Out of stock but available on special order</td>
                                        </tr>
                                            <!--Datagrid Available On Special Order (3)-->
                                        <tr>
                                            <td valign = "top" align = "center">
                                                <Saifi:MyDg id = "jobber" runat = "server" width = "100%" CssClass = "Grid_shopping" 
                                                    CellPadding = "0" ImageFirst = "images/b_firstpage.gif" 
                                                    ImageLast = "images/b_lastpage.gif" ImageNext = "images/b_nextpage.gif" 
                                                    ImagePrevious = "images/b_prevpage.gif" ShowFirstAndLastImage = "True" 
                                                    ShowPreviousAndNextImage = "True" AutoGenerateColumns = "False" 
                                                    PageSize="100">
                                                <FooterStyle Horizontalalign = "Center" Font-Bold = "False" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></FooterStyle>
                                                <EditItemStyle Horizontalalign = "Center" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></EditItemStyle>
                                                <SelectedItemStyle Horizontalalign = "Center" BackColor = "#99CCFF" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></SelectedItemStyle>
                                                <AlternatingItemStyle Horizontalalign = "Center" CssClass = "Grid_shoppingAltItem" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></AlternatingItemStyle>
                                                <ItemStyle Horizontalalign = "Center" CssClass = "Grid_shoppingItem" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></ItemStyle>
                                                <PagerStyle Mode = "NumericPages" PageButtonCount = "5" Visible = "False"></PagerStyle>
                                                    <Columns>
                                                        <asp:TemplateColumn HeaderText = "Item No" SortExpression = "No">
                                                            <ItemTemplate>
                                                                <asp:Label style = "text-align:center" id = "No_Jobber" runat = "server" width = "100%" 
                                                                    Text='<%# DataBinder.Eval(Container.DataItem,"No") %>' __designer:wfdid = "w22"></asp:Label> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "7%"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Title" SortExpression = "Book_Title">
                                                            <ItemTemplate>
                                                                <a class = "Grid_bookItem_A" href='book_detail_internet.aspx?Title_1=<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>'>
                                                                <asp:Label style = "text-align:left" id = "Book_Title_Jobber" runat = "server" width = "100%" 
                                                                    Text='<%# DataBinder.Eval(Container.DataItem,"Book_Title") %>'></asp:Label> 
                                                                </a>
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "20%" />
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "ISBN" SortExpression = "ISBN">
                                                            <ItemTemplate>
                                                                <asp:Label style = "text-align:center" id = "ISBN_Jobber" runat = "server" width = "100%" 
                                                                    Text='<%# DataBinder.Eval(Container.DataItem,"ISBN_13") %>'></asp:Label> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "15%"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Price (Baht)">
                                                            <ItemTemplate>
                                                                <asp:Label style = "text-align:right" id = "Price_Jobber" runat = "server" width = "100%" 
                                                                    Text='<%# DataBinder.Eval(Container.DataItem,"Selling_Price","{0:##,###.00}") %>'></asp:Label> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "10%"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Lead Time (Day)">
                                                            <ItemTemplate>
                                                                <asp:Label id = "Lead_Time_Jobber" runat = "server" 
                                                                    Text='<%# DataBinder.Eval(Container.DataItem,"Lead_Time") %>'></asp:Label> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "10%"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Weight (Kg)">
                                                            <ItemTemplate>
                                                                <asp:Label style = "text-align:right" id = "Weight_Jobber" runat = "server" width = "100%" 
                                                                    Text='<%# DataBinder.Eval(Container.DataItem,"Weight","{0:##,###.00}") %>'></asp:Label> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "10%"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Quantity">
                                                            <ItemTemplate>
                                                                <asp:TextBox onblur = "ValidInt();" style = "text-align:center" id = "Quantity_Jobber" runat = "server" 
                                                                    width = "30px" Text='<%# DataBinder.Eval(Container.DataItem,"Quantity") %>' __designer:wfdid = "w23" 
                                                                    OnTextChanged = "Quantity_Jobber_TextChanged" AutoPostBack = "True" MaxLength="3">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                </asp:TextBox> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "8%"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Amount &lt;br&gt; (Baht)">
                                                            <ItemTemplate>
                                                                <asp:Label style = "text-align:right" id = "Amount_Jobber" runat = "server" width = "100%" 
                                                                    Text='<%# DataBinder.Eval(Container.DataItem,"Amount","{0:##,###.00}") %>'></asp:Label>
                                                                    <br />
                                                                <asp:Label style = "text-align:right" id = "lbl_Amount_jobber_usd" runat = "server" width = "100%" 
                                                                    CssClass = "font_yellow_11_bold"></asp:Label> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "15%"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton style = "text-align:center" id = "b_del_Jobber" runat = "server" 
                                                                    ImageUrl = "~/images/bin.jpg" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ISBN_13") %>' 
                                                                    CommandName = "Delete">
                                                                </asp:ImageButton> 
                                                            </ItemTemplate>
                                                            <HeaderStyle width = "5%"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Stock" Visible = "False">
                                                            <ItemTemplate>
                                                                <asp:ImageButton id = "b_stock_Jobber" runat = "server" 
                                                                    ImageUrl = "~/images/star.jpg" CommandName = "Stock" 
                                                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem,"No") %>'>
                                                                </asp:ImageButton> 
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Ordstt" Visible = "False">
                                                            <ItemTemplate>
                                                                <asp:Label id = "ordstt_jobber" runat = "server" Text = "0"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "To_Org_AB_Code" Visible = "False">
                                                            <ItemTemplate>
                                                                <asp:Label id = "To_Org_AB_Code_jobber" runat = "server" Text='<%# "" %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText = "Status" Visible = "False">
                                                            <ItemTemplate>
                                                                <asp:Label id = "Status_jobber" runat = "server" 
                                                                    Text='<%# DataBinder.Eval(Container.DataItem,"Status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                <HeaderStyle Horizontalalign = "Center" Verticalalign = "Middle" BackColor = "#49A514" BorderStyle = "None" CssClass = "Grid_shoppingHeader" Font-Bold = "True" Font-Italic = "False" Font-Names = "arial" Font-Overline = "False" Font-Size = "11px" Font-Strikeout = "False" Font-Underline = "False" ForeColor = "White"></HeaderStyle>
                                                </Saifi:MyDg>
                                                <!--Data footer Available On Special Order (3)--> 
                                                <table style = "border-top-width:1px; border-right:1px solid; border-left:1px solid; width:100%; border-bottom:1px solid; border-style: solid; border-color: #008000;" 
                                                cellspacing = "0" cellpadding = "0" border = "1">
                                                    <tbody>
                                                        <tr>
                                                            <td align = "right" height = "30px">
                                                                <asp:Label style = "font-weight:bold; font-size:9pt; color:#ff6600; font-family:arial; text-align:left" 
                                                                id = "lbl_item_in_shopping3" runat = "server" width = "100%"></asp:Label> 
                                                                <asp:Label style = "text-align:right" id = "lbl_total_jobber" runat = "server" 
                                                                CssClass = "font_green_11" Text = "Label" width = "95%"></asp:Label>
                                                            </td>
                                                            <td class = "font_gray_11" align = "right" height = "30px" width = "15%">
                                                                <asp:Label style = "font-size:11px; color:#4e4e4e; font-family:arial; text-align:right" 
                                                                    id = "lbl_Amount_Jobber" runat = "server"> </asp:Label>
                                                                <br />
                                                                <asp:Label style = "text-align:right" id = "lbl_Amount_Jobber_usd" runat = "server" 
                                                                    CssClass = "font_yellow_11_bold"> </asp:Label>
                                                            </td>
                                                            <td height = "30px" width = "5%"></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style = "background-image:url(images/Asiabooks/ImagesTP_ec/BS_menuBooksSearch_Bg.jpg); width:100%; height:24px; text-align:left" class = "menuHeaderGreen">eBook</td>
                                        </tr>
                                        <tr>
                                            <td>
                                            <%--//////////////////promptnow////////////////////--%>
                                                <Saifi:MyDg id = "ebook_inCart" runat = "server" width = "100%" 
                                                    CssClass = "Grid_shopping" CellPadding = "0" ImageFirst = "images/b_firstpage.gif" 
                                                    ImageLast = "images/b_lastpage.gif" ImageNext = "images/b_nextpage.gif" 
                                                    ImagePrevious = "images/b_prevpage.gif" ShowFirstAndLastImage = "True" 
                                                    ShowPreviousAndNextImage = "True" AutoGenerateColumns = "False" 
                                                    PageSize="100">
                                                    <FooterStyle Horizontalalign = "Center" Font-Bold = "False" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></FooterStyle>
                                                    <EditItemStyle Horizontalalign = "Center" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></EditItemStyle>
                                                    <SelectedItemStyle Horizontalalign = "Center" BackColor = "#99CCFF" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></SelectedItemStyle>
                                                    <AlternatingItemStyle Horizontalalign = "Center" CssClass = "Grid_shoppingAltItem" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></AlternatingItemStyle>
                                                    <ItemStyle Horizontalalign = "Center" CssClass = "Grid_shoppingItem" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></ItemStyle>
                                                    <PagerStyle Mode = "NumericPages" PageButtonCount = "5" Visible = "False"></PagerStyle>
                                                        <Columns>
                                                            <asp:TemplateColumn HeaderText = "Item No" SortExpression = "No">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:center" id = "NO_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"No") %>' __designer:wfdid = "w22"></asp:Label> 
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "7%"></HeaderStyle>
                                                            </asp:TemplateColumn>
                                                            
                                                            <asp:TemplateColumn HeaderText = "Title" SortExpression = "Book_Title">
                                                                <ItemTemplate>
                                                                    <a class = "Grid_bookItem_A" href='ebook_detail.aspx?code=<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>&format=<%# DataBinder.Eval(Container, "DataItem.Format_Type") %>'>
                                                                    <asp:Label style = "text-align:left" id = "Book_Title_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Book_Title") %>'></asp:Label> 
                                                                    </a>
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "20%"></HeaderStyle>
                                                            </asp:TemplateColumn>
                                                            
                                                            <asp:TemplateColumn HeaderText = "ISBN" SortExpression = "ISBN">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:center" id = "ISBN_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"ISBN_13") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "15%"></HeaderStyle>
                                                            </asp:TemplateColumn>
                                                            
                                                            <asp:TemplateColumn HeaderText = "Price (Baht)">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:right" id = "Price_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Selling_Price","{0:##,###.00}") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "10%"></HeaderStyle>
                                                            </asp:TemplateColumn>
                                                            
                                                            <asp:TemplateColumn HeaderText = "Supplier Code" Visible = "False">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:right" id = "Supplier_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Supplier") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>

                                                            <asp:TemplateColumn HeaderText = "Exchange"  Visible = "False">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:right" id = "Exchange_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Exchange") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>

                                                            <asp:TemplateColumn HeaderText = "Exchange Internet"  Visible = "False">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:right" id = "Exchange_Internet_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Exchange_Internet") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>

                                                            <asp:TemplateColumn HeaderText = "eBook Format" >
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:center" id = "Format_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Format") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                            <HeaderStyle width = "10%"></HeaderStyle>
                                                            </asp:TemplateColumn>

                                                            <asp:TemplateColumn HeaderText = "Format Type" Visible = "False">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:center" id = "Format_Type_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Format_Type") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>

                                                            <asp:TemplateColumn HeaderText = "Country" Visible = "False">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:right" id = "Country_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Country") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>

                                                            <asp:TemplateColumn HeaderText = "Book_ID"  Visible = "False">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:right" id = "Book_ID_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Book_ID") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>

                                                            <asp:TemplateColumn HeaderText = "Discount"  Visible = "False">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:right" id = "Discount_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Discount") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>

                                                            <asp:TemplateColumn HeaderText = "Size (KB.)" >
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:right" id = "Size_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Size") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "10%"></HeaderStyle>
                                                            </asp:TemplateColumn>

                                                            <asp:TemplateColumn HeaderText = "Quantity">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="Quantity_ebook" runat="server" style = "text-align:center" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Quantity") %>' onblur = "ValidInt();"
                                                                        ontextchanged = "Quantity_ebook_TextChanged" AutoPostBack = "True" 
                                                                        Width="30" Height="20" MaxLength="3"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "8%"></HeaderStyle>
                                                            </asp:TemplateColumn>
                                                            
                                                            <asp:TemplateColumn HeaderText = "Amount &lt;br&gt; (Baht)">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:right" id = "Amount_ebook" runat = "server" width = "100%"
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Items_Amount","{0:##,###.00}") %>'></asp:Label>
                                                                    <asp:Label style = "text-align:right" id = "lbl_Amount_ebook_usd" runat = "server" 
                                                                        width = "100%" CssClass = "font_yellow_11_bold"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "15%"></HeaderStyle>
                                                            </asp:TemplateColumn>
                                                            
                                                            <asp:TemplateColumn HeaderText = "Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton style = "text-align:center" id = "b_ebook_delete" runat = "server" 
                                                                        ImageUrl = "~/images/bin.jpg" __designer:wfdid = "w22"
                                                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Book_id") %>' 
                                                                        CommandName = "Delete" ></asp:ImageButton> 
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "5%"></HeaderStyle>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                    <HeaderStyle Horizontalalign = "Center" Verticalalign = "Middle" BackColor = "#49A514" BorderStyle = "None" CssClass = "Grid_shoppingHeader" Font-Bold = "True" Font-Italic = "False" Font-Names = "arial" Font-Overline = "False" Font-Size = "11px" Font-Strikeout = "False" Font-Underline = "False" ForeColor = "White"></HeaderStyle>
                                                    </Saifi:MyDg>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table style = "border-top-width:1px; border-right:1px solid; border-left:1px solid; width:100%; border-bottom:1px solid; border-style: solid; border-color: #008000;" 
                                                cellspacing = "0" cellpadding = "0" border = "1">
                                                    <tbody>
                                                        <%  If lbltxt_promotion.Visible = True Or Label_ebook_inShopping.Visible = True Then%> 
                                                        <tr>
                                                            <td  align = "right" height = "30px">
                                                                <asp:Label ID = "Label_ebook_inShopping" runat = "server" 
                                                                    style = "font-weight:bold; font-size:9pt; color:#ff6600; font-family:arial; text-align:left" 
                                                                    width = "100%"></asp:Label>
                                                                <asp:Label ID = "lbltxt_promotion" runat = "server" 
                                                                    ForeColor = "#CC0000" Text = "Promotion Discount " Font-Bold = "True" style = "margin-right:3px"></asp:Label>
                                                            </td>
                                                            <td align = "right" style = "width:15%; height:15px;">
                                                                <asp:Label ID = "lbldiscount" runat = "server" ForeColor = "#CC0000" 
                                                                Font-Bold = "True"></asp:Label>
                                                            </td>
                                                            <td style = "width:5%; height:17px;"></td>
                                                        </tr>
                                                        <% End If%>
                                                        <%  If Label_ebook_inShopping.Visible = False Then %> 
                                                        <tr>
                                                            <td>
                                                                <asp:Label style = "text-align:right" id = "ebook_total" runat = "server" CssClass = "font_green_11" 
                                                                    width = "95%" Text = "Label" height = "15px"></asp:Label> 
                                                            </td>
                                                            <td style = "width:15%; text-align:right" class = "font_gray_11" align = "right">
                                                                <asp:Label style = "font-size:11px; color:#4e4e4e; font-family:arial; text-align:right" 
                                                                    id = "lb_ebook_amount" runat = "server"></asp:Label>
                                                                <br />
                                                                <asp:Label style = "text-align:right" id = "lb_ebook_usd" runat = "server" 
                                                                    CssClass = "font_yellow_11_bold"></asp:Label>   
                                                            </td>
                                                            <td style = "width:5%"></td>
                                                        </tr>
                                                        <% End If%>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <%If Me.DatagridPromotion.Items.Count > 0 Then%>
                                        <tr>
                                            <td style = "background-image:url(images/Asiabooks/ImagesTP_ec/BS_menuBooksSearch_Bg.jpg); width:100%; height:24px; text-align:left" class = "menuHeaderGreen">Free-eBook Promotion</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <Saifi:MyDg id = "DatagridPromotion" runat = "server" width = "100%" 
                                                    CssClass = "Grid_shopping" CellPadding = "0" ImageFirst = "images/b_firstpage.gif" 
                                                    ImageLast = "images/b_lastpage.gif" ImageNext = "images/b_nextpage.gif" 
                                                    ImagePrevious = "images/b_prevpage.gif" ShowFirstAndLastImage = "True" 
                                                    ShowPreviousAndNextImage = "True" AutoGenerateColumns = "False">
                                                    <FooterStyle Horizontalalign = "Center" Font-Bold = "False" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></FooterStyle>
                                                    <EditItemStyle Horizontalalign = "Center" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></EditItemStyle>
                                                    <SelectedItemStyle Horizontalalign = "Center" BackColor = "#99CCFF" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></SelectedItemStyle>
                                                    <AlternatingItemStyle Horizontalalign = "Center" CssClass = "Grid_shoppingAltItem" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></AlternatingItemStyle>
                                                    <ItemStyle Horizontalalign = "Center" CssClass = "Grid_shoppingItem" Font-Bold = "True" Font-Italic = "False" Font-Overline = "False" Font-Strikeout = "False" Font-Underline = "False"></ItemStyle>
                                                    <PagerStyle Mode = "NumericPages" PageButtonCount = "5" Visible = "False"></PagerStyle>
                                                        <Columns>
                                                            <asp:TemplateColumn HeaderText = "Item No" SortExpression = "No">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:center" id = "NO_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"No") %>' __designer:wfdid = "w22"></asp:Label> 
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "7%"></HeaderStyle>
                                                            </asp:TemplateColumn>
                                                            
                                                            <asp:TemplateColumn HeaderText = "Title" SortExpression = "Book_Title">
                                                                <ItemTemplate>
                                                                    <a class = "Grid_bookItem_A" href='ebook_detail.aspx?code=<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>&format=<%# DataBinder.Eval(Container, "DataItem.Format_Type") %>'>
                                                                    <asp:Label style = "text-align:left" id = "Book_Title_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Book_Title") %>'></asp:Label> 
                                                                    </a>
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "20%"></HeaderStyle>
                                                            </asp:TemplateColumn>
                                                            
                                                            <asp:TemplateColumn HeaderText = "ISBN" SortExpression = "ISBN">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:center" id = "ISBN_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"ISBN_13") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "15%"></HeaderStyle>
                                                            </asp:TemplateColumn>
                                                            
                                                            <asp:TemplateColumn HeaderText = "Price (Baht)">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:center" id = "Price_ebook" runat = "server" width = "100%" 
                                                                        Text="Free"></asp:Label> 
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "10%"></HeaderStyle>
                                                            </asp:TemplateColumn>

                                                            <asp:TemplateColumn HeaderText = "eBook Format" >
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:center" id = "Format_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Format") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                            <HeaderStyle width = "10%"></HeaderStyle>
                                                            </asp:TemplateColumn>

                                                            <asp:TemplateColumn HeaderText = "Book_ID"  Visible = "False">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:right" id = "Book_ID_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Book_ID") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>

                                                            <asp:TemplateColumn HeaderText = "Size (KB.)" >
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:right" id = "Size_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Size") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "10%"></HeaderStyle>
                                                            </asp:TemplateColumn>

                                                            <asp:TemplateColumn HeaderText = "Quantity">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:center" id = "Quantity_ebook" runat = "server" width = "100%" 
                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"Quantity") %>'></asp:Label> 
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "8%"></HeaderStyle>
                                                            </asp:TemplateColumn>
                                                            
                                                            <asp:TemplateColumn HeaderText = "Amount &lt;br&gt; (Baht)">
                                                                <ItemTemplate>
                                                                    <asp:Label style = "text-align:center" id = "Amount_ebook" runat = "server" width = "100%"
                                                                        Text="Free"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "15%"></HeaderStyle>
                                                            </asp:TemplateColumn>
                                                            
                                                            <asp:TemplateColumn HeaderText = "Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton style = "text-align:center" id = "b_ebook_free_delete" runat = "server" 
                                                                        ImageUrl = "~/images/bin.jpg" __designer:wfdid = "w22"
                                                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Book_id") %>' 
                                                                        CommandName = "Delete" ></asp:ImageButton> 
                                                                </ItemTemplate>
                                                                <HeaderStyle width = "5%"></HeaderStyle>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                    <HeaderStyle Horizontalalign = "Center" Verticalalign = "Middle" BackColor = "#49A514" BorderStyle = "None" CssClass = "Grid_shoppingHeader" Font-Bold = "True" Font-Italic = "False" Font-Names = "arial" Font-Overline = "False" Font-Size = "11px" Font-Strikeout = "False" Font-Underline = "False" ForeColor = "White"></HeaderStyle>
                                                    </Saifi:MyDg>
                                            </td>
                                        </tr>
                                        <%End If%>
                                    </tbody>
                                </table>
                            <asp:Panel ID = "paneltotal_all" runat = "server">
                                <br />
                                <br />
                                <p class = "menuHeaderGreen">Total</p>
                                <table style = "border-right: 1px solid; border-left: 1px solid; width: 100%; border-bottom: 1px solid; border: 1px solid #047700;" 
                                    cellspacing = "0" cellpadding = "0" border = "1">
                                    <tr>
                                        <td align = "right" 
                                            style = "border: 1px solid #008000; height:32px; width: 588px;">
                                            <asp:Label ID = "lbltxttotal" runat = "server" style = "font-size:14px; color:#4e4e4e; 
                                                font-family:arial; text-align:right; font-weight:bold; margin-right:5px; 
                                                color:#55880F;" Text = "Total Payment consolidation" ></asp:Label>
                                        </td>
                                        <td style = "border: 1px solid #008000; width:140px; height:32px;" 
                                            align = "right">
                                            <asp:Label ID = "lblfinaltotal" runat = "server" style = "font-size:14px; 
                                                color:#4e4e4e; font-family:arial; text-align:right; 
                                                font-weight:bold" Text = ""></asp:Label>
                                            <br />
                                            <asp:Label ID = "lblus_all" runat = "server" CssClass = "font_yellow_11_bold" 
                                                style = "text-align:right"></asp:Label>
                                        </td>
                                    </tr> 
                                </table>
                                <br />
                            </asp:Panel>
                            <asp:UpdateProgress id = "UpdateProgress1" runat = "server"><ProgressTemplate>
                            <asp:Image id = "Image1" runat = "server" ImageUrl = "~/images/loading.gif"></asp:Image><br />Loading..</ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td style = "width:100%; height:15px; text-align:left" class = "textRed">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; *** The pricing and stock availability is valid for 1 day.</td>
                    </tr>
                    <tr>
                        <td style = "width:100%; height:15px; text-align:left"></td>
                    </tr>
                    <tr>
                        <td style = "width:100%; height:26px; text-align:left" valign = "middle">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                        <table cellpadding = "0" cellspacing = "0" border = "0" width = "100%">
                            <tr>
                                <td align = "right" width = "60%">
                                    <asp:ImageButton ID = "b_clear_cart" runat = "server" 
                                        ImageUrl = "~/images/Template/Button/clear_cart.gif" />
                                    <asp:ImageButton ID = "btn_recalculate" runat = "server" 
                                        ImageUrl = "~/images/Template/Button/recalculate.gif" />
                                    <asp:ImageButton ID = "btn_proceed" runat = "server" 
                                        ImageUrl = "~/images/Template/Button/proceed_payment_02.gif" 
                                        onclick = "btn_proceed_Click" />
                                </td>
                                <td align = "left" width = "40%">
                                    <asp:Image ID = "img_click_cart" runat = "server" 
                                        ImageUrl = "~/images/Template/icon_arrow_shopping.gif" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    </tr>
                </tbody>
            </table>
        </contenttemplate>
    </asp:UpdatePanel>
    <%--<asp:ModalPopupExtender ID="ModalPopupPromotion" 
        TargetControlID="LinkButton" PopupControlID="panel_promotion"
        runat="server" BackgroundCssClass="ModelBackground" >
    </asp:ModalPopupExtender>
    <asp:Panel ID="panel_promotion" runat="server" ScrollBars="Vertical" Width="750px" Height="500px" style="display:none">
        <table border="0" align="center" cellpadding="0" cellspacing="0" style="background-color:White">
            <tr>
                <td><img src="images/ebook/corner_left_top_03.gif" width="15px" height="15px" /></td>
                <td width="740px" background="images/ebook/top_04.gif"></td>
                <td><img src="images/ebook/corner_right_top_05.gif" width="15px" height="15px" /></td>
            </tr>
            <tr>
                <td background="images/ebook/left_07.gif"></td>
                <td align="left" valign="top" >
                    <asp:Label ID="lblhead" 
                        runat="server" CssClass="grdBestseller_detail" Font-Bold="True" 
                        Font-Size="Small" >PROMOTION : YOU HAVE </asp:Label>&nbsp;
                    <asp:Label ID="lblcredits" runat="server" CssClass="grdBestseller_detail" 
                        Font-Bold="True" Font-Size="Small" ForeColor="Maroon" Text="CREDITS"></asp:Label>&nbsp;
                    <asp:Label ID="Label16" runat="server" CssClass="grdBestseller_head" Font-Bold="True" 
                        Font-Size="Small" Text="CREDIT(S)"></asp:Label>         
                </td>
                <td background="images/ebook/right_09.gif"></td>
            </tr>
            <tr>
                <td background="images/ebook/left_07.gif"></td>
                <td align="right">
                     <asp:ImageButton ID="btn_cancel" runat="server" ImageUrl="~/images/ebook/Button/cancel.jpg" style="margin-right:40px" />
                </td>
                <td background="images/ebook/right_09.gif"></td>
            </tr>
            <tr>
                <td background="images/ebook/left_07.gif"></td>
                <td align="center">
                <Saifi:MyDg ID="Datagrid" runat="server" AutoGenerateColumns="False"
                    BorderColor="White" CssClass="Grid_book" GridLines="None" HeaderStyle-BackColor="#aaaadd"
                    HeaderStyle-CssClass="tableHeader" ImageFirst="images/b_firstpage.gif" ImageLast="images/b_lastpage.gif"
                    ImageNext="images/b_nextpage.gif" ImagePrevious="images/b_prevpage.gif" 
                    ItemStyle-CssClass="tableItem" SelectedItemStyle-BackColor="#99ccff" ShowFirstAndLastImage="False"
                    ShowPreviousAndNextImage="False" UseAccessibleHeader="True"
                        style="margin-right: 0px" PageSize="1000">
                    <Columns>
                        <asp:TemplateColumn>
                            <itemtemplate>
                            <br />
                            <table border="0" cellpadding="0" cellspacing="0" style="width:105px;">
                                <tr>
                                    <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                                    <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                                    <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                                </tr>
                                <tr>
                                    <td align="left" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                    <td align="center" valign="middle">
                                        <asp:Image  id="Book_Image" runat="server" ImageUrl='<%# Eval("image") %>' 
                                        Width="85px"  Height="126px" title='<%# Eval("synopsis_full") %>' AlternateText='<%# Eval("synopsis_full") %>'></asp:Image></td>
                                    <td align="left" style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                    <td align="left" valign="top" style="background-image:url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                                    <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                                </tr>
                            </table>
                            &nbsp;<asp:Label ID="lblBook_Image" runat="server" Text='<%# Eval("image") %>' Visible="False"></asp:Label>
                            <br /><br />
                            </itemtemplate>
                        <headerstyle width="10%" />
                        <itemstyle font-bold="False" font-italic="False" font-overline="False" font-strikeout="False"
                            font-underline="False" horizontalalign="left" verticalalign="Top" width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <itemtemplate>
                            </itemtemplate>
                            <headerstyle width="5%" />
                            <itemstyle font-bold="False" font-italic="False" font-overline="False" font-strikeout="False"
                                font-underline="False" horizontalalign="left" verticalalign="Top" width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <itemtemplate>
                            <br />
                            <asp:Label id="lblBook_Title" runat="server" CssClass="grdBestseller_title" Font-Bold="True" 
                                __designer:dtid="2814749767106603" __designer:wfdid="w364" Text='<%# Eval("title") %>'></asp:Label>
                            <br /><br /><asp:Label id="Label2" runat="server" CssClass="grdBestseller_head" Font-Bold="True" 
                                __designer:dtid="2814749767106606" __designer:wfdid="w365" Text="ISBN : "></asp:Label><asp:Label id="Label12" 
                                runat="server" CssClass="grdBestseller_detail" __designer:dtid="2814749767106607" __designer:wfdid="w366" 
                                Text='<%# Eval("ISBN_13") %>'></asp:Label><br /><asp:Label id="Label1" 
                                runat="server" CssClass="grdBestseller_head" Font-Bold="True" __designer:dtid="2814749767106609" 
                                __designer:wfdid="w367" Text="Author : "></asp:Label><asp:Label id="lblauthor" runat="server" 
                                CssClass="grdBestseller_detail" __designer:dtid="2814749767106610" __designer:wfdid="w368" 
                                Text='<%# Eval("author") %>'></asp:Label><br /><asp:Label id="Label3" runat="server" 
                                CssClass="grdBestseller_head" Font-Bold="True" __designer:dtid="2814749767106612" __designer:wfdid="w369" 
                                Text="Publisher : "></asp:Label><asp:Label id="Label13" runat="server" CssClass="grdBestseller_detail" 
                                __designer:dtid="2814749767106613" __designer:wfdid="w370" 
                                Text='<%# Eval("publisher") %>'></asp:Label><br />
                                <asp:Label ID="Label14" runat="server" __designer:dtid="2814749767106612" 
                                    __designer:wfdid="w369" CssClass="grdBestseller_head" Font-Bold="True" 
                                    Text="Format : "></asp:Label>
                                <asp:Label ID="Label15" runat="server" __designer:dtid="2814749767106613" 
                                    __designer:wfdid="w370" CssClass="grdBestseller_detail"  ForeColor="Red"
                                    Text='<%# Eval("format") %>'></asp:Label><br />
                                <asp:Label ID="Label4" runat="server" __designer:dtid="2814749767106612" 
                                    __designer:wfdid="w369" CssClass="grdBestseller_head" Font-Bold="True" 
                                    Text="Synopsis : "></asp:Label>
                                <br/>    
                                <asp:Label ID="Label6" runat="server" __designer:dtid="2814749767106613" 
                                    __designer:wfdid="w370" CssClass="grdBestseller_detail" 
                                    Text='<%# Eval("synopsis") %>'></asp:Label>
                                <br />
                            </itemtemplate>
                            <headerstyle width="55%" />
                            <itemstyle font-bold="False" font-italic="False" font-overline="False" font-strikeout="False"
                                font-underline="False" horizontalalign="Left" verticalalign="Top" width="55%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <itemtemplate>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 138px; height: 100px;">
                            <tbody>
                                <tr>
                                    <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                                    <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                                    <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                                </tr>
                                <tr>
                                    <td align="left" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                    <td align="left" valign="top" style="width:100px;">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 119px; height: 119px">
                                        <tr>
                                            <td align="center" style="width: 119px; height:25px" valign="middle">
                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                    Font-Size="9pt" ForeColor="#006600" Text="Quantity" />
                                                <br />
                                                <asp:TextBox ID="txt_qty" runat="server" Width="70px" Text="1" 
                                                    style="text-align: center" MaxLength="3"></asp:TextBox>
                                                <br />
                                                <br />
                                                <asp:Button ID="btn_add" runat="server" Text="Get Free" 
                                                    onclick="btn_add_Click"/>
                                            </td>
                                        </tr>
                                        </table>
                                    </td>
                                    <td align="left" style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                    <td align="left" valign="top" style="background-image:url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                                    <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                                </tr>
                            </tbody>
                            </table>
                            </itemtemplate>
                            <headerstyle width="15%" />
                            <itemstyle font-bold="False" font-italic="False" font-overline="False" font-strikeout="False"
                                font-underline="False" horizontalalign="right" verticalalign="Top" width="15%" />
                        </asp:TemplateColumn>
                    </Columns>
                    <ItemStyle CssClass="Grid_bookItem" />
                    <HeaderStyle BackColor="White" CssClass="Grid_bookHeader" />
                    <SelectedItemStyle BackColor="#99CCFF" />
                    <PagerStyle CssClass="Grid_bookPager" Mode="NumericPages"
                        PageButtonCount="5" Position="TopAndBottom" Visible="False" />
                </Saifi:MyDg>
                </td>
                <td background="images/ebook/right_09.gif"></td>
            </tr>
            <tr>
                <td background="images/ebook/left_07.gif"></td>
                <td align="right">
                    <asp:ImageButton ID="btn_next" runat="server" ImageUrl="~/images/ebook/Button/cancel.jpg" style="margin-right:40px" />
                </td>
                <td background="images/ebook/right_09.gif"></td>
            </tr>
            <tr>
                <td><img src="images/ebook/corner_left_bottom_10.gif" width="15" height="15" /></td>
                <td background="images/ebook/bottom_11.gif"></td>
                <td><img src="images/ebook/corner_right_bottom_12.gif" width="15" height="15" /></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupPromotionMsg1" 
        TargetControlID="LinkButton1" PopupControlID="panel_promotionMsg1"
        runat="server" BackgroundCssClass="ModelBackground" >
    </asp:ModalPopupExtender>
    <asp:Panel ID="panel_promotionMsg1" runat="server" style="display:none">
        <div>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="background-color:White">
              <tr>
                <td><img src="images/ebook/corner_left_top_03.gif" width="15" height="15" /></td>
                <td width="420" background="images/ebook/top_04.gif"></td>
                <td><img src="images/ebook/corner_right_top_05.gif" width="15" height="15" /></td>
              </tr>
              <tr>
                <td width="15" height="120" background="images/ebook/left_07.gif"></td>
                <td><asp:Label ID="lblMsg1" runat="server" Text="Promotion" Width="100%" style="margin-left:20px;margin-right:20px"></asp:Label></td>
                <td background="images/ebook/right_09.gif"></td>
              </tr>
              <tr>
                <td width="15" height="40" background="images/ebook/left_07.gif"></td>
                <td align="center"><asp:ImageButton ID="btn_closeMsg1" runat="server" ImageUrl="~/images/ebook/Button/b_ok.jpg" /></td>
                <td background="images/ebook/right_09.gif"></td>
              </tr>
              <tr>
                <td><img src="images/ebook/corner_left_bottom_10.gif" width="15" height="15" /></td>
                <td background="images/ebook/bottom_11.gif"></td>
                <td><img src="images/ebook/corner_right_bottom_12.gif" width="15" height="15" /></td>
              </tr>
            </table>            
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupPromotionMsg2" 
        TargetControlID="LinkButton2" PopupControlID="panel_promotionMsg2"
        runat="server" BackgroundCssClass="ModelBackground" >
    </asp:ModalPopupExtender>
    <asp:Panel ID="panel_promotionMsg2" runat="server" style="display:none">
        <div>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="background-color:White">
              <tr>
                <td><img src="images/ebook/corner_left_top_03.gif" width="15" height="15" /></td>
                <td width="420" background="images/ebook/top_04.gif"></td>
                <td><img src="images/ebook/corner_right_top_05.gif" width="15" height="15" /></td>
              </tr>
              <tr>
                <td width="15" height="120" background="images/ebook/left_07.gif"></td>
                <td><asp:Label ID="lblMsg2" runat="server" Text="Promotion" Width="100%" style="margin-left:20px;margin-right:20px"></asp:Label></td>
                <td background="images/ebook/right_09.gif"></td>
              </tr>
              <tr>
                <td width="15" height="40" background="images/ebook/left_07.gif"></td>
                <td align="center"><asp:ImageButton ID="btn_closeMsg2" runat="server" ImageUrl="~/images/ebook/Button/b_ok.jpg" /></td>
                <td background="images/ebook/right_09.gif"></td>
              </tr>
              <tr>
                <td><img src="images/ebook/corner_left_bottom_10.gif" width="15" height="15" /></td>
                <td background="images/ebook/bottom_11.gif"></td>
                <td><img src="images/ebook/corner_right_bottom_12.gif" width="15" height="15" /></td>
              </tr>
            </table>            
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupPromotionMsg3" 
        TargetControlID="LinkButton3" PopupControlID="panel_promotionMsg3"
        runat="server" BackgroundCssClass="ModelBackground" >
    </asp:ModalPopupExtender>
    <asp:Panel ID="panel_promotionMsg3" runat="server" style="display:none">
        <div>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="background-color:White">
              <tr>
                <td><img src="images/ebook/corner_left_top_03.gif" width="15" height="15" /></td>
                <td width="420" background="images/ebook/top_04.gif"></td>
                <td><img src="images/ebook/corner_right_top_05.gif" width="15" height="15" /></td>
              </tr>
              <tr>
                <td width="15" height="120" background="images/ebook/left_07.gif"></td>
                <td><asp:Label ID="lblMsg3" runat="server" Text="Promotion" Width="100%" style="margin-left:20px;margin-right:20px"></asp:Label></td>
                <td background="images/ebook/right_09.gif"></td>
              </tr>
              <tr>
                <td width="15" height="40" background="images/ebook/left_07.gif"></td>
                <td align="center"><asp:ImageButton ID="btn_closeMsg3" runat="server" ImageUrl="~/images/ebook/Button/b_ok.jpg" /></td>
                <td background="images/ebook/right_09.gif"></td>
              </tr>
              <tr>
                <td><img src="images/ebook/corner_left_bottom_10.gif" width="15" height="15" /></td>
                <td background="images/ebook/bottom_11.gif"></td>
                <td><img src="images/ebook/corner_right_bottom_12.gif" width="15" height="15" /></td>
              </tr>
            </table>            
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupPromotionThankyouMsg" 
        TargetControlID="LinkButton4" PopupControlID="panel_promotionThankyouMsg"
        runat="server" BackgroundCssClass="ModelBackground" >
    </asp:ModalPopupExtender>
    <asp:Panel ID="panel_promotionThankyouMsg" runat="server" style="display:none">
        <div>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="background-color:White">
              <tr>
                <td><img src="images/ebook/corner_left_top_03.gif" width="15" height="15" /></td>
                <td width="420" background="images/ebook/top_04.gif"></td>
                <td><img src="images/ebook/corner_right_top_05.gif" width="15" height="15" /></td>
              </tr>
              <tr>
                <td width="15" height="120" background="images/ebook/left_07.gif"></td>
                <td align="center" style="font-weight:bold">Thank you. Your free ebook(s) are already in your cart !!</td>
                <td background="images/ebook/right_09.gif"></td>
              </tr>
              <tr>
                <td width="15" height="40" background="images/ebook/left_07.gif"></td>
                <td align="center"><asp:ImageButton ID="btn_alertThankClose" runat="server" ImageUrl="~/images/ebook/Button/b_ok.jpg" /></td>
                <td background="images/ebook/right_09.gif"></td>
              </tr>
              <tr>
                <td><img src="images/ebook/corner_left_bottom_10.gif" width="15" height="15" /></td>
                <td background="images/ebook/bottom_11.gif"></td>
                <td><img src="images/ebook/corner_right_bottom_12.gif" width="15" height="15" /></td>
              </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupPromotionGetmoreMsg" 
        TargetControlID="LinkButton5" PopupControlID="panel_promotionGetmoreMsg"
        runat="server" BackgroundCssClass="ModelBackground" >
    </asp:ModalPopupExtender>
    <asp:Panel ID="panel_promotionGetmoreMsg" runat="server" style="display:none">
        <div >
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="background-color:White">
              <tr>
                <td><img src="images/ebook/corner_left_top_03.gif" width="15" height="15" /></td>
                <td width="420" background="images/ebook/top_04.gif"></td>
                <td><img src="images/ebook/corner_right_top_05.gif" width="15" height="15" /></td>
              </tr>
              <tr>
                <td width="15" height="120" background="images/ebook/left_07.gif"></td>
                <td align="center" style="font-weight:bold">You get free ebook(s) but you still have credits to get more !!</td>
                <td background="images/ebook/right_09.gif"></td>
              </tr>
              <tr>
                <td width="15" height="40" background="images/ebook/left_07.gif"></td>
                <td align="center"><asp:ImageButton ID="btn_alertMoreClose" runat="server" ImageUrl="~/images/ebook/Button/b_ok.jpg" /></td>
                <td background="images/ebook/right_09.gif"></td>
              </tr>
              <tr>
                <td><img src="images/ebook/corner_left_bottom_10.gif" width="15" height="15" /></td>
                <td background="images/ebook/bottom_11.gif"></td>
                <td><img src="images/ebook/corner_right_bottom_12.gif" width="15" height="15" /></td>
              </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:LinkButton ID="LinkButton" runat="server" style="display:none">LinkButton</asp:LinkButton>
    <asp:LinkButton ID="LinkButton1" runat="server" style="display:none">LinkButton</asp:LinkButton>
    <asp:LinkButton ID="LinkButton2" runat="server" style="display:none">LinkButton</asp:LinkButton>
    <asp:LinkButton ID="LinkButton3" runat="server" style="display:none">LinkButton</asp:LinkButton>
    <asp:LinkButton ID="LinkButton4" runat="server" style="display:none">LinkButton</asp:LinkButton>
    <asp:LinkButton ID="LinkButton5" runat="server" style="display:none">LinkButton</asp:LinkButton>--%>
</asp:Content>
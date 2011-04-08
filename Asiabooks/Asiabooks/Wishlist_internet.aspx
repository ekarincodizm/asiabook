<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Wishlist_internet.aspx.vb" Inherits="Wishlist_internet" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="MycustomDG" Namespace="MycustomDG" TagPrefix="Saifi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: left">
        <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" style="WIDTH: 100%" class="header_other"></td>
            </tr>    
            <tr>
                <td align="left" style="WIDTH: 100%" class="header_other">Wish List</td>
            </tr>
            <tr>
                <td align="left" style="WIDTH: 100%" class="font_other">
                    <asp:Label ID="lblStatus_Header" runat="server" 
                        Text="There are currently no items in your Wish List."></asp:Label>
                    <br /><br />
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 100%; height: 51px; text-align: left">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="right" colspan="4">
                                <asp:ImageButton ID="b_continue" runat="server" 
                                    ImageUrl="~/images/Template/Button/continue_shopping.gif" />
                            </td>
                        </tr>

                        <%--//////////////////promptnow////////////////////--%>
                        <tr >
                            <td align="right" colspan="4"></td>
                        </tr>
                        <%--////////////////promptnow end//////////////////--%>

                        <tr>
                            <td colspan="2" width="50%" align="left" >
                                <asp:Label ID="Label_Result" runat="server" Font-Bold="False" Font-Names="Verdana"
                                    Font-Size="11px" Style="color: black"></asp:Label>
                            </td>
                            <td colspan="2" width="50%" align="right">        
                                <asp:ImageButton ID="btn_del_all" runat="server" 
                                    ImageUrl="~/images/ebook/Button/delete_list.gif" />
                                <asp:ImageButton ID="btn_add_all" runat="server" 
                                    ImageUrl="~/images/ebook/Button/add_list.gif" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#006600" Text="Book list item(s)"></asp:Label>
                    <br />
                    <br />
                    <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <Saifi:MyDg id="Datagrid_book" runat="server" Width="100%" CssClass="Grid_inq" AutoGenerateColumns="False" 
                                HeaderStyle-CssClass="Grid_inqHeader" ImageFirst="" ImageLast="" ImageNext="" ImagePrevious="" 
                                ItemStyle-CssClass="Grid_inqItem" ShowFirstAndLastImage="False" ShowPreviousAndNextImage="False" 
                                AlternatingItemStyle-CssClass="Grid_inqAltItem" SelectedItemStyle-CssClass="Grid_inqAltItem"
                                GridLines="None" ShowFooter="False" AllowPaging="False">
                            <SelectedItemStyle CssClass="Grid_inqAltItem"></SelectedItemStyle>
                            <AlternatingItemStyle CssClass="Grid_inqAltItem"></AlternatingItemStyle>
                            <ItemStyle CssClass="Grid_inqItem"></ItemStyle>
                            <PagerStyle Mode="NumericPages" PageButtonCount="5" Font-Bold="False" 
                                Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                Font-Underline="False" NextPageText="" PrevPageText="" Visible="False">
                            </PagerStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="">
                                        <ItemTemplate>
                                            <asp:Panel ID="panel_cbx" runat="server" align="center" >
                                                <asp:CheckBox ID="cbx" runat="server" ForeColor="White" />
                                            </asp:Panel> 
                                        </ItemTemplate>
                                        <HeaderStyle Width="7%"></HeaderStyle>
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="Picture">
                                        <ItemTemplate>
                                            <a class="Grid_bookItem_A" href='book_detail_internet.aspx?Title_1=<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>'>
                                            <asp:Image id="img_Image" runat="server" Width="100px" Height="140px" ImageAlign="Middle"
                                                ImageUrl='<%# ConfigurationSettings.AppSettings("PicPath") & DataBinder.Eval(Container, "DataItem.image") %>'
                                                AlternateText='<%# DataBinder.Eval(Container, "DataItem.Synopsis") %>' title='<%# DataBinder.Eval(Container, "DataItem.Synopsis") %>'>
                                            </asp:Image>
                                            </a>
                                        </ItemTemplate>
                                        <HeaderStyle Width="15%"></HeaderStyle>
                                    </asp:TemplateColumn>
                                    
                                    <asp:TemplateColumn HeaderText="pic name" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label id="lbl_image" runat="server" Width="150px" Font-Size="11px" Font-Names="Verdana" Text='<%# DataBinder.Eval(Container.DataItem,"Image") %>' ForeColor="#4E4E4E"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    
                                    <asp:TemplateColumn HeaderText="Title">
                                        <ItemTemplate>
                                            <a class="Grid_bookItem_A" href='book_detail_internet.aspx?Title_1=<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>'>
                                            <asp:Label style="vertical-align:middle; TEXT-ALIGN: left" id="lbl_Book_Title" runat="server" 
                                                Width="100%" Font-Bold="True" Text='<%# DataBinder.Eval(Container, "DataItem.book_title") %>'>
                                            </asp:Label>
                                            </a>
                                        </ItemTemplate>
                                        <HeaderStyle Width="30%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateColumn>
                                    
                                    <asp:TemplateColumn HeaderText="ISBN">
                                        <ItemTemplate>
                                            <asp:Label style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="lbl_ISBN_13" runat="server" 
                                                Width="100%" Font-Size="11px" Font-Names="Verdana" Text='<%# DataBinder.Eval(Container.DataItem,"ISBN_13") %>' ForeColor="#4E4E4E">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="13%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="Author">
                                        <ItemTemplate>
                                            <asp:Label style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" id="lbl_Author" runat="server" 
                                                Width="100%" Font-Size="11px" Font-Names="Verdana" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Author") %>'>
                                            </asp:Label> 
                                        </ItemTemplate>
                                        <HeaderStyle Width="15%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="Item Disc Group" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lbl_item_disc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Item_Dis_Group") %>'></asp:Label> 
                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="Status" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lbl_status" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Status") %>'></asp:Label> 
                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="Status" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lbl_source" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Source") %>'></asp:Label> 
                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="Price &lt;br&gt; (Baht)">
                                        <ItemTemplate>
                                            <asp:Label style="VERTICAL-ALIGN: middle;TEXT-ALIGN: right" id="lbl_Selling_Price" runat="server" 
                                                Width="100%" Font-Size="11px" Font-Names="Verdana" ForeColor="#4E4E4E" Text='<%# DataBinder.Eval(Container.DataItem,"Selling_Price","{0:#,###}") %>'>
                                            </asp:Label> 
                                        </ItemTemplate>
                                        <HeaderStyle Width="15%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="Add To Cart">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btn_buy_book" runat="server" 
                                                ImageUrl="~/images/Template/add_to_cart.jpg"  
                                                OnClick="btn_buy_book_Click"/>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton style="TEXT-ALIGN: center" id="b_del" runat="server" ImageUrl="~/images/bin.jpg" 
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ISBN_13") %>' CommandName="Delete">
                                            </asp:ImageButton> 
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Width="7%"></HeaderStyle>
                                        <ItemStyle Font-Underline="False" VerticalAlign="Middle"></ItemStyle>
                                    </asp:TemplateColumn>
                                </Columns>
                            <HeaderStyle CssClass="Grid_inqHeader"></HeaderStyle>
                            </Saifi:MyDg> 
                        </contenttemplate>
                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="Datagrid_book" EventName="DeleteCommand"></asp:AsyncPostBackTrigger>
                    </triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
            ForeColor="#006600" Text="eBook list item(s)"></asp:Label>
        <br />
        <br />
        <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <contenttemplate>
                <Saifi:MyDg id="Datagrid_ebook" runat="server" Width="100%" CssClass="Grid_inq" AutoGenerateColumns="False" 
                    HeaderStyle-CssClass="Grid_inqHeader" ImageFirst="" ImageLast="" ImageNext="" ImagePrevious="" 
                    ItemStyle-CssClass="Grid_inqItem" ShowFirstAndLastImage="False" ShowPreviousAndNextImage="False" 
                    AlternatingItemStyle-CssClass="Grid_inqAltItem" SelectedItemStyle-CssClass="Grid_inqAltItem"
                    GridLines="None" ShowFooter="False" AllowPaging="False">
                <SelectedItemStyle CssClass="Grid_inqAltItem"></SelectedItemStyle>
                <AlternatingItemStyle CssClass="Grid_inqAltItem"></AlternatingItemStyle>
                <ItemStyle CssClass="Grid_inqItem"></ItemStyle>
                <PagerStyle Mode="NumericPages" PageButtonCount="5" Font-Bold="False" 
                    Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                    Font-Underline="False" NextPageText="" PrevPageText="" Visible="False">
                </PagerStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="">
                            <ItemTemplate>
                                <asp:Panel ID="panel_cbx" runat="server" align="center" >
                                    <asp:CheckBox ID="cbx" runat="server" />
                                </asp:Panel> 
                            </ItemTemplate>
                            <HeaderStyle Width="5%"></HeaderStyle>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="Picture">
                            <ItemTemplate>
                                <a class="Grid_bookItem_A" href='ebook_detail.aspx?code=<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>&format=<%# DataBinder.Eval(Container, "DataItem.Format_Num") %>'>
                                <asp:Image id="img_Image" runat="server" Width="100px" Height="140px" AlternateText='<%# DataBinder.Eval(Container, "DataItem.Synopsis") %>' title='<%# DataBinder.Eval(Container, "DataItem.Synopsis") %>'></asp:Image>
                                </a>
                            </ItemTemplate>
                            <HeaderStyle Width="15%"></HeaderStyle>
                        </asp:TemplateColumn>
                        
                        <asp:TemplateColumn HeaderText="pic name" Visible="False">
                            <ItemTemplate>
                                <asp:Label id="lbl_image" runat="server" Width="150px" Font-Size="11px" Font-Names="Verdana" 
                                    Text='<%# DataBinder.Eval(Container.DataItem,"Image") %>' ForeColor="#4E4E4E">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        
                        <asp:TemplateColumn HeaderText="Title">
                            <ItemTemplate>
                                <a class="Grid_bookItem_A" href='ebook_detail.aspx?code=<%# DataBinder.Eval(Container, "DataItem.ISBN_13") %>&format=<%# DataBinder.Eval(Container, "DataItem.Format_Num") %>'>
                                <asp:Label style="VERTICAL-ALIGN:middle; TEXT-ALIGN: left" id="lbl_Book_Title" 
                                    runat="server" Width="100%" Font-Bold="True" 
                                    Text='<%# DataBinder.Eval(Container, "DataItem.book_title") %>'>
                                </asp:Label>
                                </a>
                            </ItemTemplate>
                            <HeaderStyle Width="30%"></HeaderStyle>
                        </asp:TemplateColumn>
                        
                        <asp:TemplateColumn HeaderText="ISBN">
                            <ItemTemplate>
                                <asp:Label style="VERTICAL-ALIGN: middle; TEXT-ALIGN: left" id="lbl_ISBN_13" 
                                    runat="server" Width="100%" Font-Size="11px" Font-Names="Verdana" 
                                    Text='<%# DataBinder.Eval(Container.DataItem,"ISBN_13") %>' 
                                    ForeColor="#4E4E4E"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="13%"></HeaderStyle>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="Author">
                            <ItemTemplate>
                                <asp:Label style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" id="lbl_Author" 
                                    runat="server" Width="100%" Font-Size="11px" Font-Names="Verdana" 
                                    ForeColor="#4E4E4E" 
                                    Text='<%# DataBinder.Eval(Container.DataItem,"Author") %>'></asp:Label> 
                            </ItemTemplate>
                            <HeaderStyle Width="15%"></HeaderStyle>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="Format">
                            <ItemTemplate>
                                <asp:Label style="VERTICAL-ALIGN: middle; TEXT-ALIGN: center" id="lbl_format" 
                                    runat="server" Width="100%" Font-Size="11px" Font-Names="Verdana" 
                                    ForeColor="#4E4E4E" 
                                    Text='<%# DataBinder.Eval(Container.DataItem,"Format") %>'></asp:Label> 
                            </ItemTemplate>
                            <HeaderStyle Width="15%"></HeaderStyle>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="Price &lt;br&gt; (Baht)">
                            <ItemTemplate>
                                <asp:Label style="TEXT-ALIGN: right; vertical-align:middle;" id="lbl_Selling_Price" runat="server"
                                    Width="100%" Font-Size="11px" Font-Names="Verdana" ForeColor="#4E4E4E" 
                                    Text='<%# DataBinder.Eval(Container.DataItem,"Selling_Price","{0:#,###}") %>'>
                                </asp:Label> 
                            </ItemTemplate>
                            <HeaderStyle Width="15%"></HeaderStyle>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lbl_ebook_id" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"eBook_id") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="Add To Cart">
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_buy_ebook" runat="server" 
                                    ImageUrl="~/images/Template/add_to_cart.jpg" 
                                    onclick="btn_buy_ebook_Click"/>
                            </ItemTemplate>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="Delete">
                            <ItemTemplate>
                                <asp:ImageButton style="TEXT-ALIGN: center" id="b_del" runat="server" 
                                    ImageUrl="~/images/bin.jpg"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ISBN_13") %>' 
                                    CommandName="Delete">
                                </asp:ImageButton> 
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:TemplateColumn>
                    </Columns>
                <HeaderStyle CssClass="Grid_inqHeader"></HeaderStyle>
                </Saifi:MyDg> 
            </contenttemplate>
        <triggers>
            <asp:AsyncPostBackTrigger ControlID="Datagrid_ebook" EventName="DeleteCommand"></asp:AsyncPostBackTrigger>
        </triggers>
        </asp:UpdatePanel>
    </div>
    <%--//////////////////promptnow////////////////////--%>
    <asp:Panel ID="panCheck_Promotion" runat="server" HorizontalAlign="Center" style="display:none">
        <table border="0" cellpadding="0" cellspacing="0" style="width:450px; background-color:White;">
            <tr>
                <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
            </tr>
            <tr>
                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                <td align="center" valign="top">
                <table cellpadding="0" cellspacing="0" style="width: 90%">
                    <tr>
                        <td align="right" style="height: 25px"></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="font_about_us" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblPopUp" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="font_about_us" align="left"><asp:Label ID="lblPopUp2" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="font_other" style="height: 19px"></td>
                    </tr>
                    <tr>
                        <td class="font_other" align="center"><asp:ImageButton ID="img_add_to_cart" runat="server" ImageUrl="~/images/b_ok.jpg" />
                        &nbsp;<asp:ImageButton ID="btnCancelPro" runat="server" ImageUrl="~/images/b_cancel.jpg" />&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="font_other"></td>
                    </tr>
                    <tr>
                        <td class="font_other" style="height: 25px"></td>
                    </tr>
                </table>
                </td>
                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
            </tr>
            <tr>
                <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                <td align="left" valign="top" style="height:10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:ModalPopupExtender ID="mdlPopupCheck_Promotion" TargetControlID="linkBtFadeMaster" 
        PopupControlID="panCheck_Promotion" CancelControlID="btnCancelPro" runat="server" BackgroundCssClass="ModelBackground" >
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="ModalPopupAlert" TargetControlID="LinkButton1" 
    PopupControlID="panAlert" runat="server" BackgroundCssClass="ModelBackground" >
    </asp:ModalPopupExtender>
    <asp:Panel ID="panAlert" runat="server" style="display:none">
        <div>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="background-color:White">
              <tr>
                <td><img src="images/ebook/corner_left_top_03.gif" width="15" height="15" /></td>
                <td width="270" background="images/ebook/top_04.gif"></td>
                <td><img src="images/ebook/corner_right_top_05.gif" width="15" height="15" /></td>
              </tr>
              <tr>
                <td width="15" height="120" background="images/ebook/left_07.gif"></td>
                <td align="center" style="font-weight:bold">You already have item(s) in shopping cart !!</td>
                <td background="images/ebook/right_09.gif"></td>
              </tr>
              <tr>
                <td width="15" height="40" background="images/ebook/left_07.gif"></td>
                <td align="center"><asp:ImageButton ID="btn_alertClose" runat="server" ImageUrl="~/images/ebook/Button/b_ok.jpg" /></td>
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
<asp:LinkButton ID="LinkButton1" runat="server" style="display:none">LinkButton</asp:LinkButton>
    <asp:LinkButton ID="linkBtFadeMaster" runat="server" style="display:none">LinkButton</asp:LinkButton>        
    <%--////////////////promptnow end//////////////////--%>
</asp:Content>
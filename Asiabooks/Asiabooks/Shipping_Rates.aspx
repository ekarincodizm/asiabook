<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Shipping_Rates.aspx.vb" Inherits="Shipping_Rates" title="Untitled Page" %>
<%@ Register Assembly="MycustomDG" Namespace="MycustomDG" TagPrefix="Saifi" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">




    <table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%; height: 24px;">
                </td>
        </tr>
        <tr>
            <td class="header_other" style="width: 100%">
                Shipping Rate</td>
        </tr>
        <tr>
            <td style="width: 100%; height: 21px;">
                </td>
        </tr>
        <tr>
            <td align="center" style="width: 100%">
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 10%">
                            Country Name :&nbsp; </td>
                        <td style="width: 25%" align="left">
                            <asp:DropDownList ID="ddlCountry" runat="server" Width="250px" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                                                      </td>
                      <td style="width: 45%" align="left">
                            <asp:ImageButton id="b_search" runat="server" ImageUrl="~/images/b_search.jpg"></asp:ImageButton>
                      </td>
                  </tr>
              </table>
          </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 22px;">
                </td>
        </tr>
        <tr>
            <td style="width: 100%" align="center">
                <table cellpadding="0" cellspacing="0" style="width: 90%">
                    <tr>
                        <td align="right" style="width: 90%" class="font_other">
                            <asp:Label ID="Label_Result" runat="server" CssClass="font_other"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    </tr>
                    <tr>
                        <td style="width: 90%">
                            <Saifi:MyDg id="Datagrid" runat="server" ShowFooter="True" 
                                PagerStyle-Mode="NumericPages" SelectedItemStyle-CssClass="Grid_inqAltItem" AlternatingItemStyle-CssClass="Grid_inqAltItem" 
                            CssClass="Grid_inq" ShowPreviousAndNextImage="True" 
                                ShowFirstAndLastImage="True" AutoGenerateColumns="False" 
                            HeaderStyle-CssClass="Grid_inqHeader" ItemStyle-CssClass="Grid_inqItem" ImagePrevious="images/b_prevpage.gif" 
                            ImageNext="images/b_nextpage.gif" ImageLast="images/b_lastpage.gif" ImageFirst="images/b_firstpage.gif" 
                            AllowPaging="True" GridLines="None" Width="90%">
                            <SelectedItemStyle CssClass="Grid_inqAltItem"></SelectedItemStyle>

                            <AlternatingItemStyle CssClass="Grid_inqAltItem"></AlternatingItemStyle>

                            <ItemStyle CssClass="Grid_inqItem"></ItemStyle>

                            <PagerStyle Mode="NumericPages" PageButtonCount="5" CssClass="Grid_inqPager"></PagerStyle>

                            <HeaderStyle CssClass="Grid_inqHeader"></HeaderStyle>
                            <Columns>
                            <asp:TemplateColumn HeaderText="Transport Type"><FooterTemplate>
                            <asp:Label id="lbltxt" runat="server" Font-Names="Verdana" __designer:wfdid="w345" Text="Data not found in your search" Font-Bold="True" ForeColor="#FF6600"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                            &nbsp;<asp:Label id="lbl_Transport_Type" runat="server"  __designer:wfdid="w344" Text='<%# DataBinder.Eval(Container.DataItem,"Transport_Type") %>'></asp:Label>&nbsp;&nbsp;&nbsp; 
                            </ItemTemplate>
                            <EditItemTemplate>
                             
                            </EditItemTemplate>
                                <HeaderStyle Width="20%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Zone"><ItemTemplate>
                            <asp:Label id="lbl_Zone_Code" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem,"Zone_Code") %>' __designer:wfdid="w5"></asp:Label>&nbsp; 
                            </ItemTemplate>
                            <EditItemTemplate>
                            &nbsp; 
                            </EditItemTemplate>
                                <HeaderStyle Width="5%" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Country Name"><ItemTemplate>
                            &nbsp;<asp:Label id="lbl_country_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Country_Name") %>' __designer:wfdid="w4"></asp:Label>&nbsp;
                            </ItemTemplate>
                            <EditItemTemplate>
                            &nbsp;
                            </EditItemTemplate>
                                <HeaderStyle Width="20%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Weight (g.)"><ItemTemplate>
                            &nbsp;<asp:Label id="lbl_Weight" runat="server" __designer:wfdid="w1" Text='<%# DataBinder.Eval(Container.DataItem,"Weight","{0:#,##0.00}") %>'></asp:Label>&nbsp; 
                            </ItemTemplate>
                            <EditItemTemplate>
                            &nbsp; 
                            </EditItemTemplate>
                                <HeaderStyle Width="10%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="To Weight"><ItemTemplate>
                            &nbsp;<asp:Label id="lbl_To_Weight" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem,"To_Weight","{0:#,##0.00}") %>' __designer:wfdid="w25"></asp:Label>
                            </ItemTemplate>
                                <HeaderStyle Width="10%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Rate(BHT)"><ItemTemplate>
                            &nbsp;<asp:Label id="lbl_Charge_Rate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Charge_Rate","{0:#,##0.00}") %>' __designer:wfdid="w24" ></asp:Label> 
                            </ItemTemplate>
                                <HeaderStyle Width="10%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Fuel Surcharge(%) "><ItemTemplate>
                            &nbsp;<asp:Label id="lbl_Fuel_Surcharge" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem,"Fuel_Surcharge") %>' __designer:wfdid="w25"></asp:Label>  
                            </ItemTemplate>
                            <EditItemTemplate>
                              
                            </EditItemTemplate>
                                <HeaderStyle Width="15%" />
                            </asp:TemplateColumn>
                            </Columns>
                            </Saifi:MyDg>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90%">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Customer_Tran_Buy_Books.aspx.vb" Inherits="Customer_Tran_Buy_Books" title="Untitled Page" %>

<%@ Register assembly="MycustomDG" namespace="MycustomDG" tagprefix="Saifi" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
        <td style="width: 100%">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 100%">
            <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 5%; height: 23px;">
                        </td>
                    <td align="left" 
                        
                        style="width: 15%; height: 23px; font-weight: bold; color: #696969; font-family: arial, Helvetica, sans-serif; font-size: 9pt;">
                        Member Code :&nbsp;
                    </td>
                    <td style="width: 30%; height: 23px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #696969;" 
                        align="left">
                                                                <asp:Label ID="lblMember_Code" runat="server"></asp:Label>
                                                                </td>
                    <td style="width: 15%; height: 23px; font-weight: bold; color: #696969; font-family: arial, Helvetica, sans-serif; font-size: 9pt;" 
                        align="left">
                        Member Type :&nbsp;
                                                                </td>
                    <td style="width: 35%; height: 23px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #696969;" 
                        align="left">
                                                                <asp:Label ID="lblMember_Type" runat="server"></asp:Label>
                                                                </td>
                </tr>
                <tr>
                    <td style="width: 5%; height: 23px;">
                        </td>
                    <td align="left" 
                        
                        style="width: 15%; height: 23px; font-weight: bold; color: #696969; font-family: arial, Helvetica, sans-serif; font-size: 9pt;">
                        Name&nbsp; :&nbsp;
                    </td>
                    <td style="width: 30%; height: 23px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #696969;" 
                        align="left">
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                    <td style="width: 15%; height: 23px; font-weight: bold; color: #696969; font-family: arial, Helvetica, sans-serif; font-size: 9pt;" 
                        align="left">
                        Expire Date :&nbsp;
                        </td>
                    <td style="width: 35%; height: 23px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #696969;" 
                        align="left">
                        <asp:Label ID="lblExpire_Date" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td style="width: 5%; height: 23px;">
                        &nbsp;</td>
                    <td align="left" 
                        
                        style="width: 15%; height: 23px; font-weight: bold; color: #696969; font-family: arial, Helvetica, sans-serif; font-size: 9pt;">
                        Total Points :&nbsp;
                    </td>
                    <td style="width: 30%; height: 23px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #696969;" 
                        align="left">
                        <asp:Label ID="lblTotal_Point" runat="server"></asp:Label>
                    </td>
                    <td style="width: 15%; height: 23px;" align="right">
                        &nbsp;</td>
                    <td style="width: 35%; height: 23px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #696969;" 
                        align="left">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%; height: 23px;">
                        &nbsp;</td>
                    <td align="right" 
                        style="width: 15%; height: 23px; font-weight: bold; color: #696969; font-family: arial, Helvetica, sans-serif; font-size: 9pt;">
                        &nbsp;</td>
                    <td style="width: 30%; height: 23px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #696969;" 
                        align="left">
                        &nbsp;</td>
                    <td style="width: 15%; height: 23px;" align="left">
                        &nbsp;</td>
                    <td style="width: 35%; height: 23px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #696969;">
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
            <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" ForeColor="#333333" AllowPaging="True" PageSize="25" 
                Width="100%">
                <FooterStyle BackColor="#75A829" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EAF5D8" />
                <Columns>
                    <asp:BoundField HeaderText="Date" DataField="trans_date" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Time" DataField="trans_time" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Branch " DataField="org_name" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Document No. ">
                        <ItemTemplate>
                            <asp:Label ID="lblDocument_No" runat="server" Text='<%# Bind("document_no") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Purchase Value (Bt.) " DataField="amount" >
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Gift / Activity " DataField="gift" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Total Points" DataField="get_point" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Points Redeemed " DataField="use_point" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Number of Gift Redeemed" DataField="qty_gift" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgView" runat="server" ImageUrl="~/images/b_view.jpg" 
                                onclick="imgView_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle BackColor="#75A829" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#75A829" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td style="width: 100%">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 100%">
                                <asp:Panel ID="panPopUp_Detail" runat="server" HorizontalAlign="Center" style="display:none">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 650px; background-color: White;">
                        <tr>
                            <td align="left" valign="top" style="width:9px; height:7px; background-image: url('images/Template/cart_head_start.jpg');"></td>
                            <td align="left" valign="top" style="background-image: url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                            <td align="left" valign="top" style="width:10px; height:7px; background-image: url('images/Template/cart_head_end.jpg');"></td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                            <td align="center" valign="top">
                                <table cellpadding="0" cellspacing="0" >
                                <tr>
                                    <td align="right"><asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/Template/close.jpg" /></td>
                                </tr>
                                <tr>
                                    <td class="font_about_us" align="left">Document No :&nbsp;
                                        <asp:Label ID="lblDocument_No" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                    <tr>
                                        <td align="left" class="font_about_us">
                                            &nbsp;</td>
                                    </tr>
                                <tr>
                                    <td class="font_other">
                                        <asp:GridView ID="gvDetail_Tran" runat="server" AllowPaging="True" 
                                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                                            Width="630px">
                                            <FooterStyle BackColor="#75A829" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#EAF5D8" />
                                            <Columns>
                                                <asp:BoundField DataField="rowno" HeaderText="No.">
                                                    <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="name_en" HeaderText="Book Title">
                                                    <ItemStyle HorizontalAlign="Left" Width="400px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="qty" HeaderText="QTY">
                                                    <ItemStyle HorizontalAlign="Right" Width="10px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="price" HeaderText="Price">
                                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                </asp:BoundField>
                                            </Columns>
                                            <PagerStyle BackColor="#75A829" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#75A829" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#7C6F57" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="font_other" align="center">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="font_other">&nbsp;</td>
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
                        <asp:ModalPopupExtender ID="mdlPopUp_Detail" TargetControlID="lnkDetail" PopupControlID="panPopUp_Detail"  CancelControlID="btnCancel"
                            runat="server" BackgroundCssClass="ModelBackground" >
                        </asp:ModalPopupExtender>
                        <asp:LinkButton ID="lnkDetail" runat="server" style="display:none">LinkButton</asp:LinkButton>    
        </td>
    </tr>
    <tr>
        <td style="width: 100%">
            &nbsp;</td>
    </tr>
</table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Store_Event.aspx.vb" Inherits="Store_Event" title="Untitled Page" %>
<%@ Register Src="uc/ucPromotion.ascx" TagName="ucPromotion" TagPrefix="uc1" %>
<%@ Register Src="uc/ucSubscribe.ascx" TagName="ucSubscribe" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
           <tr>
            <td style="width: 100%" align="left">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Template/Store&Event.jpg" /></td>
        </tr>
        <tr>
            <td style="width: 100%; height: 20px">
                &nbsp;</td>
        </tr>
   <tr>
      <td style="width: 100%" align="left">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td align="left" style="width: 45%;" class="font_other">
                            Find our store (
                            <asp:Label ID="lblTotal_ShopAB" runat="server" Font-Bold="True"></asp:Label>
&nbsp; Shops)</td>
                        <td align="left" style="width: 5%">
                            &nbsp;</td>
                        <td align="left" style="width: 45%;" class="font_other">
                            Find our store (
                            <asp:Label ID="lblTotal_ShopBZ" runat="server" Font-Bold="True"></asp:Label>
&nbsp; Shops)</td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 45%; height:41px; background-image:url('images/Template/store&event_ab_bg.jpg'); ">
                           <span id="spanab" runat="server"></span> 
                            <asp:Image ID="Image50" runat="server" 
                                ImageUrl="~/images/Template/store&amp;event_ab.jpg" />
                            </td>
                        <td align="left" style="width: 5%">
                        </td>
                        <td align="left" style="width: 45%; height:41px; background-image:url('images/Template/store&event_bz_bg.jpg'); ">
                            <span id="spanbz" runat="server"></span>
                            <asp:Image ID="Image51" runat="server" 
                                ImageUrl="~/images/Template/store&amp;event_bz.jpg" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 45%;">
                            &nbsp;</td>
                        <td align="left" style="width: 5%">
                            &nbsp;</td>
                        <td align="left" style="width: 45%;" valign="top">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 45%;" valign="top">
                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td style="width: 100%">
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                            <tr>
                                <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                                <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                                <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="left" valign="top" class="header_other_ab" style="font-size: 12pt">Central</td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="left" valign="top" style="height: 13px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" class="font_other">
                                    <asp:GridView ID="gvAB_Central" runat="server" AutoGenerateColumns="False" 
                                        ShowHeader="False" BorderStyle="None" GridLines="None" Width="90%">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Image ID="Image52" runat="server" ImageUrl="~/images/arrow_green.gif" />
                                                    &nbsp;
                                                    <a href='Store_Event_Detail.aspx?Branch_Code=<%# Eval("Org_AB_Code") %> &Branch_Group=<%# Eval("Group_Code") %>'>
                                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Branch_Display") %>'></asp:Label></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="65%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="province" >
                                                <ItemStyle Width="25%" HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" style="height: 15px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" 
                                    style="background-image: url('images/Template/cart_head_bg.jpg'); height: 7px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" style="height: 15px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                                <td align="left" valign="top" style="font-size: 12pt;" class="header_other_ab">
                                    Nothern</td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                                <td align="center" valign="top" style="height: 15px">&nbsp;</td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                                <td align="center" valign="top" style="height: 15px">
                                    <asp:GridView ID="gvAB_Nothern" runat="server" AutoGenerateColumns="False" 
                                        ShowHeader="False" BorderStyle="None" GridLines="None" Width="90%" 
                                        CssClass="font_other">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Image ID="Image59" runat="server" ImageUrl="~/images/arrow_green.gif" />
                                                    &nbsp;
                                                    <a href='Store_Event_Detail.aspx?Branch_Code=<%# Eval("Org_AB_Code") %> &Branch_Group=<%# Eval("Group_Code") %>'>
                                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("Branch_Display") %>'></asp:Label></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="65%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="province" >
                                                <ItemStyle Width="25%" HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                                                            </td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                                <td align="center" valign="top" style="height: 15px">&nbsp;</td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                                <td align="center" valign="top" 
                                    style="background-image: url('images/Template/cart_head_bg.jpg'); height: 7px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                                <td align="center" valign="top" style="height: 15px">&nbsp;</td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="left" valign="top" class="header_other_ab" style="font-size: 12pt">Northeast</td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" style="height: 13px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                                <td align="center" valign="top">
                                    <asp:GridView ID="gvAB_Northeast" runat="server" AutoGenerateColumns="False" 
                                        ShowHeader="False" BorderStyle="None" GridLines="None" Width="90%" 
                                        CssClass="font_other">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Image ID="Image53" runat="server" ImageUrl="~/images/arrow_green.gif" />
                                                    &nbsp;
                                                    <a href='Store_Event_Detail.aspx?Branch_Code=<%# Eval("Org_AB_Code") %> &Branch_Group=<%# Eval("Group_Code") %>'>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Branch_Display") %>'></asp:Label></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="65%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="province" >
                                                <ItemStyle Width="25%" HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                            </tr>
                             <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" style="height: 15px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" 
                                    style="background-image: url('images/Template/cart_head_bg.jpg'); height: 7px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" style="height: 15px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="left" valign="top" class="header_other_ab" style="font-size: 12pt">Southern</td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" style="height: 13px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top">
                                    <asp:GridView ID="gvAB_Southern" runat="server" AutoGenerateColumns="False" 
                                        ShowHeader="False" BorderStyle="None" GridLines="None" Width="90%" 
                                        CssClass="font_other">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Image ID="Image54" runat="server" ImageUrl="~/images/arrow_green.gif" />
                                                    &nbsp;
                                                    <a href='Store_Event_Detail.aspx?Branch_Code=<%# Eval("Org_AB_Code") %> &Branch_Group=<%# Eval("Group_Code") %>'>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Branch_Display") %>'></asp:Label></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="65%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="province" >
                                                <ItemStyle Width="25%" HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" style="height: 15px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                <td align="left" valign="top" style="height:10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                                <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                            </tr>
                           </table></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%">&nbsp;</td>
                                </tr>
                                <tr>
                                   <td align="left" style="width: 45%; height:41px; background-image:url('images/Template/store&event_ab_bg.jpg'); ">
                                   <span id="span3" runat="server"></span> 
                                    <asp:Image ID="Image5" runat="server" 
                                        ImageUrl="~/images/Template/eCom_store.jpg" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%">
                                     <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                            <tr>
                                <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                                <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                                <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" 
                                    style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y; height: 13px;"></td>
                                <td align="left" valign="top" style="height: 13px"></td>
                                <td align="left" valign="top" 
                                    style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y; height: 13px;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" 
                                    style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y; height: 18px;"></td>
                                <td align="left" valign="top" style="height: 18px; padding-left: 10px" class="font_other">•	For eCommerce Customer Service, please contact 02-715-9000 ext. 8102, 8103, and 8105
<br />•	For eBooksSupport, please contact 02-715-9000 ext. 8101, 8104, and 8106
</td>
                                <td align="left" valign="top" 
                                                                                style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y; height: 18px;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" 
                                    style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y; height: 13px;"></td>
                                <td align="left" valign="top" style="height: 13px"></td>
                                <td align="left" valign="top" 
                                    style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y; height: 13px;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                <td align="left" valign="top" style="height:10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                                <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                            </tr>
                           </table> </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%">&nbsp;</td>
                                </tr>
                                <tr>
                                   <td align="left" style="width: 45%; height:41px; background-image:url('images/Template/store&event_ab_bg.jpg'); ">
                                   <span id="span1" runat="server"></span> 
                                    <asp:Image ID="Image6" runat="server" 
                                        ImageUrl="~/images/Template/store&amp;event_warehouse.jpg" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%">
                                     <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                            <tr>
                                <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                                <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                                <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" 
                                    style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y; height: 13px;"></td>
                                <td align="left" valign="top" style="height: 13px"></td>
                                <td align="left" valign="top" 
                                    style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y; height: 13px;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" 
                                    style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y; height: 18px;"></td>
                                <td align="left" valign="top" style="height: 18px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Image ID="Image60" runat="server" ImageUrl="~/images/arrow_orange.gif" />
&nbsp;
                                    <asp:LinkButton ID="lnkWarehouse_Thai" runat="server" Font-Names="Arial" 
                                        Font-Size="9pt" ForeColor="Gray">Warehouse Map Thai</asp:LinkButton>
                                                                            </td>
                                <td align="left" valign="top" 
                                                                                style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y; height: 18px;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" 
                                    style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y; height: 20px;"></td>
                                <td align="left" valign="top" style="height: 20px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Image ID="Image61" runat="server" ImageUrl="~/images/arrow_orange.gif" />
&nbsp;
                                    <asp:LinkButton ID="lnkWarehouse_Eng" runat="server" Font-Names="Arial" 
                                        Font-Size="9pt" ForeColor="Gray">Warehouse Map Eng.</asp:LinkButton>
                                                                            </td>
                                <td align="left" valign="top" 
                                                                                style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y; height: 20px;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" 
                                    style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y; height: 13px;"></td>
                                <td align="left" valign="top" style="height: 13px"></td>
                                <td align="left" valign="top" 
                                    style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y; height: 13px;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                <td align="left" valign="top" style="height:10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                                <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                            </tr>
                           </table> </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3" class="font_other"> For comments and suggesions about our service, please contact</td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3" class="font_other"><a href="mailto:information@asiabooks.com" style="color: #0066FF">
                                        information@asiabooks.com</a> (Tel : 0-2651-0430). Thank you.</td>
                                </tr>
                                <tr>
                                    <td style="width: 100%">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" style="width: 5%">
                            &nbsp;</td>
                        <td align="left" style="width: 45%;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                            <tr>
                                <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                                <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                                <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="left" valign="top" class="header_other_bz" style="font-size: 12pt">Central</td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="left" valign="top" style="height: 13px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" class="font_other">
                                    <asp:GridView ID="gvBZ_Central" runat="server" AutoGenerateColumns="False" 
                                        ShowHeader="False" BorderStyle="None" GridLines="None" Width="90%">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Image ID="Image55" runat="server" ImageUrl="~/images/icon_arrow_blue.gif" />
                                                    &nbsp;
                                                    <a href='Store_Event_Detail.aspx?Branch_Code=<%# Eval("Org_AB_Code") %> &Branch_Group=<%# Eval("Group_Code") %>'>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Branch_Display") %>'></asp:Label></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="65%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="province" >
                                                <ItemStyle Width="25%" HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" style="height: 15px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" 
                                    style="background-image: url('images/Template/cart_head_bg.jpg'); height: 7px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" style="height: 15px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="left" valign="top" class="header_other_bz" style="font-size: 12pt">Northern</td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" style="height: 13px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                                <td align="center" valign="top">
                                    <asp:GridView ID="gvBZ_Northern" runat="server" AutoGenerateColumns="False" 
                                        ShowHeader="False" BorderStyle="None" GridLines="None" Width="90%" 
                                        CssClass="font_other">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Image ID="Image56" runat="server" ImageUrl="~/images/icon_arrow_blue.gif" />
                                                    &nbsp;
                                                    <a href='Store_Event_Detail.aspx?Branch_Code=<%# Eval("Org_AB_Code") %> &Branch_Group=<%# Eval("Group_Code") %>'>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Branch_Display") %>'></asp:Label></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="65%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="province" >
                                                <ItemStyle Width="25%" HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;">
                                    &nbsp;</td>
                            </tr>
                             <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" style="height: 15px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" 
                                    style="background-image: url('images/Template/cart_head_bg.jpg'); height: 7px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" style="height: 15px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="left" valign="top" class="header_other_bz" style="font-size: 12pt">Southern</td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top" style="height: 13px"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top">
                                    <asp:GridView ID="gvBZ_Southern" runat="server" AutoGenerateColumns="False" 
                                        ShowHeader="False" BorderStyle="None" GridLines="None" Width="90%" 
                                        CssClass="font_other">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Image ID="Image57" runat="server" ImageUrl="~/images/icon_arrow_blue.gif" />
                                                    &nbsp;
                                                    <a href='Store_Event_Detail.aspx?Branch_Code=<%# Eval("Org_AB_Code") %> &Branch_Group=<%# Eval("Group_Code") %>'>
                                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Branch_Display") %>'></asp:Label></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="65%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="province" >
                                                <ItemStyle Width="25%" HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
                                <td align="center" valign="top"></td>
                                <td align="left" valign="top" style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                <td align="left" valign="top" style="height:10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                                <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px;"></td>
                                <td align="left" valign="top" style="height:10px;"></td>
                                <td align="left" valign="top" style="width:10px;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" colspan="3" style="width: 45%; height:41px; background-image:url('images/Template/store&event_ab_bg.jpg'); ">
                                   <span id="span2" runat="server"></span> 
                                    <asp:Image ID="Image12" runat="server" ImageUrl="~/images/Template/headoffice_bar.jpg" /></td>
                            </tr>
                            <tr>
                            <td align="left" colspan="3" style="width:100%;">
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                            <tr>
                                <td align="left" valign="top" style="width:9px; height:7px; background-image:url('images/Template/cart_head_start.jpg');"></td>
                                <td align="left" valign="top" style="height:7px; background-image:url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
                                <td align="left" valign="top" style="width:10px; height:7px; background-image:url('images/Template/cart_head_end.jpg');"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" 
                                    style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y; height: 13px;"></td>
                                <td align="left" valign="top" style="height: 13px"></td>
                                <td align="left" valign="top" 
                                    style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y; height: 13px;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" 
                                    style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y; height: 18px;"></td>
                                <td align="left" valign="top" style="height: 18px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Image ID="Image7" runat="server" ImageUrl="~/images/arrow_orange.gif" />
&nbsp;
                                    <asp:LinkButton ID="lnkHeadOffice_Thai" runat="server" Font-Names="Arial" 
                                        Font-Size="9pt" ForeColor="Gray">Head Office Map Thai</asp:LinkButton>
                                                                            </td>
                                <td align="left" valign="top" 
                                                                                style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y; height: 18px;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" 
                                    style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y; height: 20px;"></td>
                                <td align="left" valign="top" style="height: 20px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Image ID="Image8" runat="server" ImageUrl="~/images/arrow_orange.gif" />
&nbsp;
                                    <asp:LinkButton ID="lnkHeadOffice_Eng" runat="server" Font-Names="Arial" 
                                        Font-Size="9pt" ForeColor="Gray">Head Office Map Eng.</asp:LinkButton>
                                                                            </td>
                                <td align="left" valign="top" 
                                                                                style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y; height: 20px;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" 
                                    style="width:9px; background-image:url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y; height: 13px;"></td>
                                <td align="left" valign="top" style="height: 13px"></td>
                                <td align="left" valign="top" 
                                    style="width:10px; background-image:url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y; height: 13px;"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width:9px; height:10px; background-image:url('images/Template/cart_footer_start.jpg');"></td>
                                <td align="left" valign="top" style="height:10px; background-image: url('images/Template/cart_footer_bg.jpg'); background-repeat:repeat-x;"></td>
                                <td align="left" valign="top" style="width:10px; height:10px; background-image:url('images/Template/cart_footer_end.jpg');"></td>
                            </tr>
                           </table>
                            <tr>
                                <td align="left" valign="top" colspan="3">&nbsp;</td>
                            </tr>
                           </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 45%;">&nbsp;</td>
                        <td align="left" style="width: 5%">&nbsp;</td>
                        <td align="left" style="width: 45%;">&nbsp;</td>
                    </tr>
                </table>
            </td>
   </tr>
   <tr>
      <td style="width: 100%" align="left"><asp:Image ID="Image58" runat="server" ImageUrl="~/images/Template/Promotion&Event.jpg" /></td>
   </tr>
   <tr>
      <td style="width: 100%" align="left">
      <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
         <tr>
            <td align="left" valign="top">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
               <tr>
                   <td style="width: 100%">
                       <table cellpadding="0" cellspacing="0" style="width: 100%">
                           <tr>
                               <td align="left" 
                                   style="width: 48%; background-image: url('images/Template/instore_promotion_bg.jpg');">
                                   &nbsp;<asp:Image ID="Image62" runat="server" 
                                       ImageUrl="~/images/in-store-promotion.jpg" />
                               </td>
                               <td align="left" 
                                   style="width: 5%;">
                                   &nbsp;</td>
                               <td align="left" 
                                   style="width: 48%; background-image: url('images/Template/instore_promotion_bg.jpg');">
                                   <asp:Image ID="Image63" runat="server" ImageUrl="~/images/in-store-event.jpg" />
                               </td>
                           </tr>
                           <tr>
                               <td style="width: 48%" align="left" valign="top">
                                   <asp:GridView ID="gvPromotion" runat="server" AutoGenerateColumns="False" 
                                       CellPadding="0" GridLines="None" ShowHeader="False" Width="100%">
                                       <Columns>
                                           <asp:TemplateField>
                                               <ItemTemplate>
                                                   <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                       <tr>
                                                           <td style="width: 100%">
                                                               <table border="0" cellpadding="0" cellspacing="0">
                                                                   <tr>
                                                                       <td style="width: 9px; height: 7px" valign="top">
                                                                           <asp:Image ID="Image64" runat="server" Border="0" 
                                                                               ImageUrl="~/images/Template/cart_head_start.jpg" />
                                                                       </td>
                                                                       <td style="height: 7px; background-image: url('images/Template/cart_head_bg.jpg')" 
                                                                           valign="top">
                                                                       </td>
                                                                       <td style="width: 10px; height: 7px" valign="top">
                                                                           <asp:Image ID="Image3" runat="server" Border="0" 
                                                                               ImageUrl="~/images/Template/cart_head_end.jpg" />
                                                                       </td>
                                                                   </tr>
                                                                   <tr>
                                                                       <td style="background-image: url('images/Template/cart_left_bg.jpg'); width: 9px" 
                                                                           valign="top">
                                                                       </td>
                                                                       <td align="center" valign="top">
                                                                           <a href='StoreDetail.aspx?ID=<%# Eval("ID")%>' style="width: 20%">
                                                                           <asp:Image ID="Image2" runat="server" src='<%# Eval("Thumbnails_Image_path")%>' 
                                                                               style="width:160px; height:160px; border:0;" />
                                                                           </a>
                                                                       </td>
                                                                       <td style="background-image: url('images/Template/cart_right_bg.jpg'); width: 10px;" 
                                                                           valign="top">
                                                                       </td>
                                                                   </tr>
                                                                   <tr>
                                                                       <td style="width: 9px; height: 10px" valign="top">
                                                                           <asp:Image ID="Image9" runat="server" Border="0" 
                                                                               ImageUrl="~/images/Template/cart_footer_start.jpg" />
                                                                       </td>
                                                                       <td style="height: 10px; background-image: url('images/Template/cart_footer_bg.jpg')" 
                                                                           valign="top">
                                                                       </td>
                                                                       <td style="width: 10px; height: 10px" valign="top">
                                                                           <asp:Image ID="Image4" runat="server" Border="0" 
                                                                               ImageUrl="~/images/Template/cart_footer_end.jpg" />
                                                                       </td>
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
                                                               <a class="book-title" href='StoreDetail.aspx?ID=<%# Eval("ID")%>' 
                                                                   rel="add-to-cart" 
                                                                   style="text-decoration:none; color: #808080; font-weight: bold;">
                                                               <asp:Label ID="Label1" runat="server" Text='<%# Eval("Subject") %>' 
                                                                   ToolTip='<%# Eval("Full_Detail") %>'></asp:Label>
                                                               </a>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td style="width: 100%">
                                                               &nbsp;</td>
                                                       </tr>
                                                       <tr>
                                                           <td style="width: 100%">
                                                               <asp:Label ID="Label2" runat="server" CssClass="font_other" 
                                                                   Text='<%# Eval("Short_Detail") %>'></asp:Label>
                                                           </td>
                                                       </tr>
                                                   </table>
                                                   <br />
                                               </ItemTemplate>
                                           </asp:TemplateField>
                                       </Columns>
                                       <PagerStyle HorizontalAlign="Center" />
                                   </asp:GridView>
                               </td>
                               <td style="width: 5%" align="left" valign="top">
                                   &nbsp;</td>
                               <td align="left" style="width: 48%" valign="top">
                                   <asp:GridView ID="gvEvent" runat="server" AutoGenerateColumns="False" 
                                       CellPadding="0" GridLines="None" ShowHeader="False" Width="100%">
                                       <Columns>
                                           <asp:TemplateField>
                                               <ItemTemplate>
                                                   <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                       <tr>
                                                           <td style="width: 100%">
                                                               <table border="0" cellpadding="0" cellspacing="0">
                                                                   <tr>
                                                                       <td style="width: 9px; height: 7px" valign="top">
                                                                           <asp:Image ID="Image65" runat="server" Border="0" 
                                                                               ImageUrl="~/images/Template/cart_head_start.jpg" />
                                                                       </td>
                                                                       <td style="height: 7px; background-image: url('images/Template/cart_head_bg.jpg')" 
                                                                           valign="top">
                                                                       </td>
                                                                       <td style="width: 10px; height: 7px" valign="top">
                                                                           <asp:Image ID="Image66" runat="server" Border="0" 
                                                                               ImageUrl="~/images/Template/cart_head_end.jpg" />
                                                                       </td>
                                                                   </tr>
                                                                   <tr>
                                                                       <td style="background-image: url('images/Template/cart_left_bg.jpg'); width: 9px" 
                                                                           valign="top">
                                                                       </td>
                                                                       <td align="center" valign="top">
                                                                           <a href='StoreDetail.aspx?ID=<%# Eval("ID")%>' style="width: 20%">
                                                                           <asp:Image ID="Image67" runat="server" 
                                                                               src='<%# Eval("Thumbnails_Image_path")%>' 
                                                                               style="width:160px; height:160px; border:0;" />
                                                                           </a>
                                                                       </td>
                                                                       <td style="background-image: url('images/Template/cart_right_bg.jpg'); width: 10px;" 
                                                                           valign="top">
                                                                       </td>
                                                                   </tr>
                                                                   <tr>
                                                                       <td style="width: 9px; height: 10px" valign="top">
                                                                           <asp:Image ID="Image68" runat="server" Border="0" 
                                                                               ImageUrl="~/images/Template/cart_footer_start.jpg" />
                                                                       </td>
                                                                       <td style="height: 10px; background-image: url('images/Template/cart_footer_bg.jpg')" 
                                                                           valign="top">
                                                                       </td>
                                                                       <td style="width: 10px; height: 10px" valign="top">
                                                                           <asp:Image ID="Image69" runat="server" Border="0" 
                                                                               ImageUrl="~/images/Template/cart_footer_end.jpg" />
                                                                       </td>
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
                                                               <a class="book-title" href='StoreDetail.aspx?ID=<%# Eval("ID")%>' 
                                                                   rel="add-to-cart" 
                                                                   style="text-decoration:none; color: #808080; font-weight: bold;">
                                                               <asp:Label ID="Label10" runat="server" Text='<%# Eval("Subject") %>' 
                                                                   ToolTip='<%# Eval("Full_Detail") %>'></asp:Label>
                                                               </a>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td style="width: 100%">
                                                               &nbsp;</td>
                                                       </tr>
                                                       <tr>
                                                           <td style="width: 100%">
                                                               <asp:Label ID="Label11" runat="server" CssClass="font_other" 
                                                                   Text='<%# Eval("Short_Detail") %>'></asp:Label>
                                                           </td>
                                                       </tr>
                                                   </table>
                                                   <br />
                                               </ItemTemplate>
                                           </asp:TemplateField>
                                       </Columns>
                                       <PagerStyle HorizontalAlign="Center" />
                                   </asp:GridView>
                               </td>
                           </tr>
                           <tr>
                               <td style="width: 48%">
                                   &nbsp;</td>
                               <td style="width: 5%">
                                   &nbsp;</td>
                               <td style="width: 48%">
                                   &nbsp;</td>
                           </tr>
                           <tr>
                               <td style="width: 48%">
                                   &nbsp;</td>
                               <td style="width: 5%">
                                   &nbsp;</td>
                               <td style="width: 48%">
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
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td align="right" style="width: 201px" valign="top">
                            <uc1:ucPromotion ID="UcPromotion1" runat="server" />
                        </td>
                    </tr>
                </table></td>
        </tr>
        <tr>
            <td style="width: 100%">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%" align="left">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%; height: 17px;"></td>
        </tr>
        <tr>
            <td style="width: 100%; background-image:url('images/Template/instore_promotion_bg.jpg'); " align="left"></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%"></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%"></td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
<asp:Panel runat="server" ID="panMap_Thai" HorizontalAlign="Center" style="display:none;">   
<table border="0" cellpadding="0" cellspacing="0" style="background-color:White;">
<tr>
    <td align="left" valign="top" style="width:9px; height:7px; background-image: url('images/Template/cart_head_start.jpg');"></td>
    <td align="left" valign="top" style="background-image: url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
    <td align="left" valign="top" style="width:10px; height:7px; background-image: url('images/Template/cart_head_end.jpg');"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
    <td align="right" valign="top"><asp:ImageButton ID="btnCancelWTH" runat="server" ImageUrl="~/images/Template/close.jpg" /></td>
    <td style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
    <td align="left" valign="top">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
        <tr>
            <td colspan="2"><asp:Image ID="Image55" runat="server" ImageUrl="~/images/Map/map_thai.jpg" /></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Image ID="Image56" runat="server" ImageUrl="~/images/Map/Map-DC-(Thai-Version)_Big.jpg" /></td>
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
<asp:LinkButton ID="lnkMap_Thai" runat="server" style="display:none;">LinkButton</asp:LinkButton>
<asp:ModalPopupExtender ID="mdlPopupMap_Thai" TargetControlID="lnkMap_Thai" PopupControlID="panMap_Thai"
    CancelControlID="btnCancelWTH" runat="server" BackgroundCssClass="ModelBackground">
</asp:ModalPopupExtender>

<asp:Panel runat="server" ID="panMap_En" HorizontalAlign="Center" style="display:none;">   
<table border="0" cellpadding="0" cellspacing="0" style="background-color:White;">
<tr>
    <td align="left" valign="top" style="width:9px; height:7px; background-image: url('images/Template/cart_head_start.jpg');"></td>
    <td align="left" valign="top" style="background-image: url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
    <td align="left" valign="top" style="width:10px; height:7px; background-image: url('images/Template/cart_head_end.jpg');"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
    <td align="right" valign="top"><asp:ImageButton ID="btnCancelWEN" runat="server" ImageUrl="~/images/Template/close.jpg" /></td>
    <td style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
    <td align="left" valign="top">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
        <tr>
            <td colspan="2">
                <asp:Image ID="Image20" runat="server" ImageUrl="~/images/Map/map_en.jpg" />
            </td>
        </tr>
            <tr>
                <td colspan="2">
                    <asp:Image ID="Image21" runat="server" 
                        ImageUrl="~/images/Map/Map-DC-(Eng-Version)_Big.jpg" />
                </td>
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
<asp:LinkButton ID="lnkMap_En" runat="server" style="display:none">LinkButton</asp:LinkButton>
<asp:ModalPopupExtender ID="mdlPopupMap_En" TargetControlID="lnkMap_En" PopupControlID="panMap_En"
    CancelControlID="btnCancelWEN" runat="server" BackgroundCssClass="ModelBackground" >
</asp:ModalPopupExtender>

<asp:Panel runat="server" ID="pnlHO_Thai" HorizontalAlign="Center" style="display:none;">   
<table border="0" cellpadding="0" cellspacing="0" style="background-color:White;">
<tr>
    <td align="left" valign="top" style="width:9px; height:7px; background-image: url('images/Template/cart_head_start.jpg');"></td>
    <td align="left" valign="top" style="background-image: url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
    <td align="left" valign="top" style="width:10px; height:7px; background-image: url('images/Template/cart_head_end.jpg');"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
    <td align="right" valign="top"><asp:ImageButton ID="btnCancelHOTH" runat="server" ImageUrl="~/images/Template/close.jpg" /></td>
    <td style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
    <td align="left" valign="top">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
        <tr>
            <td colspan="2"><asp:Image ID="Image10" runat="server" ImageUrl="~/images/Map/ho_map_thai.jpg" /></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Image ID="Image11" runat="server" ImageUrl="~/images/Map/headoffice_map_th.jpg" /></td>
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
<asp:LinkButton ID="lnkHOMap_Thai" runat="server" style="display:none;">LinkButton</asp:LinkButton>
<asp:ModalPopupExtender ID="mdlPopupMapHO_Th" TargetControlID="lnkHOMap_Thai" PopupControlID="pnlHO_Thai"
    CancelControlID="btnCancelHOTH" runat="server" BackgroundCssClass="ModelBackground">
</asp:ModalPopupExtender>

<asp:Panel runat="server" ID="pnlHO_En" HorizontalAlign="Center" style="display:none;">
<table border="0" cellpadding="0" cellspacing="0" style="background-color:White;">
<tr>
    <td align="left" valign="top" style="width:9px; height:7px; background-image: url('images/Template/cart_head_start.jpg');"></td>
    <td align="left" valign="top" style="background-image: url('images/Template/cart_head_bg.jpg'); background-repeat:repeat-x;"></td>
    <td align="left" valign="top" style="width:10px; height:7px; background-image: url('images/Template/cart_head_end.jpg');"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
    <td align="right" valign="top"><asp:ImageButton ID="btnCancelHOEn" runat="server" ImageUrl="~/images/Template/close.jpg" /></td>
    <td style="width:10px; background-image: url('images/Template/cart_right_bg.jpg'); background-repeat:repeat-y;"></td>
</tr>
<tr>
    <td align="left" valign="top" style="width:9px; background-image: url('images/Template/cart_left_bg.jpg'); background-repeat:repeat-y;"></td>
    <td align="left" valign="top">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
        <tr>
            <td colspan="2"><asp:Image ID="Image13" runat="server" ImageUrl="~/images/Map/ho_map_en.jpg" /></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Image ID="Image14" runat="server" ImageUrl="~/images/Map/headoffice_map_en.jpg" /></td>
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
<asp:LinkButton ID="lnkHOMap_En" runat="server" style="display:none;">LinkButton</asp:LinkButton>
<asp:ModalPopupExtender ID="mdlPopupMapHO_En" TargetControlID="lnkHOMap_En" PopupControlID="pnlHO_En"
    CancelControlID="btnCancelHOEn" runat="server" BackgroundCssClass="ModelBackground">
</asp:ModalPopupExtender>
</asp:Content>
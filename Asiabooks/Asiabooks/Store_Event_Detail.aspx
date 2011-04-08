<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Store_Event_Detail.aspx.vb" Inherits="Store_Event_Detail" title="Untitled Page" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<%@ Register Src="uc/ucPromotion.ascx" TagName="ucPromotion" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
<tr>
    <td style="width: 100%">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Template/Store&Event.jpg" /></td>
</tr>
<tr>
    <td style="width: 100%; height: 20px">
    </td>
</tr>
<tr>
   <td align="left" style="width: 100%; ">
         
    </td>
</tr>
<tr>
    <td style="width: 100%; height: 20px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height:41px; background-image:url('<% getUrl("/images/Template/store&event_ab_bg.jpg")%>'); ">
            <tr>
                <td style="width: 150px">
                    <span id="spanbz" runat="server"></span>
                    <span id="spanab" runat="server"></span></td>
                <td align="left">
                    <asp:Label ID="lblBranch_Name1" runat="server" CssClass="label_store_event_head"></asp:Label></td>
            </tr>
        </table>
    </td>
</tr>
<tr>
    <td style="width: 100%; height: 20px">
    </td>
</tr>
<tr>
    <td style="width: 100%">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td align="left" style="width: 100%">
                                    <table border="0" cellpadding="0" cellspacing="0">
        
                                                <tr>
                                                    <td style="width: 9px; height: 7px">
                                                        <asp:Image ID="Image17" runat="server" 
                                                            ImageUrl="~/images/Template/cart_head_start.jpg" />
                                                    </td>
                                                    <td style="background-image: url('<% getUrl("/images/Template/cart_head_bg.jpg")%>')">
                                                    </td>
                                                    <td style="width: 10px; height: 7px">
                                                        <asp:Image ID="Image18" runat="server" 
                                                            ImageUrl="~/images/Template/cart_head_end.jpg" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="background-image: url('<% getUrl("/images/Template/cart_left_bg.jpg")%>'); width: 9px">
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        <asp:Image ID="img_shop" runat="server" />
                                                    </td>
                                                    <td style="background-image: url('<% getUrl("/images/Template/cart_right_bg.jpg")%>'); width: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 9px; height: 10px">
                                                        <asp:Image ID="Image19" runat="server" 
                                                            ImageUrl="~/images/Template/cart_footer_start.jpg" />
                                                    </td>
                                                    <td style="background-image: url('<% getUrl("/images/Template/cart_footer_bg.jpg")%>')">
                                                    </td>
                                                    <td style="width: 10px; height: 10px">
                                                        <asp:Image ID="Image20" runat="server" 
                                                            ImageUrl="~/images/Template/cart_footer_end.jpg" />
                                                    </td>
                                                </tr>
                                          
                                        </table>
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100%; height: 20px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100%" class="label_store_event_head">
                                
                                <asp:Label ID="lblBranch_Name2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100%" class="label_store_event_detail">
                                <asp:Label ID="lbladdress" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100%; height: 20px;">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="label_store_event_head" style="width: 100%">
                                PHONE :</td>
                        </tr>
                        <tr>
                            <td align="left" class="label_store_event_detail" style="width: 100%">
                                <asp:Label ID="lblPhone" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100%; height: 21px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="label_store_event_head" style="width: 100%">
                                OPENING HOURS :</td>
                        </tr>
                        <tr>
                            <td align="left" class="label_store_event_detail" style="width: 100%">
                                <asp:Label ID="lblOpening" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100%; height: 20px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100%; background-image:url('<% getUrl("/images/Template/StoreDetail_activities_bg.jpg")%>'); height: 33px;" class="label_head">
                                Map</td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100%">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100%">
                                &nbsp;<cc1:gmap id="GMap1" runat="server" height="400px" width="450px"></cc1:gmap></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100%">
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 250px" align="right" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td align="center" style="width: 100%">
                                <uc1:ucPromotion ID="UcPromotion1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 100%">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </td>
</tr>
<tr>
    <td style="width: 100%">
    </td>
</tr>
<tr>
    <td style="width: 100%">
    </td>
</tr>
</table>
</asp:Content>
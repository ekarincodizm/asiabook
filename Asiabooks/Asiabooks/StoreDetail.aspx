<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="StoreDetail.aspx.vb" Inherits="StoreDetail" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left">
                <asp:Image ID="Image58" runat="server" 
              ImageUrl="~/images/Template/Promotion&Event.jpg" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 17px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:Image ID="Image2" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height:10px;">
                </td>
        </tr>
        <tr>
            <td style="text-decoration: none; color: #808080; font-weight: bold;">
                <asp:Label ID="lblSubject" runat="server" Text="lblSubject"></asp:Label>
            <div style="height:10px;"></div>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFullDetail" runat="server" Text="lblFullDetail" 
                    CssClass="font_other"></asp:Label>
            
                </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>


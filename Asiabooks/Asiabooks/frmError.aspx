<%@ Page Language="VB" MasterPageFile="~/Template.master" AutoEventWireup="false" CodeFile="frmError.aspx.vb" Inherits="frmError"   %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="Server">

    <table style="width: 400px; text-align: center;">
        <tr>
            <td align="right" style="text-align: center">
                <table width="400">
                    <tr>
                        <td align="left" style="width: 360px; height: 17px;">
                            <asp:Label ID="Label4" runat="server" Text="Internal Error" ForeColor="Red" Visible="False"></asp:Label></td>
                        <td style="width: 125px; height: 17px;">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#" Visible="False">Back</asp:HyperLink></td>
                    </tr>
                </table>
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="16pt" Text="System Error ! Please Try again"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="height: 26px; text-align: center">
                <asp:Label ID="lbl_exmessage" runat="server" Font-Bold="True" Font-Size="16pt" Width="317px"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="height: 26px; text-align: center">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="10pt" Width="336px" ForeColor="#009900">Server Connection Error, Please contact Staff.<br />
(Monday-Friday 8.30 am.- 5.30 pm.) <br />Tel: (662) 715-9000 ext. 8103, 3202 
</asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="height: 26px; text-align: center">
            </td>
        </tr>
        <tr>
            <td align="right" style="text-align: center">
                <asp:ImageButton ID="b_exit" runat="server" ImageUrl="~/images/exit.jpg" /></td>
        </tr>
        <tr>
            <td style="width: 305px">
                <table style="width: 400px">
                    <tr>
                        <td align="left" style="width: 90px; height: 17px;" valign="top">
                            <asp:Label ID="Label3" runat="server" Text="Message" Visible="False"></asp:Label></td>
                        <td style="width: 12px; height: 17px;">
                        </td>
                        <td align="left" style="height: 17px">
                            <asp:Label ID="lblMessage" runat="server" Width="300px" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 90px; height: 17px;" valign="top">
                            <asp:Label ID="Label1" runat="server" Text="Source" Visible="False"></asp:Label></td>
                        <td style="width: 12px; height: 17px;">
                        </td>
                        <td align="left" style="height: 17px">
                            <asp:Label ID="lblSource" runat="server" Width="300px" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 90px" valign="top">
                            <asp:Label ID="Label2" runat="server" Text="StackTrace" Visible="False"></asp:Label></td>
                        <td style="width: 12px">
                        </td>
                        <td align="left">
                            <asp:Label ID="lblStactTrace" runat="server" Height="128px" Width="300px" Visible="False"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>


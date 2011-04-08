<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="My_Ebook2.aspx.vb" Inherits="MyEbook2" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="MycustomDG" Namespace="MycustomDG" TagPrefix="Saifi" %>  

<%@ Register src="uc/ucBooks.ascx" tagname="ucBooks" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         
    <table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="WIDTH: 100%" class="header_other">
                Download eBook</td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%">
                <asp:Label ID="Label_eBook" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">

                <tr align="center">
                    <td align="center" style="width: 100%; text-align: left">
                        &nbsp;</td>
                </tr>
                <tr align="left">
                    <td align="left" style="width: 100%;">
                        <asp:Label ID="Label_Status" runat="server"></asp:Label></td>
                </tr>
                <tr align="center">
                    <td align="center" width="100%">
                        <iframe frameBorder="0" width="100%" scrolling="no" 
                            runat="server" id="Frame_Download" style="height: 797px">
                        </iframe>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                    </td>
                </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
    </table> 
</asp:Content>


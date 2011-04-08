<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Bestsellers_SeeMore.aspx.vb" Inherits="Bestsellers_SeeMore" title="Untitled Page" %>
<%@ Register src="uc/ucBooks.ascx" tagname="ucBooks" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0" style="width: 100%">
<tr>
    <td style="width: 100%">&nbsp;</td>
</tr>
<tr>
    <td style="width: 100%; margin-left: 40px;">
        <uc1:ucBooks ID="ucBooks1" runat="server" Visible="false" />
        <uc1:ucBooks ID="ucBooks2" runat="server" Visible="false" />
        <uc1:ucBooks ID="ucBooks3" runat="server" Visible="false" />
        <uc1:ucBooks ID="ucBooks4" runat="server" Visible="false" />
        <uc1:ucBooks ID="ucBooks5" runat="server" Visible="false" />
        <uc1:ucBooks ID="ucBooks6" runat="server" Visible="false" /></td>
</tr>
<tr>
    <td style="width: 100%">&nbsp;</td>
</tr>
</table>
</asp:Content>
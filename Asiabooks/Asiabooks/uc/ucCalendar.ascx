<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucCalendar.ascx.vb" Inherits="uc_dtp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table cellpadding="0" cellspacing="0" style="height: 1px">
    <tr>
        <td style="height: 4px">
            <asp:TextBox ID="tbxDate1" runat="server" Width="95px" Font-Names="MS Sans Serif" Font-Size="10pt"></asp:TextBox></td>
        <td style="height: 4px">
            <asp:ImageButton ID="Date1" runat="server" ImageUrl="~/images/calender_icon.jpg"
                OnClientClick="return false;" /></td>
    </tr>
</table>
<div style="width: 100px; position: absolute; top: -999px; height: 100px">
    <cc1:CalendarExtender ID="c" runat="server" Format="dd/MM/yyyy" PopupButtonID="Date1"
        TargetControlID="tbxDate1">
    </cc1:CalendarExtender>
</div>

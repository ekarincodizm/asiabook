<%@ Control Language="VB" AutoEventWireup="true" CodeFile="currency.ascx.vb" Inherits="uc_PopEmp" %>
<table cellpadding="0" cellspacing="0" style="width: 1px; height: 1px">
    <tr>
        <td style="width: 120px; height: 21px;">
            <asp:DropDownList ID="cboEmp" runat="server" Font-Names="MS Sans Serif" Font-Size="10pt"></asp:DropDownList></td>
        <td style="width: 12px; height: 21px;">
            <img id="btnFind<%=Me.ClientID%>" src="images/bt_sc.jpg"  style="cursor:hand" onclick="return btnFind<%=Me.ClientID%>onclick()" /></td>
    </tr>
</table>
<div style="display:none; width: 334px; height: 22px; border-right: silver 1px solid; border-top: silver 1px solid; border-left: silver 1px solid; border-bottom: silver 1px solid; position: absolute; background-color: white; left: 43px; top: -999px;" id="divEmp<%=Me.ClientID%>">
   
    <table width="100%" style="border-right: darkgray 2px solid; border-top: darkgray 2px solid; border-left: darkgray 2px solid; border-bottom: darkgray 2px solid; background-color: gainsboro">
        <tr>
            <td style="width: 330px; text-align: center">
                <asp:Label ID="Label2" runat="server" Text="Search organizeab" Width="200px" Font-Bold="True" Font-Names="Verdana" Font-Size="11pt"></asp:Label></td>
            <td style="width: 3px">
            </td>
            <td style="width: 3px">
                <input id="Button1" onclick="divHide<%=Me.ClientID%>()" style="font-weight: bold;
                    width: 19px; color: red; height: 25px" title="Close" type="button" value="x" /></td>
        </tr>
        <tr>
            <td colspan="3">
    <table style="height: 51px" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 87px">
                <asp:Label ID="Label1" runat="server" Text="Search By" Width="100px" Font-Names="Verdana" Font-Size="10pt"></asp:Label></td>
            <td style="width: 178px">
            </td>
            <td style="width: 60px">
            </td>
        </tr>
        <tr>
            <td style="width: 87px; height: 24px;">
                <asp:DropDownList ID="ddlSearch" runat="server" Width="93px" Font-Names="MS Sans Serif" Font-Size="10pt">
                    <asp:ListItem Value="0">Org AB code</asp:ListItem>
                    <asp:ListItem Value="1">Org AB Name</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 178px; height: 24px;" >
                <asp:TextBox ID="tbxSearch" runat="server" Width="160px" Font-Names="MS Sans Serif" Font-Size="10pt"></asp:TextBox></td>
            <td style="width: 60px; height: 24px">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" Width="55px" Font-Names="Verdana" Font-Size="10pt"  /></td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" Height="230px" Style="overflow: scroll" Width="331px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="grdDetail" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" Height="37px" Width="266px" Font-Names="Tahoma" Font-Size="8pt">
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:TextBox ID="tbxID" runat="server" BorderStyle="None" Style="background-color: transparent; cursor: hand; color: #0099ff; text-decoration: underline;"
                                    Width="100px" Text = '<%#DataBinder.Eval(Container.DataItem,"Currency_Code")%>'  ReadOnly="True" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox>
                            </ItemTemplate>
                            <HeaderTemplate>
                                Org AB code
                            </HeaderTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:TextBox ID="tbxName" runat="server" BorderStyle="None" Style="background-color: transparent"
                                    Width="185px" Text = '<%#DataBinder.Eval(Container.DataItem,"Currency_Code")%>' ReadOnly="True" Font-Names="Tahoma" Font-Size="8pt" ></asp:TextBox>
                            </ItemTemplate>
                            <HeaderTemplate>
                                Org AB Name
                            </HeaderTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#E3EAEB" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
            </td>
        </tr>
    </table>
 
</div>

<script language="javascript" type="text/javascript">
// <!CDATA[

function btnFind<%=Me.ClientID%>onclick() 
{
    var div = document.getElementById('divEmp<%=Me.ClientID%>');
   if ( div.style.display == 'none')
  {
        divShow<%=Me.ClientID%>();
  } 
   else
  {
       divHide<%=Me.ClientID%>();
  }
}
function divShow<%=Me.ClientID%>()
{
    var div = document.getElementById('divEmp<%=Me.ClientID%>');
    div.style.display = '';
    /*
    var btn_offset = new ElementOffset(document.all["btnFind<%=Me.ClientID%>"])
    div.style.left = btn_offset.left - 170;
    div.style.top = btn_offset.bottom+5;
    var div_offset = new ElementOffset(div)
    div_offset.HideIntersecTag("SELECT","<%=Me.ClientID%>");
    */
    
    div.style.left = 410;
    div.style.top = 300;

    
    //var ss = document.getElementById("<%=Me.ClientID%>_ddlSearch");
    //ss.style.display = '';
}

function divHide<%=Me.ClientID%>()
{
        var div = document.getElementById('divEmp<%=Me.ClientID%>');
        div.style.display = 'none'; 
        var div_offset = new ElementOffset(div)
        div_offset.ShowIntersecTag("<%=Me.ClientID%>");
}
function selectData<%=Me.ClientID%>(value,obj)
{
//  

       obj.value = value;
       divHide<%=Me.ClientID%>();
} 


// ]]>
</script>

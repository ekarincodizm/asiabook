<%@ Page Language="VB" AutoEventWireup="false" CodeFile="kung_test.aspx.vb" Inherits="kung_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server" method ="post" action  ="Mail_Payment.aspx">
    <div>
            HOSTRESP : <asp:TextBox ID="HOSTRESP" runat="server"></asp:TextBox>
        REFCODE : <asp:TextBox ID="REFCODE" runat="server"></asp:TextBox>
        AUTHCODE : <asp:TextBox ID="AUTHCODE" runat="server"></asp:TextBox>
        RETURNINV : <asp:TextBox ID="RETURNINV" runat="server"></asp:TextBox>
        UAID : <asp:TextBox ID="UAID" runat="server"></asp:TextBox>
        CARDNUMBER : <asp:TextBox ID="CARDNUMBER" runat="server"></asp:TextBox>
        AMOUNT : <asp:TextBox ID="AMOUNT" runat="server"></asp:TextBox>
        FILLSPACE : <asp:TextBox ID="FILLSPACE" runat="server"></asp:TextBox>
 
        <asp:Button ID="btnSend" runat="server" Text="Send"  PostBackUrl ="~/Mail_Payment.aspx" />
    </div>
    </form>
</body>
</html>

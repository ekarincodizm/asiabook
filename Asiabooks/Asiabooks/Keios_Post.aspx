<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Keios_Post.aspx.vb" Inherits="Keios_Post" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pay at Asia Books Counter</title>

    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="760" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td width="20"><asp:Image runat="server" ImageUrl="~/images/Keios_Post/top_left.jpg" width="20" height="103" /></td>
        <td style="background-image: url('images/Keios_Post/bg_top.jpg')">
            <asp:Image runat="server" ImageUrl="~/images/Keios_Post/logo.jpg" width="321" height="103" /></td>
        <td width="20"><asp:Image runat="server" ImageUrl="~/images/Keios_Post/top_right.jpg" width="20" height="103" /></td>
      </tr>
      <tr>
        <td style="background-image: url('images/Keios_Post/left.gif'); width:20px; "></td>
        <td style="height: 300px; width: 720px;" valign="top">
            <table width="100%"  align="center" cellpadding="0" cellspacing="0" >
	            <tr><td style="width: 746px">&nbsp;</td>
	            </tr>
	            <tr><td style="width: 746px" align="right">
                    <a href="https://www.asiabooks.com"><asp:Image ID="imageHome" runat="server" 
                        ImageUrl="~/images/home.gif" /></a>
                    </td>
	            </tr>
	            <tr><td style="width: 746px; font-family: arial, Helvetica, sans-serif; font-size: 15pt; font-weight: bold; color: #006600;" 
                        align="center">
                    Order Detail (รายละเอียดการสั่งซื้อ)
                    </td>
	            </tr>
	            <tr><td style="width: 746px" align="right">
                    &nbsp;</td>
	            </tr>
	            <tr><td style="width: 746px; font-family: arial, Helvetica, sans-serif; font-size: 11pt; font-weight: bold; color: #696969;">
                    <table cellpadding="0" cellspacing="0" class="style1">
                        <tr>
                            <td align="left" 
                                style="width: 40%; height: 21px; font-family: arial, Helvetica, sans-serif; font-size: 10pt; color: #696969;">
                                ประเภทบริการ (Service Type) </td>
                            <td align="left" 
                                style="width: 60%; height: 21px; font-family: arial, Helvetica, sans-serif; font-size: 10pt; color: #696969; font-weight: normal;">
                                <b>:</b>
                                Order By www.Asiabooks.com - สั่งซื้อสินค้าจาก www.Asiabooks.com</td>
                        </tr>
                        <tr>
                            <td align="left" 
                                style="width: 40%; height: 21px; font-family: arial, Helvetica, sans-serif; font-size: 10pt; color: #696969;">
                                วันที่ทำรายการ (Order Date) </td>
                            <td align="left" 
                                style="width: 60%; height: 21px; font-family: arial, Helvetica, sans-serif; font-size: 10pt; color: #696969; font-weight: normal;">
                                :
                                <asp:Label ID="lblOrderDate" runat="server"></asp:Label>
                                            </td>
                        </tr>
                        <tr>
                            <td align="left" 
                                style="width: 40%; height: 21px; font-family: arial, Helvetica, sans-serif; font-size: 10pt; color: #696969;">
                                หมายเลขการสั่งซื้อ (Order No) </td>
                            <td align="left" 
                                style="width: 60%; height: 21px; font-family: arial, Helvetica, sans-serif; font-size: 10pt; color: #696969; font-weight: normal;">
                                <b>:</b>                     
	            <asp:Label ID="lblOrder_No" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" 
                                style="width: 40%; height: 21px; font-family: arial, Helvetica, sans-serif; font-size: 10pt; color: #696969;">
                                หมายเลขสมาชิก (Member No)</td>
                            <td align="left" 
                                style="width: 60%; height: 21px; font-family: arial, Helvetica, sans-serif; font-size: 10pt; color: #696969; font-weight: normal;">
                                <b>:</b>
                                <asp:Label ID="lblMemberID" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" 
                                                style="width: 40%; height: 21px; font-family: arial, Helvetica, sans-serif; font-size: 10pt; color: #696969;">
                                                วิธีการชำระเงิน (Payment Method)
                                            </td>
                                            <td align="left" 
                                                style="width: 60%; height: 21px; font-family: arial, Helvetica, sans-serif; font-size: 10pt; color: #696969; font-weight: normal;">
                                                <b>:</b>
                                                Pay at Asia Books Counter – จ่ายผ่าน เคาน์เตอร์เอเชียบุ๊คส์</td>
                                        </tr>
                                        <tr>
                                            <td align="left" 
                                                style="width: 40%; height: 21px; font-family: arial, Helvetica, sans-serif; font-size: 10pt; color: #696969;">
                                                ยอดเงินรวมที่ต้องจ่าย(Payment Amount)</td>
                                            <td align="left" 
                                                style="width: 60%; height: 21px; font-family: arial, Helvetica, sans-serif; font-size: 10pt; color: #696969; font-weight: normal;">
                                                <b>:</b>
                                                <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
	            </tr>
	            <tr><td style="font-family: arial, Helvetica, sans-serif; font-size: 13pt; font-weight: bold; color: #696969; width: 746px; height: 100px" 
                        align="center" valign="middle">
                    Payment Code (รหัสการจ่ายเงิน)&nbsp; :&nbsp;                     
                    <asp:Label ID="lblKeios" runat="server" Font-Size="15pt" ForeColor="#FF6600"></asp:Label>
                    </td>
	            </tr>
	            <tr><td style="width: 746px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #696969;">
                    <b>ข้อแนะนำ :<br />
                    </b></td>
	            </tr>
	            <tr><td style="width: 746px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #696969;">
                    1. เพื่อความสะดวกในการชำระเงิน 
                    กรุณานำแบบฟอร์มนี้ไปชำระเงินที่จุดบริการรับชำระเงินที่เอเชียบุ๊คส์เคาน์เตอร์<br />
                    For your convenience, please print this payment form to pay at Asia Books 
                    Counter in Asia Books shops or Bookazine shops.</td>
	            </tr>
	            <tr><td style="width: 746px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #696969;">
                    &nbsp;</td>
	            </tr>
	            <tr><td style="width: 746px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #696969;">
                    2. หากมีข้อสงสัย หรือไม่ได้รับความสะดวกประการใด กรุณาติดต่อ 
                    หน่วยงานลูกค้าสัมพันธ์ เอเชีย บุ๊คส โทร. (662) 715-9000 ต่อ 8101, 8106, 8010 
                    ตั้งแต่วันจันทร์ – วันศุกร์ เวลา 09:00 – 18.00 น.<br />
                    For more information please contact Customer Service. Tel. (662) 715-9000 Ext. 
                    8102, 8103,&nbsp; Monday-Friday 09.00 am – 06.00 pm.</td>
	            </tr>
	            <tr><td style="width: 746px; font-family: arial, Helvetica, sans-serif; font-size: 9pt; color: #696969;">
                    &nbsp;</td>
	            </tr>
	            </table>
		 <br />
        </td>
        <td style="background-image: url('images/Keios_Post/right.gif'); width:20px; "></td>
      </tr>
      <tr>
        <td><asp:Image runat="server" ImageUrl="~/images/Keios_Post/bottom_left.jpg" width="20" height="80" /></td>
        <td align="center" bgcolor="#73B017" 
          style="color: #FFFFFF; font-weight: bold; FONT-FAMILY: Tahoma; font-size: 10pt;">Asia 
        Books Co.,ltd 65/66,65/70 Chamnan Phenjati Business Center 7th Floor,<br />
        Rama 9 road Huaykwang, Huaykwang, Bangkok 10320 Thailand<br />
        Customer Service Tel : (662) 715-9000 Fax : (662) 715-9197 www.asiabooks.com</td>
        <td><asp:Image runat="server" ImageUrl="~/images/Keios_Post/bottom_right.jpg" width="20" height="80" /></td>
      </tr>
    </table>
    </div>
    </form>
</body>
</html>

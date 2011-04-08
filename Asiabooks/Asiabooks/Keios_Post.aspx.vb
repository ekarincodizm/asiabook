Imports System
Imports System.Data

Partial Class Keios_Post
    Inherits System.Web.UI.Page
    Dim uCon As uConnect
    Dim ws_Send_SMS As New Send_SMS.Send_SMS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblOrder_No.Text = Request.QueryString("Order_No")

            'lblOrder_No.Text = "110124000039"
            'Dim strKeios As String = "1102090002003160010"

            Dim strSql As String = ""
            strSql &= " select Telephone,order_no,order_date,convert(numeric(18,2),grand_total) as amount,member_id,Keios_Post"
            strSql &= " from tbt_asbkeo_cus_order"
            strSql &= " where order_no = '" + lblOrder_No.Text.Trim + "'"
            uCon = New uConnect
            Dim dt As New DataTable
            dt = uFunction.getDataTable(uCon.conn, strSql)
            If dt.Rows.Count > 0 Then
                Dim strKeios As String = dt.Rows(0).Item("Keios_Post").ToString.Trim
                lblMemberID.Text = dt.Rows(0).Item("member_id").ToString
                lblAmount.Text = dt.Rows(0).Item("amount").ToString
                lblOrderDate.Text = Format(Now.Date, "dd MMMM yyyy")
                lblKeios.Text = strKeios.Substring(0, 6) & " - " & strKeios.Substring(6, 4) & " - " & strKeios.Substring(10, 9)

                Dim strOrder_No As String = ""
                'strOrder_No = "101004000007"  
                Dim strTelephone As String = ""
                strTelephone = dt.Rows(0).Item("telephone").ToString
                strOrder_No = dt.Rows(0).Item("order_no").ToString

                If strTelephone <> "" Then
                    Dim strSplit As String()
                    Dim strPrice As String = ""
                    strSplit = strTelephone.Replace("-", "").Split(" ")
                    If strSplit.Length > 1 Then
                        If Left(strSplit(0), 2) = "08" Then
                            If strSplit(0).Length = 10 Then
                                ws_Send_SMS.CallSend_SMS(strOrder_No, strSplit(0).ToString, "Your payment code for order " + strOrder_No + " is (" + lblKeios.Text.Replace(" ", "") + ").", "d6hojkiyd", "Kiosk POS")
                            End If
                        Else
                            If Left(strSplit(1), 2) = "08" Then
                                If strSplit(1).Length = 10 Then
                                    ws_Send_SMS.CallSend_SMS(strOrder_No, strSplit(1).ToString, "Your payment code for order " + strOrder_No + " is (" + lblKeios.Text.Replace(" ", "") + ").", "d6hojkiyd", "Kiosk POS")
                                End If
                            End If
                        End If
                    Else
                        If Left(strSplit(0), 2) = "08" Then
                            If strSplit(0).Length = 10 Then
                                ws_Send_SMS.CallSend_SMS(strOrder_No, strSplit(0).ToString, "Your payment code for order " + strOrder_No + " is (" + lblKeios.Text.Replace(" ", "") + ").", "d6hojkiyd", "Kiosk POS")
                            End If
                        End If
                    End If

                End If

            End If
        End If
    End Sub
End Class

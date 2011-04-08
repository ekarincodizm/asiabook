Imports System
Imports System.Data
Imports System.IO
Partial Class Mail_Payment
    Inherits System.Web.UI.Page
    Dim PaymentService As New ws_payment.paymentservice.PaymentService
    'Dim ws_Send_SMS As New Send_SMS.Send_SMS
    Dim Url As String
    'Dim uCon As uConnect

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Your credit card country does not match ebook sale permit territory.'); window.location.href = '" & ConfigurationManager.AppSettings("AB_HomePage") & "';", True)

            'Response.Redirect(ConfigurationManager.AppSettings("AB_HomePage"))

        End If
    End Sub
End Class

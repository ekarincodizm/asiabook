Imports Microsoft.VisualBasic
Imports System
Imports System.Net
Imports System.Data
Imports System.Configuration

Partial Class Test_Send_Mail
    Inherits System.Web.UI.Page
    Dim SmtpMail As String = Convert.ToString(ConfigurationSettings.AppSettings("SmtpServer"))
    Dim UserPassword As String = Convert.ToString(ConfigurationSettings.AppSettings("MailPassword"))
    Dim UserName As String = Convert.ToString(ConfigurationSettings.AppSettings("MailUserID"))
    Dim MailFrom As String = Convert.ToString(ConfigurationSettings.AppSettings("MailFrom"))

    Protected Sub btnSendMail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendMail.Click
        Try

            Dim mailMessage As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage
            mailMessage.From = MailFrom
            mailMessage.To = txtTo.Text.Trim
            mailMessage.Cc = txtCC.Text.Trim
            mailMessage.Subject = txtSubject.Text
            mailMessage.BodyFormat = System.Web.Mail.MailFormat.Html
            mailMessage.Body = "Test"

            System.Web.Mail.SmtpMail.SmtpServer = "61.90.159.15"

            If Me.UserName <> "" Or Me.UserPassword <> "" Then
                mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1")
                mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", UserName)
                mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", UserPassword)
            End If
            System.Web.Mail.SmtpMail.Send(mailMessage)


            'Dim smtpmail As New Mail.SmtpClient
            'Dim m As New Mail.MailMessage

            'smtpmail.Host = "61.90.159.15"
            'smtpmail.Port = 25
            'smtpmail.Credentials = New System.Net.NetworkCredential("cs@mail2.asiabooks.com", "abs999.")
            'smtpmail.DeliveryMethod = Mail.SmtpDeliveryMethod.Network

            'm.From = New Mail.MailAddress("ecommerce@asiabooks.com")
            'm.Subject = txtSubject.Text
            'm.IsBodyHtml = True
            'm.Body = "Test"
            'm.To.Add(txtTo.Text)
            'm.CC.Add(txtCC.Text)

            'smtpmail.Send(m)


            txtCC.Text = ""
            txtSubject.Text = ""
            txtTo.Text = ""

            uScript.Alert(Me.Page, Me.GetType, "Send mail complete")
        Catch ex As Exception
            uScript.Alert(Me.Page, Me.GetType, ex.ToString)
        End Try
    End Sub

End Class

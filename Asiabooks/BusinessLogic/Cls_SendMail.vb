'tom+.a.2009-07-01 k.orapin request
Imports System.Web.Mail
Imports System.Configuration
Imports System.IO
Imports System

'------------------------------------
Public Class Cls_SendMail
    'tom+.a.2009-07-01 k.orapin request
    Dim SmtpMail As String = Convert.ToString(ConfigurationSettings.AppSettings("SmtpServer"))
    Dim UserPassword As String = Convert.ToString(ConfigurationSettings.AppSettings("MailPassword"))
    Dim UserName As String = Convert.ToString(ConfigurationSettings.AppSettings("MailUserID"))
    Dim mailto As String = Convert.ToString(ConfigurationSettings.AppSettings("to"))
    Dim mailcc As String = Convert.ToString(ConfigurationSettings.AppSettings("cc"))
    Dim Mailtemp As String = System.AppDomain.CurrentDomain.BaseDirectory() & ConfigurationSettings.AppSettings("MailTemplate")
    'tom+.a.2009-07-01 k.orapin request
    Private strOrderNo As String
    Private strMessageError As String
    Private strFilenm As String
    Property OrderNo()
        Get
            Return strOrderNo
        End Get
        Set(ByVal value)
            strOrderNo = value
        End Set
    End Property
    Property MessageError()
        Get
            Return strMessageError
        End Get
        Set(ByVal value)
            strMessageError = value
        End Set
    End Property
    Property Filenm()
        Get
            Return strFilenm
        End Get
        Set(ByVal value)
            strFilenm = value
        End Set
    End Property
    Public Function SendMessage() As Boolean
        Dim status As Boolean = True
        Try
            Dim strhtml As String = ""
            If File.Exists(Mailtemp) Then
                Dim sr As New IO.StreamReader(Mailtemp)
                strhtml = sr.ReadToEnd()
            Else
                MessageError = "File Template not found! "
                status = False
                Exit Function
            End If

            Dim mailMessage As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage
            mailMessage.From = UserName
            mailMessage.To = mailto
            mailMessage.Cc = mailcc
            mailMessage.Subject = "Indent Order No: " & OrderNo
            mailMessage.BodyFormat = System.Web.Mail.MailFormat.Html
            mailMessage.Body = strhtml
            System.Web.Mail.SmtpMail.SmtpServer = Me.SmtpMail
            If File.Exists(Filenm) Then
                Dim att As New MailAttachment(Filenm)
                mailMessage.Attachments.Add(att)
            Else
                MessageError = "Indent Order No: " & OrderNo & " : File not found "
                status = False
                Exit Function
            End If
            If Me.UserName <> "" Or Me.UserPassword <> "" Then
                mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1")
                mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", UserName)
                mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", UserPassword)
            End If
            System.Web.Mail.SmtpMail.Send(mailMessage)
            status = True
        Catch ex As Exception
            status = False
        End Try
        Return status
    End Function
End Class

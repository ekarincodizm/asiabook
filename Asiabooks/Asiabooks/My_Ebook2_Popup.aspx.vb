Imports Eordering.BusinessLogic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Data


Partial Class My_Ebook2_Popup
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim MyEBookID As String
    Private uCon As uConnect
    Dim SmtpMail As String = Convert.ToString(ConfigurationSettings.AppSettings("SmtpServer"))

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "My EBook ::"
        MyEBookID = Session("DL_MyEBookID")

        If Not Me.IsPostBack And Not Me.IsCallback Then
            If MyEBookID <> "-1" Then
                download()
            End If
        End If
    End Sub

    Private Sub download()
        Dim OrderNo As String = ""

        GenerateLog("MyEbook2_Download_Popup", "", "", OrderNo, "", "", "https://www.asiabooks.com", "", "download in MyEbook2_Popup")

        Try
            Dim sqlCommand As String

            sqlCommand = "SELECT distinct MyEBookID, e.bookid, e.isbn_13, isnull(l.supplier_code, e.supplier_code) as supplier_code, e.max_download, Downloaded_Times, Download_URL, l.Order_No, isnull(o.Customer_Country, 'ZZ') as Customer_Country, od.Unitprice "
            sqlCommand &= "FROM ebook_mylist l "
            sqlCommand &= "LEFT JOIN ebook_store e ON e.BookID = l.EBookID "
            sqlCommand &= "LEFT JOIN tbt_asbkeo_cus_order o ON o.Order_No = l.Order_No "
            sqlCommand &= "LEFT JOIN tbt_asbkeo_cus_orderdtl od ON od.EBookID = l.EBookID "
            sqlCommand &= "WHERE MyEBookID = '" + MyEBookID + "' AND  e.max_download > Downloaded_Times AND l.Download_URL <> '' "

            uCon = New uConnect
            dt = uFunction.getDataTable(uCon.conn, sqlCommand)

            If dt.Rows.Count > 0 Then

                OrderNo = dt.Rows(0).Item("Order_No")

                If dt.Rows(0).Item("supplier_code").ToString.Trim.ToLower.Equals("gardners") Then
                    LogDownload(dt.Rows(0).Item("bookid"), dt.Rows(0).Item("Order_No"), dt.Rows(0).Item("Unitprice"), dt.Rows(0).Item("Customer_Country"), "3", Request.UserAgent, dt.Rows(0).Item("MyEBookID"))
                    CreditDownload(MyEBookID, dt.Rows(0).Item("Downloaded_Times"))

                    Session("DL_MyEBookID") = "-1"

                    'Dim mailMessage As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage
                    'Dim _mail As New StringBuilder
                    'Dim _strQuery As New StringBuilder

                    'Dim br As String = "<br />"
                    ''_mail.Append("Download URL: " & dt.Rows(0).Item("Download_URL").ToString)
                    '_mail.Append("Dear Sirs, " & br & br)
                    '_mail.Append("Account No.: ASI001 (Asia Books)" & br)
                    '_mail.Append("ISBN: " & dt.Rows(0).Item("isbn_13") & br & br & br)
                    '_mail.Append("Following is  the URL that our customer downloads eBook. Please provide the confirmation on status of eBooks downloading for our reference. Thank you." & br & br)
                    '_mail.Append("_Download URL: " & dt.Rows(0).Item("Download_URL") & br & br)

                    '_mail.Append("Hope to hear from you soon." & br & br & br)
                    '_mail.Append("Best regards," & br & br)
                    '_mail.Append("eCommerce Team" & br & br & br)
                    '_mail.Append("ASIA BOOKS CO., LTD." & br)
                    '_mail.Append("65/66, 65/70 Chamnan Phenjati Business Center 7th Floor," & br)
                    '_mail.Append("Rama 9, Huaykwang, Bangkok 10320" & br)
                    '_mail.Append("Tel:  0-2715-9000 ext. 8101" & br)

                    'Try
                    '    mailMessage.To = "gsupport@gardners.com"
                    '    mailMessage.From = "eCommerce@asiabooks.com"
                    '    mailMessage.Cc = "eCommerce@asiabooks.com,porntip_m@asiabooks.com,aunnop_k@asiabooks.com,jirathep@promptnow.com,phamorn@promptnow.com,warangkana@promptnow.com"
                    '    'mailMessage.Subject = "Our customer downloads eBook as the URL appeared in this email"
                    '    mailMessage.Subject = "ASI001: Asia Books: Request for a confirmation on status of eBooks (downloading) - order reference no." & dt.Rows(0).Item("Order_No_Tx")
                    '    mailMessage.BodyFormat = System.Web.Mail.MailFormat.Html
                    '    mailMessage.Body = _mail.ToString

                    '    System.Web.Mail.SmtpMail.SmtpServer = SmtpMail
                    '    mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1")
                    '    mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "eOrdering@asiabooks.com")
                    '    mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "abs999.")

                    '    System.Web.Mail.SmtpMail.Send(mailMessage)
                    'Catch ex As Exception
                    '    GenerateLog("EmailToGardners(My_Ebook2_Popup)", "", "", OrderNo, "", "", "https://www.asiabooks.com", "", ex.Message.ToString)
                    'End Try

                ElseIf dt.Rows(0).Item("supplier_code").ToString.Trim.ToLower.Equals("ingram") Then
                    LogDownload(dt.Rows(0).Item("bookid"), dt.Rows(0).Item("Order_No"), dt.Rows(0).Item("Unitprice"), dt.Rows(0).Item("Customer_Country"), "3", Request.UserAgent, dt.Rows(0).Item("MyEBookID"))
                    CreditDownload(MyEBookID, dt.Rows(0).Item("Downloaded_Times"))

                    Session("DL_MyEBookID") = "-1"
                End If

                Response.Redirect(dt.Rows(0).Item("Download_URL").ToString)

            Else
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Your download credit is not enough for this eBook.'); window.close();", True)
            End If
        Catch ex As Exception
            GenerateLog("MyEbook2_Download_Popup", "", "", OrderNo, "", "", "https://www.asiabooks.com", "", ex.Message.ToString)
            Throw ex
        End Try

    End Sub

    Public Function LogDownload(ByVal BookID As String, ByVal OrderNo As String, ByVal Selling_Price As String, ByVal Country_Code As String, ByVal Status As String, ByVal UserAgent As String, ByVal MyEBookID As String) As Boolean
        Try
            Dim SqlDb As SqlDb = New SqlDb
            Dim _strQuery As New StringBuilder
            Dim ds As New DataSet

            UserAgent = UserAgent.Replace("'", "''")

            If UserAgent.Length > 2000 Then
                UserAgent = UserAgent.Substring(0, 2000)
            End If

            SqlDb.BeginTrans()
            Try
                _strQuery = New StringBuilder
                _strQuery.Append("INSERT INTO ebook_download_log ([Timestamp],[BookID],[IP],[OrderNo],[Selling_Price],[Country_Code],[Status],[UserAgent],[MyEBookID]) ")
                _strQuery.Append("values (")
                _strQuery.Append("getdate() ")
                _strQuery.Append(",'" + BookID + "'")
                _strQuery.Append(",'" + Request.ServerVariables("REMOTE_ADDR") + "'")
                _strQuery.Append(",'" + OrderNo + "'")
                _strQuery.Append(",'" + Selling_Price + "'")
                _strQuery.Append(",'" + Country_Code + "'")
                _strQuery.Append(",'" + Status + "'")
                _strQuery.Append(",'" + UserAgent + "'")
                _strQuery.Append(",'" + MyEBookID + "')")

                SqlDb.Exec(_strQuery.ToString())

                SqlDb.CommitTrans()
                'message = "Add  Successful"
                Return True

            Catch ex As Exception
                SqlDb.RollbackTrans()
                'GenLog.GenerateLog("BankTransfer", "", "", OrderNo, "", "", "https://www.asiabooks.com", "", ex.Message.ToString)
                Return False
            End Try

        Catch ex As Exception
            'Throw ex
            Return False
        End Try

    End Function

    Public Function CreditDownload(ByVal MyBookID As String, ByVal Downloaded_Times As String) As Boolean

        Dim dl_time As Integer = CInt(Downloaded_Times)
        dl_time = dl_time + 1

        Try
            Dim SqlDb As SqlDb = New SqlDb
            Dim _strQuery As New StringBuilder
            Dim ds As New DataSet

            SqlDb.BeginTrans()
            Try
                _strQuery = New StringBuilder
                _strQuery.Append("UPDATE ebook_mylist SET ")
                _strQuery.Append("Downloaded_Times = " & dl_time & " ")
                _strQuery.Append("WHERE MyEBookID = " & MyBookID)

                SqlDb.Exec(_strQuery.ToString())

                SqlDb.CommitTrans()
                'message = "Add  Successful"
                Return True

            Catch ex As Exception
                SqlDb.RollbackTrans()
                'GenLog.GenerateLog("BankTransfer", "", "", OrderNo, "", "", "https://www.asiabooks.com", "", ex.Message.ToString)
                Return False
            End Try

        Catch ex As Exception
            'Throw ex
            Return False
        End Try

    End Function

    Public Function GenerateLog(ByVal CallFunation As String, ByVal CallServiceURL As String, ByVal IPAddress As String, ByVal DocumrntNo As String, ByVal MemberNo As String, ByVal Amount As String, ByVal ResultURL As String, ByVal TanksURL As String, ByVal Description As String) As Boolean
        Try
            Dim StrPath As String = Server.MapPath("Log File").ToString & "\"
            Dim StrFileName As String = "Log_eOrdering_" & Format(Now, "yyyyMMdd") & ".txt"
            Dim StrValue As New StringBuilder

            StrValue.Append(Format(Now, "dd/MM/yyyy") & " " & Format(Now, "hh:mm:ss"))
            StrValue.Append("; CallFunation ")
            StrValue.Append(CallFunation)
            StrValue.Append("; CallServiceURL ")
            StrValue.Append(CallServiceURL)
            StrValue.Append("; IPAddress ")
            StrValue.Append(IPAddress)
            StrValue.Append("; DocumrntNo ")
            StrValue.Append(DocumrntNo)
            StrValue.Append("; MemberNo ")
            StrValue.Append(MemberNo)
            StrValue.Append("; Amount ")
            StrValue.Append(Amount)
            'StrValue.Append("; ResultURL ")
            'StrValue.Append(ResultURL)
            StrValue.Append("; TanksURL ")
            StrValue.Append(TanksURL)
            StrValue.Append("; Description ")
            StrValue.Append(Description)
            StrValue.Append(";")

            'Dim sw As StreamWriter = New StreamWriter(StrPath.Replace("PaymentMethod\", "") & StrFileName, True, Encoding.GetEncoding(874))
            ' '' Add some text to the file.
            'sw.WriteLine(StrValue.ToString)
            'sw.Close()
            'StrValue.Remove(0, StrValue.Length)
            CollectionWrite(StrPath.Replace("PaymentMethod\", ""), StrFileName, StrValue.ToString)

            Return True

        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Public Function CollectionWrite(ByVal strPath As String, ByVal strName As String, ByVal error_message As String) As Boolean
        Try
            Dim i As Integer = 0
            Dim fso As New StreamWriter(strPath & "\" & strName, True)
            fso.WriteLine(error_message)
            fso.Close()
            fso = Nothing
        Catch ex As Exception
        End Try
    End Function

End Class

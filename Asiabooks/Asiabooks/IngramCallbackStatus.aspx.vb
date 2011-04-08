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


Partial Class IngramCallbackStatus
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Try
                Dim vendorid As String = Request.Form("vendorid")
                Dim orderno As String = Request.Form("orderno")
                Dim instanceid As String = Request.Form("instanceid")
                Dim status As String = Request.Form("status")
                Dim statustime As String = Request.Form("statustime")

                'Dim vendorid As String = Request.QueryString("vendorid")
                'Dim orderno As String = Request.QueryString("orderno")
                'Dim instanceid As String = Request.QueryString("instanceid")
                'Dim status As String = Request.QueryString("status")
                'Dim statustime As String = Request.QueryString("statustime")

                GenerateLog("IngramCallbackStatus", "", "", orderno, "", "", "http://www.asiabooks.com", "", _
                            "vendorid=" & vendorid & ",orderno=" & orderno & ",instanceid=" & instanceid & _
                            ",status=" & status)

                Dim uCon As uConnect
                Dim dt As New DataTable
                Dim sqlCommand As String

                sqlCommand = "SELECT distinct MyEBookID, e.bookid, isnull(l.supplier_code, e.supplier_code) as supplier_code, e.max_download, Downloaded_Times, Download_URL, l.Order_No, isnull(o.Customer_Country, 'ZZ') as Customer_Country, od.Unitprice "
                sqlCommand &= "FROM ebook_mylist l "
                sqlCommand &= "LEFT JOIN ebook_store e ON e.BookID = l.EBookID "
                sqlCommand &= "LEFT JOIN tbt_asbkeo_cus_order o ON o.Order_No = l.Order_No "
                sqlCommand &= "LEFT JOIN tbt_asbkeo_cus_orderdtl od ON od.EBookID = l.EBookID "
                sqlCommand &= "WHERE l.Order_No_Tx = '" + orderno + "'"

                uCon = New uConnect
                dt = uFunction.getDataTable(uCon.conn, sqlCommand)

                If status = "1" Then
                    'LogDownload
                    'Credit Download

                    If dt.Rows.Count > 0 Then
                        LogDownload(dt.Rows(0).Item("bookid"), dt.Rows(0).Item("Order_No"), dt.Rows(0).Item("Unitprice"), dt.Rows(0).Item("Customer_Country"), "1", dt.Rows(0).Item("MyEBookID"))
                        'Else
                        '    LogDownload(dt.Rows(0).Item("bookid"), dt.Rows(0).Item("Order_No"), dt.Rows(0).Item("Unitprice"), dt.Rows(0).Item("Customer_Country"), "0", dt.Rows(0).Item("MyEBookID"))
                        '    UnCreditDownload(dt.Rows(0).Item("MyEBookID"), dt.Rows(0).Item("Downloaded_Times"))
                    End If
                Else
                    If dt.Rows.Count > 0 Then
                        LogDownload(dt.Rows(0).Item("bookid"), dt.Rows(0).Item("Order_No"), dt.Rows(0).Item("Unitprice"), dt.Rows(0).Item("Customer_Country"), "0", dt.Rows(0).Item("MyEBookID"))
                        UnCreditDownload(dt.Rows(0).Item("MyEBookID"), dt.Rows(0).Item("Downloaded_Times"))
                    End If
                End If
            Catch ex As Exception
                GenerateLog("IngramCallbackStatus_Error", "", "", "", "", "", "http://www.asiabooks.com", "", ex.Message + " " + ex.GetBaseException.ToString)
            End Try

        End If
    End Sub

    Public Function LogDownload(ByVal BookID As String, ByVal OrderNo As String, ByVal Selling_Price As String, ByVal Country_Code As String, ByVal Status As String, ByVal MyEBookID As String) As Boolean
        Try
            Dim SqlDb As SqlDb = New SqlDb
            Dim _strQuery As New StringBuilder
            Dim ds As New DataSet

            SqlDb.BeginTrans()
            Try
                _strQuery = New StringBuilder
                _strQuery.Append("INSERT INTO ebook_download_log ([Timestamp],[BookID],[IP],[OrderNo],[Selling_Price],[Country_Code],[Status],[MyEBookID]) ")
                _strQuery.Append("values (")
                _strQuery.Append("getdate() ")
                _strQuery.Append(",'" + BookID + "'")
                _strQuery.Append(",'" + Request.ServerVariables("REMOTE_ADDR") + "'")
                _strQuery.Append(",'" + OrderNo + "'")
                _strQuery.Append(",'" + Selling_Price + "'")
                _strQuery.Append(",'" + Country_Code + "'")
                _strQuery.Append(",'" + Status + "'")
                _strQuery.Append(",'" + MyEBookID + "')")

                SqlDb.Exec(_strQuery.ToString())

                SqlDb.CommitTrans()
                'message = "Add  Successful"
                Return True

            Catch ex As Exception
                SqlDb.RollbackTrans()
                GenerateLog("IngramCallbackStatus_LogDownload", "", "", OrderNo, "", "", "http://www.asiabooks.com", "", ex.Message.ToString)

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
                _strQuery.Append(" Downloaded_Times = " & dl_time)
                _strQuery.Append(" WHERE MyEBookID = " & MyBookID)

                SqlDb.Exec(_strQuery.ToString())

                SqlDb.CommitTrans()
                'message = "Add  Successful"
                Return True

            Catch ex As Exception
                SqlDb.RollbackTrans()
                'GenLog.GenerateLog("BankTransfer", "", "", OrderNo, "", "", "http://www.asiabooks.com", "", ex.Message.ToString)
                Return False
            End Try

        Catch ex As Exception
            'Throw ex
            Return False
        End Try

    End Function

    Public Function UnCreditDownload(ByVal MyBookID As String, ByVal Downloaded_Times As String) As Boolean

        Dim dl_time As Integer = CInt(Downloaded_Times)
        dl_time = dl_time - 1

        Try
            Dim SqlDb As SqlDb = New SqlDb
            Dim _strQuery As New StringBuilder
            Dim ds As New DataSet

            SqlDb.BeginTrans()
            Try
                _strQuery = New StringBuilder
                _strQuery.Append("UPDATE ebook_mylist SET ")
                _strQuery.Append(" Downloaded_Times = " & dl_time)
                _strQuery.Append(" WHERE MyEBookID = " & MyBookID)

                SqlDb.Exec(_strQuery.ToString())

                SqlDb.CommitTrans()
                'message = "Add  Successful"
                Return True

            Catch ex As Exception
                SqlDb.RollbackTrans()
                'GenLog.GenerateLog("BankTransfer", "", "", OrderNo, "", "", "http://www.asiabooks.com", "", ex.Message.ToString)
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
            Dim StrFileName As String = "Log_IngramCallback_" & Format(Now, "yyyyMMdd") & ".txt"
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

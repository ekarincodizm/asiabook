Imports Microsoft.VisualBasic
Imports System
Imports System.Net
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.DirectoryServices
Imports System.Web.Mail

Public Class uClass
    Public Const vKey As Integer = 9
    Public TitleProgram As String = "Work Flow Online V2.0"
    Public NowDate As String = Format(Now.Date, "dd/MM/yyyy")
    Public NowDateTime As String = Format(Now, "dd/MM/yyyy HH:mm:ss")
    Public CheckNoseries As Boolean

    Sub New()

    End Sub

    Public Sub BindData(ByRef xGrid As GridView, ByVal xDt As DataTable, ByVal PageIndex As Integer)
        Dim dr As DataRow

        Try
            If xDt.Rows.Count > 0 Then
                xGrid.DataSource = xDt
                If PageIndex > xGrid.PageCount Then
                    xGrid.PageIndex = xGrid.PageCount - 1
                Else
                    xGrid.PageIndex = PageIndex
                End If
            Else
                dr = xDt.NewRow
                dr(0) = "ไม่มีข้อมูล"
                xDt.Rows.Add(dr)
                xGrid.DataSource = xDt
            End If

            xGrid.DataBind()
        Catch ex As Exception
            Throw New Exception("BindData : " & ex.Message.ToString)
        Finally
            dr = Nothing
        End Try
    End Sub
    Public Sub BindData(ByRef xGrid As GridView, ByVal xDt As DataTable)
        Dim dr As DataRow

        Try
            If xDt.Rows.Count > 0 Then
                xGrid.DataSource = xDt
            Else
                dr = xDt.NewRow
                dr(0) = "ไม่มีข้อมูล"
                xDt.Rows.Add(dr)
                xGrid.DataSource = xDt
            End If

            xGrid.DataBind()
        Catch ex As Exception
            Throw New Exception("BindData : " & ex.Message.ToString)
        Finally
            dr = Nothing
        End Try
    End Sub

    Public Function SpritDate(ByVal DateValue As String) As String
        Dim date1, month1, year1 As String
        Dim DateReturn As String = ""
        Dim arr1() As String = DateValue.Split("/".ToCharArray())
        If DateValue.Trim <> "" Then
            date1 = arr1(0)
            month1 = arr1(1)
            year1 = arr1(2)
            If CInt(year1) > 2300 Then
                year1 = year1 - 543
            End If
            DateReturn = month1 + "/" + date1 + "/" + year1
            Return DateReturn
        Else
            Return ""
        End If
    End Function
    Public Function checkSQLInject(ByVal str As String) As Boolean
        Dim ch As Boolean = True
        If str = "" Then
            Return True
        Else
            ch = False
        End If
        If InStr(str, "'") Then
            Return True
        Else
            ch = False
        End If

        Return ch
    End Function
  
    Public Function SendMail(ByVal strTo As String, ByVal strCC As String, ByVal strSubject As String, ByVal strBody As String, ByVal strAttachments As String) As Boolean

        Dim smtpmail As New Mail.SmtpClient
        Dim m As New Mail.MailMessage

        Dim MailHost As String = ConfigurationManager.AppSettings("MailHost").ToString
        Dim MailFrom As String = ConfigurationManager.AppSettings("MailFrom").ToString
        Dim MailBCC As String = ConfigurationManager.AppSettings("MailBCC").ToString

        Try
            smtpmail.Host = "mail.csloxinfo.com"
            smtpmail.Port = 25

            m.From = New Mail.MailAddress(MailFrom)
            m.Subject = strSubject
            m.IsBodyHtml = True

            m.Body = strBody
            If strTo <> "" Then
                m.To.Add(strTo)
            End If

            If strCC <> "" Then
                m.CC.Add(strCC)
            End If
            If MailBCC <> "" Then
                m.Bcc.Add(MailBCC)
            End If

            If strAttachments <> "" Then
                m.Attachments.Add(New Mail.Attachment(strAttachments))
            End If


            smtpmail.Send(m)

            Return True
        Catch ex As Exception

            Return False
        End Try
    End Function
    Public Function SendMail_Inquiry(ByVal strTo As String, ByVal strCC As String, ByVal strSubject As String, ByVal strBody As String, ByVal strAttachments As String) As Boolean

        Dim smtpmail As New Mail.SmtpClient
        Dim m As New Mail.MailMessage

        Dim MailHost As String = ConfigurationManager.AppSettings("MailHost").ToString
        Dim MailFrom As String = ConfigurationManager.AppSettings("MailFrom").ToString

        Try
            smtpmail.Host = "mail.csloxinfo.com"
            smtpmail.Port = 25

            m.From = New Mail.MailAddress(MailFrom)
            m.Subject = strSubject
            m.IsBodyHtml = True

            m.Body = strBody
            If strTo <> "" Then
                m.To.Add(strTo)
            End If

            If strCC <> "" Then
                m.CC.Add(strCC)
            End If

            If strAttachments <> "" Then
                m.Attachments.Add(New Mail.Attachment(strAttachments))
            End If

            smtpmail.Send(m)

            Return True
        Catch ex As Exception

            Return False
        End Try
    End Function
    Public Function SendMailError(ByVal Body As String) As Boolean
        Dim smtpmail As New Mail.SmtpClient
        Dim m As New Mail.MailMessage

        Dim MailHost As String = ConfigurationManager.AppSettings("MailHost").ToString
        Dim MailFrom As String = ConfigurationManager.AppSettings("MailFrom").ToString
        Dim MailTo As String = ConfigurationManager.AppSettings("MailTo").ToString
        Dim MailSubject As String = ConfigurationManager.AppSettings("MailSubject").ToString

        Try
            smtpmail.Host = MailHost
            smtpmail.Port = 25

            m.From = New Mail.MailAddress(MailFrom)
            m.Subject = (MailSubject & " At " & Format(Now.Date, "dd/MM/yyyy"))
            m.IsBodyHtml = True
            m.Body = "<div style='font-family:MS Sans Serif; font-size:10pt;'> " & Body.Replace(vbCrLf, "<br>") & "</div>"
            m.To.Add(MailTo)
            smtpmail.Send(m)

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Public Function CheckDupArr(ByVal arr As ArrayList) As ArrayList
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim ch As Boolean = False
        Dim _arr As New ArrayList

        For i = 0 To arr.Count - 1
            If i = 0 Then
                _arr.Add(arr(i).ToString)
            ElseIf arr(i).ToString.Trim <> "" Then
                For j = 0 To _arr.Count - 1
                    If arr(i).ToString = _arr(j).ToString Then
                        ch = False
                        Exit For

                    ElseIf arr(i).ToString.Trim = "" Then
                        ch = False
                        Exit For

                    Else
                        ch = True

                    End If
                Next

                If ch Then
                    _arr.Add(arr(i).ToString)
                End If
            End If
        Next

        Return _arr
    End Function
    Public Function TempKey() As String
        Dim uRandom As New Random
        Dim Result As String = ""

        For i As Integer = 0 To 100
            Result += uRandom.Next(10).ToString
        Next

        Return Result
    End Function

#Region "User Detail"
    Public Function EncryptIntranet(ByVal str As String) As String
        Dim X As String
        Dim tmp As String = ""
        Dim i As Integer
        For i = 1 To Len(str)
            X = Mid(str, i, 1)
            tmp = tmp & Chr(Asc(X) + 1)
        Next
        tmp = StrReverse(tmp)

        Return tmp
    End Function
    Public Function DecryptIntranet(ByVal str As String) As String
        Dim X As String
        Dim tmp As String = ""
        Dim i As Integer
        str = StrReverse(str)
        For i = 1 To Len(str)
            X = Mid(str, i, 1)
            tmp = tmp & Chr(Asc(X) - 1)
        Next

        Return tmp
    End Function

    Public Function Encrypt(ByVal PlainText As String, ByVal Key As Integer) As String
        'convert plaintext(String) to array of Char
        Dim PlainChar() As Char = PlainText.ToCharArray()
        Dim Ascii(PlainChar.Length) As Integer

        For Count As Integer = 0 To PlainChar.Length - 1
            'convert Char to ASCII number
            Ascii(Count) = Asc(PlainChar(Count))

            'Filter A-Z and a-z only
            'A-Z in ASCII is 65-90
            'a-z in ASCII is 97-122
            If Ascii(Count) >= 65 And Ascii(Count) <= 90 Then
                Ascii(Count) = ((Ascii(Count) - 65 + Key) Mod 26) + 65

                'for easy learning
                'Ascii(Count) -= 65 'assign A-Z as 0 to 25 in order
                'Ascii(Count) = (Ascii(Count) + Key) Mod 26
                'Ascii(Count) += 65
            ElseIf Ascii(Count) >= 97 And Ascii(Count) <= 122 Then
                Ascii(Count) = ((Ascii(Count) - 97 + Key) Mod 26) + 97

                'for easy learning
                'Ascii(Count) -= 97 'assign a-z as 0 to 25 in order
                'Ascii(Count) = (Ascii(Count) + Key) Mod 26
                'Ascii(Count) += 97
            End If

            'convert ASCII to Char
            PlainChar(Count) = Chr(Ascii(Count))
        Next

        'return array of Char as String
        Return PlainChar
    End Function
    Public Function Decrypt(ByVal CipherText As String, ByVal Key As Integer) As String
        'convert ciphertext(String) to array of Char
        Dim CipherChar() As Char = CipherText.ToCharArray()
        Dim Ascii(CipherChar.Length) As Integer

        For Count As Integer = 0 To CipherChar.Length - 1
            'convert Char to ASCII number
            Ascii(Count) = Asc(CipherChar(Count))

            'Filter A-Z and a-z only
            'A-Z in ASCII is 65-90
            'a-z in ASCII is 97-122
            If Ascii(Count) >= 65 And Ascii(Count) <= 90 Then
                Ascii(Count) = ((Ascii(Count) - 65 - (Key Mod 26) + 26)) Mod 26 + 65

                'code below for explain 
                'Ascii(Count) -= 65 'assign A-Z as 0 to 25 in order
                'Key = Key Mod 26
                'Ascii(Count) = (Ascii(Count) - Key + 26) Mod 26
                'Ascii(Count) += 65
            ElseIf Ascii(Count) >= 97 And Ascii(Count) <= 122 Then
                Ascii(Count) = (((Ascii(Count) - 97 - (Key Mod 26) + 26)) Mod 26) + 97

                'code below for explain 
                'Ascii(Count) -= 97 'assign a-z as 0 to 25 in order
                'Key = Key Mod 26
                'Ascii(Count) = (Ascii(Count) - Key + 26)) Mod 26
                'Ascii(Count) += 97
            End If

            'convert ASCII to Char
            CipherChar(Count) = Chr(Ascii(Count))
        Next

        'return array of Char as String
        Return CipherChar
    End Function

    Public Function checkAD(ByVal strUser As String, ByVal strPass As String) As String
        Dim rootEntry As DirectoryEntry
        Dim obj As Object
        Dim Search As DirectorySearcher
        Dim resultCollection As SearchResultCollection
        Dim count As Integer = 0

        Try
            rootEntry = New DirectoryEntry("LDAP://ASIABOOKS.COM", strUser, strPass)

            obj = rootEntry.NativeObject
            Search = New DirectorySearcher(rootEntry)

            'เป็นการ Query
            Search.Filter = "(&(SAMAccountName=" & strUser & ")(sAMAccountType=*))"
            resultCollection = Search.FindAll()

            If resultCollection.Count = 0 Then
                Return "NO"
            Else
                Return ""
            End If
        Catch ex As Exception
            Return "NO" '"Can not logon : " & Environment.NewLine & "    " & ex.Message
        End Try
    End Function
    Public Function checkID(ByVal strUser As String, ByVal strPwd As String) As Boolean
        Dim intTmp1 As Integer
        Dim intTmp2 As Integer
        Dim intTmp3 As Integer
        Dim intTmp4 As Integer
        Dim xint As Integer
        Dim xtmp As Integer
        Dim strTmp As Boolean = False

        If IsNumeric(strUser) = False Then
            Return False
        End If

        If IsNumeric(strPwd) = False Then
            Return False
        End If

        Try
            intTmp1 = CInt(Microsoft.VisualBasic.Left(strUser, 1))
            intTmp2 = CInt(Microsoft.VisualBasic.Mid(strUser, 2, 1))
            intTmp3 = CInt(Microsoft.VisualBasic.Mid(strUser, 3, 1))
            intTmp4 = CInt(Microsoft.VisualBasic.Right(strUser, 1))
            Select Case 5
                Case 1 To 3
                    xint = CInt(Microsoft.VisualBasic.Right((((((intTmp1 + intTmp3) * (intTmp2 + intTmp4)) + 7159) * 1) + 2009), 4))
                    xtmp = CInt(Microsoft.VisualBasic.Right((((((intTmp1 + intTmp3) * (intTmp2 + intTmp4)) + 7159) * 4) + 2009), 4))
                    If Now.Month = 1 Then
                        If Now.Day > 0 And Now.Day < 11 Then
                            If CInt(strPwd) = xint Then
                                strTmp = True
                            ElseIf CInt(strPwd) = xtmp Then
                                strTmp = True
                            Else
                                strTmp = False
                            End If
                        Else
                            If CInt(strPwd) = xint Then
                                strTmp = True
                            Else
                                strTmp = False
                            End If
                        End If
                    Else
                        If CInt(strPwd) = xint Then
                            strTmp = True
                        Else
                            strTmp = False
                        End If
                    End If


                Case 4 To 6
                    xint = CInt(Microsoft.VisualBasic.Right((((((intTmp1 + intTmp3) * (intTmp2 + intTmp4)) + 7159) * 2) + 2009), 4))
                    If Now.Month = 4 Then
                        If CInt(strPwd) = xint Then
                            strTmp = True
                        Else
                            strTmp = False
                        End If
                    Else
                        If CInt(strPwd) = xint Then
                            strTmp = True
                        Else
                            strTmp = False
                        End If
                    End If

                Case 7 To 9
                    xint = CInt(Microsoft.VisualBasic.Right((((((intTmp1 + intTmp3) * (intTmp2 + intTmp4)) + 7159) * 3) + 2009), 4))
                    xtmp = CInt(Microsoft.VisualBasic.Right((((((intTmp1 + intTmp3) * (intTmp2 + intTmp4)) + 7159) * 2) + 2009), 4))
                    If Now.Month = 7 Then
                        If Now.Day > 0 And Now.Day < 11 Then
                            If CInt(strPwd) = xint Then
                                strTmp = True
                            ElseIf CInt(strPwd) = xtmp Then
                                strTmp = True
                            Else
                                strTmp = False
                            End If
                        Else
                            If CInt(strPwd) = xint Then
                                strTmp = True
                            Else
                                strTmp = False
                            End If
                        End If
                    Else
                        If CInt(strPwd) = xint Then
                            strTmp = True
                        Else
                            strTmp = False
                        End If
                    End If

                Case 10 To 12
                    xint = CInt(Microsoft.VisualBasic.Right((((((intTmp1 + intTmp3) * (intTmp2 + intTmp4)) + 7159) * 4) + 2009), 4))
                    xtmp = CInt(Microsoft.VisualBasic.Right((((((intTmp1 + intTmp3) * (intTmp2 + intTmp4)) + 7159) * 3) + 2009), 4))
                    If Now.Month = 10 Then
                        If Now.Day > 0 And Now.Day < 11 Then
                            If CInt(strPwd) = xint Then
                                strTmp = True
                            ElseIf CInt(strPwd) = xtmp Then
                                strTmp = True
                            Else
                                strTmp = False
                            End If
                        Else
                            If CInt(strPwd) = xint Then
                                strTmp = True
                            Else
                                strTmp = False
                            End If
                        End If
                    Else
                        If CInt(strPwd) = xint Then
                            strTmp = True
                        Else
                            strTmp = False
                        End If
                    End If
            End Select
            Return strTmp
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function checkCmpName() As String
        'Dim host As System.Net.IPHostEntry
        'host = System.Net.Dns.GetHostByAddress(Request.ServerVariables.Item("REMOTE_HOST"))
        'Session("ComputerName") = host.HostName
        Return Environment.MachineName
    End Function

    Public Function GetShop(ByVal conn As SqlConnection, ByVal EmpId As String) As String
        Dim dt As New DataTable

        If conn.State = ConnectionState.Closed Then conn.Open()

        Try
            dt = uFunction.getDataTable(conn, "select case when dept_id in (16,19,26,30) then 'shop' else 'hq' end as [caseShop] from tbm_employee where is_active='Y' And emp_id = '" & EmpId & "'")
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("caseShop").ToString.ToLower.Trim
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dt = Nothing
        End Try
    End Function
    Public Function GetEmpId(ByVal conn As SqlConnection, ByVal login As String) As String
        Dim User As String = ""
        Dim dt As New DataTable

        If conn.State = ConnectionState.Closed Then conn.Open()

        Try
            dt = uFunction.getDataTable(conn, "SELECT emp_id FROM tbm_employee where is_active='Y' And emp_id='" & login & "'")
            If dt.Rows.Count > 0 Then
                User = dt.Rows(0)("emp_id").ToString
            Else
                User = ""
            End If

            Return User
        Catch ex As Exception

            Return ""
        Finally
            dt = Nothing
            conn.Close()
        End Try
    End Function
    Public Function GetEmpName(ByVal conn As SqlConnection, ByVal login As String) As String
        Dim User As String = ""
        Dim dt As New DataTable

        If conn.State = ConnectionState.Closed Then conn.Open()

        Try
            dt = uFunction.getDataTable(conn, "select emp_id,name from tbm_employee where is_active='Y' And emp_id='" & login & "'")
            If dt.Rows.Count > 0 Then
                User = dt.Rows(0)("name").ToString
            Else
                User = ""
            End If
            Return User
        Catch ex As Exception

            Return ""
        Finally
            dt = Nothing
            conn.Close()
        End Try
    End Function
    Public Function GetDeptId(ByVal conn As SqlConnection, ByVal login As String) As String
        Dim EmpId As String
        Dim dt As New DataTable
        Dim _strQuery As New StringBuilder

        _strQuery.Append("select dept_id ")
        _strQuery.Append("from tbm_employee  ")
        _strQuery.Append("where is_active='Y' And emp_id='" & login & "' ")

        If conn.State = ConnectionState.Closed Then conn.Open()

        Try
            dt = uFunction.getDataTable(conn, _strQuery.ToString)
            If dt.Rows.Count > 0 Then
                EmpId = dt.Rows(0)("dept_id").ToString
            Else
                EmpId = ""
            End If
            Return EmpId
        Catch ex As Exception

            Return ""
        Finally
            dt = Nothing
            conn.Close()
        End Try
    End Function
    Public Function GetDeptName(ByVal conn As SqlConnection, ByVal login As String) As String
        Dim User As String = ""
        Dim dt As New DataTable
        Dim _strQuery As New StringBuilder

        _strQuery.Append("select isnull(b.name,'') as [deptname] ")
        _strQuery.Append("from tbm_employee a  ")
        _strQuery.Append("left join tbm_department b ")
        _strQuery.Append("on a.dept_id=b.dept_id ")
        _strQuery.Append("where a.is_active='Y' And a.emp_id='" & login & "' ")

        If conn.State = ConnectionState.Closed Then conn.Open()

        Try
            dt = uFunction.getDataTable(conn, _strQuery.ToString)
            If dt.Rows.Count > 0 Then
                User = dt.Rows(0)("deptname").ToString
            Else
                User = ""
            End If
            Return User
        Catch ex As Exception

            Return ""
        Finally
            dt = Nothing
            conn.Close()
        End Try
    End Function
    Public Function GetEmpIdlogin(ByVal conn As SqlConnection, ByVal UserName As String, ByVal PassWord As String) As String
        Dim User As String = ""
        Dim dt As New DataTable

        If conn.State = ConnectionState.Closed Then conn.Open()

        Try
            dt = uFunction.getDataTable(conn, "select emp_id,name from tbm_employee where is_active='Y' And emp_id='" & UserName & "' and password = '" & PassWord & "'")
            If dt.Rows.Count > 0 Then
                User = dt.Rows(0)("name").ToString
            Else
                User = ""
            End If
            Return User
        Catch ex As Exception
            Return ""
        Finally
            dt = Nothing
            conn.Close()
        End Try
    End Function
    Public Function GetPermition(ByVal conn As SqlConnection, ByVal PageUrl As String, ByVal UserName As String) As Boolean
        Dim status As String = ""
        Dim dt As New DataTable
        Dim _strQuery As New StringBuilder

        _strQuery.Append("select isnull(b.[is_active],'N') as [active] ")
        _strQuery.Append("from [tbm_page] a ")
        _strQuery.Append("left join [tbm_secure] b on a.page_id=b.page_id ")
        _strQuery.Append("where a.[page_url]='" & PageUrl & "' ")
        _strQuery.Append("and b.emp_id='" & UserName & "'")

        If conn.State = ConnectionState.Closed Then conn.Open()

        Try
            dt = uFunction.getDataTable(conn, _strQuery.ToString)
            If dt.Rows.Count <= 0 Then
                Return False
            Else
                If dt.Rows(0)("active") = "Y" Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Return False
        Finally
            dt = Nothing
            conn.Close()
        End Try
    End Function
    Public Function GetImageEmp(ByVal conn As SqlConnection, ByVal EmpId As String) As String
        Dim imgEmp As String = ""
        Dim dt As New DataTable

        If conn.State = ConnectionState.Closed Then conn.Open()

        Try
            dt = uFunction.getDataTable(conn, "select image from tbm_employee where is_active='Y' And emp_id='" & EmpId & "'")
            If dt.Rows.Count > 0 Then
                imgEmp = dt.Rows(0)("image").ToString
            Else
                imgEmp = ""
            End If

            Return imgEmp
        Catch ex As Exception

            Return ""
        Finally
            dt = Nothing
            conn.Close()
        End Try
    End Function
    Public Function getEmpMail(ByVal conn As SqlConnection, ByVal empID As String) As String
        Dim dt As New DataTable

        Try
            dt = uFunction.getDataTable(conn, "select isnull(email,'') as [mail] from [tbm_employee] where [emp_id]='" & empID.Trim & "'")

            If dt.Rows.Count > 0 Then
                Return dt.Rows(0).Item("mail").ToString
            Else
                Return ""
            End If

        Catch ex As Exception
            Throw ex
            Return ""
        Finally
            dt = Nothing
        End Try
    End Function

    Public Function checkPermissionForRepair(ByVal conn As SqlConnection, ByVal userlogon As String) As Boolean
        Dim flag As Boolean = False
        Dim dt As New DataTable

        dt = uFunction.getDataTable(conn, "select * from tbs_receive_repair where [repair_id]='" & userlogon & "' and [is_active]='Y' ")

        If dt.Rows.Count > 0 Then
            flag = True
        Else
            flag = False
        End If
        Return flag
    End Function

    Public Function checkNextPageIncident(ByVal conn As SqlConnection, ByVal logId As String, ByVal strPage As String) As String
        Dim strUrl As String
        Dim dt As New DataTable

        dt = uFunction.getDataTable(conn, "select logcall_id,next_url from workflow_incident where logcall_id = '" & logId & "' ")

        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("next_url").ToString.Trim = strPage Then
                strUrl = ""
            Else
                strUrl = dt.Rows(0)("next_url").ToString & "?" & Encrypt(TempKey, vKey) & "&logcall_id=" & Encrypt(logId, vKey)
            End If
        Else
            strUrl = ""
        End If

        Return strUrl
    End Function
    Public Function checkNextPageUR(ByVal conn As SqlConnection, ByVal logId As String, ByVal strPage As String) As String
        Dim strUrl As String
        Dim dt As New DataTable

        dt = uFunction.getDataTable(conn, "select logcall_id,next_url from workflow_userrequest where logcall_id = '" & logId & "' ")

        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("next_url").ToString.Trim = strPage Then
                strUrl = ""
            Else
                strUrl = dt.Rows(0)("next_url").ToString & "?" & Encrypt(TempKey, vKey) & "&logcall_id=" & Encrypt(logId, vKey)
            End If
        Else
            strUrl = ""
        End If

        Return strUrl
    End Function
    Public Function checkNextPageDeploy(ByVal conn As SqlConnection, ByVal logId As String, ByVal strPage As String) As String
        Dim strUrl As String
        Dim dt As New DataTable

        dt = uFunction.getDataTable(conn, "select logcall_id,next_url from workflow_deploy where logcall_id = '" & logId & "' ")

        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("next_url").ToString.Trim = strPage Then
                strUrl = ""
            Else
                strUrl = dt.Rows(0)("next_url").ToString & "?" & Encrypt(TempKey, vKey) & "&logcall_id=" & Encrypt(logId, vKey)
            End If
        Else
            strUrl = ""
        End If

        Return strUrl
    End Function
    Public Function checkNextPageRepair(ByVal conn As SqlConnection, ByVal logId As String, ByVal strPage As String) As String
        Dim strUrl As String
        Dim dt As New DataTable

        dt = uFunction.getDataTable(conn, "select logcall_id,next_url from workflow_repair where logcall_id = '" & logId & "' ")

        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("next_url").ToString.Trim = strPage Then
                strUrl = ""
            Else
                strUrl = dt.Rows(0)("next_url").ToString & "?" & Encrypt(TempKey, vKey) & "&logcall_id=" & Encrypt(logId, vKey)
            End If
        Else
            strUrl = ""
        End If

        Return strUrl
    End Function
#End Region

End Class
